namespace Funcionarios.Domain.Exceptions
{
    public class CargoException : Exception
    {
        public CargoException()
        { }

        public CargoException(string message)
            : base(message)
        { }

        public CargoException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
