using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V136.Emulation;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection ("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }
        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            //nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //senha
            var inputSenha = driver.FindElement(By.Id("Password"));

            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            inputNome.SendKeys("Vinícius Beltrami");
            inputEmail.SendKeys("vinicius@outlook.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            //botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act
            botaoRegistro.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(drv => drv.Url.Contains("Obrigado"));

            //assert
            Assert.Contains("Obrigado", driver.PageSource);
        }

            [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "daniel",
                senha: "",
                confirmSenha: ""
            );

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("Please enter a valid email address.", registroPO.NomeMensagemErro);
        }
    }
}