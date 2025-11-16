/// <summary>
/// Autor: a31504 Diogo Silva
/// Data: 15/11/2025  
/// Nome: Pessoas.cs
/// Descrição: As classes neste ficheiro servem para guardar as informações pessoais
/// </summary>

using BibliotecaClasses;
using System;
using System.Collections.Immutable;

namespace BibliotecaClasses
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
            this.nome= string.Empty;
            this.sobrenome= string.Empty;
            this.nif= string.Empty;
            this.morada= string.Empty;
            this.telefone= 0;
            this.dataNascimento= DateOnly.MinValue;
            this.genero= 'I';

        }
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
            return (Genero == 'M') ? "Masculino" : Genero=='F' ? "Feminino" : "Atributo Vazio";
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
        public int NumFuncionario { get { return numFuncionario; } set { numFuncionario = value; } }
        public DateOnly DataContratacao { get { return dataContratacao; } set { dataContratacao = value; } }
        public decimal Salario { get { return salarioHora; } set { salarioHora = value; } }
        public string Email { get { return emailProfissional; } set { emailProfissional = value; } }
        public string Departamento { get { return departamento; } set { departamento = value; } }
        public string Cargo { get { return cargo; } set { cargo = value; } }
        public string Turno { get { return turno; } set { turno = value; } }
        public bool Ativo { get { return ativo; } set { ativo = value; } }
        #endregion
        #region Metodos
        public int ObterAnosServico()
        {
            return DateTime.Now.Year - dataContratacao.Year;
        }
        //o inteiro que devolve é o código de erro
        public int AumentarSalario(decimal percentagem)
        {
            if (percentagem <= 0) 
            {
                return 201;
            }
            this.salarioHora *= (1+percentagem);
            return 1;
        }
        public override string GetTipo()
        {
            return "Funcionário";
        }
        public override string ToString()
        {
            return $"Funcionario[numFuncionario={numFuncionario}, nome='{Nome} {Sobrenome}', " +
                   $"departamento='{departamento}', cargo='{cargo}', turno='{turno}', " +
                   $"salarioHora={salarioHora:F2}€, ativo={ativo}, anosServico={ObterAnosServico()}]";
        }
        #endregion

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
        private string alergias; //alterar para uma estrutura de dados com classe alergia
        //Inserir estrutura de dados para adicionar consultas que participou e internamentos
        #endregion

        #region Construtor
        public Paciente()
        {
            numeroUtente = -1;
            internado = false;
            contactoEmergencia = string.Empty;
            alergias = string.Empty;
        }
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
        /// <summary>
        /// Função para adicionar alergias ao paciente
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>

        public int AdicionarAlergia(string alergia)
        {
            if (alergia.Equals(string.Empty))
            {
                return 5;
            }
            this.alergias += (";" +alergia);
            return 1;
            
        }
        /// <summary>
        /// Função para remover  alergias ao paciente
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverAlergia(string alergia)
        {
            if (this.alergias.Contains(alergia))
            {
                this.alergias = this.alergias.Replace(alergia + ";", "")
                .Replace(";" + alergia, "")
                .Replace(alergia, "");
                return 1;
            }
            return 5;
        }
        /// <summary>
        /// Função para obter a útima consulta que um paciente participou
        /// </summary>
        /// <returns>Consulta</returns>
        public Consulta ObterUltimaConsulta()
        {
            //Falta adicionar estutura de dados e completar
            return new Consulta();
        }
        /// <summary>
        /// Função para retornar se um paciente pode receber alta ou não
        /// </summary>
        /// <returns>true se está apto</returns>
        public bool AptoAAlta()
        {
            //Falta adicionar estutura de dados internamentos
            return true;
        }
        /// <summary>
        /// Função para dar alta ao paciente
        /// </summary>
        /// <returns>true se está apto</returns>
        public int DarAlta()
        {
            if(this.AptoAAlta()) { return 0; }
            //Falta adicionar estutura de dados internamentos
            
            return 1;
        }

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
        private bool fazUrgencias;
        private string gabinete;
        //Falta adicionar estrutura Consultas
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
            this.fazUrgencias = plantonista;
            this.gabinete = gabinete;
        }
        #endregion

        #region Propriedades
        public string Especialidade { get { return especialidade; } set { especialidade = value; } }
        public string NumeroOrdem { get { return numeroOrdem; } set { numeroOrdem = value; } }
        public bool Plantonista { get { return fazUrgencias; } set { fazUrgencias = value; } }
        public string Gabinete { get { return gabinete; } set { gabinete = value; } }
        #endregion
        /// <summary>
        /// Verfica se o médico está disponivel a uma certa hora num certo dia
        /// </summary>
        /// <param name="diaHora"></param>
        /// <returns>true se desponível</returns>
        public bool EstaDisponivel(DateTime diaHora)
        {
            //Falta adicionar estrutura de dados 
            return false; 
        }
        /// <summary>
        /// Verfica os pacientes que vai ter num certo dia
        /// </summary>
        /// <param name="dia"></param>
        /// <returns>Estrutura de dados de Paciente se houver</returns>
        public Paciente ObterPacientesDoDia(DateOnly dia)
        {
            //Falta adicionar Estrutura de dados 
            return new Paciente();
        }
        /// <summary>
        /// Função para adicionar especialidades ao médico
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int AdicionarEspecialidade(string esp)
        {
            if (esp.Equals(string.Empty))
            {
                return 5;
            }
            this.especialidade += (";" + esp);
            return 1;
        }
        /// <summary>
        /// Função para ver as coonsultas que o médico fez ao longo da sua carreira no hospital
        /// </summary>
        /// <returns>Lista das consultas que o medico fez</returns>
        public Consulta ConsultasMedico()
        {
            //falta adicionar estrutura
            return new Consulta();
        }
        /// <summary>
        /// Função para adicionar uma consulta á agenda do médico
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int AdicionarCuidadosEnfermeiro(Consulta consulta)
        {
            //falta adicionar estrutura
            return 1;
        }
        /// <summary>
        /// Função para remover uma consulta da agenda do médico
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverCuidadosEnfermeiro(EnfermagemCuidados observacoes)
        {
            //falta adicionar estrutura
            return 1;
        }
        /// <summary>
        /// Função para remover uma consulta da agenda do médico através do id da consulta
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverCuidadosEnfermeiro(int idConsulta)
        {
            //falta adicionar estrutura
            return 1;
        }
        public override string GetTipo()
        {
            return "Médico";
        }
        public override string ToString()
        {
            return $"Medico[especialidade='{especialidade}', numeroOrdem='{numeroOrdem}', " +
                   $"gabinete='{gabinete}', fazUrgencias={fazUrgencias}, {base.ToString().Replace("Funcionario", "")}]";
        }
    }

    /// <summary>
    /// Classe Para criação de Enfermeiros através da classe base Funcionario
    /// 
    /// </summary>
    public class Enfermeiro : Funcionario
    {
        #region Atributos
        private string categoria;//saude,reabilitação, etc
        private bool chefeEnfermagem;
        //Adicionar estrutura de EnfermagemCuidados
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
                          bool chefeEnfermagem = false)
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero,
                   numFuncionario, cedulaProfissional, dataContratacao, salario, email, departamento, cargo, turno, ativo)
        {
            this.categoria = categoria;
            this.chefeEnfermagem = chefeEnfermagem;
        }
        #endregion

        #region Propriedades
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public bool ChefeEnfermagem { get { return chefeEnfermagem; } set { chefeEnfermagem = value; } }
        #endregion

        /// <summary>
        /// Verifica se o Enfermeiro pode ser chefe da sua especialidade
        /// </summary>
        /// <param name="especialidade"></param>
        /// <return>true se cumpre requesitos</returns>
        public bool PodeSerChefe(string especialidade)
        {
            if(this.ObterAnosServico()>5 && this.categoria == especialidade) return true;
            return false;
        }
        /// <summary>
        /// Função para ver os cuidados que o enfermeiro fez ao longo da sua carreira no hospital
        /// </summary>
        /// <returns>Devolve observacoes que o enfermeiro fez</returns>
        public EnfermagemCuidados CuidadosEnfermeiro()
        {
            //falta adicionar estrutura
            return new EnfermagemCuidados();
        }
        /// <summary>
        /// Função para adicionar observacoes de cuidados que o enfermeiro fez 
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int AdicionarCuidadosEnfermeiro(EnfermagemCuidados observacoes)
        {
            //falta adicionar estrutura
            return 1;
        }
        /// <summary>
        /// Função para remover observacoes de cuidados que o enfermeiro fez 
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverCuidadosEnfermeiro(EnfermagemCuidados observacoes)
        {
            //falta adicionar estrutura
            return 1;
        }
        /// <summary>
        /// Função para remover observacoes de cuidados que o enfermeiro fez com o id da observacao
        /// </summary>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverCuidadosEnfermeiro(int idObservação)
        {
            //falta adicionar estrutura
            return 1;
        }
        public override string GetTipo()
        {
            return "Enfermeiro";
        }
        public override string ToString()
        {
            return $"Enfermeiro[categoria='{categoria}', chefeEnfermagem={chefeEnfermagem}, {base.ToString().Replace("Funcionario", "")}]";
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
        public override string ToString()
{
    return $"Auxiliar[area='{area}', funcaoPrincipal='{funcaoPrincipal}', {base.ToString().Replace("Funcionario", "")}]";
}
    }
}
