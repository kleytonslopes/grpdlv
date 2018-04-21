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
        protected static readonly String mTabelaModelo     = "T_MODELO";
#region Columns
        protected static readonly String mId               = "INT_MODELO";
        protected static readonly String mDescricaoModelo  = "VARCHAR_MODELO";
        protected static readonly String mInteiro64Modelo  = "BIG_INT_MODELO";
        protected static readonly String mStatusModelo     = "BIT_MODEDLO";
        protected static readonly String mPrecoModelo      = "DECIMAL_MODELO";
        #endregion
        #region Params
        protected static readonly String pId               = "@INTMODELO";
        protected static readonly String pDescricaoModelo  = "@VARCHARMODELO";
        protected static readonly String pInteiro64Modelo  = "@BIGINTMODELO";
        protected static readonly String pStatusModelo     = "@BITMODEDLO";
        protected static readonly String pPrecoModelo      = "@DECIMALMODELO";
        #endregion
    }
}
