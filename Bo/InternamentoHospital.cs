/*
 * Nome: InternamentoHospital.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Internamento
*/
namespace Bo
{
    /// <summary>
    /// Representa o internamento de um paciente no hospital.
    /// </summary>
    [Serializable]
    public class InternamentoHospital
    {
        private int id;
        private Paciente paciente;
        private Cama cama;
        private DateTime dataEntrada;
        private DateTime? dataSaida;

        public InternamentoHospital() { }

        public InternamentoHospital(int id, Paciente pacienteId, Cama camaId, DateTime dataEntrada, DateTime? dataSaida)
        {
            this.id = id;
            this.paciente = pacienteId;
            this.cama = camaId;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
        }

        public int Id { get { return id; } }
        public Paciente PacienteId { get { return paciente; } set { paciente = value; } }
        public Cama CamaId { get { return cama; } set { cama = value; } }
        public DateTime DataEntrada { get { return dataEntrada; } set { dataEntrada = value; } }
        public DateTime? DataSaida { get { return dataSaida; } set { dataSaida = value; } }

        /// <summary>
        /// Retorna uma representação textual do internamento hospitalar.
        /// </summary>
        /// <returns>
        /// String formatada com informação do internamento,
        /// incluindo paciente, cama, data de entrada e data de saída.
        /// </returns>
        public override string ToString()
        {
            return $"Internamento[id={id}, paciente='{paciente?.Nome} {paciente?.Sobrenome}', " +
                   $"cama={cama?.Id}, entrada={dataEntrada:yyyy-MM-dd}, " +
                   $"saida={(dataSaida?.ToString("yyyy-MM-dd") ?? "ativo")}]";
        }

        #region Operadores

        /// <summary>
        /// Compara dois internamentos hospitalares para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">Internamento à esquerda da comparação.</param>
        /// <param name="direita">Internamento à direita da comparação.</param>
        /// <returns>
        /// True se ambos os internamentos tiverem o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public static bool operator ==(InternamentoHospital esquerda, InternamentoHospital direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }

        /// <summary>
        /// Compara dois internamentos hospitalares para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">Internamento à esquerda da comparação.</param>
        /// <param name="direita">Internamento à direita da comparação.</param>
        /// <returns>
        /// True se os identificadores forem diferentes;
        /// caso contrário, false.
        /// </returns>
        public static bool operator !=(InternamentoHospital esquerda, InternamentoHospital direita)
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
        /// True se o objeto for do tipo InternamentoHospital e tiver o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is InternamentoHospital)
            {
                return ((InternamentoHospital)obj).id == this.id;
            }
            return false;
        }

        #endregion
    }
}
