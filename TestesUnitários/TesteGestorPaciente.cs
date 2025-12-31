/*
 * Nome: TesteGestorPaciente.cs
 * Autor: Diogo Silva
 * Data de Criação: 23/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Testa a Classe GestorPaciente
*/

using Bo;
using Dados;

namespace TestesUnitários
{
    public class GestorPacienteBDTests
    {
        private GestorPacienteBD gestor;
        private Paciente pacienteExemplo;

        [SetUp]
        public void Setup()
        {
            gestor = new GestorPacienteBD();
            pacienteExemplo = new Paciente(
                1, "Ana", "Silva", "123456789",
                "Rua X", 911111111, new DateOnly(1990, 1, 1),
                'F', 12345, false, "912345678", "");
        }

        [Test]
        public void InserePaciente_Duplicado_DeveRetornarFalse()
        {
            bool ok1 = gestor.InserePaciente(pacienteExemplo);
            bool ok2 = gestor.InserePaciente(pacienteExemplo);

            Assert.IsTrue(ok1);
            Assert.IsFalse(ok2);
        }

        [Test]
        public void ObterPacienteBO_DeveRetornarSomenteBO()
        {
            gestor.InserePaciente(pacienteExemplo);

            Paciente? bo = gestor.ObterPorNif("123456789");
            PacienteBD? bd = gestor.ObterPorNifComConsulta("123456789");

            Assert.IsNotNull(bo);
            Assert.IsNotNull(bd);
            Assert.That(bo.Nome, Is.EqualTo("Ana"));
            Assert.That(bd.Paciente.Nome, Is.EqualTo("Ana"));
            Assert.IsInstanceOf<Paciente>(bo);
            Assert.IsInstanceOf<PacienteBD>(bd);
            Assert.AreNotSame(bo, bd.Paciente); // garante objetos distintos
        }

        [Test]
        public void RemoverPorNif_Inexistente_DeveRetornarFalse()
        {
            var ok = gestor.RemoverPorNif("999999999");
            Assert.IsFalse(ok);
        }

        [Test]
        public void RemoverPorNif_Existente_DeveRetornarTrue()
        {
            gestor.InserePaciente(pacienteExemplo);
            var ok = gestor.RemoverPorNif("123456789");
            Assert.IsTrue(ok);
        }
    }
}
