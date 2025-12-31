/*
 * Nome: InterfaceCrud.cs
 * Autor: Diogo Silva
 * Data de Criação: 18/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Interface para exigir funções de crud
*/

namespace Interfaces
{
    //interface que obriga as regras a possuirem pelo menos um CRUD
    //ele recebe o tipo de dados que as regras estão a tratar e o tipo do id (neste caso maior parte é int)
    public interface ICrud<T, Tid>
    {

        List<T> Listar();
        bool JaExiste(T entidade);
        bool JaExiste(Tid id);
        T? BuscarPorId(Tid id);
        bool Inserir(T entidade);
        bool Remover(T entidade);
        bool Remover(Tid id);
        bool Atualizar(T entidade);
    }
}
