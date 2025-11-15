using ProjetoPoon31504;
using System;

namespace ProjetoPOODiogo31504
{
        public class Consulta
        {
            private int id;
            private Paciente paciente;
            private Medico medicoId;
            private DateTime dataConsulta;
            private Exame exame; //Posteriormente adicionar uma Estrutura de dados pois uma consula pode resultar em vários exames
            private Diagnostico diagnostico;
            private decimal custo;


        public Consulta() { }

            public Consulta(int id, Paciente pacienteId, Medico medicoId, DateTime dataConsulta)
            {
                this.id = id;
                this.paciente = pacienteId;
                this.medicoId = medicoId;
                this.dataConsulta = dataConsulta;
            }

            public int Id { get { return id; } set { id = value; } }
            public Paciente Paciente { get { return paciente; } set { paciente = value; } }
            public Medico MedicoId { get { return medicoId; } set { medicoId = value; } }
            public DateTime DataConsulta { get { return dataConsulta; } set { dataConsulta = value; } }
        }

        public class Diagnostico
        {
            private int id;
            private string descricao;

            public Diagnostico() { }

            public Diagnostico(int id, string descricao)
            {
                this.id = id;
                this.descricao = descricao;
            }

            public int Id { get { return id; } set { id = value; } }
            public string Descricao { get { return descricao; } set { descricao = value; } }
        }

        public class Exame
        {
            private int id;
            private int consultaId;
            private string tipo;
            private ResultadoExame resultado;
            private bool realizado;
            private decimal custo;

            public Exame() { }

            public Exame(int id, int consultaId, string tipo)
            {
                this.id = id;
                this.consultaId = consultaId;
                this.tipo = tipo;
            }

            public int Id { get { return id; } set { id = value; } }
            public int ConsultaId { get { return consultaId; } set { consultaId = value; } }
            public string Tipo { get { return tipo; } set { tipo = value; } }
        }

        public class ResultadoExame
        {
            private int id;
            private string resultado;

            public ResultadoExame() { }

            public ResultadoExame(int id, string resultado)
            {
                this.id = id;
                this.resultado = resultado;
            }

            public int Id { get { return id; } set { id = value; } }
            public string Resultado { get { return resultado; } set { resultado = value; } }
        }
    
}
