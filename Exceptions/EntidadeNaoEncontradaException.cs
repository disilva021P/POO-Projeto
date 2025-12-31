/*
 * Nome: CamaOcupadaException.cs
 * Autor: Diogo Silva
 * Data de Criação: 23/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Exceção criada para quando uma Entidade não existe e quer se fazer alguma operação nela/com ela
*/


namespace Exceptions
{
    public class EntidadeNaoEncontradaException : KeyNotFoundException
    {
        public EntidadeNaoEncontradaException(string entidade, string parametro, string id)
            : base($"{entidade} com {parametro}:{id}, não foi encontrada.") { }
    }

}
