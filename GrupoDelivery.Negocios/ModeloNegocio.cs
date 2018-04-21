using GrupoDelivery.AcessoDados;
using GrupoDelivery.Entidades;
using GrupoDelivery.Nucleo;
using System;
using System.Collections.Generic;
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

                using (MapaDAO mapaDao = new MapaDAO(con))
                {
                    if (modelo.IdModelo > 0)
                        throw new InvalidOperationException("O Id do Modelo não pode ser Atribuido a um novo registro!");
                    if (modelo.PrecoModelo <= 0)
                        throw new InvalidOperationException("O Preço do Modelo não pode ser Negativo ou Ígual a 0.00!");
                    if (String.IsNullOrWhiteSpace(modelo.DescricaoModelo))
                        throw new InvalidOperationException("A Descrição do Modelo deve conter um valor!");

                    mapaDao.InsertModelo(modelo);
                }

                con.Commit();
            }
            catch (System.Exception ex)
            {
                if (con != null)
                    con.RollBack();

                throw new InvalidProgramException($"{Environment.NewLine}{ex.ToString()}");
            }
        }
    }
}
