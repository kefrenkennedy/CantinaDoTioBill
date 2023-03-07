# Desafio:

A empresa Cantina do Tio Bill está em busca de automatizar o processo de vendas de suas quentinhas. A empresa decidiu contratar você, desenvolvedor, para desenvolver a solução. Ela gostaria de um sistema para gerenciar os seus clientes e as vendas. As seguintes necessidades devem ser levadas em consideração:

- A empresa trabalha com mais de um tipo de quentinha.
- A partir de 5 quentinhas, a empresa oferece um desconto de 2.15%.
- A empresa cobra uma taxa variável de entrega.
- Deve ser possível cancelar um pedido.
- Ela gostaria de ter um relatório de suas vendas.

O objetivo é criar um app desktop para Windows. Deve-se utilizar:

- Versionamento de código
- WinForms
- ReportViewer
- SQL Server
- Entity Framework como ferramenta ORM
- Testes unitários

Tudo feito com Clean Code e respeitando as boas práticas de programação.

# ABSTRAÇÃO DO PROJETO (MVP)

### Diagrama de entidade-relacionamento: <br>
![Diagrama de entidade-relacionamento](imagens/Diagrama-MVP.png)

### Tabelas: <br>
![Tabela Users](imagens/tabelaUsers.png) <br>
![Tabela Endereço](imagens/tabelaEndereços.png) <br>
![Tabelas Meals, Orders e Order's Meals](imagens/tabelaOrdersMealsOrdersMeal.png) <br>

### FUNCIONALIDADES

1. Cadastro de usuários

   - Criar uma tela para cadastro de usuários com campos para nome, tipo(cliente | gerente), e-mail, senha e endereço.
   - Armazenar as informações dos usuários em um banco de dados.
   - Validar os campos de entrada para garantir que sejam preenchidos corretamente.

2. Cadastro de tipos de quentinhas disponíveis para venda

   - Criar uma tela para cadastrar os tipos de quentinhas disponíveis, com campos para nome, tipo(pequena | media | grande), ingredientes e preço.
   - Armazenar as informações dos tipos de quentinhas em um banco de dados.
   - Validar os campos de entrada para garantir que sejam preenchidos corretamente.

3. Adição de pedidos de clientes com opções para selecionar o tipo de quentinha e quantidade desejada

   - Criar uma tela para adicionar pedidos de clientes com opções para selecionar o tipo de quentinha e quantidade desejada.
   - Validar os campos de entrada para garantir que sejam preenchidos corretamente.
   - Armazenar os pedidos em um banco de dados.

4. Cálculo automático de descontos de 2,15% para pedidos com 5 ou mais quentinhas

   - Implementar uma função para calcular descontos de 2,15% em pedidos com 5 ou mais quentinhas.
   - Aplicar o desconto automaticamente quando o pedido atingir a quantidade mínima.

5. Cálculo automático de uma taxa de entrega variável

   - Implementar uma função para calcular a taxa de entrega com base na distância e no valor do pedido.
   - Aplicar a taxa de entrega automaticamente ao valor do pedido.

6. Capacidade de cancelar um pedido de cliente

   - Criar uma tela para cancelar um pedido de cliente.
   - Validar a identificação do pedido para garantir que seja correto.
   - Remover o pedido do banco de dados.

7. Geração de relatórios de vendas com informações como quantidade de vendas, valor total de vendas, quantidade de cancelamentos, filtro de quanto foi vendido/cancelado por dia/semana/mês/ano e valor total de descontos aplicados.

   - Criar uma tela para gerar relatórios de vendas com informações como quantidade de vendas, valor total de vendas e valor total de descontos aplicados.
   - Extrair as informações do banco de dados.
   - Apresentar as informações de forma clara e legível. 


# ABSTRAÇÃO DO PROJETO (Escalado em seu potencial)

O sistema iniciará com uma tela de login, e há 3 possíveis usuários: Clientes, Funcionários e Gerente. Na mesma tela deve haver a opção de criar conta, que levará à outra tela, desta vez, de registro de usuário cliente.

A conta Gerente será criada pelo desenvolvedor e seu acesso será dado ao Gerente do estabelecimento, onde ele poderá alterar seus dados.

### FUNCIONALIDADES PARA O GERENTE:

Quando uma conta Gerente loga, deverá aparecer uma tela com as seguintes opções:

- Relatório de vendas (onde ele poderá verificar as vendas do dia, semana, mês e ano)
- Clientes (ele poderá visualizar todos os clientes, com suas informações e também poderá realizar a deleção ou um soft-delete)
- Cadastrar/Atualizar/Deletar Funcionário
- Alterar dados da conta
- Logout
- Cadastrar/Atualizar/Deletar Quentinhas.

### FUNCIONALIDADES PARA O FUNCIONÁRIO:

Quando uma conta Funcionário loga, deverá aparecer uma tela com as seguintes opções:

- Relatório de pedidos (poderá analisar os pedidos do dia, da semana e do mês)
- Pedidos pendentes (aparecerá a informação de todos os pedidos que foram solicitados pelos clientes e que ainda não foram confirmados, no qual o Funcionário poderá aceitar o pedido ou entrar em contato por telefone/whatsapp com o cliente)
- Fechar caixa (onde ele deverá informar qual o valor (R$) em que o caixa foi encerrado)
- Logout

### FUNCIONALIDADES PARA O CLIENTE:

Quando uma conta Cliente loga, deverá aparecer uma tela com as seguintes opções:

- Alterar dados da conta
- Deletar conta (soft-delete)
- Ver dados da conta
- Adicionar novo endereço
- Realizar pedido (deve poder escolher quantas quentinhas disponíveis ele quiser)
- Falar com Funcionário (whatsapp do estabelecimento)
- Verificar histórico de pedidos (onde aparecerá todas as informações dos pedidos anteriores)
- Logout

# CRUD de Funcionários

Este CRUD permitirá gerenciar informações de funcionários, incluindo login e cadastro.

## Login de Funcionário

Para iniciar o sistema, é necessário que um funcionário faça login. Ele deve informar:

- Username
- Senha
- Valor (R$) que o caixa possui no momento da abertura

Para encerrar o estabelecimento (fechando o sistema), o funcionário logado deve fornecer a informação do valor final que o caixa possui.

Isso permitirá um controle de caixa para prevenção de perdas.

## Cadastro de Funcionário

O cadastro de funcionários deverá ser feito com as seguintes informações:

- Id (UUID)
- Nome completo
- Username
- Senha
- LoginInfo (contém informações sobre os logins do usuário)

### LoginInfo

O LoginInfo deverá conter as seguintes informações:

- Quantas vezes o usuário fez login
- Para cada vez que ele fez login, deve haver informações sobre:
  - Hora e data em que ele fez login
  - Quantos R$ havia no caixa quando ele fez login
  - Hora e data em que ele deslogou
  - Quantos R$ havia no caixa quando ele deslogou

Isso permitirá um controle de acesso e monitoramento das ações do usuário.

## Atualização de informações

Deve ser possível atualizar os dados do funcionário.

## Verificação de dados do Funcionário

Deverá ser possível verificar as seguintes informações do funcionário:

- Id
- Nome completo
- Username
- LoginInfo

## Exclusão de Funcionário

Deverá ser possível excluir um funcionário do sistema (soft-delete).

# CRUD de Clientes

Este CRUD permitirá cadastrar, atualizar e excluir informações de clientes.

## Cadastro

O cadastro de clientes é feito com as seguintes informações:

- Id (UUID)
- Nome completo
- Telefone
- Endereço (Rua, Número, Bairro, CEP, Complemento)
- Pedidos (inicialmente vazio)

### Endereços

Deve ser possível cadastrar mais de um endereço para o cliente, sendo que um deles deve ser definido como principal.

## Atualização de informações

O cliente poderá atualizar suas informações, incluindo:

- Nome completo
- Telefone
- Endereços (adicionar, editar ou remover)

## Verificação de dados da conta

O cliente poderá verificar seus dados cadastrais, incluindo:

- Nome completo
- Telefone
- Endereços
- Pedidos

## Exclusão de conta

O cliente poderá excluir sua conta, sendo que a exclusão é do tipo "soft-delete".

# CRUD de Endereços

Este CRUD permitirá cadastrar, atualizar e excluir informações de endereços.

## Cadastro de Endereço

O cadastro de endereço deverá ser feito com as seguintes informações:

- Rua
- Número
- Bairro
- CEP
- Complemento
- Frete

Para checar se o endereço é válido, deverá ser feito
uma consulta a uma API de serviços de mapas, como a do Google Maps. Se o endereço for válido, o valor do frete para esse endereço é calculado com base na distância do endereço do cliente ao do estabelecimento. Esse valor é incluso no valor total de cada pedido.

## Atualização de Endereço

Deve ser possível atualizar os dados de um endereço, incluindo:

- Rua
- Número
- Bairro
- CEP
- Complemento

## Visualização de Endereços

Deve ser possível visualizar todos os endereços cadastrados no sistema.

## Definição de Endereço Principal

Para cada cliente, é possível definir um endereço principal.

## Exclusão de Endereço

Deve ser possível excluir um endereço cadastrado, com exceção do endereço principal.

# CRUD de Quentinhas

Este CRUD permitirá cadastrar, atualizar e excluir informações de quentinhas.

## Cadastro de Quentinha

O cadastro de quentinha deve ser feito com as seguintes informações:

- Descrição
- Disponibilidade (boolean)
- Preço

## Visualização de Quentinhas

Deve ser possível visualizar todas as quentinhas cadastradas no sistema.

## Atualização de Quentinha

Deve ser possível atualizar as informações de uma ou mais quentinhas, incluindo:

- Descrição
- Disponibilidade (boolean)
- Preço

## Exclusão de Quentinha

Deve ser possível excluir uma quentinha cadastrada, com a opção de soft-delete.

## Lista de Quentinhas para Pedidos

Deve haver uma lista (inicialmente vazia) de quentinhas para os clientes escolherem quando forem fazer o pedido.

# CRUD de Pedidos

Este CRUD permitirá cadastrar, atualizar e excluir informações de pedidos.

## Cadastro de Pedido

O cadastro de pedido deve ser feito com as seguintes informações:

- Quentinhas
- Delivery ou Balcão
- Forma de pagamento (dinheiro ou cartão)
- Valor total (contém o valor total em reais(R$), que equivale à soma dos preços das quentinhas contidas no pedido somado ao valor do frete do delivery, caso o cliente opte por essa opção, se a quantidade de quentinhas for maior ou igual a 5, descontar do valor total das quentinhas 2.15%)

## Visualização de Pedidos

Deve ser possível visualizar todos os pedidos cadastrados no sistema.

## Atualização de Pedido

Deve ser possível atualizar as informações de um pedido, incluindo:

- Quentinhas
- Delivery ou Balcão
- Forma de pagamento (dinheiro ou cartão)
- Valor total

## Exclusão de Pedido

Deve ser possível excluir um pedido cadastrado.

## Cancelamento de Pedido

Deve ser possível cancelar um pedido cadastrado.

