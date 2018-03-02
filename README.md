# Portabilis

# 1 - Requisitos:
* Arquivo com a descrição do processo em: [Processo](https://docs.google.com/document/d/1QmtdXLDxBGD4ZDq0M4BkkEgiaIYLrj-eN2qr5ZDiNAQ/edit)
* Arquivo com os requisitos descritos disponível em: [Requisitos.md](https://github.com/johseffer/Portabilis/blob/develop-1.1/Requisitos.md)

# 2 - Parecer do sistema relacionado aos requisitos;

## 2.1 - Cadastro de alunos
  - [x] Cadastro possui os campos em conformidade com os requisitos.
  
  - [ ] Cadastro deve validar cadastro de registro com CPF duplicado.
  
  - [ ] Cadastro deve emitir mensagem ao salvar e excluir um registro.
  
<br /><br />**Total de requisitos em conformidade:** 1/3
  
## 2.2 - Cadastro de cursos
  - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.4 - Cadastro de matrículas
 - [x] Cadastro possui os campos em conformidade com os requisitos.
 
 - [x] Cadastro deve verificar aluno já matriculado em determinado curso.
 
 - [x] Cadastro deve informar ativo/inativo, pagamento e ano.
 
<br /><br />**Total de requisitos em conformidade:** 3/3

## 2.5 - Listagem de matrículas
 - [x] Cadastro possui os campos em conformidade com os requisitos.
 
 - [ ] Cadastro possui os filtros em conformidade com os requisitos.
 
 - [x] Cadastro possui deve possuir funcionalidade de flag ativo/inativo.
 
<br /><br />**Total de requisitos em conformidade:** 2/3

## 2.6 - Dashboard de matrícula

 - [x] Cadastro possui os campos em conformidade com os requisitos.
 
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.7 - Pagamento

 - [x] Cadastro possui os campos em conformidade com os requisitos.
 - [x] Cadastro deve permitir pagamento de matricula/mensalidades, possibilitando troco ao cliente e informando quantidade de cedulas/moedas.
 - [x] Matricula deve ser paga apenas uma vez.
 - [x] Deve ser possível pagar e acompanhar as mensalidades mensalmente.
 
<br /><br />**Total de requisitos em conformidade:** 4/4

## 2.8 - Cancelamento de matrículas

 - [x] Deve ser possível efetuar o cancelamento das matriculas do aluno.
 - [x] Deve ser exibido ao aluno o valor de multa.
 - [ ] Deve ser cobrado o valor de 1% ao mês e o aluno poderá continuar tendo acesso ao curso.
 
 <br /><br />**Total de requisitos em conformidade:** 2/3

# 3 - Lista de bugs com descrição para o desenvolvedor ajustar;

## 3.1 - Cadastro de alunos
**Total de bugs encontrados:** 2

### 3.1.1 - BUG311
**Rotina:** Cadastro de alunos
<br />**Descrição:** Cadastro de alunos não exibe mensagem de erro ao cadastrar registro com CPF já existente e redireciona para uma página de erro não tratado.
<br />**Simulação:** Acessar home da aplicação, clicar no menu alunos, cadastrar aluno, informar todos os campos e um cpf já cadastrado e clicar em salvar.
<br />**Critérios de aceite:**
<br /><br />**CA3111:** 
<br />Dado que exista um aluno cadastrado com CPF 9.999.999-99;
<br />Ao acessar o cadastro de alunos e tentar cadastrar outro aluno com mesmo cpf;
<br />Uma mensagem de alerta deve ser exibida informando que o cpf já foi cadastrado;

### 3.1.2 - BUG312
**Rotina:** Cadastro de alunos
<br />**Descrição:** Cadastro de alunos não exibe mensagem de confirmação ao salvar registro.
<br />**Simulação:** Acessar home da aplicação, clicar no menu alunos, cadastrar aluno, informar todos os campos e clicar em salvar.
<br />**Critérios de aceite:**
<br /><br />**CA3121:** 
<br />Dado que um aluno esteja sendo cadastrado;
<br />Ao informar todos os campos e clicar em salvar;
<br />Uma mensagem de confirmação deve ser exibida informando que o aluno será cadastrado, assim como quando um aluno é excluído;

## 3.2 - Cadastro de cursos
<br />**Total de bugs encontrados:** 0

## 3.4 - Cadastro de matrículas
<br />**Total de bugs encontrados:** 0

## 3.5 - Listagem de matrículas
<br />**Total de bugs encontrados:** 0

### 3.5.1 - BUG351
**Rotina:** Listagem de Matrículas
<br />**Descrição:** Listagem de matrículas não possui filtro por ano.
<br />**Simulação:** Acessar home da aplicação, clicar no menu matrículas, listagem.
<br />**Critérios de aceite:**
<br /><br />**CA3511:** 
<br />Dado que seja acessada a listagem de matrículas.
<br />Um campo para informar o ano para filtro deve ser exibido
<br />Ao informar o campo, a lista de matrículas deve trazer somente os registros do ano informado.

## 3.6 - Dashboard de matrícula
<br />**Total de bugs encontrados:** 0

## 3.7 - Pagamento
<br />**Total de bugs encontrados:** 0

## 3.8 - Cancelamento de matrículas
<br />**Total de bugs encontrados:** 1

### 3.8.1 - BUG381
**Rotina:** Cancelamento de Matrículas
<br />**Descrição:** Ao cancelar a matrícula de um aluno, o acesso ao curso e as parcelas pagas foi perdido.
<br />**Simulação:** Acessar home da aplicação, acessar meus cursos e selecionar o curso desejado para em seguida cancelar a matricula.
<br />**Critérios de aceite:**
<br /><br />**CA3811:** 
<br />Dado que um aluno esteja matriculado em um curso
<br />Ao logar como o aluno, acessar os detalhes da matricula no curso e clicar em cancelar matricula
<br />Uma mensagem de confirmação deve ser exibida informando a taxa de 1% ao mês e o valor total da multa, e caso confirmado a matricula deve ser inativada, permitindo para o aluno consultar o curso com a matricula cancelada e suas mensalidades pagas anteriormente.

# 4 - Protótipo de um checklist de teste;

- [x] **4.1-Teste de funcionalidade**
  - [x] Item em conformidade com os requisitos
  - [x] Item funcional na execução de integrações (Caso possua)

- [x] **4.2-Usabilidade**
  - [x] Verificar conformidade de layout de acordo com o padrão
  - [x] Verificar fácil interação com o usuário, com posicionamento de campos dispostos de maneira interativa
  - [x] Verificar a facilidade na buscar pelos atalhos de execução das principais ações do sistema

- [x] **4.3-Compatibilidade**
  - [x] Verificar execução da automação de testes nos principais navegadores: chrome, firefox e edge.
  - [x] Verificar a execução da automação em diferentes dispositivos: mobile, tablet e pc (caso aplicação seja responsiva)
  - [x] Verificar a execução da automação em diferentes sistemas operacionais (caso seja requisito)
  
- [x] **4.4-Base de dados**
  - [x] Verificar integridade da base de dados, validando se as alterações feitas por meio do sistema são realmente efetivadas

- [x] **4.5-Performance**
  - [x] Deve ser feita uma análise de dados como numero de erros, numero de consultas, tempo de resposta na execução das funcionalidades dispostas, utilizando o sistema operando em uso normal como também sobrecarregado afim de entender como o sistema se comporta de acordo com o nivel de estresse.

- [x] **4.6-Segurança**
  - [x] Fazer variados testes de login, de forma a verificar se os dados de cada usuários ficam bem armazenados e se somente os dados disponível para determinado usuário podem ser acessados pelo menos. Verificar também se as atividades de multiplos usuários não conflitam entre si em termos de uso e desempenho.

- [x] **4.7-Conformidade**
  - [x] Essa etapa fica disponível para validar se o sistema foi desenvolvido em conformidade com as principais normas de TI e se o software realmente apresenta tudo que se dispõe a fazer. É um teste geral e pode ser utilizado do teste de multidão para facilitar o processo.

# 5 - Scripts com a automação dos testes com uma documentação explicando como executar;

## 5.1 - Projeto de testes

### 5.1.1 - Tecnologias utilizadas:
O projeto com as automações dos testes de interface foi desenvolvido utilizando projeto de Unit Tests .NET em conjunto com driver web Selenium.

### 5.1.2 - Pré-Requisitos:
* 5.1.2.1 - Visual Studio 2017 Community - https://www.visualstudio.com/pt-br/vs/community (Versão gratuita, também é possível instalar a versão enterprise de avaliação;

### 5.1.3 - Download: 
* 5.1.3.1 - Baixar o projeto disponível em: [Tests](https://github.com/johseffer/Portabilis/blob/develop-1.1/Tests)

** IMPORTANTE: ** A pasta Tests deve ser copiada para o diretório C:/TFS/Portabilis para que os executáveis facilitadores funcionem corretamente, caso seja necessário extrair a solução para outro diretório, os testes devem ser executados manualmente.

### 5.1.4 - Instruções de execução:
* 5.1.4.1 - Após ter instalado o Visual Studio 2017.
* 5.1.4.2 - Executar o arquivo [build.exe](https://github.com/johseffer/Portabilis/blob/develop-1.1/Tests/build.exe) para baixar os pacotes necessários e compilar a solução.
* 5.1.4.3 - Para facilitar a execução sem uso da interface da IDE, foi incluído um executável para startar a execução de todos os testes. Disponível em: [ExecutarTodosTestes.exe](https://github.com/johseffer/Portabilis/blob/develop-1.1/Tests/ExecutarTodosTestes.exe).
* 5.1.4.4 - Após a finalização da execução dos testes, um arquivo com o resultado dos testes é criado em Tests/TestResults. É possível abrir o arquivo com os resultados via IDE, ou criar uma ferramenta que extraia os resultados para gerar indicadores.
* 5.1.4.5 - Para visualizar o código dos testes, é possível abrir o arquivo da solution [PortabilisTests.sln](https://github.com/johseffer/Portabilis/blob/master/Tests/PortabilisTests.sln) com a IDE.
* 5.1.4.6 - Os scripts de testes foram organizados separadamente pelos cenários:
  - 5.1.4.5.1 - CN001_Alunos.
  - 5.1.4.5.2 - CN002_Cursos.
  - 5.1.4.5.3 - CN001_Matriculas.
* 5.1.4.7 - Os scripts foram criados para execução nos navegadores Google Chrome, Mozilla Firefox e Microsoft Edge, separados assim dentro do projeto com um diretório para cada navegador.

