using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelper
    {
        // Um enum para tornar a escolha do navegador mais legível e segura
        public enum BrowserType
        {
            Chrome,
            Firefox,
            Edge
        }

        public static class WebDriverFactory
        {
            // O método principal que cria e retorna o driver
            public static IWebDriver CreateWebDriver(BrowserType browserType, bool isHeadless = false)
            {
                switch (browserType)
                {
                    case BrowserType.Chrome:
                        return CreateChromeDriver(isHeadless);

                    case BrowserType.Firefox:
                        return CreateFirefoxDriver(isHeadless);

                    case BrowserType.Edge:
                        return CreateEdgeDriver(isHeadless);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(browserType), browserType, "Tipo de navegador não suportado.");
                }
            }

            private static IWebDriver CreateChromeDriver(bool isHeadless)
            {
                // O WebDriverManager cuida do download e setup
                new DriverManager().SetUpDriver(new ChromeConfig());

                // Configurações específicas do Chrome (opções)
                var chromeOptions = new ChromeOptions();
                if (isHeadless)
                {
                    chromeOptions.AddArgument("--headless");
                    chromeOptions.AddArgument("--disable-gpu"); // Frequentemente necessário para headless no Windows
                }
                chromeOptions.AddArgument("--start-maximized"); // Inicia o navegador maximizado
                chromeOptions.AddArgument("--incognito"); // Usa o modo anônimo

                return new ChromeDriver(chromeOptions);
            }

            private static IWebDriver CreateFirefoxDriver(bool isHeadless)
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                var firefoxOptions = new FirefoxOptions();
                if (isHeadless)
                {
                    firefoxOptions.AddArgument("--headless");
                }
                return new FirefoxDriver(firefoxOptions);
            }

            private static IWebDriver CreateEdgeDriver(bool isHeadless)
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                var edgeOptions = new EdgeOptions();
                if (isHeadless)
                {
                    edgeOptions.AddArgument("headless");
                    edgeOptions.AddArgument("disable-gpu");
                }
                return new EdgeDriver(edgeOptions);
            }
        }
    }
}