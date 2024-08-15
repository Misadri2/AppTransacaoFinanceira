namespace AppTransacaoFinanceira.Models
{
    public class ContaSaldo
    {
        public ContaSaldo(long conta, decimal saldo)
        {
            Conta = conta;
            Saldo = saldo;
        }

        public long Conta { get; set; }
        public decimal Saldo { get; set; }

    }

}

