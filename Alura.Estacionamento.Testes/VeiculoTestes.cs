using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class UnitTest1
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrear()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Frear(10);
        //Assert
        //No Assert.Equal, primeiro passamos qual deve ser o valor, depois onde que ele deve verificar.
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaTipoVeiculo()
    {
        //Arrange
        Veiculo veiculo = new Veiculo();
        //Act
        //Assert
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact]
    public void TestaConstrutor()
    {
        //Arrange
        Veiculo veiculo = new Veiculo("Vinícius");
        //Act
        //Assert
        Assert.Equal("Vinícius", veiculo.Proprietario);
    }
}