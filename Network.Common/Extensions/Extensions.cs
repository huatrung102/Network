namespace Network.Common.Extensions
{
    public static class Extension
    {
        //Extension method for checking null values
        public static bool IsNotNull(this object obj)
        {
            return obj == null;
        }
    }
}
