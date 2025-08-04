using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static Alura.LeilaoOnline.Selenium.Helpers.TestHelper;
using Xunit;
using System;
using Alura.LeilaoOnline.Selenium.Fixtures;
using AngleSharp.Dom;

namespace Alura.LeilaoOnline.Selenium.Testes
{

    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private readonly IWebDriver driver;

        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange (Já foi feito no construtor)

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange (Já foi feito no construtor)

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            //arrange (Já foi feito no construtor)

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach(var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}