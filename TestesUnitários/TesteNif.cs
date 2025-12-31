/*
 * Nome: TesteNif.cs
 * Autor: Diogo Silva
 * Data de Criação: 23/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Testa a validação dos Nifs
*/

using Exceptions;
using Regras;

namespace TestesUnitários
{
    public class TesteNif
    {
        [Test]
        public void NifValido_Com9Digitos_DevePassar()
        {
            Assert.DoesNotThrow(() => Validacoes.NifValido("123456789"));
        }

        [Test]
        public void NifValido_ComLetras_DeveLancarExcecao()
        {
            NifInvalidoException? ex = Assert.Throws<NifInvalidoException>(() => Validacoes.NifValido("12345A789"));
            Assert.That(ex.Message, Does.Contain("Nif inválido"));
        }

        [Test]
        public void NifValido_Null_DeveLancarExcecao()
        {
            NifInvalidoException? ex = Assert.Throws<NifInvalidoException>(() => Validacoes.NifValido(null!));
            Assert.That(ex.Message, Does.Contain("Nif inválido"));
        }

        [Test]
        public void NifValido_Com8Digitos_DeveLancarExcecao()
        {
            NifInvalidoException? ex = Assert.Throws<NifInvalidoException>(() => Validacoes.NifValido("12345678"));
            Assert.That(ex.Message, Does.Contain("Nif inválido"));
        }
    }
}