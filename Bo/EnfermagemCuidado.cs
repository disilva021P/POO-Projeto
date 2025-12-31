/*
 * Nome: EnfermagemCuidado.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um cuidado de enfermagens
*/
namespace Bo
{
    /// <summary>
    /// Classe para os enfermeiros guardarem observações de pacientes
    /// </summary>
    [Serializable]
    public class EnfermagemCuidado
    {
        private int id;
        private InternamentoHospital internamentoHospital;
        private Enfermeiro enfermeiro;
        private DateTime dataHora;
        private string observacao;

        public EnfermagemCuidado() { }

        public EnfermagemCuidado(int id, InternamentoHospital internamentoId, Enfermeiro enfermeiroId, DateTime dataHora, string observacao)
        {
            this.id = id;
            this.internamentoHospital = internamentoId;
            this.enfermeiro = enfermeiroId;
            this.dataHora = dataHora;
            this.observacao = observacao;
        }

        public int Id { get { return id; } }
        public InternamentoHospital InternamentoId { get { return internamentoHospital; } set { internamentoHospital = value; } }
        public Enfermeiro EnfermeiroId { get { return enfermeiro; } set { enfermeiro = value; } }
        public DateTime DataHora { get { return dataHora; } set { dataHora = value; } }
        public string Observacao { get { return observacao; } set { observacao = value; } }

        /// <summary>
        /// Retorna uma representação textual do cuidado de enfermagem.
        /// </summary>
        /// <returns>
        /// String formatada com os dados do cuidado, incluindo internamento,
        /// enfermeiro, data/hora e observação.
        /// </returns>
        public override string ToString()
        {
            return $"EnfermagemCuidados[id={id}, internamento={internamentoHospital?.Id}, " +
                   $"enfermeiro='{enfermeiro?.Nome} {enfermeiro?.Sobrenome}', " +
                   $"dataHora={dataHora:yyyy-MM-dd HH:mm}, observacao='{observacao}']";
        }

        #region Operadores

        /// <summary>
        /// Compara dois cuidados de enfermagem para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">Objeto EnfermagemCuidado à esquerda da comparação.</param>
        /// <param name="direita">Objeto EnfermagemCuidado à direita da comparação.</param>
        /// <returns>
        /// True se ambos os objetos tiverem o mesmo identificador; caso contrário, false.
        /// </returns>
        public static bool operator ==(EnfermagemCuidado esquerda, EnfermagemCuidado direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.id == direita.id;
        }

        /// <summary>
        /// Compara dois cuidados de enfermagem para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">Objeto EnfermagemCuidado à esquerda da comparação.</param>
        /// <param name="direita">Objeto EnfermagemCuidado à direita da comparação.</param>
        /// <returns>
        /// True se os identificadores forem diferentes; caso contrário, false.
        /// </returns>
        public static bool operator !=(EnfermagemCuidado esquerda, EnfermagemCuidado direita)
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
        /// True se o objeto for do tipo EnfermagemCuidado e tiver o mesmo identificador;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            if (obj is EnfermagemCuidado)
            {
                return ((EnfermagemCuidado)obj).id == this.id;
            }
            return false;
        }

        #endregion
    }
}
