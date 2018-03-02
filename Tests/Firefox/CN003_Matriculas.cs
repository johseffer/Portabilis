using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml;

namespace PortabilisTests.Firefox
{
    [TestClass]
    public class CN003_Matriculas
    {
        static FirefoxDriver driver;
        static AlunoMock aluno;
        static MatriculaMock matricula;
        static CursoMock curso;
        static MatriculaAlunoMock matriculaAluno;

        [TestMethod]
        public void CN003_Matriculas_ValidarCadastroMatriculas()
        {
            driver = Application.StartApplication();

            var faker = new Faker("en");
            var nameMock = new Bogus.DataSets.Name();
            var firstName = nameMock.FirstName(Bogus.DataSets.Name.Gender.Male);
            var lastName = nameMock.LastName(Bogus.DataSets.Name.Gender.Male);

            aluno = new AlunoMock()
            {
                CPF = faker.Random.Long(11111111111, 99999999999).ToString(),
                RG = faker.Random.Long(1111111, 9999999).ToString(),
                Telefone = faker.Phone.PhoneNumber(),
                DataNascimento = "01/01/1991",
                UserName = faker.Internet.UserName(firstName, lastName),
                Email = faker.Internet.Email(firstName, lastName, "portabilis.com"),
                Senha = faker.Internet.Password(8, true),
                Name = firstName + " " + lastName
            };

            CN001_Alunos alunosCenary = new CN001_Alunos();
            CN001_Alunos.aluno = aluno;
            CN001_Alunos.driver = driver;

            alunosCenary.CN001_Alunos_AcessarCadastro();
            alunosCenary.CN001_Alunos_CadastrarAluno();

            curso = new CursoMock()
            {
                Name = "Curso " + faker.Lorem.Sentence(1),
                ValMatricula = faker.Random.Number(50, 100).ToString(),
                ValMensalidade = faker.Random.Number(20, 800).ToString(),
                Periodo = "noturno",
                Descricao = faker.Lorem.Sentence(15),
                QuantMesesDuracao = "12"
            };

            CN002_Cursos cursosCenary = new CN002_Cursos();
            CN002_Cursos.curso = curso;
            CN002_Cursos.driver = driver;

            cursosCenary.CN002_Cursos_AcessarCadastro();
            cursosCenary.CN002_Cursos_CadastrarCurso();
            cursosCenary.CN002_Cursos_BuscarIdCurso();

            matricula = new MatriculaMock()
            {
                Ano = "2018",
                Curso = curso.Name
            };

            this.CN003_Matriculas_AcessarCadastro();
            this.CN003_Matriculas_CadastrarMatricula();

            this.CN003_Matriculas_BuscarIdMatricula();

            matriculaAluno = new MatriculaAlunoMock()
            {
                Aluno = aluno.Name,
                Curso = curso.Name,
                Periodo = "noturno",
                Ano = "2018"
            };

            this.CN003_Matriculas_AcessarCadastroAlunoDetail();
            this.CN003_Matriculas_CadastrarMatriculaAlunoDetail();

            Thread.Sleep(2000);

            this.CN003_Matriculas_AcessarCadastroAluno();
            this.CN003_Matriculas_CadastrarMatriculaAluno();

            this.CN003_Matriculas_ValidarMatriculaDuplicada();

            Application.DoLogout(driver);

            Application.DoLogin(driver, aluno.UserName, aluno.Senha);

            this.CN003_Matriculas_AcessarDetalheMatricula();

            this.CN003_Matriculas_PagarMatricula();

            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/aluno/dashboard");

            this.CN003_Matriculas_AcessarDetalheMatricula();

            this.CN003_Matriculas_PagarMensalidade();

            this.CN003_Matriculas_ValidarPagamento();

            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/aluno/dashboard");

            this.CN003_Matriculas_AcessarDetalheMatricula();

            //this.CN003_Matriculas_ExcluirMatricula();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            if (driver != null)
            {
                //CN002_Cursos cursosCenary = new CN002_Cursos();
                //CN002_Cursos.curso = curso;
                //CN002_Cursos.driver = driver;

                //cursosCenary.CN002_Cursos_ExcluirCurso();

                //    driver.Quit();
            }
        }

