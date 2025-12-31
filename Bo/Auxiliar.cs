/*
 * Nome: Auxiliar.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Auxiliar que herda a classe Funcionario
*/

namespace Bo
{
    /// <summary>
    /// Classe Para criação de Funcionários auxiliares (Ex: Funcionarias Limpeza, Departamento Informática... etc)
    /// através da classe base Funcionario
    /// </summary>
    [Serializable]
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
        /// <summary>
        /// Obtém ou define a área de atuação do auxiliar.
        /// </summary>
        public string Area { get { return area; } set { area = value; } }
        /// <summary>
        /// Obtém ou define a função principal do auxiliar.
        /// </summary>
        public string FuncaoPrincipal { get { return funcaoPrincipal; } set { funcaoPrincipal = value; } }
        #endregion

        
        /// <summary>
        /// Devolve o tipo de pessoa como "Auxiliar".
        /// </summary>
        /// <returns>A string "Auxiliar".</returns>
        public override string TipoPessoa()
        {
            return "Auxiliar";
        }
        /// <summary>
        /// Devolve uma representação em string do objeto Auxiliar.
        /// </summary>
        /// <returns>Uma string que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"Auxiliar[area='{area}', funcaoPrincipal='{funcaoPrincipal}', {base.ToString().Replace("Funcionario", "")}]";
        }

    }
}
