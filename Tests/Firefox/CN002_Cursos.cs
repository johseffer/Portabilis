using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Threading;

namespace PortabilisTests.Firefox
{
    [TestClass]
    public class CN002_Cursos
    {
        public static FirefoxDriver driver;
      public static CursoMock curso;

        [TestMethod]
        public void CN002_Cursos_ValidarCadastroCursos()
        {
            this.CN002_Cursos_AcessarCadastro();

            var faker = new Faker("en");
            var nameMock = new Bogus.DataSets.Name();
            var firstName = nameMock.FirstName(Bogus.DataSets.Name.Gender.Male);
            var lastName = nameMock.LastName(Bogus.DataSets.Name.Gender.Male);

            curso = new CursoMock()
            {
                Name = "Curso Portabilis",
                //ValMatricula = Math.Round(faker.Random.Decimal(decimal.Parse("50"), decimal.Parse("100")), 2).ToString(),
                //ValMensalidade = Math.Round(faker.Random.Decimal(decimal.Parse("200"), decimal.Parse("800")),2).ToString(),
                ValMatricula = faker.Random.Number(50,100).ToString(),
                ValMensalidade = faker.Random.Number(20, 800).ToString(),
                Periodo = "noturno",
                Descricao = faker.Lorem.Sentence(15),
                QuantMesesDuracao = "12"
            };

            this.CN002_Cursos_CadastrarCurso();
            this.CN002_Cursos_BuscarIdCurso();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            if (driver != null)
                driver.Quit();
        }

        public void CN002_Cursos_AcessarListagem()
        {
            if (driver == null)
                driver = Application.StartApplication();

            var link = driver.FindElementByXPath("//a[@href='/admin/curso/']");
            link.Click();
        }

        public void CN002_Cursos_AcessarCadastro()
        {
            if (driver == null)
                driver = Application.StartApplication();

            driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/admin/curso/new");
        }

        public void CN002_Cursos_BuscarIdCurso()
        {
            var title = driver.FindElementByXPath("//*[text()[contains(., 'Detalhes do curso #')]]");
            curso.Id = title.Text.Split('#')[1];
        }

        public void CN002_Cursos_CadastrarCurso()
        {
            var nameInput = driver.FindElementById("school_cursobundle_curso_nome");
            nameInput.SendKeys(curso.Name);

            var mensalidadeInput = driver.FindElementById("school_cursobundle_curso_mensualidade");
            mensalidadeInput.SendKeys(curso.ValMensalidade);

            var matriculaInput = driver.FindElementById("school_cursobundle_curso_valorMatricula");
            matriculaInput.SendKeys(curso.ValMatricula);

            var periodoInput = driver.FindElementById("school_cursobundle_curso_periodo");
            periodoInput.SendKeys(curso.Periodo);
            periodoInput.SendKeys(Keys.Enter);

            var duracaoInput = driver.FindElementById("school_cursobundle_curso_mesesDuracao");
            duracaoInput.SendKeys(curso.QuantMesesDuracao);

            var descricaoInput = driver.FindElementById("school_cursobundle_curso_descripcao");
            descricaoInput.SendKeys(curso.Descricao);
            descricaoInput.SendKeys(Keys.Tab);

            var button = driver.FindElementByXPath("//input[@value='Criar curso']");
            button.Click();
        }

        [TestMethod]
        public void CN002_Cursos_ExcluirCurso()
        {
            this.CN002_Cursos_AcessarListagem();

            var link = driver.FindElementByXPath("//a[@href='/admin/curso/" + curso.Id + "']");
            link.Click();

            link = driver.FindElementByXPath("//a[@data-target='#exampleModalCenter']");
            link.Click();

            var form = driver.FindElementByName("form");
            form.Submit();            
        }
    }

    public class CursoMock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ValMensalidade { get; set; }
        public string ValMatricula { get; set; }
        public string Periodo { get; set; }
        public string QuantMesesDuracao { get; set; }
        public string Descricao { get; set; }
    }
}
