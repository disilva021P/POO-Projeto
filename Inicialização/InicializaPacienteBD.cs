using Dados;
using Bo;
using Ficheiros;
using static Inicialização.ClassesAuxiliares;
using System.Collections.Generic;
namespace Inicialização
{
    /// <summary>
    /// Classe responsável por guardar e carregar os dados de Pacientes,
    /// incluindo suas consultas e internamentos.
    /// </summary>
    public class InicializaPacienteBD
    {
        /// <summary>
        /// Guarda todas as listas de pacientes, consultas e internamentos em ficheiros binários.
        /// Além disso, guarda as relações entre pacientes e seus registros.
        /// </summary>
        /// <param name="pacientes">Lista de pacientes a ser guardada.</param>
        /// <param name="consultas">Lista de consultas a ser guardada.</param>
        /// <param name="internamentos">Lista de internamentos a ser guardada.</param>
        public static void GuardarTodos(List<Paciente> pacientes, List<Consulta> consultas, List<InternamentoHospital> internamentos)
        {
            Ficheiro<Paciente>.Guardar("pacientes.bin", pacientes);
            Ficheiro<Consulta>.Guardar("consultas.bin", consultas);
            Ficheiro<InternamentoHospital>.Guardar("internamentos.bin", internamentos);

            List<RelacoesDTO> relacoes = new List<RelacoesDTO>();
            RelacoesDTO relacao = new RelacoesDTO();

            foreach (Consulta c in consultas)
            {
                relacao.Consultas.Add(new ConsultaRelacao(c.Id, c.Paciente.Id));
            }

            foreach (InternamentoHospital i in internamentos)
            {
                relacao.Internamentos.Add(new InternamentoRelacao(i.Id, i.PacienteId.Id));
            }

            relacoes.Add(relacao);
            Ficheiro<RelacoesDTO>.Guardar("relacoes.bin", relacoes);
        }

        /// <summary>
        /// Carrega todas as listas de pacientes, consultas e internamentos a partir de ficheiros binários
        /// e reconstrói as relações entre eles, retornando um GestorPacienteBD completo.
        /// </summary>
        /// <returns>Um objeto GestorPacienteBD contendo todos os pacientes com suas consultas e internamentos associados.</returns>
        public static GestorPacienteBD CarregarTodos()
        {
            // 1. Carrega listas brutas
            List<Paciente> pacientes = Ficheiro<Paciente>.Ler("pacientes.bin") ?? new List<Paciente>();
            List<Consulta> consultasCarregadas = Ficheiro<Consulta>.Ler("consultas.bin") ?? new List<Consulta>();
            List<InternamentoHospital> internamentosCarregadas = Ficheiro<InternamentoHospital>.Ler("internamentos.bin") ?? new List<InternamentoHospital>();
            List<RelacoesDTO> relacoes = Ficheiro<RelacoesDTO>.Ler("relacoes.bin") ?? new List<RelacoesDTO>();
            RelacoesDTO? relacao = relacoes.FirstOrDefault();

            // 2. Reconstrói o gestor
            GestorPacienteBD gestor = new GestorPacienteBD();

            foreach (Paciente? p in pacientes)
            {
                if (p is not null)
                {
                    gestor.InserePaciente(p);
                }
            }

            if (relacoes is not null && relacao is not null)
            {
                foreach (ConsultaRelacao? c in relacao.Consultas)
                {
                    Consulta? consulta = consultasCarregadas.FirstOrDefault(co => co.Id == c.ConsultaId);
                    if (consulta is not null)
                    {
                        consulta.Paciente = gestor.ObterPorId(c.PacienteId);
                        gestor.InserirConsulta(consulta, c.PacienteId);
                    }
                }

                foreach (InternamentoRelacao i in relacao.Internamentos)
                {
                    InternamentoHospital? internamento = internamentosCarregadas.FirstOrDefault(into => into.Id == i.InternamentoId);
                    if (internamento is not null)
                    {
                        internamento.PacienteId = gestor.ObterPorId(i.PacienteId);
                        gestor.InserirInternamento(internamento, i.PacienteId);
                    }
                }
            }

            return gestor;
        }
    }
}

