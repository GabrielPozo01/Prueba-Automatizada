using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace PruebaAutomatizada
{
    class Program
    {
        static void Main(string[] args)
        {

            string edgeDriverPath = @"C:\Gabriel Arnaldo Pozo Tavarez\ITLA\Cuatrimestre 6\Programacion III\edgedriver_win64 (1)\msedgedriver.exe";


            EdgeOptions edgeOptions = new EdgeOptions();



            IWebDriver driver = new EdgeDriver(edgeDriverPath, edgeOptions);

            try
            {

                driver.Manage().Window.Maximize();


                driver.Navigate().GoToUrl("https://www.youtube.com");


                System.Threading.Thread.Sleep(3000);


                IWebElement searchBox = driver.FindElement(By.Name("search_query"));
                searchBox.SendKeys("Alofoke");
                searchBox.SendKeys(Keys.Enter);


                System.Threading.Thread.Sleep(5000);


                if (driver.Title.Contains("Alofoke"))
                {
                    Console.WriteLine("La prueba ha sido exitosa.");
                }
                else
                {
                    Console.WriteLine("La prueba ha fallado.");
                }


                IWebElement secondVideo = driver.FindElement(By.XPath("(//ytd-thumbnail)[2]"));
                secondVideo.Click();


                System.Threading.Thread.Sleep(15000);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la ejecución de la prueba: " + ex.Message);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}




