using AppTransacaoFinanceira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransacaoFinanceira.Interfaces
{
    public interface IAcessoDados
    {
        T getSaldo<T>(long id);
        bool Atualizar<T>(T dado) where T : ContaSaldo;
    }
}
