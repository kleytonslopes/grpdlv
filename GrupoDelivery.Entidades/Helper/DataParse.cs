using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Entidades.Helper
{
    public abstract class DataParse
    {
        /// <summary>
        /// Converter dados da row para String
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Valor da Row, em caso de Erro String.Empty</returns>
        public static String ParseToString(DataRow row, String column)
        {
            try
            {
                return row[column].ToString();
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Converter dados da row para Int32
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Valor da Row, em caso de Erro 0</returns>
        public static Int32 ParseToInt32(DataRow row, String column)
        {
            try
            {
                String value = row[column].ToString();
                if (!String.IsNullOrWhiteSpace(value))
                    return Convert.ToInt32(value);
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converter dados da row para Int64
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Valor da Row, em caso de Erro 0</returns>
        public static Int64 ParseToInt64(DataRow row, String column)
        {
            try
            {
                String value = row[column].ToString();
                if (!String.IsNullOrWhiteSpace(value))
                    return Convert.ToInt64(value);
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converter dados da row para Decimal
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Valor da Row, em caso de Erro 0</returns>
        public static Decimal ParseToDecimal(DataRow row, String column)
        {
            try
            {
                String value = row[column].ToString();
                if (!String.IsNullOrWhiteSpace(value))
                    return Convert.ToDecimal(value);
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converter dados da row para Float
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Valor da Row, em caso de Erro 0</returns>
        public static float ParseToFloat(DataRow row, String column)
        {
            try
            {
                String value = row[column].ToString();
                if (!String.IsNullOrWhiteSpace(value))
                    return float.Parse(value);
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converter dados da row para Boolean
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns>Valor da Row, em caso de Erro false</returns>
        public static Boolean ParseToBoolean(DataRow row, String column)
        {
            try
            {
                String value = row[column].ToString();
                if (!String.IsNullOrWhiteSpace(value))
                    return Convert.ToBoolean(value);
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
