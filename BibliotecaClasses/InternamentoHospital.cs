using ProjetoPoon31504;
using System;

namespace ProjetoPOODiogo31504
{
        public class Quarto
        {
            private int id;
            private string tipo;
            private int andar;

            public Quarto() { }

            public Quarto(int id, string tipo, int andar)
            {
                this.id = id;
                this.tipo = tipo;
                this.andar = andar;
            }

            public int Id { get { return id; } set { id = value; } }
            public string Tipo { get { return tipo; } set { tipo = value; } }
            public int Andar { get { return andar; } set { andar = value; } }
        }

        public class Cama
        {
            private int id;
            private Quarto quartoId;
            private bool ocupada;

            public Cama() { }

            public Cama(int id, Quarto quartoId, bool ocupada)
            {
                this.id = id;
                this.quartoId = quartoId;
                this.ocupada = ocupada;
            }

            public int Id { get { return id; } set { id = value; } }
            public Quarto QuartoId { get { return quartoId; } set { quartoId = value; } }
            public bool Ocupada { get { return ocupada; } set { ocupada = value; } }
        }

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
        }

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
        }

    }
