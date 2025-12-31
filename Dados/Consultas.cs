/*
 * Nome: Consultas.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Consultas
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade Consulta
    /// </summary>
    public class Consultas
    {
        List<Consulta> consultas;

        /// <summary>
        /// Construtor que inicializa a lista vazia de consultas.
        /// </summary>
        public Consultas()
        {
            this.consultas = new List<Consulta>();
        }

        /// <summary>
        /// Construtor que inicializa a lista de consultas com uma lista existente.
        /// </summary>
        /// <param name="consulta">Lista inicial de consultas.</param>
        public Consultas(List<Consulta> consulta)
        {
            this.consultas = consulta;
        }

        /// <summary>
        /// Retorna uma cópia da lista de consultas.
        /// </summary>
        /// <returns>Lista de consultas.</returns>
        public List<Consulta> ListaConsultas()
        {
            return new List<Consulta>(consultas);
        }

        /// <summary>
        /// Verifica se uma consulta já existe na lista.
        /// </summary>
        /// <param name="consulta">Consulta a verificar.</param>
        /// <returns>True se a consulta existir; caso contrário, false.</returns>
        public bool JaExiste(Consulta consulta)
        {
            return consultas.Contains(consulta);
        }

        /// <summary>
        /// Verifica se existe uma consulta com determinado identificador.
        /// </summary>
        /// <param name="id">Identificador da consulta.</param>
        /// <returns>True se existir consulta com o id fornecido; caso contrário, false.</returns>
        public bool JaExiste(int id)
        {
            return consultas.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Obtém uma consulta pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da consulta.</param>
        /// <returns>Consulta encontrada ou null se não existir.</returns>
        public Consulta? ObterConsulta(int id)
        {
            return consultas.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere uma nova consulta na lista.
        /// </summary>
        /// <param name="consulta">Consulta a inserir.</param>
        /// <returns>True se a consulta for inserida; false se já existir.</returns>
        public bool InsereConsulta(Consulta consulta)
        {
            if (consultas.Contains(consulta)) return false;
            consultas.Add(consulta);
            return true;
        }

        /// <summary>
        /// Remove uma consulta da lista.
        /// </summary>
        /// <param name="consulta">Consulta a remover.</param>
        /// <returns>True se a consulta foi removida; caso contrário, false.</returns>
        public bool RemoveConsulta(Consulta consulta)
        {
            return consultas.Remove(consulta);
        }

        /// <summary>
        /// Remove uma consulta pelo seu identificador.
        /// </summary>
        /// <param name="idconsulta">Identificador da consulta a remover.</param>
        /// <returns>True se alguma consulta foi removida; caso contrário, false.</returns>
        public bool RemoveConsulta(int idconsulta)
        {
            return consultas.RemoveAll(x => x.Id == idconsulta) > 0;
        }

        /// <summary>
        /// Atualiza uma consulta existente com os dados de uma nova versão.
        /// </summary>
        /// <param name="nova_versao">Objeto Consulta com os dados atualizados.</param>
        /// <returns>True se a consulta foi atualizada; caso contrário, false.</returns>
        public bool UpdateConsulta(Consulta nova_versao)
        {
            Consulta? aux = ObterConsulta(nova_versao.Id);
            if (aux is null) { return false; }
            aux.DataConsulta = nova_versao.DataConsulta;
            aux.Custo = nova_versao.Custo;
            aux.MedicoId = nova_versao.MedicoId;
            aux.Paciente = nova_versao.Paciente;
            return true;
        }
    }
}

