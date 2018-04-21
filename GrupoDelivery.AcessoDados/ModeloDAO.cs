using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using GrupoDelivery.Entidades;
using GrupoDelivery.Entidades.Mapping;
using GrupoDelivery.Nucleo;
using GrupoDelivery.Nucleo.Helpers;
using GrupoDelivery.Nucleo.Types;

namespace GrupoDelivery.AcessoDados
{
    public class ModeloDAO : MapaModelo, IDisposable
    {
        private readonly Connection con;

        public ModeloDAO(Connection connection)
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
                if (con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);
                query.AddQuery($"INSERT INTO {mTabelaModelo} ( ");
                query.AddQuery($"   {mDescricaoModelo}, ");
                query.AddQuery($",   {mInteiro64Modelo} ");
                query.AddQuery($",   {mStatusModelo} ");
                query.AddQuery($",   {mPrecoModelo} ");
                query.AddQuery($" ) VALUES ( ");
                query.AddQuery($"   {pDescricaoModelo} ");
                query.AddQuery($",   {pInteiro64Modelo} ");
                query.AddQuery($",   {pStatusModelo} ");
                query.AddQuery($",   {pPrecoModelo} ");
                query.AddQuery($");");

                query.AddParam(pDescricaoModelo, modelo.DescricaoModelo);
                query.AddParam(pInteiro64Modelo, modelo.Inteiro64Modelo);
                query.AddParam(pStatusModelo   , modelo.StatusModelo   );
                query.AddParam(pPrecoModelo    , modelo.PrecoModelo    );

                query.Execute();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("InsertModelo", ex);
            }
        }

        public DataTable SelectModelo(Int32 id)
        {
            try
            {
                if (con == null)
                    throw ErroMessage.Operation(EErrosCode.WithOutConnection);

                Query query = new Query(con);

                query.AddQuery($"SELECT * FROM {mTabelaModelo} WHERE {mId} = {pId};");

                query.AddParam(pId, id);

                return query.ExecuteSelect();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("SelectModelo", ex);
            }
        }
    }
}
