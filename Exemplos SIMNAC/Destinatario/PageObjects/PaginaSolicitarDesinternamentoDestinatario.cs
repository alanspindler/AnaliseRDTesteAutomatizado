using OpenQA.Selenium;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using System;
using Lampp.AnaliseRD.Teste.Automatizado.Login.PageObjects;

namespace Lampp.AnaliseRD.Teste.Automatizado.Destinatario.PageObjects
{
    [TestClass]
    public class PaginaSolicitarDesinternamentoDestinatario : PaginaBase
    {

        #region Declaração de variáveis públicas da classe

        public PaginaInicial paginaInicial { get; set; }

        public By botaoSolicitarDesiternamento = By.ClassName("fa-plus");
        public By campoChaveAcesso = By.XPath("//app-modal-desinternamento-registrar-solicitacao/div/div/div/div[2]/section/div/section/article/form/div[2]/div/div/input");
        public By campoJustificativa = By.Id("//app-modal-desinternamento-registrar-solicitacao/div/div/div/div[2]/section[2]/div[2]/div/div/textarea");
        public By botaoFechar = By.XPath("//app-modal-desinternamento-registrar-solicitacao/div/div/div/div[3]/button");
        public By botaoBuscar = By.XPath("//app-modal-desinternamento-registrar-solicitacao/div/div/div/div[2]/section/div/section/footer/div/button");
        public By botaoEncaminhar = By.Id("confirmar");
        public By telaSolicitarDesinternamento = By.XPath("//*[@id='content']/section/section/section/section/solicitar-desinternamento/app-modal-desinternamento-registrar-solicitacao/div[1]");

        #endregion

        #region Métodos públicos

        public PaginaSolicitarDesinternamentoDestinatario(RemoteWebDriver driver) : base(driver)
        {

        }

        public bool TestePesquisaChaveAcesso()
        {
            paginaInicial = new PaginaInicial(driver);
            paginaInicial.AbrirPagina("http://localhost:4200/#/importar-chave-acesso");
            Thread.Sleep(1500);
            AguardarProcessando();
            paginaInicial.AbrirPagina("http://localhost:4200/#/solicitar-desinternamento-dest/2");
            AguardarProcessando();
            ClicarElementoPagina(botaoSolicitarDesiternamento);
            AguardarProcessando();
            PreencherCampo(campoChaveAcesso, "35180802462805000778550010007969841857254751");
            ClicarElementoPagina(botaoBuscar);
            AguardarProcessando();            
            driver.SwitchTo().ActiveElement();
            //(driver.FindElement(telaSolicitarDesinternamento));
            AguardarElemento(botaoEncaminhar);
            if (IsElementDisplayed(driver, botaoEncaminhar))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}