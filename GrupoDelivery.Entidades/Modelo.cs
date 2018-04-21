using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoDelivery.Entidades.Helper;
using GrupoDelivery.Entidades.Mapping;
using GrupoDelivery.Nucleo.Helpers;

namespace GrupoDelivery.Entidades
{
    public class Modelo : MapaModelo
    {
        private Int32 _idModelo;
        private String _descricaoModelo;
        private Int64 _inteiro64Modelo;
        private Boolean _statusModelo;
        private Decimal _precoModelo;

        #region Public Properties
        public int IdModelo { get => _idModelo; private set => _idModelo = value; }
        public string DescricaoModelo
        {
            get => _descricaoModelo;
            private set
            {
                if (value.Length > 50)
                    throw ErroMessage.Operation("Limite de 50 caracteres para a Descrição do Modelo ultrapassados!");

                _descricaoModelo = value;
            }
        }
        public long Inteiro64Modelo { get => _inteiro64Modelo; private set => _inteiro64Modelo = value; }
        public bool StatusModelo { get => _statusModelo; private set => _statusModelo = value; }
        public decimal PrecoModelo
        {
            get => _precoModelo; private set
            {
                if (value <= 0)
                    throw ErroMessage.Operation("Valor Inválido para o Preço. O Valor deve ser maior que Zero!");
                _precoModelo = value;
            }
        }
        #endregion

        #region Public Methods
        public void CriaModelo(String descricao, Decimal preco, Boolean status, Int64 bigint)
        {
            this.DescricaoModelo = descricao;
            this.PrecoModelo = preco;
            this.Inteiro64Modelo = bigint;
            this.StatusModelo = status;
        }

        public void AtualizaPreco(Decimal preco) => this.PrecoModelo = preco;
        public void AtualizaDescricao(String descricao) => this.DescricaoModelo = descricao;
        public void AtualizaStatus(Boolean status) => this.StatusModelo = status;
        public void AtualizaInteiro64(Int64 bigint) => this.Inteiro64Modelo = bigint;

        #endregion

        #region DataFix
        /// <summary>
        /// Retorna para uma Lista de Objeto os dados da DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<Modelo> FixDataTable(DataTable table)
        {
            try
            {
                if (table != null)
                {

                    return (from DataRow row in table.Rows
                            select new Modelo
                            {
                                _idModelo = ParseToInt32(row, mId),
                                DescricaoModelo = ParseToString(row, mDescricaoModelo),
                                StatusModelo = ParseToBoolean(row, mStatusModelo),
                                PrecoModelo = ParseToDecimal(row, mPrecoModelo),
                                Inteiro64Modelo = ParseToInt64(row, mInteiro64Modelo)
                            }).ToList();
                }

                return null;
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("FixDataTable [Modelo]", ex);
            }
        }
        #endregion

    }
}
