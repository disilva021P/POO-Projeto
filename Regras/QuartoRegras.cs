/*
 * Nome: QuartoRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Quarto 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Quarto
    /// </summary>
    public class QuartoRegras : ICrud<Quarto, int>
    {
        private Quartos dados;

        public QuartoRegras()
        {
            dados = new Quartos();
        }

        public QuartoRegras(Quartos dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os quartos existentes
        /// </summary>
        /// <returns>Lista de objetos Quarto</returns>
        public List<Quarto> Listar()
        {
            return dados.ListaQuartos();
        }

        /// <summary>
        /// Verifica se um quarto já existe
        /// </summary>
        /// <param name="quarto">Quarto a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Quarto quarto)
        {
            if (quarto is null) throw new ArgumentNullException(nameof(quarto));
            return dados.JaExiste(quarto);
        }

        /// <summary>
        /// Verifica se existe um quarto com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do quarto</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura um quarto pelo seu identificador
        /// </summary>
        /// <param name="numero">Identificador do quarto</param>
        /// <returns>Objeto Quarto se encontrado, ou null</returns>
        public Quarto? BuscarPorId(int numero)
        {
            if (numero < 0) throw new ArgumentException("Número de quarto inválido");
            return dados.ObterQuarto(numero);
        }

        /// <summary>
        /// Insere um novo quarto
        /// </summary>
        /// <param name="quarto">Quarto a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(Quarto quarto)
        {
            if (quarto is null) throw new ArgumentNullException(nameof(quarto));
            if (this.JaExiste(quarto)) return false;
            return dados.InsereQuartos(quarto);
        }

        /// <summary>
        /// Remove um quarto existente
        /// </summary>
        /// <param name="quarto">Quarto a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(Quarto quarto)
        {
            if (quarto is null) throw new ArgumentNullException(nameof(quarto));
            if (!this.JaExiste(quarto)) return false;
            return dados.RemoveQuartos(quarto);
        }

        /// <summary>
        /// Remove um quarto através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do quarto</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("Número de quarto inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveQuartosId(id);
        }

        /// <summary>
        /// Atualiza os dados de um quarto existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do quarto</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(Quarto nova_versao)
        {
            if (nova_versao is null) throw new ArgumentNullException(nameof(nova_versao));
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateQuartos(nova_versao);
        }
    }
}
