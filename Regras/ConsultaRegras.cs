/*
 * Nome: ConsultaRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Consulta 
*/
using Bo;
using Dados;
using Interfaces;
namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Consulta
    /// </summary>
    public class ConsultaRegras : ICrud<Consulta, int>
    {
        private Consultas dados;

        public ConsultaRegras()
        {
            dados = new Consultas();
        }

        public ConsultaRegras(Consultas dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todas as consultas existentes
        /// </summary>
        /// <returns>Lista de objetos Consulta</returns>
        public List<Consulta> Listar()
        {
            return dados.ListaConsultas();
        }

        /// <summary>
        /// Verifica se uma consulta já existe
        /// </summary>
        /// <param name="consulta">Consulta a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Consulta consulta)
        {
            ArgumentNullException.ThrowIfNull(consulta);
            return dados.JaExiste(consulta);
        }

        /// <summary>
        /// Verifica se existe uma consulta com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador da consulta</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura uma consulta pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador da consulta</param>
        /// <returns>Objeto Consulta se encontrado, ou null</returns>
        public Consulta? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterConsulta(id);
        }

        /// <summary>
        /// Insere uma nova consulta
        /// </summary>
        /// <param name="consulta">Consulta a inserir</param>
        /// <returns>True se inserida com sucesso, False se já existir</returns>
        public bool Inserir(Consulta consulta)
        {
            if (consulta is null) throw new ArgumentNullException(nameof(consulta));
            if (this.JaExiste(consulta)) return false;
            return dados.InsereConsulta(consulta);
        }

        /// <summary>
        /// Remove uma consulta existente
        /// </summary>
        /// <param name="consulta">Consulta a remover</param>
        /// <returns>True se removida com sucesso, False se não existir</returns>
        public bool Remover(Consulta consulta)
        {
            if (consulta is null) throw new ArgumentNullException(nameof(consulta));
            if (!this.JaExiste(consulta)) return false;
            return dados.RemoveConsulta(consulta);
        }

        /// <summary>
        /// Remove uma consulta através do seu identificador
        /// </summary>
        /// <param name="id">Identificador da consulta</param>
        /// <returns>True se removida com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.RemoveConsulta(id);
        }

        /// <summary>
        /// Atualiza os dados de uma consulta existente
        /// </summary>
        /// <param name="nova_versao">Nova versão da consulta</param>
        /// <returns>True se atualizada com sucesso, False se não existir</returns>
        public bool Atualizar(Consulta nova_versao)
        {
            if (nova_versao is null) throw new ArgumentNullException(nameof(nova_versao));
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateConsulta(nova_versao);
        }
    }
}
