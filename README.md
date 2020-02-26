# Calculador de Imposto de Renda

Esse é um projeto criado somente para fins de aprendizagem.
Ele foi feito em ASP.NET Core, EF Core e React

## Estrutura do projeto

Dentro do projeto tem 2 pasta: API e Front

A pasta API contém a API feita e ASP.NET Core

E a pasta Front contém o Front feito em React

## Como executar a API

Altere a string de configuração se necessário. Ela está no arquivo `\API\CalculadorImpostoRenda\CalculadorImpostoRenda.API\appsettings.json`.

Para executar a API vá até a pasta `\API\CalculadorImpostoRenda\CalculadorImpostoRenda.API` e execute o comando `dotnet run`

Agora se você abrir o endereço <http://localhost:5000/swagger/index.html> deve abrir uma página com os endpoints da API

## Como executar o Front

Vá até a pasta `\Front\calcular_imposto_renda`

Primeiro execute o comando `npm i` para instalar as dependencias

Depos execute o comando `npm start` para iniciar a aplicação. A página deve abrir automaticamente no navegador
