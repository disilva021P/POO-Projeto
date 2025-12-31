/*
 * Nome: ResultadoExameRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe ResultadoExame 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Resultado
    /// </summary>
    public class ResultadoExameRegras : ICrud<ResultadoExame, int>
    {
        private ResultadoExames dados;

        public ResultadoExameRegras()
        {
            dados = new ResultadoExames();
        }

        public ResultadoExameRegras(ResultadoExames dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os resultados de exames existentes
        /// </summary>
        /// <returns>Lista de objetos ResultadoExame</returns>
        public List<ResultadoExame> Listar()
        {
            return dados.ListaResultadoExames();
        }

        /// <summary>
        /// Verifica se um resultado de exame já existe
        /// </summary>
        /// <param name="resultado">Resultado de exame a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(ResultadoExame resultado)
        {
            if (resultado is null) throw new ArgumentNullException(nameof(resultado));
            return dados.JaExiste(resultado);
        }

        /// <summary>
        /// Verifica se existe um resultado de exame com o ID indicado
        /// </summary>
        /// <param name="id">Identificador do resultado de exame</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura um resultado de exame pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do resultado de exame</param>
        /// <returns>ResultadoExame se encontrado, ou null</returns>
        public ResultadoExame? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterResultadoExames(id);
        }

        /// <summary>
        /// Insere um novo resultado de exame
        /// </summary>
        /// <param name="resultado">Resultado de exame a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(ResultadoExame resultado)
        {
            if (resultado is null) throw new ArgumentNullException(nameof(resultado));
            if (this.JaExiste(resultado)) return false;
            return dados.InsereResultadoExame(resultado);
        }

        /// <summary>
        /// Remove um resultado de exame existente
        /// </summary>
        /// <param name="resultado">Resultado de exame a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(ResultadoExame resultado)
        {
            if (resultado is null) throw new ArgumentNullException(nameof(resultado));
            if (!this.JaExiste(resultado)) return false;
            return dados.RemoveResultadoExame(resultado);
        }

        /// <summary>
        /// Remove um resultado de exame através do seu ID
        /// </summary>
        /// <param name="id">Identificador do resultado de exame</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveResultadoExame(id);
        }

        /// <summary>
        /// Atualiza os dados de um resultado de exame existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do resultado de exame</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(ResultadoExame nova_versao)
        {
            ArgumentNullException.ThrowIfNull(nova_versao);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateResultadoExame(nova_versao);
        }
    }
}
