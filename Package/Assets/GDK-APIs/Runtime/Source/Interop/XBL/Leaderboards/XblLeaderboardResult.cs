using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
    // typedef struct XblLeaderboardResult
    // {
    //     uint32_t totalRowCount;
    //     XblLeaderboardColumn* columns;
    //     size_t columnsCount;
    //     XblLeaderboardRow* rows;
    //     size_t rowsCount;
    //     bool hasNext;
    //     XblLeaderboardQuery nextQuery;
    // } XblLeaderboardResult;

    [StructLayout(LayoutKind.Sequential)]
    internal struct XblLeaderboardResult
    {
        internal T[] GetColumns<T>(Func<XblLeaderboardColumn, T> ctor) { return Converters.PtrToClassArray(this.columns, this.columnsCount, ctor); }
        internal T[] GetRows<T>(Func<XblLeaderboardRow, T> ctor) { return Converters.PtrToClassArray(this.rows, this.rowsCount, ctor); }

        internal readonly UInt32 totalRowCount;
        private readonly IntPtr columns;
        private readonly SizeT columnsCount;
        private readonly IntPtr rows;
        private readonly SizeT rowsCount;
        internal readonly NativeBool hasNext;
        internal readonly XblLeaderboardQuery nextQuery;

        internal XblLeaderboardResult(XGamingRuntime.XblLeaderboardResult result, DisposableCollection disposableCollection)
        {
            this.totalRowCount = result.TotalRowCount;
            this.columns = Converters.ClassArrayToPtr(result.Columns, (c, dc) =>new XblLeaderboardColumn(c, dc), disposableCollection,
                out this.columnsCount);
            this.rows = Converters.ClassArrayToPtr(result.Rows, (r, dc) =>new XblLeaderboardRow(r, dc), disposableCollection,
                out this.rowsCount);
            this.hasNext = new NativeBool(result.HasNext);
            this.nextQuery = new XblLeaderboardQuery(result.NextQuery, disposableCollection);
        }
    }
}
