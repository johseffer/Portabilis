# Portabilis

# 1 - Requisitos:
* Arquivo com os requisitos descritos disponível em: [Requisitos.md](https://github.com/johseffer/Portabilis/blob/develop-1.1/Requisitos.md)

# 2 - Parecer do sistema relacionado aos requisitos;
## 2.1 - Cadastro de alunos
## 2.2 - Cadastro de cursos
## 2.4 - Cadastro de matrículas
## 2.5 - Listagem de matrículas
## 2.6 - Dashboard de matrícula
## 2.7 - Pagamento
## 2.8 - Cancelamento de matrículas

# 3 - Lista de bugs com descrição para o desenvolvedor ajustar;

## 3.1 - Cadastro de alunos

### 3.1.1 - BUG311
* **Rotina:** Cadastro de alunos
* **Simulação:** Acessar home da aplicação, clicar no menu alunos, cadastrar aluno, informar os campos e clicar em salvar.
* **Critérios de aceite:**

* **CA3111:** 
* Dado que exista um aluno com todos as parcelas pagas;
* Ao acessar o cadastro de alunos;
* O campo parcelas em aberto deve exibir o valor "Nenhuma";

## 2.2 - Cadastro de cursos
## 2.4 - Cadastro de matrículas
## 2.5 - Listagem de matrículas
## 2.6 - Dashboard de matrícula
## 2.7 - Pagamento
## 2.8 - Cancelamento de matrículas

# 4 - Protótipo de um checklist de teste;

* Item 4.1;
* Item 4.2;
* Item 4.3;

# 5 - Scripts com a automação dos testes com uma documentação explicando como executar;

## 5.1 - Projeto de testes

### 5.1.1 - Tecnologias utilizadas:
O projeto com as automações dos testes de interface foi desenvolvido utilizando projeto de Unit Tests .NET em conjunto com driver web Selenium.

### 5.1.2 - Pré-Requisitos:
* 5.1.2.1 - Visual Studio 2017 Community (https://www.visualstudio.com/pt-br/vs/community/);

### 5.1.3 - Download: 
* 5.1.3.1 - Baixar o projeto disponível em: [Tests](https://github.com/johseffer/Portabilis/blob/develop-1.1/Tests)

### 5.1.4 - Instruções de execução:
* 5.1.4.1 - Após ter instalado o Visual Studio 2017, abrir o arquivo da solution (*.sln) em [PortabilisTests.sln](https://github.com/johseffer/Portabilis/blob/develop-1.1/Tests/PortabilisTests.sln).
* 5.1.4.2 - Será aberta a solution de testes com todos os testes organizados por rotina.
* 5.1.4.3 - Executar o atalho de teclas "Ctrl+Shift+B" para baixar os pacotes necessários e compilar a solução.
* 5.1.4.4 - Para facilitar a execução sem uso da interface da IDE, foi incluído um executável para startar a execução de todos os testes. Disponível em: [ExecutarTestes.exe](https://github.com/johseffer/Portabilis/blob/develop-1.1/Tests/ExecutarTestes.exe).
