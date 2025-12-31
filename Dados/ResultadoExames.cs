/*
 * Nome: ResutadoExames.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir resultados de exames
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere objetos do tipo ResultadoExame.
    /// </summary>
    public class ResultadoExames
    {
        private List<ResultadoExame> resultadoExames;

        /// <summary>
        /// Construtor padrão que inicializa a lista de resultados de exames.
        /// </summary>
        public ResultadoExames()
        {
            this.resultadoExames = new List<ResultadoExame>();
        }

        /// <summary>
        /// Construtor que recebe uma lista de resultados de exames já existente.
        /// </summary>
        /// <param name="diagnosticos">Lista de resultados de exames a ser gerida.</param>
        public ResultadoExames(List<ResultadoExame> diagnosticos)
        {
            this.resultadoExames = diagnosticos;
        }

        /// <summary>
        /// Retorna uma cópia da lista de todos os resultados de exames.
        /// </summary>
        /// <returns>Uma lista contendo os objetos ResultadoExame.</returns>
        public List<ResultadoExame> ListaResultadoExames()
        {
            return new List<ResultadoExame>(resultadoExames);
        }

        /// <summary>
        /// Verifica se um resultado de exame específico já existe na lista.
        /// </summary>
        /// <param name="resultadoExame">Objeto ResultadoExame a verificar.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(ResultadoExame resultadoExame)
        {
            return resultadoExames.Contains(resultadoExame);
        }

        /// <summary>
        /// Verifica se existe um resultado de exame com o ID fornecido.
        /// </summary>
        /// <param name="id">O identificador do resultado de exame.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return resultadoExames.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Busca um resultado de exame pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do resultado de exame.</param>
        /// <returns>O objeto ResultadoExame se encontrado, ou null.</returns>
        public ResultadoExame? ObterResultadoExames(int id)
        {
            return resultadoExames.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo resultado de exame na lista, se não existir.
        /// </summary>
        /// <param name="resultadoExame">O resultado de exame a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereResultadoExame(ResultadoExame resultadoExame)
        {
            if (resultadoExames.Contains(resultadoExame)) return false;
            resultadoExames.Add(resultadoExame);
            return true;
        }

        /// <summary>
        /// Remove um resultado de exame da lista.
        /// </summary>
        /// <param name="resultadoExame">O resultado de exame a ser removido.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveResultadoExame(ResultadoExame resultadoExame)
        {
            return resultadoExames.Remove(resultadoExame);
        }

        /// <summary>
        /// Remove um resultado de exame da lista pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador do resultado de exame a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveResultadoExame(int id)
        {
            return resultadoExames.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza os dados de um resultado de exame existente.
        /// </summary>
        /// <param name="resultadoExame">Objeto com os novos dados do resultado de exame (identificado pelo ID).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o resultado de exame não for encontrado.</returns>
        public bool UpdateResultadoExame(ResultadoExame resultadoExame)
        {
            ResultadoExame? aux = ObterResultadoExames(resultadoExame.Id);
            if (aux is null) { return false; }
            aux.Resultado = resultadoExame.Resultado;
            return true;
        }
    }
}
