namespace Funcionarios.Domain.Exceptions
{
    public class FuncionarioCLTException : Exception
    {
        public FuncionarioCLTException()
        { }

        public FuncionarioCLTException(string message)
            : base(message)
        { }

        public FuncionarioCLTException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
