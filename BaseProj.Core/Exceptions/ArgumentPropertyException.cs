using System;

namespace BaseProj.Core.Exceptions
{
    public class ArgumentPropertyException : ArgumentException
    {
        public ArgumentPropertyException(string property) : base("Propriedade inválida para uso (inexistente no objeto ou não acessível para o propósito da função).", property)
        { }
    }
}
