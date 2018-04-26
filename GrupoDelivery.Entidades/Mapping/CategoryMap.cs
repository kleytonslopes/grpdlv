using GrupoDelivery.Entidades.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Entidades.Mapping
{
    public abstract class CategoryMap : DataParse
    {

        protected static readonly String mCategoryTable = "T_CATEGORY";

        #region Columns
        protected static readonly String mIdCategory  = "CATEGORY_ID";
        protected static readonly String mName = "CATEGORY_NAME";
        protected static readonly String mDescription = "CATEGORY_DESCRIPTION";
        #endregion

        #region Params
        protected static readonly String pIdCategory = "@CATEGORYID";
        protected static readonly String pName = "@CATEGORYNAME";
        protected static readonly String pDescription = "@CATEGORYDESCRIPTION";
        #endregion

    }
}
