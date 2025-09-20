namespace Byakkoder.BlueSteel.Domain.Common
{
    public static class Guard
    {
        public static void AgainstNullOrWhiteSpace(string? value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{paramName} cannot be null or whitespace.", paramName);
        }

        public static void Against(bool condition, string message, string? paramName = null)
        {
            if (condition) throw new ArgumentException(message, paramName);
        }
    }
}
