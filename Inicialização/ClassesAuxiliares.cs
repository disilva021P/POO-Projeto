using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicialização
{
    internal class ClassesAuxiliares
    {
        [Serializable]
        public class RelacoesDTO
        {
            public List<ConsultaRelacao> Consultas { get; set; } = new();
            public List<InternamentoRelacao> Internamentos { get; set; } = new();
        }

        [Serializable]
        public class ConsultaRelacao
        {
            public int ConsultaId { get; set; }
            public int PacienteId { get; set; }
            public ConsultaRelacao(int consultaId, int pacienteId)
            {
                ConsultaId = consultaId;
                PacienteId = pacienteId;
            }   
        }

        [Serializable]
        public class InternamentoRelacao
        {
            public int InternamentoId { get; set; }
            public int PacienteId { get; set; }
            public InternamentoRelacao(int internamentoId, int pacienteId)
            {
                InternamentoId = internamentoId;
                PacienteId= pacienteId;
            }
        }
    }
}
