﻿/*
 * Nome: GestorPacienteBD.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Pacientes
*/
using Bo;
using Exceptions;
using Regras;
using System.ComponentModel;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere classe PacienteBD
    /// </summary>
    public class GestorPacienteBD : IGestorPacienteBD
    {
        Dictionary<int, PacienteBD> pacienteBDList;

        /// <summary>
        /// Construtor padrão que inicializa o dicionário de pacientes.
        /// </summary>
        public GestorPacienteBD()
        {
            this.pacienteBDList = new Dictionary<int, PacienteBD>();
        }

        /// <summary>
        /// Construtor que recebe um dicionário de pacientes já existente.
        /// </summary>
        /// <param name="pacienteBDList">Dicionário de pacientes (ID -> PacienteBD).</param>
        public GestorPacienteBD(Dictionary<int, PacienteBD> pacienteBDList)
        {
            this.pacienteBDList = pacienteBDList;
        }

        /// <summary>
        /// Verifica se um paciente já existe no gestor (pelo NIF).
        /// </summary>
        /// <param name="paciente">Objeto Paciente a verificar.</param>
        /// <returns>True se existir, False caso contrário.</returns>
        public bool JaExiste(Paciente paciente)
        {
            return pacienteBDList.Values.Any(p => p.Paciente.Nif == paciente.Nif);
        }

        /// <summary>
        /// Verifica se existe um paciente com o ID especificado.
        /// </summary>
        /// <param name="id">ID do paciente.</param>
        /// <returns>True se existir, False caso contrário.</returns>
        public bool JaExiste(int id)
        {
            return pacienteBDList.ContainsKey(id);
        }

        /// <summary>
        /// Verifica se existe um paciente com o NIF especificado.
        /// </summary>
        /// <param name="nif">NIF do paciente.</param>
        /// <returns>True se existir, False caso contrário.</returns>
        public bool JaExiste(string nif)
        {
            return pacienteBDList.Values.Any(p => p.Paciente.Nif == nif);
        }

        /// <summary>
        /// Insere um novo paciente no gestor.
        /// </summary>
        /// <param name="pacienteBO">Objeto Paciente a inserir.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        /// <exception cref="ArgumentNullException">Lançado se pacienteBO for nulo.</exception>
        public bool InserePaciente(Paciente pacienteBO)
        {
            ArgumentNullException.ThrowIfNull(pacienteBO);
            if (JaExiste(pacienteBO.Nif)) throw new EntidadeDuplicadaException("Paciente","nif",pacienteBO.Id.ToString());
            pacienteBDList.Add(pacienteBO.Id, new PacienteBD(pacienteBO));
            return true;
        }

        /// <summary>
        /// Retorna um dicionário com todos os pacientes (apenas dados básicos).
        /// </summary>
        /// <returns>Dicionário de ID -> Paciente.</returns>
        public Dictionary<int, Paciente> ListaTodos()
        {
            return pacienteBDList.Values.ToDictionary(p => p.Paciente.Id, p => p.Paciente);
        }

        /// <summary>
        /// Retorna um dicionário com todos os pacientes completos (incluindo consultas e internamentos).
        /// </summary>
        /// <returns>Dicionário de ID -> PacienteBD.</returns>
        public Dictionary<int, PacienteBD> ListaTodosComConsultas()
        {
            return pacienteBDList;
        }

        /// <summary>
        /// Obtém um paciente pelo NIF.
        /// </summary>
        /// <param name="nif">NIF do paciente.</param>
        /// <returns>Objeto Paciente se encontrado, ou null.</returns>
        public Paciente? ObterPorNif(string nif)
        {
            Validacoes.NifValido(nif);
            if (!JaExiste(nif)) return null;
            return pacienteBDList.First(p => p.Value.Paciente.Nif == nif)!.Value.Paciente;
        }

        /// <summary>
        /// Obtém um paciente pelo ID.
        /// </summary>
        /// <param name="id">ID do paciente.</param>
        /// <returns>Objeto Paciente se encontrado, ou null.</returns>
        public Paciente? ObterPorId(int id)
        {
            return pacienteBDList.TryGetValue(id, out PacienteBD? pBD) ? pBD.Paciente : null;
        }

        /// <summary>
        /// Obtém um paciente completo (com dados associados) pelo NIF.
        /// </summary>
        /// <param name="nif">NIF do paciente.</param>
        /// <returns>Objeto PacienteBD se encontrado, ou null.</returns>
        public PacienteBD? ObterPorNifComConsulta(string nif)
        {
            Validacoes.NifValido(nif);
            if (!JaExiste(nif)) return null;
            return pacienteBDList.Values.FirstOrDefault(p => p.Paciente.Nif == nif);
        }

        /// <summary>
        /// Obtém um paciente completo (com dados associados) pelo ID.
        /// </summary>
        /// <param name="id">ID do paciente.</param>
        /// <returns>Objeto PacienteBD se encontrado, ou null.</returns>
        public PacienteBD? ObterPorIdCompleto(int id)
        {
            return pacienteBDList.Values.FirstOrDefault(p => p.Paciente.Id == id);
        }

        /// <summary>
        /// Atualiza os dados de um paciente existente.
        /// </summary>
        /// <param name="novoBO">Objeto Paciente com os novos dados.</param>
        /// <returns>True se atualizado com sucesso, False se não encontrado.</returns>
        public bool Atualizar(Paciente novoBO)
        {
            ArgumentNullException.ThrowIfNull(novoBO);
            Paciente? atual = ObterPorNif(novoBO.Nif);
            if (atual is null) return false;
            atual.Nome = novoBO.Nome;
            atual.Sobrenome = novoBO.Sobrenome;
            atual.Morada = novoBO.Morada;
            atual.Telefone = novoBO.Telefone;
            atual.DataNascimento = novoBO.DataNascimento;
            atual.Internado = novoBO.Internado;
            atual.ContactoEmergencia = novoBO.ContactoEmergencia;
            atual.Alergias = novoBO.Alergias;
            return true;
        }

        /// <summary>
        /// Remove um paciente do gestor.
        /// </summary>
        /// <param name="paciente">Objeto Paciente a remover.</param>
        /// <returns>True se removido com sucesso.</returns>
        public bool Remover(Paciente paciente)
        {
            ArgumentNullException.ThrowIfNull(paciente);
            PacienteBD? p = pacienteBDList.Values.FirstOrDefault(p => p.Paciente.Nif == paciente.Nif);
            if (paciente != null)
            {
                return pacienteBDList.Remove(paciente.Id);
            }
            return false;
        }

        /// <summary>
        /// Remove um paciente pelo ID.
        /// </summary>
        /// <param name="id">ID do paciente.</param>
        /// <returns>True se removido com sucesso.</returns>
        /// <exception cref="ArgumentException">Lançado se o ID for inválido.</exception>
        public bool RemoverPorId(int id)
        {
            if (id < 0) throw new ArgumentException("Id inválido", "id");
            return pacienteBDList.Remove(id);
        }

        /// <summary>
        /// Remove um paciente pelo NIF.
        /// </summary>
        /// <param name="nif">NIF do paciente.</param>
        /// <returns>True se removido com sucesso.</returns>
        public bool RemoverPorNif(string nif)
        {
            Validacoes.NifValido(nif);
            PacienteBD? paciente = pacienteBDList.Values.FirstOrDefault(p => p.Paciente.Nif == nif);
            if (paciente != null)
            {
                return pacienteBDList.Remove(paciente.Paciente.Id);
            }
            return false;
        }

        /// <summary>
        /// Lista as consultas de um paciente específico.
        /// </summary>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>Lista de consultas do paciente.</returns>
        /// <exception cref="EntidadeNaoEncontradaException">Lançado se o paciente não existir.</exception>
        public List<Consulta> ListarConsultas(int idPaciente)
        {
            if (!JaExiste(idPaciente)) throw new EntidadeNaoEncontradaException("Paciente", "id", idPaciente.ToString());
            return ObterPorIdCompleto(idPaciente)!.Consultas.ListaConsultas();
        }

        /// <summary>
        /// Insere uma nova consulta para um paciente.
        /// </summary>
        /// <param name="consulta">Objeto Consulta a inserir.</param>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>True se inserido com sucesso.</returns>
        public bool InserirConsulta(Consulta consulta, int idPaciente)
        {
            PacienteBD? p = ObterPorIdCompleto(idPaciente);
            if (p is null) throw new EntidadeNaoEncontradaException("Paciente", "id", idPaciente.ToString());
            return p.Consultas.InsereConsulta(consulta);
        }

        /// <summary>
        /// Remove uma consulta de um paciente.
        /// </summary>
        /// <param name="idconsulta">ID da consulta a remover.</param>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>True se removido com sucesso.</returns>
        public bool RemoveConsulta(int idconsulta, int idPaciente)
        {
            PacienteBD? p = ObterPorIdCompleto(idPaciente);
            return p is not null && p.Consultas.RemoveConsulta(idconsulta);
        }

        /// <summary>
        /// Atualiza uma consulta de um paciente.
        /// </summary>
        /// <param name="consulta">Objeto Consulta com os novos dados.</param>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>True se atualizado com sucesso.</returns>
        public bool AtualizaConsulta(Consulta consulta, int idPaciente)
        {
            PacienteBD? p = ObterPorIdCompleto(idPaciente);
            return p is not null && p.Consultas.UpdateConsulta(consulta);
        }

        /// <summary>
        /// Lista os internamentos de um paciente.
        /// </summary>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>Lista de internamentos.</returns>
        /// <exception cref="EntidadeNaoEncontradaException">Lançado se o paciente não existir.</exception>
        public List<InternamentoHospital> ListarInternamentos(int idPaciente)
        {
            if (!JaExiste(idPaciente)) throw new EntidadeNaoEncontradaException("Paciente","id",idPaciente.ToString());
            return ObterPorIdCompleto(idPaciente)!.Internamentos.ListaInternamentosHospital();
        }

        /// <summary>
        /// Insere um novo internamento para um paciente.
        /// </summary>
        /// <param name="internamento">Objeto InternamentoHospital a inserir.</param>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>True se inserido com sucesso.</returns>
        public bool InserirInternamento(InternamentoHospital internamento, int idPaciente)
        {
            PacienteBD? p = ObterPorIdCompleto(idPaciente);
            return p is not null && p.Internamentos.InsereInternamentoHospital(internamento);
        }

        /// <summary>
        /// Remove um internamento de um paciente.
        /// </summary>
        /// <param name="internamento">Objeto InternamentoHospital a remover.</param>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>True se removido com sucesso.</returns>
        public bool RemoveInternamento(InternamentoHospital internamento, int idPaciente)
        {
            PacienteBD? p = ObterPorIdCompleto(idPaciente);
            return p is not null && p.Internamentos.RemoveInternamentoHospital(internamento);
        }

        /// <summary>
        /// Atualiza um internamento de um paciente.
        /// </summary>
        /// <param name="internamento">Objeto InternamentoHospital com os novos dados.</param>
        /// <param name="idPaciente">ID do paciente.</param>
        /// <returns>True se atualizado com sucesso.</returns>
        public bool AtualizaInternamento(InternamentoHospital internamento, int idPaciente)
        {
            PacienteBD? p = ObterPorIdCompleto(idPaciente);
            return p is not null && p.Internamentos.UpdateInternamentoHospital(internamento);
        }
    }
}
