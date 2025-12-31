/*
 * Nome: InternamentoHospital.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Internamentos
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade InternamentoHospital.
    /// </summary>
    public class InternamentosHospital
    {
        List<InternamentoHospital> internamentos;

        /// <summary>
        /// Construtor padrão que inicializa a lista de internamentos vazia.
        /// </summary>
        public InternamentosHospital()
        {
            this.internamentos = new List<InternamentoHospital>();
        }

        /// <summary>
        /// Construtor que inicializa a lista de internamentos com uma lista existente.
        /// </summary>
        /// <param name="internamentos">Lista de internamentos a ser gerida.</param>
        public InternamentosHospital(List<InternamentoHospital> internamentos)
        {
            this.internamentos = internamentos;
        }

        /// <summary>
        /// Retorna uma cópia da lista de internamentos.
        /// </summary>
        /// <returns>Lista contendo os objetos InternamentoHospital.</returns>
        public List<InternamentoHospital> ListaInternamentosHospital()
        {
            return new List<InternamentoHospital>(internamentos);
        }

        /// <summary>
        /// Verifica se um internamento específico já existe na lista.
        /// </summary>
        /// <param name="internamento">O internamento a verificar.</param>
        /// <returns>True se o internamento existir, caso contrário False.</returns>
        public bool JaExiste(InternamentoHospital internamento)
        {
            return internamentos.Contains(internamento);
        }

        /// <summary>
        /// Verifica se existe um internamento com o ID fornecido.
        /// </summary>
        /// <param name="id">Identificador do internamento.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return internamentos.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Obtém um internamento pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do internamento.</param>
        /// <returns>InternamentoHospital encontrado ou null se não existir.</returns>
        public InternamentoHospital? ObterInternamentoHospital(int id)
        {
            return internamentos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo internamento na lista, se não existir.
        /// </summary>
        /// <param name="internamento">Internamento a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereInternamentoHospital(InternamentoHospital internamento)
        {
            if (internamentos.Contains(internamento)) return false;
            internamentos.Add(internamento);
            return true;
        }

        /// <summary>
        /// Remove um internamento da lista.
        /// </summary>
        /// <param name="internamento">Internamento a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveInternamentoHospital(InternamentoHospital internamento)
        {
            return internamentos.Remove(internamento);
        }

        /// <summary>
        /// Remove um internamento da lista pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do internamento a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveInternamentoHospital(int id)
        {
            return internamentos.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza os dados de um internamento existente.
        /// </summary>
        /// <param name="nova_versao">Objeto InternamentoHospital com os dados atualizados (identificado pelo ID).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o internamento não for encontrado.</returns>
        public bool UpdateInternamentoHospital(InternamentoHospital nova_versao)
        {
            InternamentoHospital? aux = ObterInternamentoHospital(nova_versao.Id);
            if (aux is null) { return false; }
            aux.CamaId = nova_versao.CamaId;
            aux.DataSaida = nova_versao.DataSaida;
            return true;
        }
    }
}
