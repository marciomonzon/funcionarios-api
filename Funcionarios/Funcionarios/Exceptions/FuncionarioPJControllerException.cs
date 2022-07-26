namespace Funcionarios.Exceptions
{
    public class FuncionarioPJControllerException : Exception
    {
        public FuncionarioPJControllerException()
        { }

        public FuncionarioPJControllerException(string message)
            : base(message)
        { }

        public FuncionarioPJControllerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
