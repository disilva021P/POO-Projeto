/*
 * Nome: Auxiliares.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata da parte de gerir Auxiliares
*/
using Bo;
namespace Dados
{
    /// <summary>
    /// Classe de Dados que gere classe Auxiliar
    /// </summary>
    public class Auxiliares
    {
        List<Auxiliar> auxiliares;

        /// <summary>
        /// Construtor padrão que inicializa a lista de auxiliares.
        /// </summary>
        public Auxiliares()
        {
            this.auxiliares = new List<Auxiliar>();
        }

        /// <summary>
        /// Construtor que recebe uma lista de auxiliares já existente.
        /// </summary>
        /// <param name="auxiliares">Lista de auxiliares a ser gerida.</param>
        public Auxiliares(List<Auxiliar> auxiliares)
        {
            this.auxiliares = auxiliares;
        }

        /// <summary>
        /// Retorna uma cópia da lista de todos os auxiliares.
        /// </summary>
        /// <returns>Uma lista contendo os objetos Auxiliar.</returns>
        public List<Auxiliar> ListaAuxiliares()
        {
            return new List<Auxiliar>(auxiliares);
        }

        /// <summary>
        /// Verifica se um auxiliar específico já existe na lista.
        /// </summary>
        /// <param name="auxiliar">O objeto Auxiliar a verificar.</param>
        /// <returns>True se o auxiliar existir, caso contrário False.</returns>
        public bool JaExiste(Auxiliar auxiliar)
        {
            return auxiliares.Contains(auxiliar);
        }

        /// <summary>
        /// Verifica se existe um auxiliar com o ID fornecido.
        /// </summary>
        /// <param name="id">O identificador do auxiliar.</param>
        /// <returns>True se existir, caso contrário False.</returns>
        public bool JaExiste(int id)
        {
            return auxiliares.Exists(x=>x.Id==id);
        }

        /// <summary>
        /// Busca um auxiliar pelo seu NIF.
        /// </summary>
        /// <param name="nif">O número de identificação fiscal.</param>
        /// <returns>O objeto Auxiliar se encontrado, ou null.</returns>
        public Auxiliar? AuxiliarporNif(string nif)
        {
            return auxiliares.FirstOrDefault(x=>x.Nif == nif);
        }

        /// <summary>
        /// Busca um auxiliar pelo número de funcionário.
        /// </summary>
        /// <param name="Nfuncionario">O número de funcionário.</param>
        /// <returns>O objeto Auxiliar se encontrado, ou null.</returns>
        public Auxiliar? AuxiliarporNFuncionario(int Nfuncionario)
        {
            return auxiliares.FirstOrDefault(x => x.NumFuncionario == Nfuncionario);
        }

        /// <summary>
        /// Busca um auxiliar pelo seu ID.
        /// </summary>
        /// <param name="id">O identificador único do auxiliar.</param>
        /// <returns>O objeto Auxiliar se encontrado, ou null.</returns>
        public Auxiliar? BuscarPorId(int id)
        {
            return auxiliares.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insere um novo auxiliar na lista, se não existir.
        /// </summary>
        /// <param name="auxiliar">O auxiliar a ser inserido.</param>
        /// <returns>True se inserido com sucesso, False se já existir.</returns>
        public bool InsereAuxiliar(Auxiliar auxiliar)
        {
            if(auxiliares.Contains(auxiliar)) return false;
            auxiliares.Add(auxiliar);
            return true;
        }

        /// <summary>
        /// Remove um auxiliar da lista.
        /// </summary>
        /// <param name="auxiliar">O auxiliar a ser removido.</param>
        /// <returns>True se removido com sucesso, False caso contrário.</returns>
        public bool RemoveAuxiliar(Auxiliar auxiliar)
        {
            return auxiliares.Remove(auxiliar);
        }

        /// <summary>
        /// Atualiza os dados de um auxiliar existente.
        /// </summary>
        /// <param name="nova_versao">Objeto com os novos dados do auxiliar (identificado pelo NIF).</param>
        /// <returns>True se a atualização for bem-sucedida, False se o auxiliar não for encontrado.</returns>
        public bool UpdateAuxiliar(Auxiliar nova_versao)
        {
            Auxiliar? aux = AuxiliarporNif(nova_versao.Nif);
            if (aux is null) { return false; }
            aux.Nome=nova_versao.Nome;
            aux.Sobrenome=nova_versao.Sobrenome;
            aux.Morada=nova_versao.Morada;
            aux.Telefone=nova_versao.Telefone;
            aux.DataNascimento=nova_versao.DataNascimento;
            aux.Salario=nova_versao.Salario;
            aux.Email=nova_versao.Email;
            aux.Cargo=nova_versao.Cargo;
            aux.Turno=nova_versao.Turno;
            aux.Ativo=nova_versao.Ativo;
            aux.Departamento = nova_versao.Departamento;
            aux.Area=nova_versao.Area;
            aux.FuncaoPrincipal=nova_versao.FuncaoPrincipal;
            return true;
        }
    }
}
