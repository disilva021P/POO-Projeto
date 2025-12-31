/*
 * Nome: AuxiliarRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Auxiliar 
*/
using Bo;
using Dados;
using Exceptions;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Auxiliar
    /// </summary>
    public class AuxiliarRegras : ICrud<Auxiliar,int>
    {
        private Auxiliares dados;

        public AuxiliarRegras()
        {
            dados = new Auxiliares();
        }

        public AuxiliarRegras(Auxiliares dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os auxiliares existentes
        /// </summary>
        /// <returns>Lista de objetos Auxiliar</returns>
        public List<Auxiliar> Listar()
        {
            return dados.ListaAuxiliares();
        }

        /// <summary>
        /// Valida os dados de um auxiliar
        /// </summary>
        /// <param name="aux">Auxiliar a validar</param>
        public static void Validar(Auxiliar aux)
        {
            if (aux is null)
                throw new ArgumentNullException(nameof(aux));

            if (aux.Id <= 0)
                throw new ArgumentException("ID deve ser um número positivo.", nameof(aux.Id));

            if (string.IsNullOrWhiteSpace(aux.Nome))
                throw new ArgumentException("Nome é obrigatório.", nameof(aux.Nome));

            if (string.IsNullOrWhiteSpace(aux.Sobrenome))
                throw new ArgumentException("Sobrenome é obrigatório.", nameof(aux.Sobrenome));

            Validacoes.NifValido(aux.Nif);

            if (string.IsNullOrWhiteSpace(aux.Morada))
                throw new ArgumentException("Morada é obrigatória.", nameof(aux.Morada));

            if (aux.Telefone.ToString().Length < 9)
                throw new ArgumentException("Telefone deve ter pelo menos 9 dígitos.", nameof(aux.Telefone));

            if (aux.DataNascimento >= DateOnly.FromDateTime(DateTime.Today))
                throw new ArgumentException("Data de nascimento deve ser no passado.", nameof(aux.DataNascimento));

            if (aux.Genero != 'M' && aux.Genero != 'F')
                throw new ArgumentException("Género deve ser 'M' ou 'F'.", nameof(aux.Genero));

            if (aux.NumFuncionario <= 0)
                throw new ArgumentException("Número de funcionário deve ser positivo.", nameof(aux.NumFuncionario));

            if (aux.DataContratacao >= DateOnly.FromDateTime(DateTime.Today))
                throw new ArgumentException("Data de contratação deve ser no passado.", nameof(aux.DataContratacao));

            if (aux.Salario <= 0)
                throw new ArgumentException("Salário deve ser maior que zero.", nameof(aux.Salario));

            Validacoes.EmailValido(aux.Email);

            if (string.IsNullOrWhiteSpace(aux.Departamento))
                throw new ArgumentException("Departamento é obrigatório.", nameof(aux.Departamento));

            if (string.IsNullOrWhiteSpace(aux.Cargo))
                throw new ArgumentException("Cargo é obrigatório.", nameof(aux.Cargo));

            if (string.IsNullOrWhiteSpace(aux.Turno))
                throw new ArgumentException("Turno é obrigatório.", nameof(aux.Turno));

            if (string.IsNullOrWhiteSpace(aux.Area))
                throw new ArgumentException("Área é obrigatória.", nameof(aux.Area));

            if (string.IsNullOrWhiteSpace(aux.FuncaoPrincipal))
                throw new ArgumentException("Função principal é obrigatória.", nameof(aux.FuncaoPrincipal));
        }

        /// <summary>
        /// Verifica se um auxiliar já existe
        /// </summary>
        /// <param name="auxiliar">Auxiliar a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Auxiliar auxiliar)
        {
            ArgumentNullException.ThrowIfNull(auxiliar);
            Validacoes.NifValido(auxiliar.Nif);
            return dados.JaExiste(auxiliar); 
        }

        /// <summary>
        /// Verifica se existe um auxiliar com o ID indicado
        /// </summary>
        /// <param name="id">Identificador do auxiliar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) { throw new ArgumentException("Id inválido"); }
            return dados.JaExiste(id);  
        }

        /// <summary>
        /// Verifica se existe um auxiliar com determinado NIF
        /// </summary>
        /// <param name="nif">NIF a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExisteNif(string nif)
        {
            Validacoes.NifValido(nif);
            Auxiliar? aux = AuxiliarporNif(nif);
            return aux is not null && JaExiste(aux);
        }

        /// <summary>
        /// Procura um auxiliar pelo NIF
        /// </summary>
        /// <param name="nif">NIF do auxiliar</param>
        /// <returns>Objeto Auxiliar se encontrado, ou null</returns>
        public Auxiliar? AuxiliarporNif(string nif)
        {
            Validacoes.NifValido(nif);
            return dados.AuxiliarporNif(nif);
        }

        /// <summary>
        /// Procura um auxiliar pelo número de funcionário
        /// </summary>
        /// <param name="Nfuncionario">Número de funcionário</param>
        /// <returns>Objeto Auxiliar se encontrado, ou null</returns>
        public Auxiliar? AuxiliarporNFuncionario(int Nfuncionario)
        {
            if (Nfuncionario < 0) { throw new ArgumentException("Nº de Funcionário inválido"); }
            return dados.AuxiliarporNFuncionario(Nfuncionario);
        }

        /// <summary>
        /// Procura um auxiliar pelo seu ID
        /// </summary>
        /// <param name="id">ID do auxiliar</param>
        /// <returns>Objeto Auxiliar se encontrado, ou null</returns>
        public Auxiliar? BuscarPorId(int id)
        {
            if (id < 0) { throw new ArgumentException("Id inválido"); }
            return dados.BuscarPorId(id);
        }

        /// <summary>
        /// Insere um novo auxiliar
        /// </summary>
        /// <param name="auxiliar">Auxiliar a inserir</param>
        /// <returns>True se inserido com sucesso, lança exceção se já existir</returns>
        public bool Inserir(Auxiliar auxiliar)
        {
            ArgumentNullException.ThrowIfNull(auxiliar);
            Validacoes.NifValido(auxiliar.Nif);
            if (this.JaExiste(auxiliar)) throw new EntidadeDuplicadaException("Auxiliar", "Nif", auxiliar.Nif);
            Validar(auxiliar);
            return dados.InsereAuxiliar(auxiliar);
        }

        /// <summary>
        /// Remove um auxiliar existente
        /// </summary>
        /// <param name="auxiliar">Auxiliar a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(Auxiliar auxiliar)
        {
            ArgumentNullException.ThrowIfNull(auxiliar); 
            Validacoes.NifValido(auxiliar.Nif);
            if (!this.JaExiste(auxiliar)) return false;
            return dados.RemoveAuxiliar(auxiliar);
        }

        /// <summary>
        /// Remove um auxiliar pelo ID
        /// </summary>
        /// <param name="id">ID do auxiliar</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) { throw new ArgumentException("Id inválido"); }
            Auxiliar? aux = BuscarPorId(id);
            if (aux is null) return false;
            return dados.RemoveAuxiliar(aux);
        }

        /// <summary>
        /// Remove um auxiliar pelo NIF
        /// </summary>
        /// <param name="nif">NIF do auxiliar</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool RemoveAuxiliarNif(string nif)
        {
            Validacoes.NifValido(nif);
            Auxiliar? aux = AuxiliarporNif(nif);
            if (aux is null) return false;
            return dados.RemoveAuxiliar(aux);
        }

        /// <summary>
        /// Remove um auxiliar pelo número de funcionário
        /// </summary>
        /// <param name="nfuncionario">Número do funcionário</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool RemoveAuxiliarNFuncionario(int nfuncionario)
        {
            if (nfuncionario < 0) { throw new ArgumentException("Nº Funcionario inválido"); }
            Auxiliar? aux = AuxiliarporNFuncionario(nfuncionario);
            if (aux is null) return false;
            return dados.RemoveAuxiliar(aux);
        }
        
        /// <summary>
        /// Atualiza os dados de um auxiliar existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do auxiliar</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(Auxiliar nova_versao)
        {
            ArgumentNullException.ThrowIfNull(nova_versao);
            Validacoes.NifValido(nova_versao.Nif);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateAuxiliar(nova_versao);
        }
    }
}



