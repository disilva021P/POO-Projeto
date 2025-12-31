/*
 * Nome: Quartos.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Quartos
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere objetos do tipo Quarto.
    /// </summary>
    public class Quartos
    {
        private List<Quarto> quartos;

        /// <summary>
        /// Construtor padrão que inicializa a lista de quartos.
        /// </summary>
        public Quartos()
        {
            this.quartos = new List<Quarto>();
        }

        /// <summary>
        /// Construtor que recebe uma lista de quartos já existente.
        /// </summary>
        /// <param name="quartos">Lista de quartos a ser gerida.</param>
        public Quartos(List<Quarto> quartos)
        {
            this.quartos = quartos;
        }

        /// <summary>
        /// Retorna uma cópia da lista de todos os quartos.
        /// </summary>
        /// <returns>Uma lista contendo os objetos Quarto.</returns>
        public List<Quarto> ListaQuartos()
        {
            return new List<Quarto>(quartos);
        }

        /// <summary>
        /// Verifica se um quarto específico já existe na lista.
        /// </summary>
        /// <param name="quarto">Objeto Quarto a verificar.</param>
        /// <returns>True se o quarto existir, caso contrário False.</returns>
        public bool JaExiste(Quarto quarto)
        {
            return quartos.Contains(quarto);
        }

        /// <summary>
        /// Verifica se existe um quarto com o ID fornecido.
        /// </summary>
        /// <param name="id">O identificador do quarto.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return quartos.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Busca um quarto pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do quarto.</param>
        /// <returns>O objeto Quarto se encontrado, ou null.</returns>
        public Quarto? ObterQuarto(int id)
        {
            return quartos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo quarto na lista, se não existir.
        /// </summary>
        /// <param name="quarto">O quarto a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereQuartos(Quarto quarto)
        {
            if (quartos.Contains(quarto)) return false;
            quartos.Add(quarto);
            return true;
        }

        /// <summary>
        /// Remove um quarto da lista.
        /// </summary>
        /// <param name="quarto">O quarto a ser removido.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveQuartos(Quarto quarto)
        {
            return quartos.Remove(quarto);
        }

        /// <summary>
        /// Remove um quarto da lista pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador do quarto a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveQuartosId(int id)
        {
            return quartos.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza os dados de um quarto existente.
        /// </summary>
        /// <param name="nova_versao">Objeto Quarto com os novos dados (identificado pelo ID).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o quarto não for encontrado.</returns>
        public bool UpdateQuartos(Quarto nova_versao)
        {
            Quarto? aux = ObterQuarto(nova_versao.Id);
            if (aux is null) { return false; }
            aux.Andar = nova_versao.Andar;
            aux.Tipo = nova_versao.Tipo;
            return true;
        }
    }
}
