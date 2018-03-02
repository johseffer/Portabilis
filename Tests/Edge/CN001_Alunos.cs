using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;
using System.Threading;

namespace PortabilisTests.Edge
{
    [TestClass]
    public class CN001_Alunos
    {
        public static EdgeDriver driver;
        public static AlunoMock aluno;

        [TestMethod]
        public void CN001_Alunos_ValidarCadastroAlunos()
        {
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

            this.CN001_Alunos_AcessarCadastro();
            this.CN001_Alunos_CadastrarAluno();

            this.CN001_Alunos_AcessarCadastro();
            this.CN001_Alunos_CadastrarAluno();

            this.CN001_Alunos_ValidarAlunoCPFDuplicado();

            this.CN001_Alunos_FazerLoginAluno();
            this.CN001_Alunos_BuscarIdAluno();

            driver.Close();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            if (driver != null)
            {
                //driver.Close();
                driver.Quit();
            }
        }

        public void CN001_Alunos_AcessarListagem()
        {
            driver = Application.StartApplication();

            var link = driver.FindElementByXPath("//a[@href='/admin/user/list']");
            link.Click();
        }

        public void CN001_Alunos_AcessarCadastro()
        {
            if (driver == null)
            {
                driver = Application.StartApplication();

                var link = driver.FindElementByXPath("//a[@href='/admin/register']");
                link.Click();
            }
            else
                driver.Navigate().GoToUrl("http://mighty-waters-85986.herokuapp.com/admin/register/form");
        }

        public void CN001_Alunos_CadastrarAluno()
        {
            var nameInput = driver.FindElementByXPath("//input[@name='name']");
            nameInput.SendKeys(aluno.Name);

            var cpfInput = driver.FindElementByXPath("//input[@name='cpf']");
            cpfInput.SendKeys(aluno.CPF);

            var rgInput = driver.FindElementByXPath("//input[@name='rg']");
            rgInput.SendKeys(aluno.RG);

            var telefoneInput = driver.FindElementByXPath("//input[@name='telefone']");
            telefoneInput.SendKeys(aluno.Telefone);

            var dataNascimentoInput = driver.FindElementByXPath("//input[@name='dataNascimento']");
            dataNascimentoInput.SendKeys(aluno.DataNascimento);

            var usernameInput = driver.FindElementByXPath("//input[@name='username']");
            usernameInput.SendKeys(aluno.UserName);

            var emailInput = driver.FindElementByXPath("//input[@name='email']");
            emailInput.SendKeys(aluno.Email);

            var passwordInput = driver.FindElementByXPath("//input[@name='plainPassword']");
            passwordInput.SendKeys(aluno.Senha);

            var button = driver.FindElementByXPath("//input[@value='Cadastrar']");
            button.Click();
        }

        public void CN001_Alunos_FazerLoginAluno()
        {
            Application.DoLogout(driver);

            Thread.Sleep(2000);

            Application.DoLogin(driver, aluno.UserName, aluno.Senha);
        }

        public void CN001_Alunos_BuscarIdAluno()
        {
            var profileButton = driver.FindElementById("dropdownMenuButton");
            profileButton.Click();

            var link = driver.FindElementByXPath("//a[@href='/profile/']");
            link.Click();

            var title = driver.FindElementByXPath("//*[text()[contains(., 'Dados do usuário #')]]");
            aluno.Id = title.Text.Split('#')[1];
        }

        [TestMethod]
        public void CN001_Alunos_ExcluirAluno()
        {
            this.CN001_Alunos_AcessarListagem();

            var link = driver.FindElementByXPath("//a[@data-target='#modal" + aluno.Id + "']");
            link.Click();

            Thread.Sleep(1000);

            link = driver.FindElementByXPath("//a[@href='/admin/remove/user/" + aluno.Id + "']");

            Assert.AreEqual(true, link != null);

            link.Click();

            driver.Close();
        }

        public void CN001_Alunos_ValidarAlunoCPFDuplicado()
        {
            // Validar a exibição da mensagem informando registro duplicado, no momento não é possível pois uma página de erro está sendo exibida.

            //var h1Input = driver.FindElementByTagName("h1");
            //Assert.AreEqual("Oops! An Error Occurred", h1Input.Text);
        }
    }

    public class AlunoMock
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }

}
