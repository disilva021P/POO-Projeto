/*
 * Nome: PacienteRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Paciente 
*/
using Bo;
using Dados;
using Exceptions;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Paciente
    /// </summary>
    public class PacienteRegras 
    {
        private IGestorPacienteBD dados;
        #region Construtores
        public PacienteRegras()
        {
            dados = new GestorPacienteBD();
        }

        public PacienteRegras(IGestorPacienteBD dados)
        {
            this.dados = dados;
        }
        #endregion

        #region M�todos de Listagem
        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Dicionário com todos os pacientes (Id, Paciente)</returns>
        public Dictionary<int, Paciente> Listar()
        {
            return dados.ListaTodos();
        }

        /// <summary>
        /// Lista todos os pacientes com as suas consultas
        /// </summary>
        /// <returns>Dicionário com todos os pacientes e consultas (Id, PacienteBD)</returns>
        public Dictionary<int, PacienteBD> ListarComConsultas()
        {
            return dados.ListaTodosComConsultas();
        }
        #endregion

        #region M�todos de Verifica��o de Exist�ncia
        /// <summary>
        /// Verifica se um paciente j� existe no sistema
        /// </summary>
        /// <param name="paciente">Paciente a verificar</param>
        /// <returns>True se existe, False caso contr�rio</returns>
        /// <exception cref="ArgumentNullException">Se paciente for null</exception>
        public bool JaExiste(Paciente paciente)
        {
            ArgumentNullException.ThrowIfNull(paciente);
            Validacoes.NifValido(paciente.Nif);
            return dados.JaExiste(paciente);
        }

        /// <summary>
        /// Verifica se um paciente com o ID especificado existe
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <returns>True se existe, False caso contr�rio</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inv�lido", nameof(id));
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Verifica se um paciente com o NIF especificado existe
        /// </summary>
        /// <param name="nif">NIF do paciente</param>
        /// <returns>True se existe, False caso contr�rio</returns>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public bool JaExisteNif(string nif)
        {
            Validacoes.NifValido(nif);
            return dados.JaExiste(nif);
        }
        #endregion

        #region M�todos de Busca
        /// <summary>
        /// Busca um paciente pelo ID
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <returns>Paciente encontrado ou null se n�o existir</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public Paciente? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inv�lido", nameof(id));
            return dados.ObterPorId(id);
        }

        /// <summary>
        /// Busca um paciente pelo NIF
        /// </summary>
        /// <param name="nif">NIF do paciente</param>
        /// <returns>Paciente encontrado ou null se n�o existir</returns>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public Paciente? PacientePorNif(string nif)
        {
            Validacoes.NifValido(nif);
            return dados.ObterPorNif(nif);
        }

        /// <summary>
        /// Busca um paciente pelo NIF com todas as suas consultas
        /// </summary>
        /// <param name="nif">NIF do paciente</param>
        /// <returns>PacienteBD com consultas ou null se n�o existir</returns>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public PacienteBD? BuscarPorNifComConsultas(string nif)
        {
            Validacoes.NifValido(nif);
            return dados.ObterPorNifComConsulta(nif);
        }

        /// <summary>
        /// Busca um paciente completo (com consultas e internamentos) pelo ID
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <returns>PacienteBD completo ou null se n�o existir</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public PacienteBD? BuscarPorIdCompleto(int id)
        {
            if (id < 0) throw new ArgumentException("ID inv�lido", nameof(id));
            return dados.ObterPorIdCompleto(id);
        }
        #endregion

        #region M�todos de Inser��o
        /// <summary>
        /// Insere um novo paciente no sistema
        /// </summary>
        /// <param name="paciente">Paciente a inserir</param>
        /// <returns>True se inserido com sucesso, False se j� existir</returns>
        /// <exception cref="ArgumentNullException">Se paciente for null</exception>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public bool Inserir(Paciente paciente)
        {
            ArgumentNullException.ThrowIfNull(paciente);
            Validacoes.NifValido(paciente.Nif);
            if (this.JaExiste(paciente)) return false;
            return dados.InserePaciente(paciente);
        }
        #endregion

        #region M�todos de Atualiza��o
        /// <summary>
        /// Atualiza os dados de um paciente existente
        /// </summary>
        /// <param name="novaVersao">Paciente com os novos dados</param>
        /// <returns>True se atualizado com sucesso, False se n�o existir</returns>
        /// <exception cref="ArgumentNullException">Se paciente for null</exception>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public bool Atualizar(Paciente novaVersao)
        {
            ArgumentNullException.ThrowIfNull(novaVersao);
            Validacoes.NifValido(novaVersao.Nif);
            if (!this.JaExiste(novaVersao)) return false;
            return dados.Atualizar(novaVersao);
        }
        #endregion

        #region M�todos de Remo��o
        /// <summary>
        /// Remove um paciente do sistema
        /// </summary>
        /// <param name="paciente">Paciente a remover</param>
        /// <returns>True se removido com sucesso, False se n�o existir</returns>
        /// <exception cref="ArgumentNullException">Se paciente for null</exception>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public bool Remover(Paciente paciente)
        {
            ArgumentNullException.ThrowIfNull(paciente);
            Validacoes.NifValido(paciente.Nif);
            if (!this.JaExiste(paciente)) return false;
            return dados.Remover(paciente);
        }

        /// <summary>
        /// Remove um paciente pelo ID
        /// </summary>
        /// <param name="id">ID do paciente a remover</param>
        /// <returns>True se removido com sucesso, False se n�o existir</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inv�lido", nameof(id));
            if (!this.JaExiste(id)) return false;
            return dados.RemoverPorId(id);
        }

        /// <summary>
        /// Remove um paciente pelo NIF
        /// </summary>
        /// <param name="nif">NIF do paciente a remover</param>
        /// <returns>True se removido com sucesso, False se n�o existir</returns>
        /// <exception cref="ArgumentException">Se NIF for inv�lido</exception>
        public bool RemoverPorNif(string nif)
        {
            Validacoes.NifValido(nif);
            if (!this.JaExisteNif(nif)) return false;
            return dados.RemoverPorNif(nif);
        }
        #endregion

        #region M�todos de Gest�o de Consultas
        /// <summary>
        /// Insere uma consulta para um paciente
        /// </summary>
        /// <param name="consulta">Consulta a inserir</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se inserida com sucesso, False caso contr�rio</returns>
        /// <exception cref="ArgumentNullException">Se consulta for null</exception>
        /// <exception cref="ArgumentException">Se ID do paciente for inv�lido</exception>
        public bool InserirConsulta(Consulta consulta, int idPaciente)
        {
            ArgumentNullException.ThrowIfNull(consulta);
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if (!this.JaExiste(idPaciente)) return false;
            return dados.InserirConsulta(consulta, idPaciente);
        }

        /// <summary>
        /// Remove uma consulta de um paciente
        /// </summary>
        /// <param name="idConsulta">ID da consulta a remover</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se removida com sucesso, False caso contr�rio</returns>
        /// <exception cref="ArgumentException">Se IDs forem inv�lidos</exception>
        public bool RemoverConsulta(int idConsulta, int idPaciente)
        {
            if (idConsulta < 0) throw new ArgumentException("ID da consulta inv�lido", nameof(idConsulta));
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if (!this.JaExiste(idPaciente)) return false;
            return dados.RemoveConsulta(idConsulta, idPaciente);
        }

        /// <summary>
        /// Atualiza uma consulta de um paciente
        /// </summary>
        /// <param name="consulta">Consulta com os novos dados</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se atualizada com sucesso, False caso contr�rio</returns>
        /// <exception cref="ArgumentNullException">Se consulta for null</exception>
        /// <exception cref="ArgumentException">Se ID do paciente for inv�lido</exception>
        public bool AtualizarConsulta(Consulta consulta, int idPaciente)
        {
            ArgumentNullException.ThrowIfNull(consulta);
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if (!this.JaExiste(idPaciente)) return false;
            return dados.AtualizaConsulta(consulta, idPaciente);
        }

        /// <summary>
        /// Lista todas as consultas de um paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>Dicion�rio de consultas ou null se paciente n�o existir</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public List<Consulta>? ListarConsultasPaciente(int idPaciente)
        {
            return dados.ListarConsultas(idPaciente);
        }

        /// <summary>
        /// Busca uma consulta espec�fica de um paciente
        /// </summary>
        /// <param name="idConsulta">ID da consulta</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>Consulta encontrada ou null</returns>
        /// <exception cref="ArgumentException">Se IDs forem inv�lidos</exception>
        public Consulta? BuscarConsulta(int idConsulta, int idPaciente)
        {
            if (idConsulta < 0) throw new ArgumentException("ID da consulta inv�lido", nameof(idConsulta));
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            PacienteBD? paciente = dados.ObterPorIdCompleto(idPaciente);
            return paciente?.Consultas.ObterConsulta(idConsulta);
        }
        #endregion

        #region M�todos de Gest�o de Internamentos
        /// <summary>
        /// Insere um internamento para um paciente
        /// </summary>
        /// <param name="internamento">Internamento a inserir</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se inserido com sucesso, False caso contr�rio</returns>
        /// <exception cref="ArgumentNullException">Se internamento for null</exception>
        /// <exception cref="ArgumentException">Se ID do paciente for inv�lido</exception>
        public bool InserirInternamento(InternamentoHospital internamento, int idPaciente)
        {
            ArgumentNullException.ThrowIfNull(internamento);
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if (!this.JaExiste(idPaciente)) return false;
            return dados.InserirInternamento(internamento, idPaciente);
        }

        /// <summary>
        /// Remove um internamento de um paciente
        /// </summary>
        /// <param name="internamento">Internamento a remover</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se removido com sucesso, False caso contr�rio</returns>
        /// <exception cref="ArgumentNullException">Se internamento for null</exception>
        /// <exception cref="ArgumentException">Se ID do paciente for inv�lido</exception>
        public bool RemoverInternamento(InternamentoHospital internamento, int idPaciente)
        {
            ArgumentNullException.ThrowIfNull(internamento);
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if (!this.JaExiste(idPaciente)) return false;
            return dados.RemoveInternamento(internamento, idPaciente);
        }

        /// <summary>
        /// Atualiza um internamento de um paciente
        /// </summary>
        /// <param name="internamento">Internamento com os novos dados</param>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se atualizado com sucesso, False caso contr�rio</returns>
        /// <exception cref="ArgumentNullException">Se internamento for null</exception>
        /// <exception cref="ArgumentException">Se ID do paciente for inv�lido</exception>
        public bool AtualizarInternamento(InternamentoHospital internamento, int idPaciente)
        {
            ArgumentNullException.ThrowIfNull(internamento);
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if (!this.JaExiste(idPaciente)) return false;
            return dados.AtualizaInternamento(internamento, idPaciente);
        }

        /// <summary>
        /// Lista todos os internamentos de um paciente
        /// </summary>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>Lista de internamentos ou null se paciente n�o existir</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public List<InternamentoHospital>? ListarInternamentosPaciente(int idPaciente)
        {
            return dados.ListarInternamentos(idPaciente);
        }

        /// <summary>
        /// Verifica se um paciente est� atualmente internado
        /// </summary>
        /// <param name="idPaciente">ID do paciente</param>
        /// <returns>True se est� internado, False caso contr�rio</returns>
        /// <exception cref="ArgumentException">Se ID for inv�lido</exception>
        public bool PacienteEstaInternado(int idPaciente)
        {
            if (idPaciente < 0) throw new ArgumentException("ID do paciente inv�lido", nameof(idPaciente));
            if(!JaExiste(idPaciente)) throw new EntidadeNaoEncontradaException("Paciente","id",idPaciente.ToString());
            Paciente? paciente = BuscarPorId(idPaciente);
            return paciente!.Internado;
        }
        #endregion

        #region M�todos de Estat�sticas e Relat�rios
        /// <summary>
        /// Conta o n�mero total de pacientes no sistema
        /// </summary>
        /// <returns>N�mero de pacientes</returns>
        public int ContarPacientes()
        {
            return dados.ListaTodos().Count;
        }

        /// <summary>
        /// Lista pacientes internados
        /// </summary>
        /// <returns>Lista de pacientes internados</returns>
        public List<Paciente> ListarPacientesInternados()
        {
            return dados.ListaTodos().Values
                .Where(p => p.Internado)
                .ToList();
        }

        /// <summary>
        /// Lista pacientes n�o internados
        /// </summary>
        /// <returns>Lista de pacientes n�o internados</returns>
        public List<Paciente> ListarPacientesNaoInternados()
        {
            return dados.ListaTodos().Values
                .Where(p => !p.Internado)
                .ToList();
        }

        /// <summary>
        /// Busca pacientes por nome (pesquisa parcial)
        /// </summary>
        /// <param name="nome">Nome ou parte do nome a pesquisar</param>
        /// <returns>Lista de pacientes encontrados</returns>
        /// <exception cref="ArgumentException">Se nome for vazio ou null</exception>
        public List<Paciente> BuscarPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome n�o pode ser vazio", nameof(nome));

            return dados.ListaTodos().Values
                .Where(p => p.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase) ||
                           p.Sobrenome.Contains(nome, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Lista pacientes com alergias
        /// </summary>
        /// <returns>Lista de pacientes que t�m alergias registadas</returns>
        public List<Paciente> ListarPacientesComAlergias()
        {
            return dados.ListaTodos().Values
                .Where(p => !string.IsNullOrWhiteSpace(p.Alergias))
                .ToList();
        }
        #endregion
    }
}

