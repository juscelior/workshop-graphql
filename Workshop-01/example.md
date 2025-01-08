# GraphQL API Documentation

Este documento fornece exemplos de queries, mutations e subscriptions utilizadas neste projeto, juntamente com suas explicações.

## Queries

### 1. Buscar Livro por Título

``
{ book(title: "C# in Depth") { title, author { name } } }
``

**Explicação**: Esta query busca um livro pelo título "C# in Depth" e retorna o título do livro e o nome do autor.

### 2. Buscar Dados do Gráfico

``
{ chartData { label, points } }
``

**Explicação**: Esta query busca os dados do gráfico, retornando os rótulos (`label`) e os pontos (`points`) de cada entrada.

### 3. Buscar Dados do Gráfico com Nome da Query

``
query getChartData { chartData { label, points } }
``

**Explicação**: Esta query nomeada `getChartData` busca os dados do gráfico, retornando os rótulos (`label`) e os pontos (`points`) de cada entrada.

### 4. Buscar Dados Paginados do Gráfico

``
{ chartDataPaged(page: 10, pageSize: 10) { data { id label points } currentPage totalPages } }
``

**Explicação**: Esta query busca os dados do gráfico de forma paginada, retornando os dados da página 10 com um tamanho de página de 10. Retorna os dados (`data`), a página atual (`currentPage`) e o total de páginas (`totalPages`).

## Mutations

### 1. Adicionar Novo Ponto

``
mutation { addNewPoint(id: 1000, value: [0, 0, 0, 0, 0, 0, 0, 0]) { id label points } }
``

**Explicação**: Esta mutation adiciona um novo ponto com o ID 1000 e um array de valores `[0, 0, 0, 0, 0, 0, 0, 0]`. Retorna o ID, o rótulo (`label`) e os pontos (`points`) do novo ponto adicionado.

### 2. Gerar Dados

``
mutation { generateData(ids: [0, 1, 3, 5, 10, 11, 2, 7], rounds: 10) { } }
``

**Explicação**: Esta mutation gera dados para os IDs fornecidos `[0, 1, 3, 5, 10, 11, 2, 7]` em 10 rodadas. Não retorna nenhum dado.

## Subscriptions

### 1. Dados Atualizados

``
subscription { updatedData { id label points } }
``

**Explicação**: Esta subscription escuta atualizações de dados e retorna o ID, o rótulo (`label`) e os pontos (`points`) do item atualizado.

---

Este documento deve ajudar a entender as diferentes operações GraphQL utilizadas neste projeto. Certifique-se de que o servidor GraphQL está configurado corretamente para suportar essas operações.

