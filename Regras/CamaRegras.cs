/*
 * Nome: CamaRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Cama 
*/
using Bo;
using Dados;
using Exceptions;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Cama
    /// </summary>
    public class CamaRegras: ICrud<Cama,int>
    {
        private Camas dados;

        public CamaRegras()
        {
            dados = new Camas();
        }

        public CamaRegras(Camas dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todas as camas existentes
        /// </summary>
        /// <returns>Lista de objetos Cama</returns>
        public List<Cama> Listar()
        {
            return dados.ListaCamas();
        }

        /// <summary>
        /// Verifica se uma cama já existe
        /// </summary>
        /// <param name="cama">Cama a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Cama cama)
        {
            ArgumentNullException.ThrowIfNull(cama);
            return dados.JaExiste(cama);
        }

        /// <summary>
        /// Verifica se existe uma cama com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador da cama</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) { throw new ArgumentException("Id inválido"); }
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura uma cama pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador da cama</param>
        /// <returns>Objeto Cama se encontrado, ou null</returns>
        public Cama? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterCama(id);
        }

        /// <summary>
        /// Insere uma nova cama
        /// </summary>
        /// <param name="cama">Cama a inserir</param>
        /// <returns>True se inserida com sucesso, lança exceção se já existir</returns>
        public bool Inserir(Cama cama)
        {
            ArgumentNullException.ThrowIfNull(cama);
            if (this.JaExiste(cama)) throw new EntidadeDuplicadaException("Cama","id",cama.Id.ToString());
            return dados.InsereCama(cama);
        }

        /// <summary>
        /// Remove uma cama existente
        /// </summary>
        /// <param name="cama">Cama a remover</param>
        /// <returns>True se removida com sucesso, False se não existir</returns>
        public bool Remover(Cama cama)
        {
            ArgumentNullException.ThrowIfNull(cama);
            if (!this.JaExiste(cama)) return false;
            return dados.RemoveCama(cama);
        }

        /// <summary>
        /// Remove uma cama através do seu identificador
        /// </summary>
        /// <param name="id">Identificador da cama</param>
        /// <returns>True se removida com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveCamaPorId(id);
        }

        /// <summary>
        /// Atualiza os dados de uma cama existente
        /// </summary>
        /// <param name="nova_versao">Nova versão da cama</param>
        /// <returns>True se atualizada com sucesso, False se não existir</returns>
        public bool Atualizar(Cama nova_versao)
        {
            ArgumentNullException.ThrowIfNull(nova_versao);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateCama(nova_versao);
        }
    }
}
