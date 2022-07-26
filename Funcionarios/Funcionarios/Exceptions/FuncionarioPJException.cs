namespace Funcionarios.Exceptions
{
    public class FuncionarioPJException : Exception
    {
        public FuncionarioPJException()
        { }

        public FuncionarioPJException(string message)
            : base(message)
        { }

        public FuncionarioPJException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
