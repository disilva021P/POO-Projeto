/*
 * Nome: EnfermeiroBD.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que trata de unir Enfermeiros com os seus respetivos cuidados
*/

using Bo;
namespace Dados
{
    /// <summary>
    /// Classe que une Enfermeiros aos cuidados de enfermagem, utilizada para gestão interna.
    /// </summary>
    public class EnfermeiroBD : IComparable<EnfermeiroBD>
    {
        private Enfermeiro enfermeiro;
        private EnfermagemCuidados cuidados;

        /// <summary>
        /// Construtor que inicializa a instância com um enfermeiro e a sua lista de cuidados.
        /// </summary>
        /// <param name="enfermeiro">Enfermeiro associado.</param>
        /// <param name="enfermagemCuidados">Lista de cuidados do enfermeiro.</param>
        public EnfermeiroBD(Enfermeiro enfermeiro, EnfermagemCuidados enfermagemCuidados)
        {
            this.enfermeiro = enfermeiro;
            this.cuidados = enfermagemCuidados;
        }

        public Enfermeiro Enfermeiro { get { return enfermeiro; } set { this.enfermeiro = value; } }
        public EnfermagemCuidados EnfermagemCuidados { get { return cuidados; } set { this.cuidados = value; } }

        /// <summary>
        /// Compara esta instância com outro objeto para verificar igualdade.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True se o objeto for do tipo EnfermeiroBD e tiver o mesmo Id ou NIF; caso contrário, false.</returns>
        public override bool Equals(object? obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            if (obj is not EnfermeiroBD) return false;
            if (((EnfermeiroBD)obj).Enfermeiro.Id == this.Enfermeiro.Id) return true;
            if (((EnfermeiroBD)obj).Enfermeiro.Nif == this.Enfermeiro.Nif) return true;
            return false;
        }

        /// <summary>
        /// Compara esta instância com outra instância de EnfermeiroBD para ordenação.
        /// </summary>
        /// <param name="other">Outra instância de EnfermeiroBD.</param>
        /// <returns>
        /// 0 se os Ids forem iguais, 1 se o Id desta instância for maior, -1 se for menor.
        /// </returns>
        public int CompareTo(EnfermeiroBD? other)
        {
            if (other is null) return -1;
            if (this.Enfermeiro.Id == other.Enfermeiro.Id) return 0;
            if (this.Enfermeiro.Id > other.Enfermeiro.Id) return 1;
            return -1;
        }
    }
}
