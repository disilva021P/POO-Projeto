/*
 * Nome: Funcionario.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe abstrata que representa um Funcionário que herda a classe Pessoa e é herdada por Medico,Enfermeiro,Auxiliar.
*/
namespace Bo
{
    /// <summary>
    /// Entidade base para funcionários do hospital
    /// </summary>
    public abstract class Funcionario : Pessoa
    {
        #region Atributos
        private int numFuncionario;
        private DateOnly dataContratacao;
        protected decimal salarioHora;
        protected string emailProfissional;
        protected string departamento;
        protected string cargo;
        protected string turno;
        protected bool ativo;
        #endregion

        #region Construtor
        public Funcionario()
        {
            numFuncionario = -1;
            dataContratacao = new DateOnly();
            salarioHora = 5.0M;
            emailProfissional = string.Empty;
            departamento = string.Empty;
            cargo = string.Empty;
            turno = string.Empty;
            ativo = false;
        }

        public Funcionario(int id,
                           string nome,
                           string sobrenome,
                           string nif,
                           string morada,
                           int telefone,
                           DateOnly dataNasc,
                           char genero,
                           int numFuncionario,
                           string cedulaProfissional,
                           DateOnly dataContratacao,
                           decimal salario,
                           string email,
                           string departamento,
                           string cargo,
                           string turno,
                           bool ativo = true)
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero)
        {
            this.numFuncionario = numFuncionario;
            this.dataContratacao = dataContratacao;
            this.salarioHora = salario;
            this.emailProfissional = email;
            this.departamento = departamento;
            this.cargo = cargo;
            this.turno = turno;
            this.ativo = ativo;
        }
        #endregion

        #region Propriedades
        public int NumFuncionario { get { return numFuncionario; } }
        public DateOnly DataContratacao { get { return dataContratacao; } set { dataContratacao = value; } }
        public decimal Salario { get { return salarioHora; } set { salarioHora = value; } }
        public string Email { get { return emailProfissional; } set { emailProfissional = value; } }
        public string Departamento { get { return departamento; } set { departamento = value; } }
        public string Cargo { get { return cargo; } set { cargo = value; } }
        public string Turno { get { return turno; } set { turno = value; } }
        public bool Ativo { get { return ativo; } set { ativo = value; } }
        #endregion

        #region Metodos

        /// <summary>
        /// Calcula o número de anos de serviço do funcionário.
        /// </summary>
        /// <returns>
        /// Número inteiro correspondente aos anos de serviço.
        /// </returns>
        public int ObterAnosServico()
        {
            return DateTime.Now.Year - dataContratacao.Year;
        }

        /// <summary>
        /// Aumenta o salário do funcionário com base numa percentagem.
        /// </summary>
        /// <param name="percentagem">Percentagem de aumento a aplicar.</param>
        /// <returns>
        /// Código de resultado da operação:
        /// 1 se o aumento for aplicado com sucesso;
        /// 201 se a percentagem for inválida.
        /// </returns>
        public int AumentarSalario(decimal percentagem)
        {
            if (percentagem <= 0)
            {
                return 201;
            }
            this.salarioHora *= (1 + percentagem);
            return 1;
        }

        /// <summary>
        /// Retorna o tipo de pessoa representado pela classe.
        /// </summary>
        /// <returns>
        /// String identificando o tipo como "Funcionário".
        /// </returns>
        public override string TipoPessoa()
        {
            return "Funcionário";
        }

        /// <summary>
        /// Retorna uma representação textual do funcionário.
        /// </summary>
        /// <returns>
        /// String formatada com informação do funcionário,
        /// incluindo dados pessoais, profissionais e anos de serviço.
        /// </returns>
        public override string ToString()
        {
            return $"Funcionario[numFuncionario={numFuncionario}, nome='{Nome} {Sobrenome}', " +
                   $"departamento='{departamento}', cargo='{cargo}', turno='{turno}', " +
                   $"salarioHora={salarioHora:F2}€, ativo={ativo}, anosServico={ObterAnosServico()}]";
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Compara dois funcionários para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">Funcionário à esquerda da comparação.</param>
        /// <param name="direita">Funcionário à direita da comparação.</param>
        /// <returns>
        /// True se ambos os funcionários tiverem o mesmo número de funcionário;
        /// caso contrário, false.
        /// </returns>
        public static bool operator ==(Funcionario esquerda, Funcionario direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.numFuncionario == direita.numFuncionario;
        }

        /// <summary>
        /// Compara dois funcionários para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">Funcionário à esquerda da comparação.</param>
        /// <param name="direita">Funcionário à direita da comparação.</param>
        /// <returns>
        /// True se os números de funcionário forem diferentes;
        /// caso contrário, false.
        /// </returns>
        public static bool operator !=(Funcionario esquerda, Funcionario direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.numFuncionario != direita.numFuncionario;
        }

        /// <summary>
        /// Determina se o objeto atual é igual a outro objeto.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// True se o objeto for do tipo Funcionario e tiver o mesmo número de funcionário;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is Funcionario)
            {
                return ((Funcionario)obj).numFuncionario == this.numFuncionario;
            }
            return false;
        }

        #endregion
    }
}
