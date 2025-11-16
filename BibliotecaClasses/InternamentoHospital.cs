/// <summary>
/// Autor: a31504 Diogo Silva
/// Data: 15/11/2025  
/// Nome: InternamentoHospital.cs
/// Descrição: As classes neste ficheiro servem para guardar as informações de internamentos
/// </summary>


using BibliotecaClasses;
using System;

namespace BibliotecaClasses
{
    /// <summary>
    /// Representa um quarto no hospital.
    /// </summary>
    public class Quarto
    {
        private int id;
        private string tipo;
        private int andar;
        //Falta adicionar estrutura de dados de camas

        public Quarto()
        {
            this.id = -1;
            this.tipo = "Básico";
            this.andar = 0;
        }

        public Quarto(int id, string tipo, int andar)
        {
            this.id = id;
            this.tipo = tipo;
            this.andar = andar;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }
        public int Andar { get { return andar; } set { andar = value; } }

        /// <summary>
        /// Adiciona uma cama ao quarto.
        /// </summary>
        /// <param name="cama">Cama a adicionar</param>
        /// <returns>cod de sucesso/erro</returns>
        public int AdicionarCama(Cama cama)
        {
            //Falta as estruturas de dados
            return 1;
        }
        /// <summary>
        /// Remove uma cama pelo id.
        /// </summary>
        /// <param name="cama">Cama a remover</param>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverCama(int idCama)
        {
            //Falta as estruturas de dados
            return 1;
        }
        /// <summary>
        /// Remove uma cama pelo objeto.
        /// </summary>
        /// <param name="cama">Cama a remover</param>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverCama(Cama cama)
        {
            //Falta as estruturas de dados
            return 1;
        }
        
        public override string ToString()
        {
            return $"Quarto{{id={id}, tipo='{tipo}', andar={andar}}}";
        }
        #region Operadores
        public static bool operator ==(Quarto esquerda, Quarto direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id == direita.id;
        }
        public static bool operator !=(Quarto esquerda, Quarto direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }
    /// <summary>
    /// Representa uma cama associada a um quarto.
    /// </summary>
    public class Cama
    {
        private int id;
        private Quarto quartoId;
        private bool ocupada;

        public Cama()
        {
        }

        public Cama(int id, Quarto quartoId, bool ocupada)
        {
            this.id = id;
            this.quartoId = quartoId;
            this.ocupada = ocupada;
        }

        public int Id { get { return id; } set { id = value; } }
        public Quarto QuartoId { get { return quartoId; } set { quartoId = value; } }
        public bool Ocupada { get { return ocupada; } set { ocupada = value; } }
        public override string ToString()
        {
            return $"Cama{{id={id}, quarto={quartoId?.Id}, ocupada={ocupada}}}";
        }
        #region Operadores
        public static bool operator ==(Cama esquerda, Cama direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id == direita.id;
        }
        public static bool operator !=(Cama  esquerda, Cama direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }
    /// <summary>
    /// Representa o internamento de um paciente no hospital.
    /// </summary>
    public class InternamentoHospital
    {
        private int id;
        private Paciente pacienteId;
        private Cama camaId;
        private DateTime dataEntrada;
        private DateTime? dataSaida;

        public InternamentoHospital() { }

        public InternamentoHospital(int id, Paciente pacienteId, Cama camaId, DateTime dataEntrada, DateTime? dataSaida)
        {
            this.id = id;
            this.pacienteId = pacienteId;
            this.camaId = camaId;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
        }

        public int Id { get { return id; } set { id = value; } }
        public Paciente PacienteId { get { return pacienteId; } set { pacienteId = value; } }
        public Cama CamaId { get { return camaId; } set { camaId = value; } }
        public DateTime DataEntrada { get { return dataEntrada; } set { dataEntrada = value; } }
        public DateTime? DataSaida { get { return dataSaida; } set { dataSaida = value; } }
        public override string ToString()
        {
            return $"Internamento[id={id}, paciente='{pacienteId?.Nome} {pacienteId?.Sobrenome}', " +
                   $"cama={camaId?.Id}, entrada={dataEntrada:yyyy-MM-dd}, " +
                   $"saida={(dataSaida?.ToString("yyyy-MM-dd") ?? "ativo")}]";
        }
        #region Operadores
        public static bool operator ==(InternamentoHospital esquerda, InternamentoHospital direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id == direita.id;
        }
        public static bool operator !=(InternamentoHospital esquerda, InternamentoHospital direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }
    /// <summary>
    /// Classe para os enfermeiros guardarem observações de pacientes
    /// </summary>
    public class EnfermagemCuidados
    {
        private int id;
        private InternamentoHospital internamentoId;
        private Enfermeiro enfermeiroId;
        private DateTime dataHora;
        private string observacao;

        public EnfermagemCuidados() { }

        public EnfermagemCuidados(int id, InternamentoHospital internamentoId, Enfermeiro enfermeiroId, DateTime dataHora, string observacao)
        {
            this.id = id;
            this.internamentoId = internamentoId;
            this.enfermeiroId = enfermeiroId;
            this.dataHora = dataHora;
            this.observacao = observacao;
        }

        public int Id { get { return id; } set { id = value; } }
        public InternamentoHospital InternamentoId { get { return internamentoId; } set { internamentoId = value; } }
        public Enfermeiro EnfermeiroId { get { return enfermeiroId; } set { enfermeiroId = value; } }
        public DateTime DataHora { get { return dataHora; } set { dataHora = value; } }
        public string Observacao { get { return observacao; } set { observacao = value; } }
        public override string ToString()
        {
            return $"EnfermagemCuidados[id={id}, internamento={internamentoId?.Id}, " +
                   $"enfermeiro='{enfermeiroId?.Nome} {enfermeiroId?.Sobrenome}', " +
                   $"dataHora={dataHora:yyyy-MM-dd HH:mm}, observacao='{observacao}']";
        }
        #region Operadores
        public static bool operator ==(EnfermagemCuidados esquerda, EnfermagemCuidados direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id == direita.id;
        }
        public static bool operator !=(EnfermagemCuidados esquerda, EnfermagemCuidados direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }

}
