using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoDelivery.Entidades.Helper;
using GrupoDelivery.Entidades.Mapping;

namespace GrupoDelivery.Entidades
{
    public class Modelo: MapaModelo
    {
        private Int32 _idModelo;
        private String _descricaoModelo;
        private Int64 _inteiro64Modelo;
        private Boolean _statusModelo;
        private Decimal _precoModelo;

        public int IdModelo { get => _idModelo; private set => _idModelo = value; }
        public string DescricaoModelo { get => _descricaoModelo;
            set
            {
                if (value.Length > 50)
                    throw new InvalidOperationException("Limite de 50 caracteres para a Descrição do Modelo ultrapassados!");

                _descricaoModelo = value;
            }
        }
        public long Inteiro64Modelo { get => _inteiro64Modelo; set => _inteiro64Modelo = value; }
        public bool StatusModelo { get => _statusModelo; set => _statusModelo = value; }
        public decimal PrecoModelo { get => _precoModelo; set => _precoModelo = value; }

        /// <summary>
        /// Retorna para uma Lista de Objeto os dados da DataTable
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<Modelo> FixDataTable(DataTable table)
        {
            return (from DataRow row in table.Rows select new Modelo
            {
                _idModelo = ParseToInt32(row, mId),
                DescricaoModelo = ParseToString(row, mDescricaoModelo),
                StatusModelo = ParseToBoolean(row, mStatusModelo),
                PrecoModelo = ParseToDecimal(row, mPrecoModelo),
                Inteiro64Modelo = ParseToInt64(row, mInteiro64Modelo)
            }).ToList();
        }
    }
}
