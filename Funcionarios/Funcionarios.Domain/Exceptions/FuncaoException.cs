namespace Funcionarios.Domain.Exceptions
{
    public class FuncaoException : Exception
    {
        public FuncaoException()
        { }

        public FuncaoException(string message)
            : base(message)
        { }

        public FuncaoException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
