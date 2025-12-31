/*
 * Nome: Pessoa.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe abstrata que representa uma Pessoa e é herdada por Funcionario.
*/
namespace Bo
{
    /// <summary>
    /// Entidade base: abstrata para não ser criada exteriormente.
    /// Entidade base para todas as informações pessoais
    /// </summary>
    public abstract class Pessoa
    {
        #region Atributos
        private int id;
        protected String nome;
        protected String sobrenome;
        private String nif;
        protected String morada;
        protected int telefone;
        private DateOnly dataNascimento;
        private char genero;
        #endregion
        #region Construtores
        public Pessoa()
        {
            this.id = -1;
            this.nome = string.Empty;
            this.sobrenome = string.Empty;
            this.nif = string.Empty;
            this.morada = string.Empty;
            this.telefone = 0;
            this.dataNascimento = DateOnly.MinValue;
            this.genero = 'I';

        }
        public Pessoa(int id, String nome, String sobrenome, String nif, String morada, int telefone, DateOnly dataNasc, char genero)
        {
            this.id = id;
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.nif = nif;
            this.morada = morada;
            this.telefone = telefone;
            this.dataNascimento = dataNasc;
            this.genero = genero;
        }
        #endregion
        #region Propriedades
        public int Id { get { return id; } }
        public String Nome { get { return nome; } set { nome = value; } }
        public String Sobrenome { get { return sobrenome; } set { sobrenome = value; } }
        public String Nif { get { return nif; } }
        public String Morada { get { return morada; } set { morada = value; } }
        public int Telefone { get { return telefone; } set { telefone = value; } }
        public DateOnly DataNascimento { get { return dataNascimento; } set { dataNascimento = value; } }
        public char Genero { get { return genero; } }
        #endregion
        #region Metodos

        /// <summary>
        /// Retorna o nome completo da pessoa concatenando nome e sobrenome
        /// </summary>
        /// <returns>String com nome completo</returns>
        public String NomeCompleto()
        {
            return nome + sobrenome;
        }
        /// <summary>
        /// Calcula a idade da pessoa em anos completos com base na data de nascimento
        /// </summary>
        /// <returns>Idade em anos (inteiro)</returns>
        public int CalculaIdade()
        {
            DateOnly hoje = DateOnly.FromDateTime(DateTime.Today);
            int idade = hoje.Year - dataNascimento.Year;

            // Se ainda não fez anos este ano, subtrai 1
            if (hoje < dataNascimento.AddYears(idade))
            {
                idade--;
            }

            return idade;
        }
        /// <summary>
        /// Verifica se a pessoa é maior de idade (18 anos ou mais)
        /// </summary>
        /// <returns>True se idade maior ou igual a 18, False caso contrário</returns>
        public bool MaiorIdade()
        {
            return CalculaIdade() > 18;
        }
        /// <summary>
        /// Retorna a descrição textual do género da pessoa
        /// </summary>
        /// <returns>"Masculino" se M, "Feminino" se F, "Atributo Vazio" caso contrário</returns>
        public String GeneroExtenso()
        {
            return (Genero == 'M') ? "Masculino" : Genero == 'F' ? "Feminino" : "Atributo Vazio";
        }
        #endregion
        #region Overrides

        /// <summary>
        /// Função para passar classe para string
        /// </summary>
        /// <returns>String que devolve todas as informações</returns>


        public override string ToString()
        {
            return "Pessoa{" +
                    "id=" + id +
                    ", nome='" + nome + '\'' +
                    ", sobrenome='" + sobrenome + '\'' +
                    ", nif='" + nif + '\'' +
                    ", morada='" + morada + '\'' +
                    ", telefone=" + telefone +
                    ", dataNascimento=" + dataNascimento +
                    ", genero=" + genero +
                    '}';
        }
        /// <summary>
        /// Verifica se duas pessoas são iguais com base no NIF
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>True se os NIFs forem iguais, False caso contrário</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Pessoa) {  return ((Pessoa)obj).Nif==this.Nif; }
            return false;

        }
        #endregion
        #region Operadores
        /// <summary>
        /// Operador de igualdade que compara duas pessoas pelo ID
        /// </summary>
        /// <param name="esquerda">Primeira pessoa a comparar</param>
        /// <param name="direita">Segunda pessoa a comparar</param>
        /// <returns>True se os IDs forem iguais</returns>
        public static bool operator ==(Pessoa esquerda, Pessoa direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }
        /// <summary>
        /// Operador de desigualdade que compara duas pessoas pelo ID
        /// </summary>
        /// <param name="esquerda">Primeira pessoa a comparar</param>
        /// <param name="direita">Segunda pessoa a comparar</param>
        /// <returns>True se os IDs forem diferentes</returns>
        public static bool operator !=(Pessoa esquerda, Pessoa direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }
}
