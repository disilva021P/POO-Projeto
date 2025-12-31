/*
 * Nome: Cama.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa uma Cama
*/

namespace Bo
{
    /// <summary>
    /// Representa uma cama associada a um quarto.
    /// </summary>
    [Serializable]
    public class Cama
    {
        private int id;
        private Quarto quarto;
        private bool ocupada;

        /// <summary>
        /// Construtor padrão da classe Cama.
        /// </summary>
        public Cama()
        {
            this.id = -1;
            this.quarto = null;
            this.ocupada = false;
        }
        /// <summary>
        /// Construtor da classe Cama com ID e quarto.
        /// </summary>
        /// <param name="id">O ID da cama.</param>
        /// <param name="quartoId">O quarto ao qual a cama pertence.</param>
        public Cama(int id, Quarto quartoId)
        {
            this.id = id;
            this.quarto = quartoId;
            this.ocupada = false;
        }
        /// <summary>
        /// Construtor da classe Cama com ID, quarto e estado de ocupação.
        /// </summary>
        /// <param name="id">O ID da cama.</param>
        /// <param name="quartoId">O quarto ao qual a cama pertence.</param>
        /// <param name="ocupada">Indica se a cama está ocupada.</param>
        public Cama(int id, Quarto quartoId, bool ocupada)
        {
            this.id = id;
            this.quarto = quartoId;
            this.ocupada = ocupada;
        }

        /// <summary>
        /// Obtém o ID da cama.
        /// </summary>
        public int Id { get { return id; } }
        /// <summary>
        /// Obtém ou define o quarto ao qual a cama pertence.
        /// </summary>
        public Quarto QuartoId { get { return quarto; } set { quarto = value; } }
        /// <summary>
        /// Obtém ou define um valor que indica se a cama está ocupada.
        /// </summary>
        public bool Ocupada { get { return ocupada; } set { ocupada = value; } }
        /// <summary>
        /// Devolve uma representação em string do objeto Cama.
        /// </summary>
        /// <returns>Uma string que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"Cama{{id={id}, quarto={quarto?.Id}, ocupada={ocupada}}}";
        }
        #region Operadores
        /// <summary>
        /// Compara duas instâncias de Cama para igualdade.
        /// </summary>
        /// <param name="esquerda">A primeira instância de Cama.</param>
        /// <param name="direita">A segunda instância de Cama.</param>
        /// <returns>Verdadeiro se as instâncias forem iguais, falso caso contrário.</returns>
        public static bool operator ==(Cama esquerda, Cama direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }
        /// <summary>
        /// Compara duas instâncias de Cama para desigualdade.
        /// </summary>
        /// <param name="esquerda">A primeira instância de Cama.</param>
        /// <param name="direita">A segunda instância de Cama.</param>
        /// <returns>Verdadeiro se as instâncias não forem iguais, falso caso contrário.</returns>
        public static bool operator !=(Cama esquerda, Cama direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return false;
            return esquerda.id != direita.id;
        }
        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">O objeto a comparar com o objeto atual.</param>
        /// <returns>Verdadeiro se o objeto especificado for igual ao objeto atual; caso contrário, falso.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Cama) { return ((Cama)obj).id == this.id; }
            return false;
        }
        #endregion
    }
}
