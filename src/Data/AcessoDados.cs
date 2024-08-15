using AppTransacaoFinanceira.Interfaces;
using AppTransacaoFinanceira.Models;

namespace AppTransacaoFinanceira.Data
{
    public class AcessoDados : IAcessoDados
    {
        private readonly List<ContaSaldo> _tabelaSaldos;

        public AcessoDados()
        {
            _tabelaSaldos = new List<ContaSaldo>
            {
                new ContaSaldo(938485762, 180),

                new ContaSaldo(347586970, 1200),

                new ContaSaldo(2147483649, 0),

                new ContaSaldo(675869708, 4900),

                new ContaSaldo(238596054, 478),

                new ContaSaldo(573659065, 787),

                new ContaSaldo(210385733, 10),

                new ContaSaldo(674038564, 400),

                new ContaSaldo(563856300, 1200)

            };

        }

        public T getSaldo<T>(long id)
        {
            return (T)Convert.ChangeType(_tabelaSaldos.Find(x => x.Conta == id), typeof(T));
        }

        public bool Atualizar<T>(T dado) where T : ContaSaldo
        {
            try
            {
                var item = dado as ContaSaldo;
                _tabelaSaldos.RemoveAll(x => x.Conta == item.Conta);
                _tabelaSaldos.Add(item);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }
    }
}
