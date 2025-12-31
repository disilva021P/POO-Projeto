/*
 * Nome: CamaOcupadaException.cs
 * Autor: Diogo Silva
 * Data de Criação: 23/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Exceção criada para quando uma Cama já está ocupada e querem associar a outra pessoa
*/

namespace Exceptions
{
    public class CamaOcupadaException : InvalidOperationException
    {
        public CamaOcupadaException(int camaId)
            : base($"A cama {camaId} já está ocupada.") { }
    }
}
