# 1 - Requisitos

## 1.1 - Cadastro de alunos
* 1.1.1 - Desenvolver um CRUD de alunos com:
- CPF
- RG
- Data de nascimento
- Nome
- Telefone
* 1.1.2 - Para um melhor resultado da funcionalidade, as seguintes regras de negócio devem ser previstas;
O número do CPF deve ser único para cada aluno;
* 1.1.3 - Ao salvar ou excluir um aluno, deve-se exibir uma mensagem de aviso ao usuário antes de sair da página.

## 1.2 - Cadastro de cursos
* 1.2.1 - Desenvolver um CRUD de cursos com:
- Nome
- Valor da mensalidade
- Valor da matrícula
- Período (matutino, vespertino, noturno)
- Meses de duração (quantitativo)

## 1.4 - Cadastro de matrículas
* 1.4.1 - Desenvolver recurso para permitir matricular determinado aluno em um curso;
* 1.4.1.1- Este recurso deve verificar se o aluno já foi matriculado em algum curso no mesmo ano e período, e nesse caso não deve permitir a efetivação da matrícula, exibindo uma mensagem amigável para o usuário;
* 1.4.2 - Através da matrículas devemos ser capaz de saber:
- se a matrícula está ativa
- se a matrícula foi paga
- qual o ano letivo

## 1.5 - Listagem de matrículas
* 1.5.1 - Desenvolver um recurso para acessar uma listagem com todas as matrículas ativas, juntamente com suas informações complementares (ano, curso, aluno, etc..);
* 1.5.2 - Deve possuir filtros como por exemplo: ano, curso, nome do aluno e pagamento pendente;
* 1.5.3 - Para fins de usabilidade, somente deverá mostrar matrículas ativas. Porém, caso uma opção no filtro seja acionada, as inativas poderão ser visualizadas.

## 1.6 - Dashboard de matrícula
* 1.6.1 - o “show” de matrícula será uma espécie de dashboard com várias informações:
- Dados do usuário
- Informações do curso
- Informações de pagamentos (matrícula e pagamentos mensais)
- Botão para pagar (documentado abaixo)
- Botão para cancelar (documentado abaixo)

## 1.7 - Pagamento
* 1.7.1 - Desenvolver um recurso para que seja possível efetuar o pagamento de matrículas e mensalidade;
* 1.7.2 - Deve possuir um campo para informar o valor que foi entregue pelo cliente para pagar a taxa de inscrição do curso e uma opção para gerar a melhor opção de troco para o cliente (informando o menor número de cédulas e moedas que devem ser fornecidas como troco).

Deve-se considerar que há:
cédulas de R$100,00, R$50,00, R$10,00, R$5,00;
moedas de R$0,50, R$1,00, R$0,10, R$0,05 e R$0,01.

* 1.7.3 - Lembrando que a matrícula é paga apenas uma vez, mas a mensalidade ocorre de acordo com o número de meses do curso, e devemos ser capazes de saber o que foi pago.

## 1.8 - Cancelamento de matrículas
* 1.8.1 - Desenvolver um recurso para permitir o cancelamento (inativação) de matrículas;
* 1.8.2 - A data do cancelamento é um dado importante;
* 1.8.3 - Exibir o valor da multa por cancelamento:
* 1.8.4 - É cobrado 1% por mês não cumprido e o aluno continua com acesso ao curso até o fim do mês corrente.
