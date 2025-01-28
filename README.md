# ConsultaDadosDengueApi-.netCoreApi

Visão Geral
O projeto ConsultaDadosDengueApi é uma aplicação ASP.NET Core que permite consultar e obter dados relacionados aos casos de dengue. A aplicação fornece uma API para buscar dados de dengue por semana e ano, facilitando o acesso a essas informações sem utilizar um banco de dados.

Estrutura do Projeto
A estrutura do projeto é organizada da seguinte maneira:

Controllers: Contém os controladores da aplicação, responsáveis por lidar com as requisições HTTP e retornar as respostas apropriadas.

Models: Contém os modelos de dados que representam a estrutura dos dados recebidos e retornados pela API.

Services: Inclui as interfaces e implementações dos serviços que contêm a lógica de negócios da aplicação.

Configuration: Contém as configurações da aplicação, como o arquivo appsettings.jsonque define as configurações de logging e hosts permitidos.

Configuração
Pré-requisitos
Para rodar este projeto, você precisará ter instalado o .NET SDK (versão 6.0 ou superior) e uma IDE, como Visual Studio ou Visual Studio Code, que é opcional, mas recomendada para desenvolvimento.

Configuração do Projeto
Clonar o Repositório: Clone o repositório do projeto para a sua máquina local utilizando o comando git clone seguido da URL do repositório.

Navegar até o Diretório do Projeto: Navegue até o diretório do projeto onde os arquivos estão localizados utilizando o comando cd seguido do caminho para o diretório do projeto.

Restaurar Dependências: Restaure as dependências do projeto utilizando o comando dotnet restore.

Executar o Projeto: Execute o projeto utilizando o comando dotnet run.

Acessar a Aplicação: Abra o navegador e acesse a URL http://localhost:5000 para visualizar a aplicação em execução.

Testes
Executar Testes Unitários
Para executar os testes unitários, utilize o comando apropriado na raiz do diretório do projeto. Primeiro, execute os testes utilizando o comando dotnet test.
