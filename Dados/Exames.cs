/*
 * Nome: Exames.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Exames
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade Exame.
    /// </summary>
    public class Exames
    {
        List<Exame> exames;

        /// <summary>
        /// Construtor padrão que inicializa a lista de exames vazia.
        /// </summary>
        public Exames()
        {
            this.exames = new List<Exame>();
        }

        /// <summary>
        /// Construtor que inicializa a lista de exames com uma lista existente.
        /// </summary>
        /// <param name="diagnosticos">Lista de exames a ser gerida.</param>
        public Exames(List<Exame> diagnosticos)
        {
            this.exames = diagnosticos;
        }

        /// <summary>
        /// Retorna uma cópia da lista de exames.
        /// </summary>
        /// <returns>Lista contendo os objetos Exame.</returns>
        public List<Exame> ListaExames()
        {
            return new List<Exame>(exames);
        }

        /// <summary>
        /// Verifica se um exame específico já existe na lista.
        /// </summary>
        /// <param name="diagnostico">O exame a verificar.</param>
        /// <returns>True se o exame existir, caso contrário False.</returns>
        public bool JaExiste(Exame diagnostico)
        {
            return exames.Contains(diagnostico);
        }

        /// <summary>
        /// Verifica se existe um exame com o ID fornecido.
        /// </summary>
        /// <param name="id">Identificador do exame.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return exames.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Obtém um exame pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do exame.</param>
        /// <returns>Exame encontrado ou null se não existir.</returns>
        public Exame? ObterExame(int id)
        {
            return exames.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo exame na lista, se não existir.
        /// </summary>
        /// <param name="exame">Exame a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereExame(Exame exame)
        {
            if (exames.Contains(exame)) return false;
            exames.Add(exame);
            return true;
        }

        /// <summary>
        /// Remove um exame da lista.
        /// </summary>
        /// <param name="exame">Exame a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveExame(Exame exame)
        {
            return exames.Remove(exame);
        }

        /// <summary>
        /// Remove um exame da lista pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do exame a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveExame(int id)
        {
            return exames.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza os dados de um exame existente.
        /// </summary>
        /// <param name="nova_versao">Objeto Exame com os dados atualizados (identificado pelo ID).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o exame não for encontrado.</returns>
        public bool UpdateExame(Exame nova_versao)
        {
            Exame? aux = ObterExame(nova_versao.Id);
            if (aux is null) { return false; }
            aux.Resultado = nova_versao.Resultado;
            aux.Custo = nova_versao.Custo;
            aux.Tipo = nova_versao.Tipo;
            aux.Realizado = nova_versao.Realizado;
            return true;
        }
    }
}
