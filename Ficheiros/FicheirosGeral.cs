/*
 * Nome: FicheirosGeral.cs
 * Autor: Diogo Silva
 * Data de Criação: 29/12/2025
 * Última Atualização: 29/12/2025
 * Descrição: Leitura e Escrita de ficheiros de forma generica
*/
using System.Runtime.Serialization.Formatters.Binary;

namespace Ficheiros
{
    /// <summary>
    /// Classe genérica para criação e leitura de ficheiros binários
    /// </summary>
    public static class Ficheiro<T>
    {
        /// <summary>
        /// Guarda uma lista de objetos num ficheiro
        /// <param name="caminho">localização do ficheiro</param>
        /// <param name="dados"/>lista de dados para guardar</param>
        /// </summary>
        /// <returns>Se Guardou ou não</returns>
        public static bool Guardar(string caminho, List<T> dados)
        {
            try
            {
                #pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(caminho,File.Exists(caminho) ? FileMode.Create : FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, dados);
                return true;
                #pragma warning restore SYSLIB0011
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lê uma lista de objetos a partir de um ficheiro
        /// <param name="caminho"/>caminho onde tem de ler</param>
        /// </summary>
        /// <returns> Devolve Lista com ficheiros</returns>
        public static List<T>? Ler(string caminho)
        {
            try
            {
                if (!File.Exists(caminho))
                    return new List<T>();
                #pragma warning disable SYSLIB0011
                using FileStream fs = new FileStream(caminho, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                return (List<T>)bf.Deserialize(fs);
                #pragma warning restore SYSLIB0011
            }
            catch
            {
                return null;    
            }
        }
    }
}