        public void CN003_Matriculas_AcessarListagem()
        {
            if (driver == null)
                driver = Application.StartApplication();

            var link = driver.FindElementByXPath("//a[@href='/admin/matricula/']");
            link.Click();
        }

        public void CN003_Matriculas_AcessarCadastro()
        {
            if (driver == null)
                driver = Application.StartApplication();

            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/admin/matricula/new");
        }

        public void CN003_Matriculas_AcessarCadastroAlunoDetail()
        {
            var link = driver.FindElementByXPath("//a[@href='/admin/matricular/form/" + matricula.Id + "']");
            link.Click();
        }

        public void CN003_Matriculas_AcessarCadastroAluno()
        {
            if (driver == null)
                driver = Application.StartApplication();

            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/admin/matricular/form/-1");
        }

        public void CN003_Matriculas_AcessarDetalheMatricula()
        {
            if (driver == null)
                driver = Application.StartApplication();

            var link = driver.FindElementByXPath("//a[contains(@href,'/aluno/matricula/')]");
            link.Click();

            //driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/admin/matricula/" + matricula.Id + "/detalle");
        }

        public void CN003_Matriculas_CadastrarMatricula()
        {
            var anoInput = driver.FindElementById("school_matriculabundle_matricula_ano");
            anoInput.SendKeys(matricula.Ano);
            anoInput.SendKeys(Keys.Tab);

            var cursoInput = driver.FindElementById("school_matriculabundle_matricula_curso");
            cursoInput.SendKeys(curso.Name);
            cursoInput.SendKeys(Keys.Enter);

            var ativaInput = driver.FindElementById("school_matriculabundle_matricula_ativa");
            ativaInput.SendKeys(Keys.Space);

            var button = driver.FindElementByXPath("//input[@value='Criar matrícula']");
            button.Click();
        }

        public void CN003_Matriculas_CadastrarMatriculaAluno()
        {
            var alunoInput = driver.FindElementById("matricula_aluno");
            alunoInput.SendKeys(aluno.Name);
            alunoInput.SendKeys(Keys.Enter);

            var cursoInput = driver.FindElementById("matricula_curso");
            cursoInput.SendKeys(curso.Name);
            cursoInput.SendKeys(Keys.Enter);

            var anoInput = driver.FindElementById("anoleitivo");
            anoInput.SendKeys(matricula.Ano);

            var periodoInput = driver.FindElementById("periodo");
            periodoInput.SendKeys("noturno");
            periodoInput.SendKeys(Keys.Enter);

            var button = driver.FindElementByXPath("//input[@value='Matricular']");
            button.Click();
        }

        public void CN003_Matriculas_CadastrarMatriculaAlunoDetail()
        {
            var alunoInput = driver.FindElementById("matricula_aluno");
            alunoInput.SendKeys(aluno.Name);

            var button = driver.FindElementByXPath("//input[@value='Matricular']");
            button.Click();
        }

        public void CN003_Matriculas_PagarMatricula()
        {
            var faker = new Faker("en");

            var link = driver.FindElementByXPath("//a[@data-target='#modal_pago']");
            link.Click();

            Thread.Sleep(1000);

            var inputValor = driver.FindElementByName("matricula_payment");
            inputValor.SendKeys(faker.Random.Number(Convert.ToInt32(curso.ValMatricula), Convert.ToInt32(curso.ValMatricula) + 100).ToString());

            var button = driver.FindElementByXPath("//*[text()='Pagar']");
            button.Click();
        }


