namespace AppTransacaoFinanceira.Models
{
    public class Transacao
    {
        public int CorrelationId { get; set; }
        public DateTime Datetime { get; set; }
        public long ContaOrigem { get; set; }
        public long ContaDestino { get; set; }
        public decimal Valor { get; set; }
    }
}
