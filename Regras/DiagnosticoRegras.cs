/*
 * Nome: DiagnosticoRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Diagnostico 
*/

using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Diagnostico
    /// </summary>
    public class DiagnosticoRegras : ICrud<Diagnostico, int>
    {
        private Diagnosticos dados;

        public DiagnosticoRegras()
        {
            dados = new Diagnosticos();
        }

        public DiagnosticoRegras(Diagnosticos dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os diagnósticos existentes
        /// </summary>
        /// <returns>Lista de objetos Diagnostico</returns>
        public List<Diagnostico> Listar()
        {
            return dados.ListaDiagnosticos();
        }

        /// <summary>
        /// Verifica se um diagnóstico já existe
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Diagnostico diagnostico)
        {
            ArgumentNullException.ThrowIfNull(diagnostico);
            return dados.JaExiste(diagnostico);
        }

        /// <summary>
        /// Verifica se existe um diagnóstico com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do diagnóstico</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura um diagnóstico pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do diagnóstico</param>
        /// <returns>Objeto Diagnostico se encontrado, ou null</returns>
        public Diagnostico? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterDiagnostico(id);
        }

        /// <summary>
        /// Insere um novo diagnóstico
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(Diagnostico diagnostico)
        {
            ArgumentNullException.ThrowIfNull(diagnostico);
            if (this.JaExiste(diagnostico)) return false;
            return dados.InsereDiagnostico(diagnostico);
        }

        /// <summary>
        /// Remove um diagnóstico existente
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(Diagnostico diagnostico)
        {
            ArgumentNullException.ThrowIfNull(diagnostico);
            if (!this.JaExiste(diagnostico)) return false;
            return dados.RemoveDiagnostico(diagnostico);
        }

        /// <summary>
        /// Remove um diagnóstico através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do diagnóstico</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveDiagnostico(id);
        }

        /// <summary>
        /// Atualiza os dados de um diagnóstico existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do diagnóstico</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(Diagnostico nova_versao)
        {
            ArgumentNullException.ThrowIfNull(nova_versao);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateDiagnostico(nova_versao);
        }
    }
}
