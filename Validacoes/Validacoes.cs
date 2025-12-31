/*
 * Nome: Validacoes.cs
 * Autor: Diogo Silva
 * Data de Criação: 13/12/2025
 * Última Atualização: 26/12/2025
 * Descrição: Classe que possui várias funções de validações gerais que podem ser utilizadas em qualquer lado
 * 
*/
using Exceptions;

namespace Regras
{
    /// <summary>
    /// Classe estática para validações de dados comuns do sistema, como NIF e email.
    /// </summary>
    public static class Validacoes
    {
        /// <summary>
        /// Valida se o NIF fornecido é válido.
        /// </summary>
        /// <param name="nif">Número de identificação fiscal a ser validado.</param>
        /// <returns>True se o NIF for válido.</returns>
        /// <exception cref="NifInvalidoException">Lançada se o NIF for nulo, vazio, não tiver 9 dígitos ou conter caracteres inválidos.</exception>
        public static bool NifValido(string nif)
        {
            if (!string.IsNullOrWhiteSpace(nif)
                   && nif.Length == 9
                   && nif.All(char.IsDigit))
                return true;

            throw new NifInvalidoException("Nif inválido"); 
        }

        /// <summary>
        /// Valida se o email fornecido é válido.
        /// </summary>
        /// <param name="email">Endereço de email a ser validado.</param>
        /// <returns>True se o email tiver um formato válido, False caso contrário.</returns>
        public static bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                System.Net.Mail.MailAddress addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }
    }
}
