/*
 * Nome: EntidadeDuplicadaException.cs
 * Autor: Diogo Silva
 * Data de Criação: 23/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Exceção criada para quando tenta-se criar ou adicionar uma entidade que já existe
*/


namespace Exceptions
{
    public class EntidadeDuplicadaException : InvalidOperationException
    {
        public EntidadeDuplicadaException(string entidade,string parametro, string id)
            : base($"{entidade} com {parametro}:{id}, já existe!") { }
    }
}
