/*
 * Nome: NifInvalidoException.cs
 * Autor: Diogo Silva
 * Data de Criação: 23/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Exceção criada para a verificação de um Nif
*/

namespace Exceptions
{
    public class NifInvalidoException : ArgumentException
    {
        public NifInvalidoException(string nif)
            : base($"O NIF '{nif}' é inválido.") { }
    }

    
}