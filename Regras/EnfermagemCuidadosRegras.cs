/*
 * Nome: EnfermagemCuidadosRegras.cs
 * Autor: Diogo Silva
 * Data de Cria��o: 13/12/2025
 * �ltima Atualiza��o: 26/12/2025
 * Descri��o: Este ficheiro serve para servir de interm�dio entre o programa e os dados para a classe EnfermagemCuidado 
*/
using Bo;
using Dados;
using Interfaces;

namespace Regras
{
    /// <summary>
    /// Classe de Regras que gere classe EnfermagemCuidado
    /// </summary>
    public class EnfermagemCuidadosRegras : ICrud<EnfermagemCuidado, int>
    {
        private EnfermagemCuidados dados;

        public EnfermagemCuidadosRegras()
        {
            dados = new EnfermagemCuidados();
        }

        public EnfermagemCuidadosRegras(EnfermagemCuidados dados)
        {
            this.dados = dados;
        }

        /// <summary>
        /// Lista todos os cuidados de enfermagem existentes
        /// </summary>
        /// <returns>Lista de objetos EnfermagemCuidado</returns>
        public List<EnfermagemCuidado> Listar()
        {
            return dados.ListaCuidados();
        }

        /// <summary>
        /// Verifica se um cuidado de enfermagem já existe
        /// </summary>
        /// <param name="cuidado">Cuidado de enfermagem a verificar</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(EnfermagemCuidado cuidado)
        {
            ArgumentNullException.ThrowIfNull(cuidado);
            return dados.JaExiste(cuidado);
        }

        /// <summary>
        /// Verifica se existe um cuidado de enfermagem com o identificador indicado
        /// </summary>
        /// <param name="id">Identificador do cuidado</param>
        /// <returns>True se existir, False caso contrário</returns>
        public bool JaExiste(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.JaExiste(id);
        }

        /// <summary>
        /// Procura um cuidado de enfermagem pelo seu identificador
        /// </summary>
        /// <param name="id">Identificador do cuidado</param>
        /// <returns>Objeto EnfermagemCuidado se encontrado, ou null</returns>
        public EnfermagemCuidado? BuscarPorId(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            return dados.ObterEnfermagemCuidado(id);
        }

        /// <summary>
        /// Insere um novo cuidado de enfermagem
        /// </summary>
        /// <param name="cuidado">Cuidado de enfermagem a inserir</param>
        /// <returns>True se inserido com sucesso, False se já existir</returns>
        public bool Inserir(EnfermagemCuidado cuidado)
        {
            ArgumentNullException.ThrowIfNull(cuidado);
            if (this.JaExiste(cuidado)) return false;
            return dados.InsereEnfermagemCuidado(cuidado);
        }

        /// <summary>
        /// Remove um cuidado de enfermagem existente
        /// </summary>
        /// <param name="cuidado">Cuidado de enfermagem a remover</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(EnfermagemCuidado cuidado)
        {
            ArgumentNullException.ThrowIfNull(cuidado);
            if (!this.JaExiste(cuidado)) return false;
            return dados.RemoveEnfermagemCuidado(cuidado);
        }

        /// <summary>
        /// Remove um cuidado de enfermagem através do seu identificador
        /// </summary>
        /// <param name="id">Identificador do cuidado</param>
        /// <returns>True se removido com sucesso, False se não existir</returns>
        public bool Remover(int id)
        {
            if (id < 0) throw new ArgumentException("ID inválido");
            if (!this.JaExiste(id)) return false;
            return dados.RemoveEnfermagemCuidado(id);
        }

        /// <summary>
        /// Atualiza os dados de um cuidado de enfermagem existente
        /// </summary>
        /// <param name="nova_versao">Nova versão do cuidado de enfermagem</param>
        /// <returns>True se atualizado com sucesso, False se não existir</returns>
        public bool Atualizar(EnfermagemCuidado nova_versao)
        {
            ArgumentNullException.ThrowIfNull(nova_versao);
            if (!this.JaExiste(nova_versao)) return false;
            return dados.UpdateEnfermagemCuidado(nova_versao);
        }
    }
}
