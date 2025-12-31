/*
 * Nome: Consulta.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa uma Consulta
*/
namespace Bo
{
    /// <summary>
    /// Classe consulta para guardar as consultas do hospital
    /// </summary>
    [Serializable]
    public class Consulta
    {
        private int id;
        private Paciente paciente;
        private Medico medico;
        private DateTime dataConsulta;
        private decimal custo;


        /// <summary>
        /// Construtor padrão da classe Consulta.
        /// </summary>
        public Consulta() { }

        public Consulta(int id, Paciente pacienteId, Medico medicoId, DateTime dataConsulta)
        {
            this.id = id;
            this.paciente = pacienteId;
            this.medico = medicoId;
            this.dataConsulta = dataConsulta;
        }

        /// <summary>
        /// Obtém o ID da consulta.
        /// </summary>
        public int Id { get { return id; } }
        /// <summary>
        /// Obtém ou define o paciente da consulta.
        /// </summary>
        public Paciente Paciente { get { return paciente; } set { paciente = value; } }
        /// <summary>
        /// Obtém ou define o médico da consulta.
        /// </summary>
        public Medico MedicoId { get { return medico; } set { medico = value; } }
        /// <summary>
        /// Obtém ou define a data da consulta.
        /// </summary>
        public DateTime DataConsulta { get { return dataConsulta; } set { dataConsulta = value; } }
        /// <summary>
        /// Obtém ou define o custo da consulta.
        /// </summary>
        public decimal Custo { get { return custo; } set { custo = value; } }

        /// <summary>
        /// Devolve uma representação em string do objeto Consulta.
        /// </summary>
        /// <returns>Uma string que representa o objeto atual.</returns>
        public override string ToString()
        {
            return $"Consulta[id={id}, data={dataConsulta:yyyy-MM-dd HH:mm}, paciente='{paciente?.Nome} {paciente?.Sobrenome}', " +
                   $"medico='{medico?.Nome} {medico?.Sobrenome}', custo={custo:F2}€]";
        }
        #region Operadores
        /// <summary>
        /// Compara duas instâncias de Consulta para igualdade.
        /// </summary>
        /// <param name="esquerda">A primeira instância de Consulta.</param>
        /// <param name="direita">A segunda instância de Consulta.</param>
        /// <returns>Verdadeiro se as instâncias forem iguais, falso caso contrário.</returns>
        public static bool operator ==(Consulta esquerda, Consulta direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }
        /// <summary>
        /// Compara duas instâncias de Consulta para desigualdade.
        /// </summary>
        /// <param name="esquerda">A primeira instância de Consulta.</param>
        /// <param name="direita">A segunda instância de Consulta.</param>
        /// <returns>Verdadeiro se as instâncias não forem iguais, falso caso contrário.</returns>
        public static bool operator !=(Consulta esquerda, Consulta direita)
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
            if (obj is Consulta) { return ((Consulta)obj).id == this.id; }
            return false;
        }
        #endregion
    }
}
