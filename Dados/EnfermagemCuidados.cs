/*
 * Nome: EnfermagemCuidados.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir cuidados de enfermagem
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade EnfermagemCuidado
    /// </summary>
    public class EnfermagemCuidados
    {
        List<EnfermagemCuidado> enfermagemCuidados;

        /// <summary>
        /// Construtor que inicializa a lista vazia de cuidados de enfermagem.
        /// </summary>
        public EnfermagemCuidados()
        {
            this.enfermagemCuidados = new List<EnfermagemCuidado>();
        }

        /// <summary>
        /// Construtor que inicializa a lista de cuidados de enfermagem com uma lista existente.
        /// </summary>
        /// <param name="enfermagemCuidados">Lista inicial de cuidados de enfermagem.</param>
        public EnfermagemCuidados(List<EnfermagemCuidado> enfermagemCuidados)
        {
            this.enfermagemCuidados = enfermagemCuidados;
        }

        /// <summary>
        /// Retorna uma cópia da lista de cuidados de enfermagem.
        /// </summary>
        /// <returns>Lista de cuidados de enfermagem.</returns>
        public List<EnfermagemCuidado> ListaCuidados()
        {
            return new List<EnfermagemCuidado>(enfermagemCuidados);
        }

        /// <summary>
        /// Verifica se um cuidado de enfermagem já existe na lista.
        /// </summary>
        /// <param name="diagnostico">Cuidado de enfermagem a verificar.</param>
        /// <returns>True se o cuidado existir; caso contrário, false.</returns>
        public bool JaExiste(EnfermagemCuidado diagnostico)
        {
            return enfermagemCuidados.Contains(diagnostico);
        }

        /// <summary>
        /// Verifica se existe um cuidado de enfermagem com determinado identificador.
        /// </summary>
        /// <param name="id">Identificador do cuidado de enfermagem.</param>
        /// <returns>True se existir cuidado com o id fornecido; caso contrário, false.</returns>
        public bool JaExiste(int id)
        {
            return enfermagemCuidados.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Obtém um cuidado de enfermagem pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do cuidado de enfermagem.</param>
        /// <returns>Cuidado de enfermagem encontrado ou null se não existir.</returns>
        public EnfermagemCuidado? ObterEnfermagemCuidado(int id)
        {
            return enfermagemCuidados.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo cuidado de enfermagem na lista.
        /// </summary>
        /// <param name="diagnostico">Cuidado de enfermagem a inserir.</param>
        /// <returns>True se o cuidado for inserido; false se já existir.</returns>
        public bool InsereEnfermagemCuidado(EnfermagemCuidado diagnostico)
        {
            if (enfermagemCuidados.Contains(diagnostico)) return false;
            enfermagemCuidados.Add(diagnostico);
            return true;
        }

        /// <summary>
        /// Remove um cuidado de enfermagem da lista.
        /// </summary>
        /// <param name="diagnostico">Cuidado de enfermagem a remover.</param>
        /// <returns>True se o cuidado foi removido; caso contrário, false.</returns>
        public bool RemoveEnfermagemCuidado(EnfermagemCuidado diagnostico)
        {
            return enfermagemCuidados.Remove(diagnostico);
        }

        /// <summary>
        /// Remove um cuidado de enfermagem pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do cuidado de enfermagem a remover.</param>
        /// <returns>True se algum cuidado foi removido; caso contrário, false.</returns>
        public bool RemoveEnfermagemCuidado(int id)
        {
            return enfermagemCuidados.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza um cuidado de enfermagem existente com os dados de uma nova versão.
        /// </summary>
        /// <param name="diagnosticos">Objeto EnfermagemCuidado com os dados atualizados.</param>
        /// <returns>True se o cuidado foi atualizado; caso contrário, false.</returns>
        public bool UpdateEnfermagemCuidado(EnfermagemCuidado diagnosticos)
        {
            EnfermagemCuidado? aux = ObterEnfermagemCuidado(diagnosticos.Id);
            if (aux is null) { return false; }
            aux.Observacao = diagnosticos.Observacao;
            aux.EnfermeiroId = diagnosticos.EnfermeiroId;
            aux.DataHora = diagnosticos.DataHora;
            aux.InternamentoId = diagnosticos.InternamentoId;
            return true;
        }
    }
}
