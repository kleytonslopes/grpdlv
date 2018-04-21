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
    public class ModeloNegocio : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void InsertModelo(Modelo modelo)
        {
            Connection con = null;

            try
            {
                con = new Connection();
                con.OpenConnection();
                con.BeginTransaction();

                using (ModeloDAO modeloDao = new ModeloDAO(con))
                {
                    if (modelo.IdModelo > 0)
                        throw ErroMessage.Operation("O Id do Modelo não pode ser Atribuido a um novo registro!");
                    if (modelo.PrecoModelo <= 0)
                        throw ErroMessage.Operation("O Preço do Modelo não pode ser Negativo ou Ígual a 0.00!");
                    if (String.IsNullOrWhiteSpace(modelo.DescricaoModelo))
                        throw ErroMessage.Operation("A Descrição do Modelo deve conter um valor!");

                    modeloDao.InsertModelo(modelo);
                }

                con.Commit();
            }
            catch (System.Exception ex)
            {
                if (con != null)
                    con.RollBack();

                throw ErroMessage.ProgramException("InsertModelo", ex);
            }
            finally
            {
                if (con != null)
                    con.CloseConnection();
            }
        }

        public Modelo SelectModeloById(Int32 id)
        {
            Connection con = null;

            try
            {
                con = new Connection();
                con.OpenConnection();

                using (ModeloDAO modeloDao = new ModeloDAO(con))
                {
                    DataTable table = modeloDao.SelectModelo(id);
                    if (table != null)
                        return Modelo.FixDataTable(table).FirstOrDefault();

                    return null;
                }
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectModeloById", ex);
            }
            finally
            {
                if (con != null)
                    con.CloseConnection();
            }
        }
    }
}
