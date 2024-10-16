<div align="center">
<h2>API DesastresNaturais</h2>
<h3>Atividade: Cap 6 - Application Lifecycle Management - Aplicando Técnicas de DevOps</h3>
</div>

- DesastresNaturais é um projeto desenvolvido em C#, que visa fornecer informações e análises sobre desastres naturais. 
- O projeto foi conteinerizado usando Docker para facilitar a execução e o gerenciamento.

## 1. Pré-requisitos

Antes de começar, você precisará ter instalado em sua máquina:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) ou superior.
- [Docker](https://www.docker.com/get-started).
- [Git](https://git-scm.com/downloads) (recomendado).

## 2. Clonando o repositório

Abra um terminal e execute o seguinte comando para clonar o repositório:


```bash
git clone https://github.com/seu-usuario/DesastresNaturais.git
cd DesastresNaturais
```

## 3. Inicializando o projeto

### a) Executando o projeto localmente (sem Docker)

- Navegue até o diretório do projeto:

```bash
cd Fiap.Api.DesastresNaturais
```

- Restaure as dependências do projeto:

```bash
dotnet restore
```

- Execute o projeto:

```bash
dotnet run
```

### b) Executando o projeto usando Docker

- Certifique-se de que o Docker está em execução em sua máquina.

- Crie a imagem Docker: execute o comando abaixo no diretório do projeto onde o Dockerfile está localizado:

```bash
docker build -t desastresnaturais .
```

- Execute o contêiner:

```bash
docker run -d -p 5000:80 desastresnaturais
```

- Acesse a aplicação: abra um navegador e acesse http://localhost:5000 para ver a aplicação em funcionamento.

## 4. Testes

- Para rodar os testes do projeto, execute o seguinte comando na raiz do diretório do projeto:

```bash
dotnet test
```

- Se estiver executando os testes dentro de um contêiner Docker, usar o comando:

```bash
docker run --rm desastresnaturais dotnet test
```

---

> Repositório de estudos [aqui](https://github.com/monicaquintal/smart_cities).