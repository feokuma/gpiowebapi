# Gpio WebApi
Esta aplicação é uma WebApi onde os endpoints são feitos para controlar um pino da Raspberry Pi. Neste pino foi conectado um rele para controlar o acionamento de uma lâmpada. 

## Tecnologias
- [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [System.Device.Gpio](https://www.nuget.org/packages/System.Device.Gpio/)
- [Raspberry Pi](https://www.raspberrypi.com/)
- [Relé](https://www.eletrogate.com/modulo-rele-1-canal-5v)

## Configuração da Raspberry Pi

Para executar a aplicação na Raspberry Pi, é necessário instalar o dotnet. Para isso, siga as instruções desta [documentação](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-install-script). Para instalar o **.NET 8**, utilize o seguinte comando com o script obtido seguindo a documentação. 

```shell
./dotnet_install.sh --channel 8.0
```
Ao final da execução do script, a versão correta para executar este projeto estará instalada na Raspberry Pi, mas ainda é necessário fazer uma configuração para que o **dotnet-cli** fique acessível em qualquer diretório no sistema.


## Compilando a aplicação no PC e transferindo para a Raspberry Pi

Para uma melhor experiência no desenvolvimento e compilação da aplicação, utilizamos um PC para ter disponíveis ferramentas de desenvolvimento e uma melhor performance nas execuções de tarefas como o build da aplicação.

A aplicação está configurada para utilizar o **GPIO 4** ou o **Pino Físico 8** da Raspberry Pi. Utilize este Gpio para controlar o rele que irá acionar a lâmpada. 

### Compilação cruzada

Como é possível imaginar, o código compilado para o PC não funciona na Raspberry Pi por terem processadores com arquiteturas diferentes. Para gerar os binários compatíveis com a arquitetura ARM, execute o seguinte comando. 

```shell
dotnet build -c Release -r linux-arm
```
Este comando irá gerar os arquivos compilados em um diretorio sementante ao seguinte `/bin/Release/net8.0/linux-arm`. 


### Transferindo os arquivos para a Raspberry Pi

Existem várias formas de enviar os dados para a Raspberry Pi. O método que costumo utilizar é com o utilitário [scp](https://en.wikipedia.org/wiki/Secure_copy_protocol). Abaixo está um exemplo utilizando este utilitário.

```shell
scp bin/Release/net8.0/linux-arm/* pi@<ip da raspberrypi>:/home/pi/gpiowebapi/
```
Neste caso estamos enviando os arquivos para um diretório chamado `gpiowebapi` na home do raspberrypi.

### Executando a aplicação na Raspberry Pi

Uma vez no terminal da Raspberry Pi, utilize o seguinte comando para executar a WebApi.

```shell
pi@raspberrypi ~/gpiowebapi $ dotnet run
```
Ao executar este comando já será possível acessar o Swagger desta aplicação. 
