/*
 * Nome: EnfermeiroRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Enfermeiro 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Enfermeiro
    /// </summary>
    public class EnfermeiroRegras : ICrud<Enfermeiro, int>
    {
        private Enfermeiros dados;

        public EnfermeiroRegras()
        {
            dados = new Enfermeiros();
        }

        public EnfermeiroRegras(Enfermeiros dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os enfermeiros existentes
        /// </summary>
        /// <returns>Lista de objetos Enfermeiro</returns>
        public List<Enfermeiro> Listar()
        {
            return dados.ListaEnfermeiros();
        }

        /// <summary>
        /// Verifica se um enfermeiro já existe
        /// </summary>
        /// <param name="enfermeiro">Enfermeiro a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Enfermeiro enfermeiro)
        {
            if (enfermeiro is null) throw new ArgumentNullException(nameof(enfermeiro));
            Validacoes.NifValido(enfermeiro.Nif);
            return dados.JaExiste(enfermeiro);
        }

        /// <summary>
        /// Verifica se existe um enfermeiro com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do enfermeiro</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Verifica se existe um enfermeiro com o NIF indicado
        /// </summary>
        /// <param name="nif">Número de Identificação Fiscal</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExisteNif(string nif)
        {
            Validacoes.NifValido(nif);
            Enfermeiro? enf = EnfermeiroPorNif(nif);
            return JaExiste(enf);
        }

        /// <summary>
        /// Procura um enfermeiro pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do enfermeiro</param>
        /// <returns>Objeto Enfermeiro se encontrado, ou null</returns>
        public Enfermeiro? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.BuscarPorId(id);
        }

        /// <summary>
        /// Procura um enfermeiro pelo seu NIF
        /// </summary>
        /// <param name="nif">Número de Identificação Fiscal</param>
        /// <returns>Objeto Enfermeiro se encontrado, ou null</returns>
        public Enfermeiro? EnfermeiroPorNif(string nif)
        {
            Validacoes.NifValido(nif);
            return dados.EnfermeiroporNif(nif);
        }

        /// <summary>
        /// Procura um enfermeiro pelo número de funcionário
        /// </summary>
        /// <param name="nFuncionario">Número de funcionário</param>
        /// <returns>Objeto Enfermeiro se encontrado, ou null</returns>
        public Enfermeiro? EnfermeiroPorNFuncionario(int nFuncionario)
        {
            if (nFuncionario < 0) throw new ArgumentException("Nº de Funcionário inválido");
            return dados.EnfermeiroporNFuncionario(nFuncionario);
        }

        /// <summary>
        /// Insere um novo enfermeiro
        /// </summary>
        /// <param name="enfermeiro">Enfermeiro a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(Enfermeiro enfermeiro)
        {
            if (enfermeiro is null) throw new ArgumentNullException(nameof(enfermeiro));
            Validacoes.NifValido(enfermeiro.Nif);
            if (this.JaExiste(enfermeiro)) return false;
            return dados.InsereEnfermeiro(enfermeiro);
        }

        /// <summary>
        /// Remove um enfermeiro existente
        /// </summary>
        /// <param name="enfermeiro">Enfermeiro a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(Enfermeiro enfermeiro)
        {
            if (enfermeiro is null) throw new ArgumentNullException(nameof(enfermeiro));
            Validacoes.NifValido(enfermeiro.Nif);
            if (!this.JaExiste(enfermeiro)) return false;
            return dados.RemoveEnfermeiro(enfermeiro);
        }

        /// <summary>
        /// Remove um enfermeiro através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do enfermeiro</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveEnfermeiro(id);
        }

        /// <summary>
        /// Remove um enfermeiro através do seu NIF
        /// </summary>
        /// <param name="nif">Número de Identificação Fiscal</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool RemoveEnfermeiroPorNif(string nif)
        {
            var enf = EnfermeiroPorNif(nif);
            if (enf is null) return false;
            return dados.RemoveEnfermeiro(enf);
        }

        /// <summary>
        /// Atualiza os dados de um enfermeiro existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do enfermeiro</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(Enfermeiro nova_versao)
        {
            if (nova_versao is null) throw new ArgumentNullException(nameof(nova_versao));
            Validacoes.NifValido(nova_versao.Nif);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateEnfermeiro(nova_versao);
        }
    }
}
