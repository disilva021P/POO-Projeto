/*
 * Nome: Medico.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Medico que herda a classe Funcionario
*/

namespace Bo
{
    /// <summary>
    /// Classe Para criação de Médicos 
    /// </summary>
    [Serializable]
    public class Medico : Funcionario
    {
        #region Atributos
        private string especialidade;
        private string numeroOrdem;
        private bool fazUrgencias;
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
            this.fazUrgencias = plantonista;
            this.gabinete = gabinete;
        }
        #endregion

        #region Propriedades
        public string Especialidade { get { return especialidade; } set { especialidade = value; } }
        public string NumeroOrdem { get { return numeroOrdem; } set { numeroOrdem = value; } }
        public bool FazUrgencias { get { return fazUrgencias; } set { fazUrgencias = value; } }
        public string Gabinete { get { return gabinete; } set { gabinete = value; } }
        #endregion

        /// <summary>
        /// Adiciona uma nova especialidade ao médico.
        /// </summary>
        /// <param name="esp">Especialidade a adicionar.</param>
        /// <returns>
        /// Código de resultado da operação:
        /// 1 se a especialidade for adicionada com sucesso;
        /// 5 se a especialidade for inválida.
        /// </returns>
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
        /// Retorna o tipo de pessoa representado pela classe.
        /// </summary>
        /// <returns>
        /// String identificando o tipo como "Médico".
        /// </returns>
        public override string TipoPessoa()
        {
            return "Médico";
        }

        /// <summary>
        /// Retorna uma representação textual do médico.
        /// </summary>
        /// <returns>
        /// String formatada com informação do médico,
        /// incluindo especialidade, número da ordem e dados profissionais.
        /// </returns>
        public override string ToString()
        {
            return $"Medico[especialidade='{especialidade}', numeroOrdem='{numeroOrdem}', " +
                   $"gabinete='{gabinete}', fazUrgencias={fazUrgencias}, {base.ToString().Replace("Funcionario", "")}]";
        }
    }
}
