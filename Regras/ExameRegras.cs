/*
 * Nome: ExameRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe Exame 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe Exame
    /// </summary>
    public class ExameRegras : ICrud<Exame, int>
    {
        private Exames dados;

        public ExameRegras()
        {
            dados = new Exames();
        }

        public ExameRegras(Exames dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os exames existentes
        /// </summary>
        /// <returns>Lista de objetos Exame</returns>
        public List<Exame> Listar()
        {
            return dados.ListaExames();
        }

        /// <summary>
        /// Verifica se um exame já existe
        /// </summary>
        /// <param name="exame">Exame a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(Exame exame)
        {
            if (exame is null) throw new ArgumentNullException(nameof(exame));
            return dados.JaExiste(exame);
        }

        /// <summary>
        /// Verifica se existe um exame com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do exame</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura um exame pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do exame</param>
        /// <returns>Objeto Exame se encontrado, ou null</returns>
        public Exame? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterExame(id);
        }

        /// <summary>
        /// Insere um novo exame
        /// </summary>
        /// <param name="exame">Exame a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(Exame exame)
        {
            if (exame is null) throw new ArgumentNullException(nameof(exame));
            if (this.JaExiste(exame)) return false;
            return dados.InsereExame(exame);
        }

        /// <summary>
        /// Remove um exame existente
        /// </summary>
        /// <param name="exame">Exame a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(Exame exame)
        {
            if (exame is null) throw new ArgumentNullException(nameof(exame));
            if (!this.JaExiste(exame)) return false;
            return dados.RemoveExame(exame);
        }

        /// <summary>
        /// Remove um exame através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do exame</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveExame(id);
        }

        /// <summary>
        /// Atualiza os dados de um exame existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do exame</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(Exame nova_versao)
        {
            if (nova_versao is null) throw new ArgumentNullException(nameof(nova_versao));
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateExame(nova_versao);
        }
    }
}
