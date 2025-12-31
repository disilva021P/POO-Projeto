/*
 * Nome: Diagnostico.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Diagnóstico
*/

namespace Bo
{
    /// <summary>
    /// Classe para guardar diagnósticos
    /// </summary>
    [Serializable]
    public class Diagnostico
    {
        private int id;
        private string descricao;

        /// <summary>
        /// Construtor padrão da classe Diagnostico.
        /// </summary>
        public Diagnostico() { }
        
        public Diagnostico(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        /// <summary>
        /// Obtém o ID do diagnóstico.
        /// </summary>
        public int Id { get { return id; } }
        /// <summary>
        /// Obtém ou define a descrição do diagnóstico.
        /// </summary>
        public string Descricao { get { return descricao; } set { descricao = value; } }
        /// <summary>
        /// Devolve uma representação em string do objeto Diagnostico.
        /// </summary>
        /// <returns>Uma string que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"Diagnostico[id={id}, descricao='{descricao}']";
        }
        /// <summary>
        /// Compara duas instâncias de Diagnostico for equality.
        /// </summary>
        /// <param name="esquerda">A primeira instância de Diagnostico.</param>
        /// <param name="direita">A segunda instância de Diagnostico.</param>
        /// <returns>Verdadeiro se as instâncias forem iguais, falso caso contrário.</returns>
        public static bool operator ==(Diagnostico esquerda, Diagnostico direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }
        /// <summary>
        /// Compara duas instâncias de Diagnostico para desigualdade.
        /// </summary>
        /// <param name="esquerda">A primeira instância de Diagnostico.</param>
        /// <param name="direita">A segunda instância de Diagnostico.</param>
        /// <returns>Verdadeiro se as instâncias não forem iguais, falso caso contrário.</returns>
        public static bool operator !=(Diagnostico esquerda, Diagnostico direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id != direita.id;
        }
        /// <summary>
        /// Determina se o objeto especificado é igual ao objeto atual.
        /// </summary>
        /// <param name="obj">O objeto a comparar com o objeto atual.</param>
        /// <returns>Verdadeiro se o objeto especificado for igual ao objeto atual; caso contrário, falso.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Diagnostico) { return ((Diagnostico)obj).id == this.id; }
            return false;
        }
    }
}
