/*
 * Nome: PacienteBD.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata de unir Pacientes com as suas respetivas consultas e internamentos
*/
using Bo;

namespace Dados
{
    /// <summary>
    /// Classe de Dados que associa um paciente às suas consultas e internamentos.
    /// Implementa IComparable para permitir comparação entre objetos PacienteBD.
    /// </summary>
    public class PacienteBD : IComparable<PacienteBD>
    {
        private Paciente paciente;
        private Consultas consultas;
        private InternamentosHospital internamentos;

        /// <summary>
        /// Construtor padrão que inicializa paciente e suas consultas.
        /// </summary>
        public PacienteBD()
        {
            this.paciente = new Paciente();
            this.consultas = new Consultas();
            this.internamentos = new InternamentosHospital();
        }

        /// <summary>
        /// Construtor que inicializa apenas o paciente.
        /// </summary>
        /// <param name="paciente">Paciente a ser associado.</param>
        public PacienteBD(Paciente paciente)
        {
            this.paciente = paciente;
            this.consultas = new Consultas();
            this.internamentos = new InternamentosHospital();
        }

        /// <summary>
        /// Construtor que inicializa paciente e suas consultas.
        /// </summary>
        /// <param name="paciente">Paciente a ser associado.</param>
        /// <param name="consultas">Consultas do paciente.</param>
        public PacienteBD(Paciente paciente, Consultas consultas)
        {
            this.paciente = paciente;
            this.consultas = consultas;
            this.internamentos = new InternamentosHospital();
        }

        /// <summary>
        /// Construtor que inicializa paciente, consultas e internamentos.
        /// </summary>
        /// <param name="paciente">Paciente a ser associado.</param>
        /// <param name="consultas">Consultas do paciente.</param>
        /// <param name="internamentos">Internamentos do paciente.</param>
        public PacienteBD(Paciente paciente, Consultas consultas, InternamentosHospital internamentos)
        {
            this.paciente = paciente;
            this.consultas = consultas;
            this.internamentos = internamentos;
        }

        /// <summary>
        /// Obtém ou define o paciente associado.
        /// </summary>
        public Paciente Paciente { get { return paciente; } set { this.paciente = value; } }

        /// <summary>
        /// Obtém ou define as consultas associadas ao paciente.
        /// </summary>
        public Consultas Consultas { get { return consultas; } set { this.consultas = value; } }

        /// <summary>
        /// Obtém ou define os internamentos associados ao paciente.
        /// </summary>
        public InternamentosHospital Internamentos { get { return internamentos; } set { internamentos = value; } }

        /// <summary>
        /// Verifica se dois objetos PacienteBD são iguais.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True se os objetos representam o mesmo paciente, False caso contrário.</returns>
        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            if (obj is not PacienteBD) return false;
            if (((PacienteBD)obj).paciente.Id == this.paciente.Id) return true;
            if (((PacienteBD)obj).paciente.Nif == this.Paciente.Nif) return true;
            return false;
        }

        /// <summary>
        /// Compara o objeto atual com outro PacienteBD.
        /// </summary>
        /// <param name="other">Outro objeto PacienteBD a comparar.</param>
        /// <returns>
        /// 0 se os IDs forem iguais, 
        /// 1 se o ID do objeto atual for maior, 
        /// -1 se o ID do objeto atual for menor ou se other for null.
        /// </returns>
        public int CompareTo(PacienteBD? other)
        {
            if (other is null) return -1;
            if (this.paciente.Id == other.paciente.Id) return 0;
            if (this.paciente.Id > other.paciente.Id) return 1;
            return -1;
        }
    }
}