        public void CN003_Matriculas_PagarMensalidade()
        {
            var faker = new Faker("en");

            var link = driver.FindElementByXPath("//a[@data-target='#modal_pago_mensualidad']");
            link.Click();

            Thread.Sleep(1000);

            var inputValor = driver.FindElementByName("mensualidad_payment");

            matricula.ValPagMensalidade = (Convert.ToInt32(curso.ValMensalidade) + Math.Round(faker.Random.Decimal(1, 100), 2)).ToString();

            inputValor.SendKeys(matricula.ValPagMensalidade);

            inputValor.SendKeys(Keys.Tab);

            Thread.Sleep(1000);

            var form = driver.FindElementByXPath("//form[@action='/pagamento/pagar/mensualidad']");
            form.Submit();

            var resume = driver.FindElementByXPath("//*[text()='Detalhes de operação']");
        }

        public void CN003_Matriculas_BuscarIdMatricula()
        {
            var title = driver.FindElementByXPath("//*[text()[contains(., 'Detalhes da matrícula ')]]");
            matricula.Id = title.Text.Split(new List<string>() { "Detalhes da matrícula " }.ToArray(), StringSplitOptions.None)[1];
        }


        [TestMethod]
        public void CN003_Matriculas_ExcluirMatricula()
        {
            this.CN003_Matriculas_AcessarListagem();

            var link = driver.FindElementByXPath("//a[@data-target='#modal26']");
            link.Click();

            Thread.Sleep(1000);

            link = driver.FindElementByXPath("//a[@href='/admin/remove/user/26']");

            Assert.AreEqual(true, link != null);

            link.Click();
        }

        public void CN003_Matriculas_ValidarMatriculaDuplicada()
        {
            Thread.Sleep(1000);

            var divInput = driver.FindElementByClassName("alert-info");
            Assert.AreEqual("Este aluno já está matriculado neste curso, no mesmo ano e período.", divInput.Text);
        }

