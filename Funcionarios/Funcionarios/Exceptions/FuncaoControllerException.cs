namespace Funcionarios.Exceptions
{
    public class FuncaoControllerException : Exception
    {
        public FuncaoControllerException()
        { }

        public FuncaoControllerException(string message)
            : base(message)
        { }

        public FuncaoControllerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
