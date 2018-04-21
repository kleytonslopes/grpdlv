using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoDelivery.Nucleo.Types
{
    public enum EErrosCode
    {
        NotDefined = 0,
        WithOutConnection = 1,
        ConnectionIsOpen = 2,
        WithOutTransaction = 3,
    }
}
