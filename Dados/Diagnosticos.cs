/*
 * Nome: Diagnositcos.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Diagnosticos
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade Diagnostico
    /// </summary>
    public class Diagnosticos
    {
        List<Diagnostico> diagnosticos;

        /// <summary>
        /// Construtor que inicializa a lista vazia de diagnósticos.
        /// </summary>
        public Diagnosticos()
        {
            this.diagnosticos = new List<Diagnostico>();
        }

        /// <summary>
        /// Construtor que inicializa a lista de diagnósticos com uma lista existente.
        /// </summary>
        /// <param name="diagnosticos">Lista inicial de diagnósticos.</param>
        public Diagnosticos(List<Diagnostico> diagnosticos)
        {
            this.diagnosticos = diagnosticos;
        }

        /// <summary>
        /// Retorna uma cópia da lista de diagnósticos.
        /// </summary>
        /// <returns>Lista de diagnósticos.</returns>
        public List<Diagnostico> ListaDiagnosticos()
        {
            return new List<Diagnostico>(diagnosticos);
        }

        /// <summary>
        /// Verifica se um diagnóstico já existe na lista.
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a verificar.</param>
        /// <returns>True se o diagnóstico existir; caso contrário, false.</returns>
        public bool JaExiste(Diagnostico diagnostico)
        {
            return diagnosticos.Contains(diagnostico);
        }

        /// <summary>
        /// Verifica se existe um diagnóstico com determinado identificador.
        /// </summary>
        /// <param name="id">Identificador do diagnóstico.</param>
        /// <returns>True se existir diagnóstico com o id fornecido; caso contrário, false.</returns>
        public bool JaExiste(int id)
        {
            return diagnosticos.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Obtém um diagnóstico pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do diagnóstico.</param>
        /// <returns>Diagnóstico encontrado ou null se não existir.</returns>
        public Diagnostico? ObterDiagnostico(int id)
        {
            return diagnosticos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo diagnóstico na lista.
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a inserir.</param>
        /// <returns>True se o diagnóstico for inserido; false se já existir.</returns>
        public bool InsereDiagnostico(Diagnostico diagnostico)
        {
            if (diagnosticos.Contains(diagnostico)) return false;
            diagnosticos.Add(diagnostico);
            return true;
        }

        /// <summary>
        /// Remove um diagnóstico da lista.
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a remover.</param>
        /// <returns>True se o diagnóstico foi removido; caso contrário, false.</returns>
        public bool RemoveDiagnostico(Diagnostico diagnostico)
        {
            return diagnosticos.Remove(diagnostico);
        }

        /// <summary>
        /// Remove um diagnóstico pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador do diagnóstico a remover.</param>
        /// <returns>True se algum diagnóstico foi removido; caso contrário, false.</returns>
        public bool RemoveDiagnostico(int id)
        {
            return diagnosticos.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza um diagnóstico existente com os dados de uma nova versão.
        /// </summary>
        /// <param name="diagnosticos">Objeto Diagnostico com os dados atualizados.</param>
        /// <returns>True se o diagnóstico foi atualizado; caso contrário, false.</returns>
        public bool UpdateDiagnostico(Diagnostico diagnosticos)
        {
            Diagnostico? aux = ObterDiagnostico(diagnosticos.Id);
            if (aux is null) { return false; }
            aux.Descricao = diagnosticos.Descricao;
            return true;
        }
    }
}
