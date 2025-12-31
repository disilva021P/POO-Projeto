﻿/*
 * Nome: Pacientes.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Pacientes
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere classe Paciente
    /// </summary>
    public class Pacientes
    {
        List<Paciente> pacientes;

        /// <summary>
        /// Construtor padrão que inicializa a lista de pacientes.
        /// </summary>
        public Pacientes()
        {
            this.pacientes = new List<Paciente>();
        }

        /// <summary>
        /// Construtor que recebe uma lista de pacientes já existente.
        /// </summary>
        /// <param name="pacientes">Lista de pacientes a ser gerida.</param>
        public Pacientes(List<Paciente> pacientes)
        {
            this.pacientes = pacientes;
        }

        /// <summary>
        /// Retorna uma cópia da lista de todos os pacientes.
        /// </summary>
        /// <returns>Uma lista contendo os objetos Paciente.</returns>
        public List<Paciente> ListaPacientes()
        {
            return new List<Paciente>(pacientes);
        }

        /// <summary>
        /// Verifica se um paciente específico já existe na lista.
        /// </summary>
        /// <param name="paciente">O objeto Paciente a verificar.</param>
        /// <returns>True se o paciente existir, caso contrário False.</returns>
        public bool JaExiste(Paciente paciente)
        {
            return pacientes.Contains(paciente);
        }

        /// <summary>
        /// Verifica se existe um paciente com o ID fornecido.
        /// </summary>
        /// <param name="id">O identificador do paciente.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return pacientes.Exists(x=>x.Id==id);
        }

        /// <summary>
        /// Busca um paciente pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do paciente.</param>
        /// <returns>O objeto Paciente se encontrado, ou null.</returns>
        public Paciente? PacienteporId(int id)
        {
            return pacientes.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Busca um paciente pelo seu NIF.
        /// </summary>
        /// <param name="nif">O número de identificação fiscal.</param>
        /// <returns>O objeto Paciente se encontrado, ou null.</returns>
        public Paciente? PacienteporNif(string nif)
        {
            return pacientes.FirstOrDefault(x => x.Nif == nif);
        }

        /// <summary>
        /// Insere um novo paciente na lista, se não existir.
        /// </summary>
        /// <param name="paciente">O paciente a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InserePaciente(Paciente paciente)
        {
            if (pacientes.Contains(paciente)) return false;
            pacientes.Add(paciente);
            return true;
        }

        /// <summary>
        /// Remove um paciente da lista.
        /// </summary>
        /// <param name="paciente">O paciente a ser removido.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemovePaciente(Paciente paciente)
        {
            return pacientes.Remove(paciente);
        }

        /// <summary>
        /// Remove um paciente da lista pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador do paciente a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemovePaciente(int id)
        {
            return pacientes.RemoveAll(x=>x.Id==id)>0;
        }

        /// <summary>
        /// Remove um paciente da lista pelo seu NIF.
        /// </summary>
        /// <param name="nif">O NIF do paciente a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemovePacientePorNif(string nif)
        {
            return pacientes.Remove(PacienteporNif(nif));
        }

        /// <summary>
        /// Atualiza os dados de um paciente existente.
        /// </summary>
        /// <param name="nova_versao">Objeto com os novos dados do paciente (identificado pelo NIF).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o paciente não for encontrado.</returns>
        public bool UpdatePaciente(Paciente nova_versao)
        {
            Paciente? aux = PacienteporNif(nova_versao.Nif);
            if (aux is null) { return false; }
            aux.Nome = nova_versao.Nome;
            aux.Sobrenome = nova_versao.Sobrenome;
            aux.Morada = nova_versao.Morada;
            aux.Telefone = nova_versao.Telefone;
            aux.DataNascimento = nova_versao.DataNascimento;
            aux.Internado = nova_versao.Internado;
            aux.ContactoEmergencia = nova_versao.ContactoEmergencia;
            aux.Alergias = nova_versao.Alergias;
            return true;
        }
    }
}
