using GrupoDelivery.Entidades;
using GrupoDelivery.Entidades.Mapping;
using GrupoDelivery.Nucleo;
using GrupoDelivery.Nucleo.Helpers;
using GrupoDelivery.Nucleo.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.AcessoDados
{
    public class CategoryDAO : CategoryMap, IDisposable
    {
        private readonly Connection con;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public CategoryDAO(Connection connection)
        {
            this.con = connection;
        }

        public void InsertCategory(Category category)
        {
            try
            {
                if(con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);
                query.AddQuery($"INSERT INTO {mCategoryTable} ( ");
                query.AddQuery($"   {mName} ");
                query.AddQuery($",  {mDescription} ");
                query.AddQuery($" ) VALUES ( ");
                query.AddQuery($"   {pName} ");
                query.AddQuery($",  {pDescription} ");
                query.AddQuery($");");

                query.AddParam(pIdCategory , category.IdCategory);
                query.AddParam(pName       , category.Name);
                query.AddParam(pDescription, category.Description);

                query.Execute();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("InsertCategory", ex);
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                if (con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);
                query.AddQuery($"UPDATE {mCategoryTable} SET ");
                query.AddQuery($"   {mName} = {pName} ");
                query.AddQuery($" AND ");
                query.AddQuery($"   {mDescription} = {pDescription} ");
                query.AddQuery($" WHERE {mIdCategory} = {pIdCategory} ");

                query.AddParam(pIdCategory , category.IdCategory);
                query.AddParam(pName       , category.Name);
                query.AddParam(pDescription, category.Description);

                query.Execute();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("UpdateCategory", ex);
            }
        }

        public DataTable SelectCategoryById(Int32 id)
        {
            try
            {
                if(con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);

                query.AddQuery($"SELECT * FROM {mCategoryTable} WHERE {mIdCategory} = {pIdCategory}; ");

                query.AddParam(pIdCategory, id);

                return query.ExecuteSelect();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectCategoryById", ex);
            }
        }

        public DataTable SelectCategoryByName(String name)
        {
            try
            {
                if (con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);

                query.AddQuery($"SELECT * FROM {mCategoryTable} WHERE {mName} = {pName}; ");

                query.AddParam(pName, name);

                return query.ExecuteSelect();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectCategoryById", ex);
            }
        }

        public DataTable SelectAllCategory()
        {
            try
            {
                if (con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);

                query.AddQuery($"SELECT * FROM {mCategoryTable}; ");

                return query.ExecuteSelect();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectAllCategory", ex);
            }
        }
    }
}
