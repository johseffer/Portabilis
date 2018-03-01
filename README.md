# Portabilis

# 1 - Requisitos:
* Arquivo com os requisitos descritos disponível em: [Requisitos.md](https://github.com/johseffer/Portabilis/blob/develop-1.1/Requisitos.md)

# 2 - Parecer do sistema relacionado aos requisitos;

## 2.1 - Cadastro de alunos
  - [x] Cadastro possui os campos em conformidade com os requisitos.
  - [x] Cadastro deve validar cadastro de registro com CPF duplicado.
  - [x] Cadastro deve emitir mensagem ao salvar e excluir um registro.
<br /><br />**Total de requisitos em conformidade:** 3/3
  
## 2.2 - Cadastro de cursos
  - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.4 - Cadastro de matrículas
 - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.5 - Listagem de matrículas
 - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.6 - Dashboard de matrícula
 - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.7 - Pagamento
 - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

## 2.8 - Cancelamento de matrículas
 - [x] Cadastro possui os campos em conformidade com os requisitos.
<br /><br />**Total de requisitos em conformidade:** 1/1

# 3 - Lista de bugs com descrição para o desenvolvedor ajustar;

## 3.1 - Cadastro de alunos
**Total de bugs encontrados:** 0

### 3.1.1 - BUG311
**Rotina:** Cadastro de alunos
<br />**Descrição:** Cadastro de alunos não exibe quantidade de parcelas pagas corretamente.
<br />**Simulação:** Acessar home da aplicação, clicar no menu alunos, cadastrar aluno, informar os campos e clicar em salvar.
<br />**Critérios de aceite:**
<br /><br />**CA3111:** 
<br />Dado que exista um aluno com todos as parcelas pagas;
<br />Ao acessar o cadastro de alunos;
<br />O campo parcelas em aberto deve exibir o valor "Nenhuma";

## 2.2 - Cadastro de cursos
<br />**Total de bugs encontrados:** 0

## 2.4 - Cadastro de matrículas
<br />**Total de bugs encontrados:** 0

## 2.5 - Listagem de matrículas
<br />**Total de bugs encontrados:** 0

## 2.6 - Dashboard de matrícula
<br />**Total de bugs encontrados:** 0

## 2.7 - Pagamento
<br />**Total de bugs encontrados:** 0

## 2.8 - Cancelamento de matrículas
<br />**Total de bugs encontrados:** 0

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
  - [x] Fazer variados testes de login, de forma a verificar se os dados de cada usuários ficam bem armazenados e se somente os dados disponível para determinado usuário podem ser acessados pelo menos. Verificar também se as atividades de multiplos usuários não comflitam entre si em termos de uso e desempenho.

- [x] **4.7-Conformidade**
  - [x] Essa etapa fica disponível para validar se o sistema foi desenvolvido em conformidade com as principais normas de TI e se o software realmente apresenta tudo que se dispõe a fazer. É um teste geral e pode ser utilizado do teste de multidão para facilitar o processo.

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
