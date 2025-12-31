/*
 * Nome: Enfermeiro.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Enfermeiro que herda a classe Funcionario
*/

namespace Bo
{
    /// <summary>
    /// Classe Para criação de Enfermeiros através da classe base Funcionario
    /// </summary>
    [Serializable]
    public class Enfermeiro : Funcionario
    {
        #region Atributos
        private string categoria;//saude,reabilitação, etc
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
        /// Verifica se o enfermeiro cumpre os requisitos para ser chefe de uma determinada especialidade.
        /// </summary>
        /// <param name="especialidade">Especialidade a avaliar.</param>
        /// <returns>
        /// True se o enfermeiro tiver mais de cinco anos de serviço
        /// e pertencer à especialidade indicada; caso contrário, false.
        /// </returns>
        public bool PodeSerChefe(string especialidade)
        {
            if (this.ObterAnosServico() > 5 && this.categoria == especialidade)
                return true;

            return false;
        }

        /// <summary>
        /// Retorna o tipo de pessoa representado pela classe.
        /// </summary>
        /// <returns>
        /// String identificando o tipo como "Enfermeiro".
        /// </returns>
        public override string TipoPessoa()
        {
            return "Enfermeiro";
        }

        /// <summary>
        /// Retorna uma representação textual do enfermeiro.
        /// </summary>
        /// <returns>
        /// String formatada com os dados do enfermeiro,
        /// incluindo informação herdada da classe Funcionario.
        /// </returns>
        public override string ToString()
        {
            return $"Enfermeiro[categoria='{categoria}', chefeEnfermagem={chefeEnfermagem}, {base.ToString().Replace("Funcionario", "")}]";
        }
    }
}
