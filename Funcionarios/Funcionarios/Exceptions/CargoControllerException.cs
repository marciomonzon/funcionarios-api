namespace Funcionarios.Exceptions
{
    public class CargoControllerException : Exception
    {
        public CargoControllerException()
        { }

        public CargoControllerException(string message)
            : base(message)
        { }

        public CargoControllerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
