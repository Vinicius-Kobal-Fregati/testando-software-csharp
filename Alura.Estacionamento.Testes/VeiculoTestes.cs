using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrearComParametro10()
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
    public void TestaTipoDoVeiculo()
    {
        //Arrange
        Veiculo veiculo = new Veiculo();
        //Act
        //Assert
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact]
    public void TestaConstrutorDoVeiculoComParametroVinicius()
    {
        //Arrange
        Veiculo veiculo = new Veiculo("Vinícius");
        //Act
        //Assert
        Assert.Equal("Vinícius", veiculo.Proprietario);
    }

    //[Fact(DisplayName = "Teste n°5", Skip = "Teste ainda não implementado. Ignorar")]
    [Fact(Skip = "Teste ainda não implementado. Ignorar")]
    public void ValidaNomeProprietario()
    { 

    }

    [Fact]
    public void FichaDeInformacaoDoVeiculo()
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