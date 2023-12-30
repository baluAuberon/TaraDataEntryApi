namespace TARA.DATAENTRY.API.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string? name, Object? key) : base($"{name} ({key}) was not found")
        {
        }
    }
}
