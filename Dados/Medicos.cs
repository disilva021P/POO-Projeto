﻿/*
 * Nome: Medicos.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Medicos
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere classe MedicoBD
    /// </summary>
    public class Medicos
    {
        List<Medico> medicos;

        /// <summary>
        /// Construtor padrão que inicializa a lista de médicos.
        /// </summary>
        public Medicos()
        {
            this.medicos = new List<Medico>();
        }

        /// <summary>
        /// Construtor que recebe uma lista de médicos já existente.
        /// </summary>
        /// <param name="auxiliares">Lista de médicos a ser gerida.</param>
        public Medicos(List<Medico> auxiliares)
        {
            this.medicos = auxiliares;
        }

        /// <summary>
        /// Retorna uma cópia da lista de todos os médicos.
        /// </summary>
        /// <returns>Uma lista contendo os objetos Medico.</returns>
        public List<Medico> ListaMedicos()
        {
            return new List<Medico>(medicos);
        }

        /// <summary>
        /// Verifica se um médico específico já existe na lista.
        /// </summary>
        /// <param name="medico">O objeto Medico a verificar.</param>
        /// <returns>True se o médico existir, caso contrário False.</returns>
        public bool JaExiste(Medico medico)
        {
            return medicos.Contains(medico);
        }

        /// <summary>
        /// Verifica se existe um médico com o ID fornecido.
        /// </summary>
        /// <param name="id">O identificador do médico.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return medicos.Exists(x=>x.Id==id);
        }

        /// <summary>
        /// Busca um médico pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do médico.</param>
        /// <returns>O objeto Medico se encontrado, ou null.</returns>
        public Medico? MedicoporId(int id)
        {
            return medicos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Busca um médico pelo seu NIF.
        /// </summary>
        /// <param name="nif">O número de identificação fiscal.</param>
        /// <returns>O objeto Medico se encontrado, ou null.</returns>
        public Medico? MedicoporNif(string nif)
        {
            return medicos.FirstOrDefault(x => x.Nif == nif);
        }

        /// <summary>
        /// Busca um médico pelo número de funcionário.
        /// </summary>
        /// <param name="Nfuncionario">O número de funcionário.</param>
        /// <returns>O objeto Medico se encontrado, ou null.</returns>
        public Medico? MedicoporNFuncionario(int Nfuncionario)
        {
            return medicos.FirstOrDefault(x => x.NumFuncionario == Nfuncionario);
        }

        /// <summary>
        /// Insere um novo médico na lista, se não existir.
        /// </summary>
        /// <param name="medico">O médico a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereMedico(Medico medico)
        {
            if (medicos.Contains(medico)) return false;
            medicos.Add(medico);
            return true;
        }

        /// <summary>
        /// Remove um médico da lista.
        /// </summary>
        /// <param name="medico">O médico a ser removido.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveMedico(Medico medico)
        {
            return medicos.Remove(medico);
        }

        /// <summary>
        /// Remove um médico da lista pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador do médico a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveMedico(int id)
        {
            return medicos.RemoveAll(x=>x.Id==id)>0;
        }

        /// <summary>
        /// Atualiza os dados de um médico existente.
        /// </summary>
        /// <param name="nova_versao">Objeto com os novos dados do médico (identificado pelo NIF).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o médico não for encontrado.</returns>
        public bool UpdateMedico(Medico nova_versao)
        {
            Medico? aux = MedicoporNif(nova_versao.Nif);
            if (aux is null) { return false; }
            aux.Nome = nova_versao.Nome;
            aux.Sobrenome = nova_versao.Sobrenome;
            aux.Morada = nova_versao.Morada;
            aux.Telefone = nova_versao.Telefone;
            aux.DataNascimento = nova_versao.DataNascimento;
            aux.Salario = nova_versao.Salario;
            aux.Email = nova_versao.Email;
            aux.Cargo = nova_versao.Cargo;
            aux.Turno = nova_versao.Turno;
            aux.Ativo = nova_versao.Ativo;
            aux.NumeroOrdem = nova_versao.NumeroOrdem;
            aux.Departamento = nova_versao.Departamento;
            aux.Especialidade = nova_versao.Especialidade;
            aux.Gabinete= nova_versao.Gabinete;
            aux.FazUrgencias = nova_versao.FazUrgencias;
            return true;
        }
    }
}
