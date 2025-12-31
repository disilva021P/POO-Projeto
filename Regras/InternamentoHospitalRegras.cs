/*
 * Nome: InternamentoHospitalRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe InternamentoHospital 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe InternamentoHospital
    /// </summary>
    public class InternamentoHospitalRegras : ICrud<InternamentoHospital, int>
    {
        private InternamentosHospital dados;

        public InternamentoHospitalRegras()
        {
            dados = new InternamentosHospital();
        }

        public InternamentoHospitalRegras(InternamentosHospital dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os internamentos hospitalares existentes
        /// </summary>
        /// <returns>Lista de objetos InternamentoHospital</returns>
        public List<InternamentoHospital> Listar()
        {
            return dados.ListaInternamentosHospital();
        }

        /// <summary>
        /// Verifica se um internamento hospitalar já existe
        /// </summary>
        /// <param name="internamento">Internamento a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(InternamentoHospital internamento)
        {
            if (internamento is null) throw new ArgumentNullException(nameof(internamento));
            return dados.JaExiste(internamento);
        }

        /// <summary>
        /// Verifica se existe um internamento hospitalar com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura um internamento hospitalar pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <returns>Objeto InternamentoHospital se encontrado, ou null</returns>
        public InternamentoHospital? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterInternamentoHospital(id);
        }

        /// <summary>
        /// Insere um novo internamento hospitalar
        /// </summary>
        /// <param name="internamento">Internamento a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(InternamentoHospital internamento)
        {
            if (internamento is null) throw new ArgumentNullException(nameof(internamento));
            if (this.JaExiste(internamento)) return false;
            return dados.InsereInternamentoHospital(internamento);
        }

        /// <summary>
        /// Remove um internamento hospitalar existente
        /// </summary>
        /// <param name="internamento">Internamento a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(InternamentoHospital internamento)
        {
            if (internamento is null) throw new ArgumentNullException(nameof(internamento));
            if (!this.JaExiste(internamento)) return false;
            return dados.RemoveInternamentoHospital(internamento);
        }

        /// <summary>
        /// Remove um internamento hospitalar através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do internamento</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveInternamentoHospital(id);
        }

        /// <summary>
        /// Atualiza os dados de um internamento hospitalar existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do internamento</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(InternamentoHospital nova_versao)
        {
            if (nova_versao is null) throw new ArgumentNullException(nameof(nova_versao));
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateInternamentoHospital(nova_versao);
        }
    }
}
