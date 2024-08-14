using AppTransacaoFinanceira.Data;
using AppTransacaoFinanceira.Models;
using Xunit;

namespace AppTransacaoFinanceiraTestes
{
    public class AcessoDadosTeste
    {
        [Fact]
        public void GetSaldo_DeveRetornarSaldoCorreto_QuandoContaExiste()
        {
            // Arrange
            var acessoDados = new AcessoDados();
            var contaId = 938485762;

            // Act
            var contaSaldo = acessoDados.GetSaldo<ContaSaldo>(contaId);

            // Assert
            Assert.NotNull(contaSaldo);
            Assert.Equal(contaId, contaSaldo.Conta);
            Assert.Equal(180, contaSaldo.Saldo);
        }

        [Fact]
        public void GetSaldo_DeveRetornarNull_QuandoContaNaoExiste()
        {
            // Arrange
            var acessoDados = new AcessoDados();
            var contaId = 123456789; // Conta inexistente

            // Act
            var contaSaldo = acessoDados.GetSaldo<ContaSaldo>(contaId);

            // Assert
            Assert.Null(contaSaldo);
        }

        [Fact]
        public void Atualizar_DeveRetornarTrue_QuandoAtualizacaoBemSucedida()
        {
            // Arrange
            var acessoDados = new AcessoDados();
            var contaSaldo = new ContaSaldo(938485762, 200); // Conta existente com novo saldo

            // Act
            var resultado = acessoDados.Atualizar(contaSaldo);
            var contaSaldoAtualizado = acessoDados.GetSaldo<ContaSaldo>(938485762);

            // Assert
            Assert.True(resultado);
            Assert.Equal(200, contaSaldoAtualizado.Saldo);
        }

        [Fact]
        public void Atualizar_DeveRetornarFalse_QuandoAtualizacaoFalha()
        {
            // Arrange
            var acessoDados = new AcessoDados();
            ContaSaldo contaSaldo = null; // Objeto nulo para simular falha

            // Act
            var resultado = acessoDados.Atualizar(contaSaldo);

            // Assert
            Assert.False(resultado);
        }
    }
}