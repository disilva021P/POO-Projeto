/*
 * Nome: MedicoRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Medico 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Medico
    /// </summary>
    public class MedicoRegras : ICrud<Medico, int>
    {
        private Medicos dados;

        public MedicoRegras()
        {
            dados = new Medicos();
        }

        public MedicoRegras(Medicos dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os médicos existentes
        /// </summary>
        /// <returns>Lista de objetos Medico</returns>
        public List<Medico> Listar()
        {
            return dados.ListaMedicos();
        }

        /// <summary>
        /// Verifica se um médico já existe
        /// </summary>
        /// <param name="medico">Médico a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Medico medico)
        {
            if (medico is null) throw new ArgumentNullException(nameof(medico));
            Validacoes.NifValido(medico.Nif);
            return dados.JaExiste(medico);
        }

        /// <summary>
        /// Verifica se existe um médico com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do médico</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Verifica se existe um médico associado ao NIF indicado
        /// </summary>
        /// <param name="nif">NIF do médico</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExisteNif(string nif)
        {
            Validacoes.NifValido(nif);
            Medico? med = MedicoPorNif(nif);
            return JaExiste(med);
        }

        /// <summary>
        /// Procura um médico pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do médico</param>
        /// <returns>Objeto Medico se encontrado, ou null</returns>
        public Medico? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.MedicoporId(id);
        }

        /// <summary>
        /// Procura um médico através do NIF
        /// </summary>
        /// <param name="nif">NIF do médico</param>
        /// <returns>Objeto Medico se encontrado, ou null</returns>
        public Medico? MedicoPorNif(string nif)
        {
            Validacoes.NifValido(nif);
            return dados.MedicoporNif(nif);
        }

        /// <summary>
        /// Procura um médico através do número de funcionário
        /// </summary>
        /// <param name="nFuncionario">Número de funcionário</param>
        /// <returns>Objeto Medico se encontrado, ou null</returns>
        public Medico? MedicoPorNFuncionario(int nFuncionario)
        {
            if (nFuncionario < 0) throw new ArgumentException("Nº de Funcionário inválido");
            return dados.MedicoporNFuncionario(nFuncionario);
        }

        /// <summary>
        /// Insere um novo médico
        /// </summary>
        /// <param name="medico">Médico a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(Medico medico)
        {
            if (medico is null) throw new ArgumentNullException(nameof(medico));
            Validacoes.NifValido(medico.Nif);
            if (this.JaExiste(medico)) return false;
            return dados.InsereMedico(medico);
        }

        /// <summary>
        /// Remove um médico existente
        /// </summary>
        /// <param name="medico">Médico a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(Medico medico)
        {
            if (medico is null) throw new ArgumentNullException(nameof(medico));
            Validacoes.NifValido(medico.Nif);
            if (!this.JaExiste(medico)) return false;
            return dados.RemoveMedico(medico);
        }

        /// <summary>
        /// Remove um médico através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do médico</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveMedico(id);
        }

        /// <summary>
        /// Remove um médico através do NIF
        /// </summary>
        /// <param name="nif">NIF do médico</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool RemoveMedicoPorNif(string nif)
        {
            var med = MedicoPorNif(nif);
            if (med is null) return false;
            return dados.RemoveMedico(med);
        }

        /// <summary>
        /// Atualiza os dados de um médico existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do médico</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(Medico nova_versao)
        {
            if (nova_versao is null) throw new ArgumentNullException(nameof(nova_versao));
            Validacoes.NifValido(nova_versao.Nif);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateMedico(nova_versao);
        }
    }
}
