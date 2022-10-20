using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
    [Fact(DisplayName = "Teste n°1")]
    [Trait("Funcionalidade", "Acelerar")]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact(DisplayName = "Teste n°2")]
    [Trait("Funcionalidade", "Frear")]
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

    [Fact(DisplayName = "Teste n°3")]
    public void TestaTipoVeiculo()
    {
        //Arrange
        Veiculo veiculo = new Veiculo();
        //Act
        //Assert
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact(DisplayName = "Teste n°4")]
    public void TestaConstrutor()
    {
        //Arrange
        Veiculo veiculo = new Veiculo("Vinícius");
        //Act
        //Assert
        Assert.Equal("Vinícius", veiculo.Proprietario);
    }

    [Fact(DisplayName = "Teste n°5", Skip ="Teste ainda não implementado. Ignorar")]
    public void ValidaNomeProprietario()
    { 

    }

    [Fact]
    public void DadosVeiculo()
    {
        //Arrange
        Veiculo carro = new Veiculo();
        carro.Proprietario = "Vinícius Fregati";
        carro.Tipo = TipoVeiculo.Automovel;
        carro.Placa = "ZAP-7419";
        carro.Cor = "Azul";
        carro.Modelo = "Variante";

        //Act
        string dados = carro.ToString();

        //Assert
        Assert.Contains("Ficha do Veículo:", dados);
    }
}