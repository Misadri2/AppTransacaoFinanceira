using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransacaoFinanceira.Interfaces
{
    public interface ITransacaoFinanceira
    {
        void Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor);
    }
}
