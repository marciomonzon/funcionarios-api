namespace Funcionarios.Exceptions
{
    public class FuncionarioCLTControllerException : Exception
    {
        public FuncionarioCLTControllerException()
        { }

        public FuncionarioCLTControllerException(string message)
            : base(message)
        { }

        public FuncionarioCLTControllerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
