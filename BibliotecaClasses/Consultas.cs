/// <summary>
/// Autor: a31504 Diogo Silva
/// Data: 15/11/2025  
/// Nome: Consultas.cs
/// Descrição: As classes neste ficheiro servem para guardar as informações de consultas em especifico
/// </summary>


using BibliotecaClasses;
using System;

namespace BibliotecaClasses
{
    /// <summary>
    /// Classe consulta para guardar as consultas do hospital
    /// </summary>
    public class Consulta
    {
        private int id;
        private Paciente paciente;
        private Medico medicoId;
        private DateTime dataConsulta;
        private Exame exame; //Posteriormente adicionar uma Estrutura de dados pois uma consula pode resultar em vários exames
        private Diagnostico diagnostico; //Posteriormente adicionar uma Estrutura de dados pois uma consula pode resultar em vários exames
        private decimal custo;


        public Consulta() { }

        public Consulta(int id, Paciente pacienteId, Medico medicoId, DateTime dataConsulta)
        {
            this.id = id;
            this.paciente = pacienteId;
            this.medicoId = medicoId;
            this.dataConsulta = dataConsulta;
        }

        public int Id { get { return id; } set { id = value; } }
        public Paciente Paciente { get { return paciente; } set { paciente = value; } }
        public Medico MedicoId { get { return medicoId; } set { medicoId = value; } }
        public DateTime DataConsulta { get { return dataConsulta; } set { dataConsulta = value; } }
        public decimal Custo { get { return custo; } set { custo = value; } }
        /// <summary>
        /// Adiciona um exame à consulta
        /// </summary>
        /// <param name="exame">Exame a adicionar</param>
        /// <returns>cod de sucesso/erro</returns>
        public int AdicionarExame(Exame exame)
        {
            //falta adicionar estrutura de dados
            return 1;
        }
        /// <summary>
        /// Remove um exame pelo objeto.
        /// </summary>
        /// <param name="exame">Exame a remover</param>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverExame(Exame exame)
        {
            //falta adicionar estrutura de dados
            return 1;
        }
        /// <summary>
        /// Remove um exame pelo ID.
        /// </summary>
        /// <param name="exameId">ID do exame a remover</param>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverExame(int exameId)
        {
            //falta adicionar estrutura de dados
            return 1;
        }

        /// <summary>
        /// Devolve todos os exames da consulta.
        /// </summary>
        /// <returns>Estrutura de dados dos exames procedesntes da consulta</returns>
        public Exame ListarExames()
        {
            //falta adicionar estrutura de dados
            return new Exame();
        }
        /// <summary>
        /// Adiciona um diagnóstico à consulta.
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a adicionar</param>
        /// <returns>cod de sucesso/erro</returns>
        public int AdicionarDiagnostico(Diagnostico exame)
        {
            //falta adicionar estrutura de dados
            return 1;
        }
        /// <summary>
        /// Remove um diagnóstico pelo objeto.
        /// </summary>
        /// <param name="diagnostico">Diagnóstico a remover</param>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverDiagnostico(Diagnostico exame)
        {
            //falta adicionar estrutura de dados
            return 1;
        }
        /// <summary>
        /// Remove um diagnóstico pelo ID.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico a remover</param>
        /// <returns>cod de sucesso/erro</returns>
        public int RemoverDiagnostico(int diagnosticoId)
        {
            //falta adicionar estrutura de dados
            return 1;
        }

        /// <summary>
        /// Devolve todos os diagnósticos da consulta.
        /// </summary>
        /// <returns>Estrutura de dados de diagnosticos procedentes da consulta</returns>
        public Diagnostico ListarDiagnostico()
        {
            //falta adicionar estrutura de dados
            return new Diagnostico();
        }
        /// <summary>
        /// Soma o custo total resultante da consulta.
        /// </summary>
        /// <returns>Valor total em decimal</returns>
        public decimal CalcularCustoTotal()
        {
            //falta adicionar estrutura de dados
            return 0.00M;
        }
        public override string ToString()
        {
            return $"Consulta[id={id}, data={dataConsulta:yyyy-MM-dd HH:mm}, paciente='{paciente?.Nome} {paciente?.Sobrenome}', " +
                   $"medico='{medicoId?.Nome} {medicoId?.Sobrenome}', custo={custo:F2}€]";
        }
        #region Operadores
        public static bool operator ==(Consulta esquerda, Consulta direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id == direita.id;
        }
        public static bool operator !=(Consulta esquerda, Consulta direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }
    /// <summary>
    /// Classe para guardar diagnósticos
    /// </summary>
    public class Diagnostico
    {
        private int id;
        private string descricao;

        public Diagnostico() { }

        public Diagnostico(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Descricao { get { return descricao; } set { descricao = value; } }
        public override string ToString()
        {
            return $"Diagnostico[id={id}, descricao='{descricao}']";
        }
    }
    /// <summary>
    /// Classe para guardar Exames pedidos/realizados 
    /// </summary>
    public class Exame
    {
        private int id;
        private Consulta consultaId;
        private string tipo;
        private ResultadoExame resultado;
        private bool realizado;
        private decimal custo;

        public Exame() { }

        public Exame(int id, Consulta consultaId, string tipo)
        {
            this.id = id;
            this.consultaId = consultaId;
            this.tipo = tipo;
            this.realizado = false;
            this.custo = 0;
            this.resultado = new ResultadoExame();
        }

        public int Id { get { return id; } set { id = value; } }
        public Consulta ConsultaId { get { return consultaId; } set { consultaId = value; } }
        public string Tipo { get { return tipo; } set { tipo = value; } }
        public ResultadoExame Resultado{get { return resultado; } set { resultado = value; } }
        public bool Realizado {get { return realizado; } set { realizado=value; } }
        public decimal Custo { get {    return custo; } set {   custo = value; } }
        public override string ToString()
        {
            return $"Exame[id={id}, tipo='{tipo}', realizado={realizado}, custo={custo:F2}€, " +
                   $"consultaId={consultaId?.Id}]";
        }

        #region Operadores
        public static bool operator ==(Exame esquerda, Exame direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id == direita.id;
        }
        public static bool operator !=(Exame esquerda, Exame direita)
        {
            if (ReferenceEquals(esquerda, direita))
                return true;

            if (ReferenceEquals(esquerda, null) || ReferenceEquals(direita, null))
                return false;
            return esquerda.id != direita.id;
        }
        #endregion
    }
    /// <summary>
    /// Classe para guardar o resultado dos exmes
    /// </summary>
    public class ResultadoExame
    {
        private int id;
        private string resultado;

        public ResultadoExame() {
            this.id = -1;
            this.resultado = string.Empty;
        }

        public ResultadoExame(int id, string resultado)
        {
            this.id = id;
            this.resultado = resultado;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Resultado { get { return resultado; } set { resultado = value; } }
        public override string ToString()
        {
            return $"ResultadoExame[id={id}, resultado='{resultado}']";
        }
    }

}
