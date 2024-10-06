namespace FastOperations.Extensions;
public static class NumberExtensions
{
    public static string ToBinaryRepresentation(this int n) => Convert.ToString(n, 2).PadLeft(8, '0');
}
