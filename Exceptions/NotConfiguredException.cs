namespace Netflex.Exceptions;
public class NotConfiguredException(string name)
    : Exception($"{name} isn't configured.")
{
}