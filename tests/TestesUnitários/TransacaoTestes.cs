using System;
using AppTransacaoFinanceira.Data;
using AppTransacaoFinanceira.Interfaces;
using AppTransacaoFinanceira.Models;
using AppTransacaoFinanceira.Service;
using Moq;
using Xunit;


namespace TestesUnitários
{
    public class TransacaoTestes
    {        

        [Fact]
        public void Transferir_Sucesso()
        {
            // Arrange
            var mockAcessoDados = new Mock<IAcessoDados>();
            var contaOrigem = new ContaSaldo(938485762, 180);
            var contaDestino = new ContaSaldo(347586970, 1200);
            var valorTransferencia = 100m;
            var correlationId = 1;

            mockAcessoDados.Setup(a => a.getSaldo<ContaSaldo>(It.Is<long>(id => id == 938485762)))
                           .Returns(contaOrigem);

            mockAcessoDados.Setup(a => a.getSaldo<ContaSaldo>(It.Is<long>(id => id == 347586970)))
                           .Returns(contaDestino);

            var transacaoService = new TransacaoService(mockAcessoDados.Object);

            // Act
            transacaoService.Transferir(correlationId, 938485762, 347586970, valorTransferencia);

            // Assert
            Assert.Equal(80, contaOrigem.Saldo);
            Assert.Equal(1300, contaDestino.Saldo);
            mockAcessoDados.Verify(a => a.Atualizar(contaOrigem), Times.Once);
            mockAcessoDados.Verify(a => a.Atualizar(contaDestino), Times.Once);
        }        
    }
}
