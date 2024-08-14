using System;
using AppTransacaoFinanceira.Data;
using AppTransacaoFinanceira.Models;
using AppTransacaoFinanceira.Service;
using Xunit;

namespace AppTransacaoFinanceira.Tests
{
    public class TransacaoServiceTests
    {
        private readonly AcessoDados _acessoDados;
        private readonly TransacaoService _transacaoService;

        public TransacaoServiceTests()
        {
            _acessoDados = new AcessoDados();
            _transacaoService = new TransacaoService(_acessoDados);
        }

        [Fact]
        public void Transferir_DeveEfetivarTransacao_QuandoSaldoSuficiente()
        {
            // Arrange
            var correlationId = 1;
            var contaOrigem = 938485762L;
            var contaDestino = 2147483649L;
            var valor = 50m;

            // Act
            _transacaoService.Transferir(correlationId, contaOrigem, contaDestino, valor);

            var contaSaldoOrigem = _acessoDados.GetSaldo<ContaSaldo>((int)contaOrigem);
            var contaSaldoDestino = _acessoDados.GetSaldo<ContaSaldo>((int)contaDestino);

            // Assert
            Assert.Equal(130, contaSaldoOrigem.Saldo); 
            Assert.Equal(50, contaSaldoDestino.Saldo); 
        }

        [Fact]
        public void Transferir_DeveCancelarTransacao_QuandoSaldoInsuficiente()
        {
            // Arrange
            var correlationId = 2;
            var contaOrigem = 2147483649L;
            var contaDestino = 210385733L;
            var valor = 50m;

            // Act
            _transacaoService.Transferir(correlationId, contaOrigem, contaDestino, valor);

            var contaSaldoOrigem = _acessoDados.GetSaldo<ContaSaldo>((int)contaOrigem);
            var contaSaldoDestino = _acessoDados.GetSaldo<ContaSaldo>((int)contaDestino);

            // Assert
            Assert.Equal(0, contaSaldoOrigem.Saldo); 
            Assert.Equal(10, contaSaldoDestino.Saldo); 
        }

        [Fact]
        public void Transferir_DeveCancelarTransacao_QuandoContaDestinoNaoExiste()
        {
            // Arrange
            var correlationId = 3;
            var contaOrigem = 938485762L;
            var contaDestino = 999999999L;
            var valor = 50m;

            // Act
            _transacaoService.Transferir(correlationId, contaOrigem, contaDestino, valor);

            var contaSaldoOrigem = _acessoDados.GetSaldo<ContaSaldo>((int)contaOrigem);
            var contaSaldoDestino = _acessoDados.GetSaldo<ContaSaldo>((int)contaDestino);

            // Assert
            Assert.Equal(180, contaSaldoOrigem.Saldo); 
            Assert.Null(contaSaldoDestino); 
        }
    }
}

