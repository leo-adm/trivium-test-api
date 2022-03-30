# Trivium Test API
API realizada para minha entrevista de emprego na empresa Trivium.
Para realizá-la eu utilizei .NET 6 juntamente com EntityFrameworkCore como ORM
para manipulação de dados juntamente com um banco SQLite. No início do desenvolvimento
utilizei mock data para simular as requisições.

###### To Do:

- Adicionar Auto Mapper para mapear as entidades do banco de dados 
em objetos de transferências de dados (leitura, criação e atualização)  

- Criar os repositórios "reais" para buscar as informações dos produtos, compras e itens.  

- Adicionar testes unitários  

## Banco de dados
A API leva em consideração um banco de dados com 4 tabelas:

#### Tabela Cliente

A tabela Cliente possui as seguintes informações:

| Coluna | Tipo | Descrição |
| --- | --- | --- |
| ID | int | Identificador único |
| Nome | string | |
| Telefone | string | |
| Endereco | string | |

#### Tabela Produto

A tabela Produto possui as seguintes informações:

| Coluna | Tipo | Descrição |
| --- | --- | --- |
| ID | int | Identificador único |
| Nome | string | |
| Preco | string | |

#### Tabela Compra

A tabela Compra possui as seguintes informações:

| Coluna | Tipo | Descrição |
| --- | --- | --- |
| ID | int | Identificador único |
| IDClient | int | Chave estrangeira que referencia a tabela Cliente |

#### Tabela CompraItem

A tabela CompraItem guarda as seguintes informações:

| Coluna | Tipo | Descrição |
| --- | --- | --- |
| ID | int | Identificador único |
| IDCompra | int | Chave estrangeira que referencia a tabela Compra |
| IDProduto | int | Chave estrangeira que referencia a tabela Produto |
| Quantidade | int | |
---
## Requisitos

1. **Crie as classes (Models) de cada Tabela e suas relações.** 

2. **Crie os seguintes end-points:**

  2.1.: Buscar Clientes

  2.2.: Buscar Compras

  2.3.: Buscar Produtos

3. **Escolha alguma das entidades e criei todos os end-points de CRUD:**

  3.1.: Create(POST)

  3.2.: Read(GET)

  3.3.: Update(PATCH)

  3.4.: Delete(DELETE)

#### Requisitos bônus

1. **Crie os seguinte end-points extras:**  

1.1.: **Busca de Compras para um Cliente**  

- Resposta deve conter uma lista de compras e cada compra precisa 
conter a sua lista de items e um preço total da compra.  

1.2.: **Busca de Compras para um Produto**  

- Resposta deve conter total de compras feitas pelo produto produto 
enviado e preço total arrecadado.  

1.3.: **Busca de Compras por Produto**  

- Resposta deve conter uma lista de produtos e cada produto deve 
conter total de compras feitas e preço total arrecadado.  

1.4.: **Busca de Produtos mais comprados para um Cliente**  

- Buscar os 5 produtos mais comprados por um cliente específico.



