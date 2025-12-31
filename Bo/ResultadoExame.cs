/*
 * Nome: ResultadoExame.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa o resultado de um exame
*/

namespace Bo
{
    /// <summary>
    /// Classe para guardar o resultado dos exames.
    /// </summary>
    [Serializable]
    public class ResultadoExame
    {
        private int id;
        private string resultado;

        public ResultadoExame()
        {
            this.id = -1;
            this.resultado = string.Empty;
        }

        public ResultadoExame(int id, string resultado)
        {
            this.id = id;
            this.resultado = resultado;
        }

        public int Id { get { return id; } }
        public string Resultado { get { return resultado; } set { resultado = value; } }

        /// <summary>
        /// Retorna uma representação textual do resultado do exame.
        /// </summary>
        /// <returns>
        /// String formatada com identificador e resultado do exame.
        /// </returns>
        public override string ToString()
        {
            return $"ResultadoExame[id={id}, resultado='{resultado}']";
        }

        /// <summary>
        /// Compara dois resultados de exame para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">ResultadoExame à esquerda da comparação.</param>
        /// <param name="direita">ResultadoExame à direita da comparação.</param>
        /// <returns>
        /// True se ambos os resultados tiverem o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public static bool operator ==(ResultadoExame esquerda, ResultadoExame direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }

        /// <summary>
        /// Compara dois resultados de exame para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">ResultadoExame à esquerda da comparação.</param>
        /// <param name="direita">ResultadoExame à direita da comparação.</param>
        /// <returns>
        /// True se os identificadores forem diferentes;
        /// caso contrário, false.
        /// </returns>
        public static bool operator !=(ResultadoExame esquerda, ResultadoExame direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id != direita.id;
        }

        /// <summary>
        /// Determina se o objeto atual é igual a outro objeto.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// True se o objeto for do tipo ResultadoExame e tiver o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is ResultadoExame)
            {
                return ((ResultadoExame)obj).id == this.id;
            }
            return false;
        }
    }
}
