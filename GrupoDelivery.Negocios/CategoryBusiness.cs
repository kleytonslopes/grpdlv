using GrupoDelivery.AcessoDados;
using GrupoDelivery.Entidades;
using GrupoDelivery.Nucleo;
using GrupoDelivery.Nucleo.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Negocios
{
    public class CategoryBusiness : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void InsertCategory(Category category)
        {
            Connection con = null;

            try
            {
                con = new Connection();
                con.OpenConnection();
                con.BeginTransaction();

                using (CategoryDAO categoryDao = new CategoryDAO(con))
                {
                    if(category.IdCategory > 0)
                        throw ErroMessage.Operation("O Id da Categoria não pode ser Atribuido a um novo registro!");
                    if(String.IsNullOrWhiteSpace(category.Name))
                        throw ErroMessage.Operation("O Nome da Categoria não pode ser Vazio!");
                    if(String.IsNullOrWhiteSpace(category.Description))
                        throw ErroMessage.Operation("A Descrição da Categoria não pode ser Vazia!");

                    Category tempCategory = SelectCategoryByName(category.Name);

                    if(tempCategory != null)
                        throw ErroMessage.Operation($"Categoria {category.Name} já Cadastrada!");

                    categoryDao.InsertCategory(category);
                }

                con.Commit();
            }
            catch (System.Exception ex)
            {
                if (con != null)
                    con.RollBack();

                throw ErroMessage.ProgramException("InsertCategory", ex);
            }
            finally
            {
                if (con != null)
                    con.CloseConnection();
            }
        }

        public Category SelectCategoryById(Int32 id)
        {
            Connection con = null;

            try
            {
                con = new Connection();
                con.OpenConnection();

                using (CategoryDAO categoryDao = new CategoryDAO(con))
                {
                    DataTable table = categoryDao.SelectCategoryById(id);
                    if (table != null)
                        return Category.FixDataTable(table).FirstOrDefault();

                    return null;
                }
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectCategoryById", ex);
            }
            finally
            {
                if (con != null)
                    con.CloseConnection();
            }
        }

        public Category SelectCategoryByName(String name)
        {
            Connection con = null;

            try
            {
                con = new Connection();
                con.OpenConnection();

                using (CategoryDAO categoryDao = new CategoryDAO(con))
                {
                    DataTable table = categoryDao.SelectCategoryByName(name);
                    if (table != null)
                        return Category.FixDataTable(table).FirstOrDefault();

                    return null;
                }
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectCategoryByName", ex);
            }
            finally
            {
                if (con != null)
                    con.CloseConnection();
            }
        }

        public List<Category> SelectAllCategory()
        {
            Connection con = null;

            try
            {
                con = new Connection();
                con.OpenConnection();

                using (CategoryDAO categoryDao = new CategoryDAO(con))
                {
                    DataTable table = categoryDao.SelectAllCategory();
                    if (table != null)
                        return Category.FixDataTable(table);

                    return null;
                }
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectCategoryByName", ex);
            }
            finally
            {
                if (con != null)
                    con.CloseConnection();
            }
        }
    }
}
