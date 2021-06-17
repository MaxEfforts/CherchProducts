namespace ProjectBase.Services.ToIntegerExt
{
    public static class ToIntegerExt
    {
        public static int ToInteger(this string str)
        {
            var n = 0;
            int.TryParse(str, out n);
            return n;
        }
    }
}
