using AppTransacaoFinanceira.Data;
using AppTransacaoFinanceira.Interfaces;
using AppTransacaoFinanceira.Models;

namespace AppTransacaoFinanceira.Service

{
    public class TransacaoService : ITransacaoFinanceira
    {
        private readonly IAcessoDados _acessoDados;

        public TransacaoService(IAcessoDados acessoDados)
        {
            _acessoDados = acessoDados;
        }

        public void Transferir(int correlationId, long contaOrigem, long contaDestino, decimal valor)
        {
            var contaSaldoOrigem = _acessoDados.getSaldo<ContaSaldo>(contaOrigem);

            if (contaSaldoOrigem == null || contaSaldoOrigem.Saldo < valor)
            {
                Console.WriteLine($"Transacao numero {correlationId} foi cancelada por falta de saldo");
                return;
            }

            var contaSaldoDestino = _acessoDados.getSaldo<ContaSaldo>(contaDestino);

            if (contaSaldoDestino == null)
            {
                Console.WriteLine($"Transacao numero {correlationId} foi cancelada. Conta destino não encontrada.");
                return;
            }

            contaSaldoOrigem.Saldo -= valor;

            contaSaldoDestino.Saldo += valor;

            _acessoDados.Atualizar(contaSaldoOrigem);

            _acessoDados.Atualizar(contaSaldoDestino);

            Console.WriteLine($"Transacao numero {correlationId} foi efetivada com sucesso! Novos saldos: Conta Origem: {contaSaldoOrigem.Saldo} | Conta Destino: {contaSaldoDestino.Saldo}");

        }

    }

}