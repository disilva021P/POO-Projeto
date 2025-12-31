using System;
using System.Collections.Generic;
/*
 * Nome: Camas.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Camas
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade Cama
    /// </summary>
    public class Camas
    {
        List<Cama> camas;

        /// <summary>
        /// Construtor que inicializa a lista vazia de camas.
        /// </summary>
        public Camas()
        {
            this.camas = new List<Cama>();
        }

        /// <summary>
        /// Construtor que inicializa a lista de camas com uma lista existente.
        /// </summary>
        /// <param name="camas">Lista inicial de camas.</param>
        public Camas(List<Cama> camas)
        {
            this.camas = camas;
        }

        /// <summary>
        /// Retorna uma cópia da lista de camas.
        /// </summary>
        /// <returns>Lista de camas.</returns>
        public List<Cama> ListaCamas()
        {
            return new List<Cama>(camas);
        }

        /// <summary>
        /// Verifica se uma cama já existe na lista.
        /// </summary>
        /// <param name="cama">Cama a verificar.</param>
        /// <returns>True se a cama existir; caso contrário, false.</returns>
        public bool JaExiste(Cama cama)
        {
            return camas.Contains(cama);
        }

        /// <summary>
        /// Verifica se uma cama com determinado identificador já existe na lista.
        /// </summary>
        /// <param name="id">Identificador da cama.</param>
        /// <returns>True se existir cama com o id fornecido; caso contrário, false.</returns>
        public bool JaExiste(int id)
        {
            return camas.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Obtém uma cama pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da cama.</param>
        /// <returns>Cama encontrada ou null se não existir.</returns>
        public Cama? ObterCama(int id)
        {
            return camas.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere uma nova cama na lista.
        /// </summary>
        /// <param name="cama">Cama a inserir.</param>
        /// <returns>True se a cama for inserida; false se já existir.</returns>
        public bool InsereCama(Cama cama)
        {
            if (camas.Contains(cama)) return false;
            camas.Add(cama);
            return true;
        }

        /// <summary>
        /// Remove uma cama da lista.
        /// </summary>
        /// <param name="cama">Cama a remover.</param>
        /// <returns>True se a cama foi removida; caso contrário, false.</returns>
        public bool RemoveCama(Cama cama)
        {
            return camas.Remove(cama);
        }

        /// <summary>
        /// Remove uma cama pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da cama a remover.</param>
        /// <returns>True se alguma cama foi removida; caso contrário, false.</returns>
        public bool RemoveCamaPorId(int id)
        {
            return camas.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza uma cama existente com os dados de uma nova versão.
        /// </summary>
        /// <param name="nova_versao">Objeto Cama com os dados atualizados.</param>
        /// <returns>True se a cama foi atualizada; caso contrário, false.</returns>
        public bool UpdateCama(Cama nova_versao)
        {
            Cama? aux = ObterCama(nova_versao.Id);
            if (aux is null) { return false; }
            aux.QuartoId = nova_versao.QuartoId;
            aux.Ocupada = nova_versao.Ocupada;
            return true;
        }
    }
}

