using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    public static class Converters
    {
        public static IntPtr Offset(this IntPtr ptr, Int64 that)
        {
            return new IntPtr(ptr.ToInt64() + (that));
        }

        public static int GetSizeRequiredToEncodeStringToUTF8(string str)
        {
            return 
                System.Text.Encoding.UTF8.GetByteCount(str) +
                System.Text.Encoding.UTF8.GetPreamble().Length;
        }

        public static DisposableBuffer StringArrayToUTF8StringArray(string[] strings)
        {
            if (strings == null)
            {
                return new DisposableBuffer();
            }

            List<Byte[]> byteArrays = new List<Byte[]>(strings.Length);
            Int32 size = 0;
            foreach (string str in strings)
            {
                Byte[] bytes = StringToNullTerminatedUTF8ByteArray(str);
                byteArrays.Add(bytes);
                if (bytes != null)
                {
                    size = checked(size + bytes.Length);
                }
            }

            Int32 pointerSize = Marshal.SizeOf(typeof(IntPtr));
            Int32 allPointerSizes = checked(pointerSize * strings.Length);
            size = checked(size + allPointerSizes);
            DisposableBuffer result = new DisposableBuffer(size);

            IntPtr currentPointerPointer = result.IntPtr;
            IntPtr currentBytePointer = currentPointerPointer.Offset(allPointerSizes);

            foreach (Byte[] bytes in byteArrays)
            {
                if (bytes != null)
                {
                    Marshal.WriteIntPtr(ptr: currentPointerPointer, val: currentBytePointer);
                    Marshal.Copy(bytes, 0, destination: currentBytePointer, length: bytes.Length);
                    currentBytePointer = currentBytePointer.Offset(bytes.Length);
                }
                else
                {
                    Marshal.WriteIntPtr(ptr: currentPointerPointer, val: IntPtr.Zero);
                }

                currentPointerPointer = currentPointerPointer.Offset(pointerSize);
            }

            return result;
        }

        public static IntPtr StringArrayToUTF8StringArray(string[] strings, DisposableCollection disposableCollection, out SizeT count)
        {
            if (strings == null)
            {
                count = new SizeT(0);
                return IntPtr.Zero;
            }

            count = new SizeT(strings.Length);
            return disposableCollection.Add(StringArrayToUTF8StringArray(strings)).IntPtr;
        }

        public static Byte[] StringToNullTerminatedUTF8ByteArray(string str) { return StringToNullTerminatedUTF8ByteArrayInternal(str, requiredByteArrayLength: -1); }
        public static Byte[] StringToNullTerminatedUTF8ByteArray(string str, int requiredByteArrayLength) { return StringToNullTerminatedUTF8ByteArrayInternal(str, requiredByteArrayLength); }

        private static Byte[] StringToNullTerminatedUTF8ByteArrayInternal(string str, int requiredByteArrayLength)
        {
            if (str == null)
            {
                return null;
            }
            else if (requiredByteArrayLength == -1)
            {
                return System.Text.Encoding.UTF8.GetBytes(str + '\0');
            }
            else
            {
                Byte[] result = new Byte[requiredByteArrayLength];
                System.Text.Encoding.UTF8.GetBytes(str + '\0', 0, str.Length + 1, result, 0);
                return result;
            }
        }

        public static unsafe void StringToNullTerminatedUTF8FixedPointer(string str, Byte* bytePointer, Int32 length)
        {
            Byte[] bytes = StringToNullTerminatedUTF8ByteArray(str, length);
            Marshal.Copy(source: bytes, startIndex: 0, destination: (IntPtr)bytePointer, length: length);
        }

        public static unsafe string BytePointerToString(Byte* bytePointer, Int32 length)
        {
            Byte[] bytes = new Byte[length];
            Marshal.Copy(source: (IntPtr)bytePointer, destination: bytes, startIndex: 0, length: length);
            return ByteArrayToString(bytes);
        }

        public static unsafe string NullTerminatedBytePointerToString(Byte* bytePointer)
        {
            var terminatorIndex = 0;
            var bytePtrCopy = bytePointer;
            while (*bytePtrCopy != '\0')
            {
                bytePtrCopy++;
                terminatorIndex++;
            }
            return BytePointerToString(bytePointer, terminatorIndex);
        }

        public static string ByteArrayToString(Byte[] arr)
        {
            string str = System.Text.Encoding.UTF8.GetString(arr);
            Int32 nullIndex = str.IndexOf('\0');
            return nullIndex >= 0 ? str.Substring(0, nullIndex) : str;
        }

        public static string ByteArrayToString(Byte[] arr, Int32 index, Int32 count)
        {
            return System.Text.Encoding.UTF8.GetString(arr, index, count).TrimEnd(new char[] { '\0' });
        }

        public static string PtrToStringUTF8(IntPtr rawPtr)
        {
            if (rawPtr == IntPtr.Zero)
            {
                return null;
            }

            List<Byte> bytes = new List<Byte>();
            while (true)
            {
                Byte b = Marshal.ReadByte(rawPtr);
                if (b == 0)
                {
                    break;
                }

                bytes.Add(b);
                rawPtr = rawPtr.Offset(1);
            }

            return System.Text.Encoding.UTF8.GetString(bytes.ToArray());
        }

        public static ClassType PtrToClass<ClassType, InteropStructType>(IntPtr rawPtr, Func<InteropStructType, ClassType> ctor)
            where ClassType : class
            where InteropStructType : struct
        {
            if (rawPtr == IntPtr.Zero)
            {
                return null;
            }
            else
            {
                return ctor((InteropStructType)Marshal.PtrToStructure(rawPtr, typeof(InteropStructType)));
            }
        }

        public static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, SizeT count, Func<InteropStructType, ClassType> ctor)
        {
            return PtrToClassArray(rawPtr, count.ToUInt32(), ctor);
        }

        public static ClassType[] PtrToClassArray<ClassType, InteropStructType>(IntPtr rawPtr, UInt32 count, Func<InteropStructType, ClassType> ctor)
        {
            ClassType[] ret = new ClassType[(Int32)count];

            if (IntPtr.Zero != rawPtr)
            {
                IntPtr arrayPtr = rawPtr;
                Int32 structSize = Marshal.SizeOf(typeof(InteropStructType));
                for (Int32 i = 0; i < count; i++)
                {
                    InteropStructType u = (InteropStructType)Marshal.PtrToStructure(arrayPtr.Offset(i * structSize), typeof(InteropStructType));
                    ret[i] = ctor(u);
                }
            }

            return ret;
        }

        public static IntPtr ClassArrayToPtr<ClassType, InteropStructType>(
            ClassType[] inputTypes,
            Func<ClassType, DisposableCollection, InteropStructType> converter,
            DisposableCollection disposableCollection,
            out UInt32 arrayCount)
        {
            SizeT count;
            IntPtr result = ClassArrayToPtr<ClassType, InteropStructType>(inputTypes, converter, disposableCollection, out count);
            arrayCount = count.ToUInt32();
            return result;
        }

        public static IntPtr ClassArrayToPtr<ClassType, InteropStructType>(
            ClassType[] inputTypes,
            Func<ClassType, DisposableCollection, InteropStructType> converter,
            DisposableCollection disposableCollection,
            out SizeT arrayCount)
        {
            if (inputTypes == null)
            {
                arrayCount = new SizeT(0);
                return IntPtr.Zero;
            }

            bool isEnum = typeof(InteropStructType).IsEnum;
            Int32 sizeOfStruct = Marshal.SizeOf(isEnum ? Enum.GetUnderlyingType(typeof(InteropStructType)) : typeof(InteropStructType));
            DisposableBuffer buffer = disposableCollection.Add(new DisposableBuffer(checked(sizeOfStruct * inputTypes.Length)));

            IntPtr currentPtr = buffer.IntPtr;
            foreach (ClassType inputType in inputTypes)
            {
                object structure = isEnum ? Convert.ChangeType(converter(inputType, disposableCollection), Enum.GetUnderlyingType(typeof(InteropStructType))) : (object)converter(inputType, disposableCollection);
                Marshal.StructureToPtr(structure, currentPtr, fDeleteOld: false);
                currentPtr = currentPtr.Offset(sizeOfStruct);
            }

            arrayCount = new SizeT(inputTypes.Length);
            return buffer.IntPtr;
        }

        public static InteropStructType[] ConvertArrayToFixedLength<ClassType, InteropStructType>(ClassType[] classes, int length, Func<ClassType, InteropStructType> ctor)
        {
            InteropStructType[] result = new InteropStructType[length];
            int minLength = Math.Min(length, classes.Length);
            for (int i = 0; i < minLength; ++i)
            {
                result[i] = ctor(classes[i]);
            }
            return result;
        }
    }
}
