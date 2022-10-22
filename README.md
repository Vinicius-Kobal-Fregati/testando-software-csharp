# Projeto do curso Testes em .NET: testando software da Alura
Neste curso eu pude aprender mais sobre testes unitários, boas práticas ao realizar testes, o padrão TDD de programação, como testar métodos (públicos, privados e em vários cenários) e como testar exceções.

## Testando um método
Nosso teste é separado em três partes, pelo padrão AAA (arrange, act e assert).  
Primeiro devemos preparar o código para ser testado, instanciando os objetos e criando as variáveis (arrange), depois devemos executar o método que desejamos testar (act), por fim, faremos a verificação se ele funcionou como o esperado (assert). Essa verificação pode validar se é exatamente igual, se contém ou se retorna uma exceção, além de outros casos.

```c#
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
```

Utilizamos um Fact pois era apenas um caso, mas também podemos testar vários ao mesmo tempo, utilizando a anotação Theory.

## Testando vários cenários de um método
```c#
[Theory]
[InlineData("Maria Andrade", "GDR-1234", "Azul", "Opala")]
[InlineData("Pedro Andrade", "GDR-0101", "Azul", "Corsa")]
public void ValidaFaturamentoComVariosVeiculos(string proprietario,
                                               string placa,
                                               string cor,
                                               string modelo)
{
    //Arrange
    Patio estacionamento = new Patio();
    Veiculo veiculo = new Veiculo();
    veiculo.Proprietario = proprietario;
    veiculo.Placa = placa;
    veiculo.Cor = cor;
    veiculo.Modelo = modelo;

    estacionamento.RegistrarEntradaVeiculo(veiculo);
    estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

    //Act
    double faturamento = estacionamento.TotalFaturado();
    //Assert
    Assert.Equal(2, faturamento);
}
```
Passamos os cenários através do InlineData, passando-os como parâmetros no teste.

## Alterando a mensagem exibida no gerenciador de testes
```c#
[Fact(DisplayName = "Teste n°2")]
public void TestaVeiculoFrear()
{
    //Arrange
    var veiculo = new Veiculo();
    //Act
    veiculo.Frear(10);
    //Assert
    Assert.Equal(-150, veiculo.VelocidadeAtual);
}
```
Ao passarmos o DisplayName na anotação Fact ou Theory, podemos mudar a forma que ela aparece no gerenciador de testes.

## Pulando um teste
```c#
[Fact(Skip ="Teste ainda não implementado. Ignorar")]
public void ValidaNomeProprietario()
{ 

}
```
Podemos passar o Skip na anotação Fact ou Theory, assim nosso teste não será executado.

## Reutilizando o código com setup

Teste antigo sem setup
```c#
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
```

Código com setup
```c#
public VeiculoTestes() 
{
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
```
O construtor do teste é executado toda vez antes do teste rodar, com isso podemos economizar muito código de instanciação e declaração de variáveis.

## Exibindo mensagens no console
Podemos exibir mensagens no corpo do teste, para isso, vamos utilizar o ITestOutputHelper
```c#
public class PatioTeste : IDisposable
{
    private Veiculo veiculo;
    private Patio estacionamento;
    public ITestOutputHelper SaidaConsoleTeste;

    public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
    {
        SaidaConsoleTeste = _saidaConsoleTeste;
        SaidaConsoleTeste.WriteLine("Construtor invocado.");
        veiculo = new Veiculo();
        estacionamento = new Patio();
    }
```

## Limpando memória com o cleanup
A memória é liberada através do Garbage Collector, contudo, através da interface IDisposable, podemos realizar essa limpeza antes da ação dele.

```c#
public class VeiculoTestes : IDisposable

[Fact]
public void TestaVeiculoFrearComParametro10()
{
    //Arrange
    var veiculo = new Veiculo();
    //Act
    veiculo.Frear(10);
    //Assert
    Assert.Equal(-150, veiculo.VelocidadeAtual);
}

public void Dispose()
{
    SaidaConsoleTeste.WriteLine("Dispose invocado.");
}
```

## Como testar métodos privados?
Não pode-se testar diretamente esse método, por conta de sua visibilidade, não podemos também alterar seu tipo de visibilidade só para poder testar. O que deve ser feito é testar algum método público que invoque o método privado, assim ele será testado de forma indireta.

## Como codificar usando o TDD?
TDD é test driven development (desenvolvimento guiado por testes), essa técnica de desenvolvimento inverte a ordem que normalmente é realizada durante a programação (criar novas funcionalidade e depois testar), no TDD, primeiro cria-se o teste (obviamente ele irá falhar), depois desenvolve o método, quando seu teste passar, ele estará pronto.

Na classe de teste, adicionaremos esse código:
```c#
[Fact]
public void AlterarDadosVeiculo()
{
    //Arrange
    Patio estacionamento = new Patio();
    Veiculo veiculo = new Veiculo();
    veiculo.Proprietario = "Vinícius Fregati";
    veiculo.Tipo = TipoVeiculo.Automovel;
    veiculo.Cor = "Verde";
    veiculo.Modelo = "Fusca";
    veiculo.Placa = "asd-9999";

    estacionamento.RegistrarEntradaVeiculo(veiculo);

    Veiculo veiculoAlterado = new Veiculo();
    veiculoAlterado.Proprietario = "Vinícius Fregati";
    veiculoAlterado.Tipo = TipoVeiculo.Automovel;
    veiculoAlterado.Cor = "Preto"; //Alterado
    veiculoAlterado.Modelo = "Fusca";
    veiculoAlterado.Placa = "asd-9999";

    //Act
    Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

    //Assert
    Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
}
```
Posteriormente, foi adicionado a implementação do método AlterarDadosVeiculo na sua classe
```c#
public Veiculo AlterarDadosVeiculo(Veiculo veiculoAlterado)
{
    Veiculo veiculoTemp = (from veiculo in this.Veiculos
                           where veiculo.Placa == veiculoAlterado.Placa
                           select veiculo).SingleOrDefault(); // LINQ

    veiculoTemp.AlterarDados(veiculoAlterado);

    return veiculoTemp;
}
```
Trabalhando desse jeito, logo ao desenvolver o método já sabemos se ele está funcionando como o esperado.

## O que é teste de regressão?
É uma técnica de testes onde se realiza a reexecução dos testes criados após modificar o comportamento de algum método ou criar algo novo que possa comprometer o funcionamento do código, caso o método mude bastante, pode ser necessário também atualizar seu teste, para ele voltar a passar com sucesso e mostrar se seu método está funcionando corretamente.
