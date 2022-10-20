using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes;

public class VeiculoTestes : IDisposable
{
    private Veiculo veiculo;
    // Permite gerar consoles no teste
    public ITestOutputHelper SaidaConsoleTeste;

    //Sempre antes de executar um m�todo, chama o construtor
    public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste) 
    {
        SaidaConsoleTeste = _saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Construtor invocado.");
        veiculo = new Veiculo();
    }

    [Fact]
    public void TestaVeiculoAcelerarComParametro10()
    {
        //Arrange
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFrearComParametro10()
    {
        //Arrange
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
        //Act
        //Assert
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact(Skip = "Desnecess�rio por conta do Setup")]
    public void TestaConstrutorDoVeiculoComParametroVinicius()
    {
        //Arrange
        Veiculo veiculo2 = new Veiculo("Vin�cius");
        //Act
        //Assert
        Assert.Equal("Vin�cius", veiculo2.Proprietario);
    }

    //[Fact(DisplayName = "Teste n�5", Skip = "Teste ainda n�o implementado. Ignorar")]
    [Fact(Skip = "Teste ainda n�o implementado. Ignorar")]
    public void ValidaNomeProprietario()
    { 

    }

    [Fact]
    public void FichaDeInformacaoDoVeiculo()
    {
        //Arrange
        veiculo.Proprietario = "Vin�cius Fregati";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Placa = "ZAP-7419";
        veiculo.Cor = "Azul";
        veiculo.Modelo = "Variante";

        //Act
        string dados = veiculo.ToString();

        //Assert
        Assert.Contains("Ficha do Ve�culo:", dados);
    }

    public void Dispose()
    {
        SaidaConsoleTeste.WriteLine("Dispose invocado.");
    }
}