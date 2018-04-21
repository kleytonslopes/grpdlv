using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoDelivery.Entidades;
using GrupoDelivery.Entidades.Mapping;
using GrupoDelivery.Nucleo;

namespace GrupoDelivery.AcessoDados
{
    public class MapaDAO : MapaModelo, IDisposable
    {
        private readonly Connection con;

        public MapaDAO(Connection connection)
        {
            this.con = connection;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void InsertModelo(Modelo modelo)
        {
            try
            {

            }
            catch (System.Exception ex)
            {
                throw new InvalidProgramException($"ERRO ON \"InsertModelo\" : {Environment.NewLine}{ex.ToString()}");
            }
        }
    }
}
