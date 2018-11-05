namespace template.Persistence.Sql.Utilities
{
    internal class IntegerUtility
    {
        internal static int ParseOrDefault(string integer)
        {
            int.TryParse(integer, out int parsedValue);
            return parsedValue;
        }
    }
}
