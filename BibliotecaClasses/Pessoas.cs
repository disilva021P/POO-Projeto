/// <summary>
/// Autor: a31504 Diogo Silva
/// Data: 15/11/2025  
/// Nome: Pessoas.cs
/// Descrição: As classes neste ficheiro servem para guardar as informações pessoais
/// </summary>

using System;

namespace ProjetoPoon31504
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
        public Pessoa(int id, String nome, String sobrenome, String nif,String morada, int telefone, DateOnly dataNasc, char genero)
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
        public int Id { get { return id; } set { id = value; } }
        public String Nome { get { return nome; } set { nome = value; } }
        public String Sobrenome { get { return sobrenome; } set { sobrenome = value; } }
        public String Nif { get { return nif; } set { nif = value; } }
        public int Telefone { get { return telefone; } set { telefone = value; } }
        public DateOnly DataNascimento { get { return dataNascimento; } set { dataNascimento = value; } }
        public char Genero { get { return genero; } set { genero = value; } }
        #endregion
        #region Metodos

        public String NomeCompleto()
        {
            return nome + sobrenome;
        }
        public int calculaIdade()
        {
            return DateTime.Now.DayOfYear < this.dataNascimento.DayOfYear ? DateTime.Now.DayOfYear - this.dataNascimento.DayOfYear - 1 : DateTime.Now.DayOfYear - this.dataNascimento.DayOfYear;
        }
        public bool maiorIdade()
        {
            return calculaIdade()<18 ? false : true;
        }
        public static bool ValidarNIF(string nif)
        {
            return !string.IsNullOrEmpty(nif) && nif.Length == 9 && nif.All(char.IsDigit);
        }
        public String GeneroExtenso()
        {
            return (Genero == 'M') ? "Masculino" : "Feminino";
        }
        #endregion
        #region Overrides

        //para classes a herdar darem override
        public abstract string GetTipo();


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

        #endregion
        #region Operadores
        public static bool operator ==(Pessoa esquerda, Pessoa direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.Nif == direita.Nif;
        }
        public static bool operator !=(Pessoa esquerda, Pessoa direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.Nif != direita.Nif;
        }
        #endregion
    }
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
        public Funcionario(int id,
                           string nome,
                           string sobrenome,
                           string nif,
                           string morada,
                           int telefone,
                           DateOnly dataNasc,
                           char genero) : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero)
        {
            numFuncionario = -1;
            dataContratacao = new DateOnly();
            salarioHora = 10.2M;
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
        public int NumFuncionario { get { return numFuncionario; } set { numFuncionario = value; } }
        public DateOnly DataContratacao { get { return dataContratacao; } set { dataContratacao = value; } }
        public decimal Salario { get { return salarioHora; } set { salarioHora = value; } }
        public string Email { get { return emailProfissional; } set { emailProfissional = value; } }
        public string Departamento { get { return departamento; } set { departamento = value; } }
        public string Cargo { get { return cargo; } set { cargo = value; } }
        public string Turno { get { return turno; } set { turno = value; } }
        public bool Ativo { get { return ativo; } set { ativo = value; } }
        #endregion

        public override string GetTipo()
        {
            return "Funcionário";
        }
        #region Operadores
        public static bool operator ==(Funcionario esquerda, Funcionario direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.numFuncionario == direita.numFuncionario;
        }
        public static bool operator !=(Funcionario esquerda, Funcionario direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.numFuncionario != direita.numFuncionario;
        }
        #endregion
    }

    /// <summary>
    /// Entidade Paciente, para todos
    /// </summary>
    public class Paciente : Pessoa
    {
        #region Atributos
        private int numeroUtente;
        private bool internado;
        private string contactoEmergencia;
        private string alergias;
        //Inserir estrutura de dados para adicionar consultas que participou e internamentos
        #endregion

        #region Construtor
        public Paciente(int id,
                        string nome,
                        string sobrenome,
                        string nif,
                        string morada,
                        int telefone,
                        DateOnly dataNasc,
                        char genero,
                        int numeroUtente,
                        bool internado,
                        string contactoEmergencia,
                        string alergias)
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero)
        {
            this.numeroUtente = numeroUtente;
            this.internado = internado;
            this.contactoEmergencia = contactoEmergencia;
            this.alergias = alergias;
        }
        #endregion

        #region Propriedades
        public int NumeroUtente { get { return numeroUtente; } set { numeroUtente = value; } }
        public bool Internado { get { return internado; } set { internado = value; } }
        public string ContactoEmergencia { get { return contactoEmergencia; } set { contactoEmergencia = value; } }
        public string Alergias { get { return alergias; } set { alergias = value; } }
        #endregion

        public override string GetTipo()
        {
            return "Paciente";
        }

    }

    /// <summary>
    /// Classe Para criação de Médicos 
    /// 
    /// </summary>
    public class Medico : Funcionario
    {
        #region Atributos
        private string especialidade;
        private string numeroOrdem;
        private bool plantonista;
        private string gabinete;
        #endregion

        #region Construtor
        public Medico(int id,
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
                      bool ativo,
                      string especialidade,
                      string numeroOrdem,
                      bool plantonista = false,
                      string gabinete = "")
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero,
                   numFuncionario, cedulaProfissional, dataContratacao, salario, email, departamento, cargo, turno, ativo)
        {
            this.especialidade = especialidade;
            this.numeroOrdem = numeroOrdem;
            this.plantonista = plantonista;
            this.gabinete = gabinete;
        }
        #endregion

        #region Propriedades
        public string Especialidade { get { return especialidade; } set { especialidade = value; } }
        public string NumeroOrdem { get { return numeroOrdem; } set { numeroOrdem = value; } }
        public bool Plantonista { get { return plantonista; } set { plantonista = value; } }
        public string Gabinete { get { return gabinete; } set { gabinete = value; } }
        #endregion

        public override string GetTipo()
        {
            return "Médico";
        }
    }

    /// <summary>
    /// Classe Para criação de Enfermeiros através da classe base Funcionario
    /// 
    /// </summary>
    public class Enfermeiro : Funcionario
    {
        #region Atributos
        private string categoria;
        private string numeroRegistro;
        private bool chefeEnfermagem;
        #endregion

        #region Construtor
        public Enfermeiro(int id,
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
                          bool ativo,
                          string categoria,
                          string numeroRegistro,
                          bool chefeEnfermagem = false)
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero,
                   numFuncionario, cedulaProfissional, dataContratacao, salario, email, departamento, cargo, turno, ativo)
        {
            this.categoria = categoria;
            this.numeroRegistro = numeroRegistro;
            this.chefeEnfermagem = chefeEnfermagem;
        }
        #endregion

        #region Propriedades
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public string NumeroRegistro { get { return numeroRegistro; } set { numeroRegistro = value; } }
        public bool ChefeEnfermagem { get { return chefeEnfermagem; } set { chefeEnfermagem = value; } }
        #endregion

        public override string GetTipo()
        {
            return "Enfermeiro";
        }
    }


    /// <summary>
    /// Classe Para criação de Funcionários auxiliares (Ex: Funcionarias Limpeza, Departamento Informática... etc)
    /// através da classe base Funcionario
    /// </summary>
    public class Auxiliar : Funcionario
    {
        #region Atributos
        private string area;
        private string funcaoPrincipal;
         #endregion

        #region Construtor
        public Auxiliar(int id,
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
                        bool ativo,
                        string area,
                        string funcaoPrincipal,
                        bool formacaoBasica = false)
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero,
                   numFuncionario, cedulaProfissional, dataContratacao, salario, email, departamento, cargo, turno, ativo)
        {
            this.area = area;
            this.funcaoPrincipal = funcaoPrincipal;
        }
        #endregion

        #region Propriedades
        public string Area { get { return area; } set { area = value; } }
        public string FuncaoPrincipal { get { return funcaoPrincipal; } set { funcaoPrincipal = value; } }
        #endregion

        public override string GetTipo()
        {
            return "Auxiliar";
        }
    }
}
