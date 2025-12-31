/*
 * Nome: MedicoBD.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata de unir Medicos com as suas respetivas consultas
*/
using Bo;

namespace Dados
{
    /// <summary>
    /// Classe de Dados que associa um médico às suas consultas.
    /// Implementa IComparable para permitir comparação entre objetos MedicoBD.
    /// </summary>
    public class MedicoBD : IComparable<MedicoBD>
    {
        private Medico medico;
        private Consultas consultas;

        /// <summary>
        /// Construtor que inicializa o médico e suas consultas.
        /// </summary>
        /// <param name="medico">Objeto Medico a ser associado.</param>
        /// <param name="consultas">Objeto Consultas associado ao médico.</param>
        public MedicoBD(Medico medico, Consultas consultas)
        {
            this.medico = medico;
            this.consultas = consultas;
        }

        /// <summary>
        /// Obtém ou define o médico associado.
        /// </summary>
        public Medico Medico { get { return medico; } set { this.medico = value; } }

        /// <summary>
        /// Obtém ou define as consultas associadas ao médico.
        /// </summary>
        public Consultas Consultas { get { return consultas; } set { this.consultas = value; } }

        /// <summary>
        /// Verifica se dois objetos MedicoBD são iguais.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True se os objetos representam o mesmo médico, False caso contrário.</returns>
        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            if (obj is not MedicoBD) return false;
            if (((MedicoBD)obj).medico.Id == this.Medico.Id) return true;
            if (((MedicoBD)obj).medico.Nif == this.Medico.Nif) return true;
            return false;
        }

        /// <summary>
        /// Compara o objeto atual com outro MedicoBD.
        /// </summary>
        /// <param name="other">Outro objeto MedicoBD a comparar.</param>
        /// <returns>
        /// 0 se os IDs forem iguais, 
        /// 1 se o ID do objeto atual for maior, 
        /// -1 se o ID do objeto atual for menor ou se other for null.
        /// </returns>
        public int CompareTo(MedicoBD? other)
        {
            if (other is null) return -1;
            if (this.Medico.Id == other.Medico.Id) return 0;
            if (this.medico.Id > other.medico.Id) return 1;
            return -1;
        }
    }
}