        public void CN003_Matriculas_ValidarPagamento()
        {
            Thread.Sleep(1000);

            var divInput = driver.FindElementByClassName("card-body");

            string resume = divInput.Text;

            string[] cedulas = resume.Split(new List<string>() { "Temos calculado para você o melhor troco:" }.ToArray(), StringSplitOptions.None)[1].Split(new List<string>() { "\r\n" }.ToArray(), StringSplitOptions.None);

            var valTroco = Convert.ToDecimal(curso.ValMensalidade) - Convert.ToDecimal(matricula.ValPagMensalidade);
            decimal valTrocoPago = Convert.ToDecimal(resume.Split(new List<string>() { "Total para retornar: " }.ToArray(), StringSplitOptions.None)[1].Split(new List<string>() { "Temos calculado para você o melhor troco:" }.ToArray(), StringSplitOptions.None)[0].Replace(".", ","));

            if (valTrocoPago < 0)
                valTrocoPago = valTrocoPago * -1;

            if (valTroco < 0)
                valTroco = valTroco * -1;

            Assert.AreEqual(valTrocoPago, valTroco, "Valor do troco pago incorreto!");

            int total100 = 0;
            if (valTroco > 100)
                total100 = Convert.ToInt32(Math.Floor(valTroco / 100));
            decimal acumulado = total100 * 100;

            int total50 = 0;
            if (valTroco > 50)
                total50 = Convert.ToInt32(Math.Floor((valTroco - acumulado) / 50));
            acumulado += total50 * 50;

            int total10 = 0;
            if (valTroco - acumulado > 10)
                total10 = Convert.ToInt32(Math.Floor((valTroco - acumulado) / 10));
            acumulado += total10 * 10;

            int total5 = 0;
            if (valTroco - acumulado > 5)
                total5 = Convert.ToInt32(Math.Floor((valTroco - acumulado) / 5));
            acumulado += total5 * 5;

            int total100cent = 0;
            if (valTroco - acumulado > 1)
                total100cent = Convert.ToInt32(Math.Floor(valTroco - acumulado));
            acumulado += total100cent;

            int total50cent = 0;
            if (valTroco - acumulado > Convert.ToDecimal(0.5))
                total50cent = Convert.ToInt32(Math.Floor((valTroco - acumulado) / Convert.ToDecimal(0.5)));
            acumulado += Convert.ToDecimal(total50cent) / 2;

            int total10cent = 0;
            if (valTroco - acumulado > Convert.ToDecimal(0.1))
                total10cent = Convert.ToInt32(Math.Floor((valTroco - acumulado) / Convert.ToDecimal(0.1)));
            acumulado += total10cent * Convert.ToDecimal(0.10);

            int total5cent = 0;
            if (valTroco - acumulado > Convert.ToDecimal(0.05))
                total5cent = Convert.ToInt32(Math.Floor((valTroco - acumulado) / Convert.ToDecimal(0.05)));
            acumulado += total5cent * Convert.ToDecimal(0.05);

            int total1cent = 0;
            if (valTroco - acumulado > Convert.ToDecimal(0.01))
                total1cent = Convert.ToInt32(Math.Floor((valTroco - acumulado) / Convert.ToDecimal(0.01)));
            acumulado += total1cent * Convert.ToDecimal(0.01);


            if (total100 > 0)
                Assert.AreEqual(resume.Contains(total100 + " cedulas de 100\r\n"), true, "Quantidade de notas de 100 incorreta");
            else
                Assert.AreEqual(resume.Contains(" cedulas de 100\r\n"), false, "Quantidade de notas de 100 incorreta");

            if (total50 > 0)
                Assert.AreEqual(resume.Contains(total50 + " cedulas de 50\r\n"), true, "Quantidade de notas de 50 incorreta");
            else
                Assert.AreEqual(resume.Contains(" cedulas de 50\r\n"), false, "Quantidade de notas de 50 incorreta");

            if (total10 > 0)
                Assert.AreEqual(resume.Contains(total10 + " cedulas de 10\r\n"), true, "Quantidade de notas de 10 incorreta");
            else
                Assert.AreEqual(resume.Contains(" cedulas de 10\r\n"), false, "Quantidade de notas de 10 incorreta");

            if (total5 > 0)
                Assert.AreEqual(resume.Contains(total5 + " cedulas de 5\r\n"), true, "Quantidade de notas de 5 incorreta");
            else
                Assert.AreEqual(resume.Contains(" cedulas de 5\r\n"), false, "Quantidade de notas de 5 incorreta");

            if (total100cent > 0)
                Assert.AreEqual(resume.Contains(total100cent + " cedulas de 1\r\n"), true, "Quantidade de notas de 1 incorreta");
            else
                Assert.AreEqual(resume.Contains(" cedulas de 1\r\n"), false, "Quantidade de notas de 1 incorreta");

            if (total50cent > 0)
                Assert.AreEqual(resume.Contains(total50cent + " moedas de 0.5\r\n"), true, "Quantidade de moedas de 0.5 incorreta");
            else
                Assert.AreEqual(resume.Contains(" moedas de 0.5\r\n"), false, "Quantidade de moedas de 0.5 incorreta");

            if (total10cent > 0)
                Assert.AreEqual(resume.Contains(total10cent + " moedas de 0.1\r\n"), true, "Quantidade de moedas de 0.1 incorreta");
            else
                Assert.AreEqual(resume.Contains(" moedas de 0.1\r\n"), false, "Quantidade de moedas de 0.1 incorreta");

            if (total5cent > 0)
                Assert.AreEqual(resume.Contains(total5cent + " moedas de 0.05"), true, "Quantidade de moedas de 0.05 incorreta");
            else
                Assert.AreEqual(resume.Contains(" moedas de 0.05"), false, "Quantidade de moedas de 0.05 incorreta");

            if (total1cent > 0)
                Assert.AreEqual(resume.Contains(total1cent + " moedas de 0.01"), true, "Quantidade de moedas de 0.01 incorreta");
            else
                Assert.AreEqual(resume.Contains(" moedas de 0.01"), false, "Quantidade de moedas de 0.01 incorreta");

        }

    }

    internal class MatriculaMock
    {
        public string Id { get; set; }
        public string Curso { get; set; }
        public string Ano { get; set; }

        public string ValPagMensalidade { get; set; }
    }

    internal class MatriculaAlunoMock
    {
        public string Id { get; set; }
        public string Aluno { get; set; }
        public string Curso { get; set; }
        public string Ano { get; set; }
        public string Periodo { get; set; }
    }
}
