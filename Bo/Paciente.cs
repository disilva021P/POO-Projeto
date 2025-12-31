/*
 * Nome: Paciente.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe base que representa um Paciente que herda a classe Pessoa.
*/

namespace Bo
{
    /// <summary>
    /// Entidade Paciente, para todos
    /// </summary>
    [Serializable]
    public class Paciente : Pessoa
    {
        #region Atributos
        private int numeroUtente;
        private bool internado;
        private string contactoEmergencia;
        private string alergias;
        #endregion

        #region Construtor
        public Paciente()
        {
            numeroUtente = -1;
            internado = false;
            contactoEmergencia = string.Empty;
            alergias = string.Empty;
        }

        public Paciente(int id,
                        string nome,
                        string sobrenome,
                        string nif,
                        string morada,
                        int telefone,
                        DateOnly dataNasc,
                        char genero,
                        int numeroUtente,
                        bool internado,
                        string contactoEmergencia,
                        string alergias)
            : base(id, nome, sobrenome, nif, morada, telefone, dataNasc, genero)
        {
            this.numeroUtente = numeroUtente;
            this.internado = internado;
            this.contactoEmergencia = contactoEmergencia;
            this.alergias = alergias;
        }
        #endregion

        #region Propriedades
        public int NumeroUtente { get { return numeroUtente; } }
        public bool Internado { get { return internado; } set { internado = value; } }
        public string ContactoEmergencia { get { return contactoEmergencia; } set { contactoEmergencia = value; } }
        public string Alergias { get { return alergias; } set { alergias = value; } }
        #endregion

        /// <summary>
        /// Adiciona uma alergia ao paciente.
        /// </summary>
        /// <param name="alergia">Alergia a adicionar.</param>
        /// <returns>
        /// Código de resultado da operação:
        /// 1 se a alergia for adicionada com sucesso;
        /// 5 se a alergia for inválida.
        /// </returns>
        public int AdicionarAlergia(string alergia)
        {
            if (alergia.Equals(string.Empty))
            {
                return 5;
            }
            this.alergias += (";" + alergia);
            return 1;
        }

        /// <summary>
        /// Remove uma alergia do paciente.
        /// </summary>
        /// <param name="alergia">Alergia a remover.</param>
        /// <returns>
        /// Código de resultado da operação:
        /// 1 se a alergia for removida com sucesso;
        /// 5 se a alergia não existir.
        /// </returns>
        public int RemoverAlergia(string alergia)
        {
            if (this.alergias.Contains(alergia))
            {
                this.alergias = this.alergias.Replace(alergia + ";", "")
                                             .Replace(";" + alergia, "")
                                             .Replace(alergia, "");
                return 1;
            }
            return 5;
        }

        /// <summary>
        /// Retorna o tipo de pessoa representado pela classe.
        /// </summary>
        /// <returns>
        /// String identificando o tipo como "Paciente".
        /// </returns>
        public override string TipoPessoa()
        {
            return "Paciente";
        }

        /// <summary>
        /// Compara dois pacientes para verificar se são iguais.
        /// </summary>
        /// <param name="esquerda">Paciente à esquerda da comparação.</param>
        /// <param name="direita">Paciente à direita da comparação.</param>
        /// <returns>
        /// True se ambos os pacientes tiverem o mesmo número de utente;
        /// caso contrário, false.
        /// </returns>
        public static bool operator ==(Paciente esquerda, Paciente direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.numeroUtente == direita.numeroUtente;
        }

        /// <summary>
        /// Compara dois pacientes para verificar se são diferentes.
        /// </summary>
        /// <param name="esquerda">Paciente à esquerda da comparação.</param>
        /// <param name="direita">Paciente à direita da comparação.</param>
        /// <returns>
        /// True se os números de utente forem diferentes;
        /// caso contrário, false.
        /// </returns>
        public static bool operator !=(Paciente esquerda, Paciente direita)
        {
            if (esquerda is null || direita is null)
                return false;
            if (ReferenceEquals(esquerda, direita))
                return true;
            return esquerda.numeroUtente != direita.numeroUtente;
        }

        /// <summary>
        /// Determina se o objeto atual é igual a outro objeto.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado.</param>
        /// <returns>
        /// True se o objeto for do tipo Paciente e tiver o mesmo número de utente;
        /// caso contrário, false.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return (obj is Paciente && ((Paciente)obj).numeroUtente == this.numeroUtente);
        }
    }
}
