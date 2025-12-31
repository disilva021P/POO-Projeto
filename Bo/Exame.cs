/*
 * Nome: Exame.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Exame
*/

namespace Bo
{
    /// <summary>
    /// Classe para guardar Exames pedidos/realizados 
    /// </summary>
    [Serializable]
    public class Exame
    {
        private int id;
        private Consulta consulta;
        private string tipo;
        private ResultadoExame resultado;
        private bool realizado;
        private decimal custo;

        public Exame() { }

        public Exame(int id, Consulta consultaId, string tipo)
        {
            this.id = id;
            this.consulta = consultaId;
            this.tipo = tipo;
            this.realizado = false;
            this.custo = 0;
            this.resultado = new ResultadoExame();
        }

        public int Id { get { return id; } }
        public Consulta ConsultaId { get { return consulta; } set { consulta = value; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }
        public ResultadoExame Resultado { get { return resultado; } set { resultado = value; } }
        public bool Realizado { get { return realizado; } set { realizado = value; } }
        public decimal Custo { get { return custo; } set { custo = value; } }

        /// <summary>
        /// Retorna uma representação textual do exame.
        /// </summary>
        /// <returns>
        /// String formatada com informação do exame,
        /// incluindo tipo, estado, custo e consulta associada.
        /// </returns>
        public override string ToString()
        {
            return $"Exame[id={id}, tipo='{tipo}', realizado={realizado}, custo={custo:F2}€, " +
                   $"consultaId={consulta?.Id}]";
        }

        #region Operadores

        /// <summary>
        /// Compara dois exames para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">Exame à esquerda da comparação.</param>
        /// <param name="direita">Exame à direita da comparação.</param>
        /// <returns>
        /// True se ambos os exames tiverem o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public static bool operator ==(Exame esquerda, Exame direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }

        /// <summary>
        /// Compara dois exames para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">Exame à esquerda da comparação.</param>
        /// <param name="direita">Exame à direita da comparação.</param>
        /// <returns>
        /// True se os identificadores forem diferentes;
        /// caso contrário, false.
        /// </returns>
        public static bool operator !=(Exame esquerda, Exame direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return false;
            return esquerda.id != direita.id;
        }

        /// <summary>
        /// Determina se o objeto atual é igual a outro objeto.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// True se o objeto for do tipo Exame e tiver o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is Exame)
            {
                return ((Exame)obj).id == this.id;
            }
            return false;
        }

        #endregion
    }
}
