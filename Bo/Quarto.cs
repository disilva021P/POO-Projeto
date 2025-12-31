/*
 * Nome: Quarto.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Quarto
*/
namespace Bo
{
    /// <summary>
    /// Representa um quarto no hospital.
    /// </summary>
    [Serializable]
    public class Quarto
    {
        private int id;
        private string tipo;
        private int andar;

        public Quarto()
        {
            this.id = -1;
            this.tipo = "Básico";
            this.andar = 0;
        }

        public Quarto(int id, string tipo, int andar)
        {
            this.id = id;
            this.tipo = tipo;
            this.andar = andar;
        }

        public int Id { get { return id; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }
        public int Andar { get { return andar; } set { andar = value; } }

        /// <summary>
        /// Retorna uma representação textual do quarto.
        /// </summary>
        /// <returns>
        /// String formatada com informação do quarto,
        /// incluindo identificador, tipo e andar.
        /// </returns>
        public override string ToString()
        {
            return $"Quarto{{id={id}, tipo='{tipo}', andar={andar}}}";
        }

        #region Operadores

        /// <summary>
        /// Compara dois quartos para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">Quarto à esquerda da comparação.</param>
        /// <param name="direita">Quarto à direita da comparação.</param>
        /// <returns>
        /// True se ambos os quartos tiverem o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public static bool operator ==(Quarto esquerda, Quarto direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }

        /// <summary>
        /// Compara dois quartos para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">Quarto à esquerda da comparação.</param>
        /// <param name="direita">Quarto à direita da comparação.</param>
        /// <returns>
        /// True se os identificadores forem diferentes;
        /// caso contrário, false.
        /// </returns>
        public static bool operator !=(Quarto esquerda, Quarto direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (esquerda is null || direita is null)
                return false;

            return esquerda.id != direita.id;
        }

        /// <summary>
        /// Determina se o objeto atual é igual a outro objeto.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// True se o objeto for do tipo Quarto e tiver o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is Quarto)
            {
                return ((Quarto)obj).id == this.id;
            }
            return false;
        }

        #endregion
    }
}
