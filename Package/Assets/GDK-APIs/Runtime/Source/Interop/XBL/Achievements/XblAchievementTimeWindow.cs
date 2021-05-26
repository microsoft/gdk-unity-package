namespace XGamingRuntime.Interop
{
    public partial struct XblAchievementTimeWindow
    {
        [NativeTypeName("time_t")]
        public long startDate;

        [NativeTypeName("time_t")]
        public long endDate;
    }
}
