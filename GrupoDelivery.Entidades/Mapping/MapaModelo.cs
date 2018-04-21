using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoDelivery.Entidades.Helper;

namespace GrupoDelivery.Entidades.Mapping
{
    public abstract class MapaModelo : DataParse
    {
        public static readonly String mTabelaModelo     = "T_MODELO";
        public static readonly String mId               = "INT_MODELO";
        public static readonly String mDescricaoModelo  = "VARCHAR_MODELO";
        public static readonly String mInteiro64Modelo  = "BIG_INT_MODELO";
        public static readonly String mStatusModelo     = "BIT_MODEDLO";
        public static readonly String mPrecoModelo      = "DECIMAL_MODELO";
    }
}
