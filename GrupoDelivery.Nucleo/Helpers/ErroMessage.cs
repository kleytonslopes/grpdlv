using GrupoDelivery.Nucleo.Properties;
using GrupoDelivery.Nucleo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Nucleo.Helpers
{
    public static class ErroMessage
    {
        private static String Get(EErrosCode errocode)
        {
            switch (errocode)
            {
                case EErrosCode.WithOutConnection:
                    return Resources.WithOutConnection;
                case EErrosCode.WithOutTransaction:
                    return Resources.WithOutTransaction;
                default:
                    return Resources.NotDefined;
            }
        }
        private static String GetOperation(String operation, Exception ex)
        {
            return $"ERRO ON {operation}.{Environment.NewLine}{ex.ToString()}";
        }


        public static InvalidOperationException Operation(EErrosCode withOutConnection)
        {
            return new InvalidOperationException(ErroMessage.Get(EErrosCode.WithOutConnection));
        }

        public static InvalidOperationException Operation(String message)
        {
            return new InvalidOperationException(message);
        }

        public static InvalidProgramException ProgramException(String operation, Exception ex)
        {
            return new InvalidProgramException(ErroMessage.GetOperation(operation, ex));
        }
    }
}
