using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime
{
    public abstract class EquatableHandle
    {
        internal abstract IntPtr GetInternalPtr();

        public override bool Equals(object obj) {
            if (obj is EquatableHandle)
            {
                EquatableHandle equatableHandle = (EquatableHandle)obj;
                return this.GetInternalPtr() == equatableHandle.GetInternalPtr();
            }
            return false;
        }
        public override int GetHashCode() { return this.GetInternalPtr().GetHashCode(); }
        public static bool operator ==(EquatableHandle handle1, EquatableHandle handle2) { return object.ReferenceEquals(handle1, null) ? object.ReferenceEquals(handle2, null) : handle1.Equals(handle2); }
        public static bool operator !=(EquatableHandle handle1, EquatableHandle handle2) { return !(handle1 == handle2); }
    }

    public abstract class SafeEquatableHandle : SafeHandle
    {
        public SafeEquatableHandle(IntPtr invalidHandleValue, bool ownsHandle, IntPtr handle) :
            base(invalidHandleValue, ownsHandle)
        {
            SetHandle(handle);
        }

        public IntPtr Handle { get { return this.handle; } }

        public override bool Equals(object obj)
        {
            if (obj is SafeEquatableHandle)
            {
                SafeEquatableHandle equatableHandle = (SafeEquatableHandle)obj;
                return this.handle == equatableHandle.handle;
            }
            return false;
        }
        public override int GetHashCode() { return this.handle.GetHashCode(); }
        public static bool operator ==(SafeEquatableHandle handle1, SafeEquatableHandle handle2) { return object.ReferenceEquals(handle1, null) ? object.ReferenceEquals(handle2, null) : handle1.Equals(handle2); }
        public static bool operator !=(SafeEquatableHandle handle1, SafeEquatableHandle handle2) { return !(handle1 == handle2); }
    }
}
