﻿/*
 * Nome: GestorPacienteBD.cs
 * Autor: Diogo Silva
 * Data de Criação: 28/12/2025
 * Última Atualização: 28/12/2025
 * Descrição: Classe que une GestorPacientesBD a PacienteRegras
*/
using Bo;

namespace Dados
{
    public interface IGestorPacienteBD
    {
        /// <summary>
        /// Verifica se um paciente já existe.
        /// </summary>
        bool JaExiste(Paciente paciente);

        /// <summary>
        /// Verifica se existe um paciente com o ID especificado.
        /// </summary>
        bool JaExiste(int id);

        /// <summary>
        /// Verifica se existe um paciente com o NIF especificado.
        /// </summary>
        bool JaExiste(string nif);

        /// <summary>
        /// Insere um novo paciente.
        /// </summary>
        bool InserePaciente(Paciente pacienteBO);

        /// <summary>
        /// Retorna todos os pacientes.
        /// </summary>
        Dictionary<int, Paciente> ListaTodos();

        /// <summary>
        /// Retorna todos os pacientes com seus dados completos.
        /// </summary>
        Dictionary<int, PacienteBD> ListaTodosComConsultas();

        /// <summary>
        /// Obtém um paciente pelo NIF.
        /// </summary>
        Paciente? ObterPorNif(string nif);

        /// <summary>
        /// Obtém um paciente pelo ID.
        /// </summary>
        Paciente? ObterPorId(int id);

        /// <summary>
        /// Obtém um paciente completo pelo NIF.
        /// </summary>
        PacienteBD? ObterPorNifComConsulta(string nif);

        /// <summary>
        /// Obtém um paciente completo pelo ID.
        /// </summary>
        PacienteBD? ObterPorIdCompleto(int id);

        /// <summary>
        /// Atualiza os dados de um paciente.
        /// </summary>
        bool Atualizar(Paciente novoBO);

        /// <summary>
        /// Remove um paciente.
        /// </summary>
        bool Remover(Paciente paciente);

        /// <summary>
        /// Remove um paciente pelo ID.
        /// </summary>
        bool RemoverPorId(int id);

        /// <summary>
        /// Remove um paciente pelo NIF.
        /// </summary>
        bool RemoverPorNif(string nif);

        /// <summary>
        /// Lista as consultas de um paciente.
        /// </summary>
        List<Consulta> ListarConsultas(int idPaciente);

        /// <summary>
        /// Insere uma consulta para um paciente.
        /// </summary>
        bool InserirConsulta(Consulta consulta, int idPaciente);

        /// <summary>
        /// Remove uma consulta de um paciente.
        /// </summary>
        bool RemoveConsulta(int idconsulta, int idPaciente);

        /// <summary>
        /// Atualiza uma consulta de um paciente.
        /// </summary>
        bool AtualizaConsulta(Consulta consulta, int idPaciente);

        /// <summary>
        /// Lista os internamentos de um paciente.
        /// </summary>
        List<InternamentoHospital> ListarInternamentos(int idPaciente);

        /// <summary>
        /// Insere um internamento para um paciente.
        /// </summary>
        bool InserirInternamento(InternamentoHospital internamento, int idPaciente);

        /// <summary>
        /// Remove um internamento de um paciente.
        /// </summary>
        bool RemoveInternamento(InternamentoHospital internamento, int idPaciente);

        /// <summary>
        /// Atualiza um internamento de um paciente.
        /// </summary>
        bool AtualizaInternamento(InternamentoHospital internamento, int idPaciente);
    }
}
