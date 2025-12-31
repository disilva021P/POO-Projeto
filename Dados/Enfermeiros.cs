﻿/*
 * Nome: Enfermeiros.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Enfermeiros
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere a entidade Enfermeiro.
    /// </summary>
    public class Enfermeiros
    {
        List<Enfermeiro> enfermeiros;

        /// <summary>
        /// Construtor padrão que inicializa a lista de enfermeiros.
        /// </summary>
        public Enfermeiros()
        {
            this.enfermeiros = new List<Enfermeiro>();
        }

        /// <summary>
        /// Construtor que recebe uma lista de enfermeiros já existente.
        /// </summary>
        /// <param name="enfermeiros">Lista de enfermeiros a ser gerida.</param>
        public Enfermeiros(List<Enfermeiro> enfermeiros)
        {
            this.enfermeiros = enfermeiros;
        }

        /// <summary>
        /// Retorna uma cópia da lista de todos os enfermeiros.
        /// </summary>
        /// <returns>Lista contendo os objetos Enfermeiro.</returns>
        public List<Enfermeiro> ListaEnfermeiros()
        {
            return new List<Enfermeiro>(enfermeiros);
        }

        /// <summary>
        /// Verifica se um enfermeiro específico já existe na lista.
        /// </summary>
        /// <param name="auxiliar">O objeto Enfermeiro a verificar.</param>
        /// <returns>True se o enfermeiro existir, caso contrário False.</returns>
        public bool JaExiste(Enfermeiro auxiliar)
        {
            return enfermeiros.Contains(auxiliar);
        }

        /// <summary>
        /// Verifica se existe um enfermeiro com o ID fornecido.
        /// </summary>
        /// <param name="id">O identificador do enfermeiro.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return enfermeiros.Exists(x => x.Id == id);
        }

        /// <summary>
        /// Busca um enfermeiro pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do enfermeiro.</param>
        /// <returns>O objeto Enfermeiro se encontrado, ou null.</returns>
        public Enfermeiro? BuscarPorId(int id)
        {
            return enfermeiros.Find(x => x.Id == id);
        }

        /// <summary>
        /// Busca um enfermeiro pelo seu NIF.
        /// </summary>
        /// <param name="nif">Número de identificação fiscal.</param>
        /// <returns>O objeto Enfermeiro se encontrado, ou null.</returns>
        public Enfermeiro? EnfermeiroporNif(string nif)
        {
            return enfermeiros.FirstOrDefault(x => x.Nif == nif);
        }

        /// <summary>
        /// Busca um enfermeiro pelo número de funcionário.
        /// </summary>
        /// <param name="Nfuncionario">Número de funcionário.</param>
        /// <returns>O objeto Enfermeiro se encontrado, ou null.</returns>
        public Enfermeiro? EnfermeiroporNFuncionario(int Nfuncionario)
        {
            return enfermeiros.FirstOrDefault(x => x.NumFuncionario == Nfuncionario);
        }

        /// <summary>
        /// Insere um novo enfermeiro na lista, se não existir.
        /// </summary>
        /// <param name="auxiliar">O enfermeiro a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereEnfermeiro(Enfermeiro auxiliar)
        {
            if (enfermeiros.Contains(auxiliar)) return false;
            enfermeiros.Add(auxiliar);
            return true;
        }

        /// <summary>
        /// Remove um enfermeiro da lista.
        /// </summary>
        /// <param name="auxiliar">O enfermeiro a ser removido.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveEnfermeiro(Enfermeiro auxiliar)
        {
            return enfermeiros.Remove(auxiliar);
        }

        /// <summary>
        /// Remove um enfermeiro da lista pelo seu ID.
        /// </summary>
        /// <param name="id">Identificador do enfermeiro a remover.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveEnfermeiro(int id)
        {
            return enfermeiros.RemoveAll(x => x.Id == id) > 0;
        }

        /// <summary>
        /// Atualiza os dados de um enfermeiro existente identificado pelo NIF.
        /// </summary>
        /// <param name="nova_versao">Objeto com os novos dados do enfermeiro.</param>
        /// <returns>True se a atualização for bem-sucedida, False se o enfermeiro não for encontrado.</returns>
        public bool UpdateEnfermeiro(Enfermeiro nova_versao)
        {
            Enfermeiro? aux = EnfermeiroporNif(nova_versao.Nif);
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
            aux.Departamento = nova_versao.Departamento;
            aux.Categoria = nova_versao.Categoria;
            aux.ChefeEnfermagem = nova_versao.ChefeEnfermagem;
            return true;
        }
    }
}
