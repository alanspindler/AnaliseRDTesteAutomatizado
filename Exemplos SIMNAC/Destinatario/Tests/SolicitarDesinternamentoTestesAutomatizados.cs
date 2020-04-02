using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lampp.AnaliseRD.Teste.Automatizado.Remetente.PageObjects;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Lampp.AnaliseRD.Teste.Automatizado.Login.PageObjects;
using System.Threading;
using OpenQA.Selenium.Remote;
using Lampp.AnaliseRD.Teste.Automatizado.Destinatario.PageObjects;

namespace Lampp.AnaliseRD.Teste.Automatizado.Destinatario.Tests
{
    [TestClass]
    class SolicitarDesinternamentoTestesAutomatizados
    {
        public Global Global { get; set; }
        public PaginaBase PaginaBase { get; set; }
        public PaginaInicial PaginaInicial { get; set; }
        public PaginaSolicitarDesinternamentoDestinatario paginaSolicitarDesinternamentoDestinatario { get; set; }
        private string urlPaginaInicial = "http://localhost:4200/#/solicitar-desinternamento-dest/2";
        Global selenium;

        [TestInitialize]
        public void IniciarTeste()
        {
            //selenium = Global.obterInstancia();
            //paginaSolicitarDesinternamentoDestinatario = new PaginaSolicitarDesinternamentoDestinatario(selenium.driver);
            ////Abre a pagina inicial
            //PaginaBase = new PaginaBase(selenium.driver);
            //PaginaInicial = new PaginaInicial(selenium.driver);
            //PaginaInicial.AbrirPagina(urlPaginaInicial);
            ////Reinicia as notas que foram solicitadas

            ////Faz Login
            //PaginaInicial.FazerLogin("13881630000164", "123");
            //paginaSolicitarDesinternamentoDestinatario.AguardarProcessando();
        }

        [TestCleanup]
        public void FinalizarTeste()
        {
            //selenium.EncerrarTeste();
        }

        [TestMethod]
        public void Teste()
        {
            selenium = Global.obterInstancia();
            paginaSolicitarDesinternamentoDestinatario = new PaginaSolicitarDesinternamentoDestinatario(selenium.driver);
            //Abre a pagina inicial
            PaginaBase = new PaginaBase(selenium.driver);
            PaginaInicial = new PaginaInicial(selenium.driver);
            PaginaInicial.AbrirPagina(urlPaginaInicial);
            //Reinicia as notas que foram solicitadas

            //Faz Login
            PaginaInicial.FazerLogin("07293118000102", "123");
            paginaSolicitarDesinternamentoDestinatario.AguardarProcessando();

            bool passou = paginaSolicitarDesinternamentoDestinatario.TestePesquisaChaveAcesso();
            while (passou)
            {
                paginaSolicitarDesinternamentoDestinatario.ClicarElementoPagina(paginaSolicitarDesinternamentoDestinatario.botaoFechar);
                paginaSolicitarDesinternamentoDestinatario.AguardarProcessando();
                passou = paginaSolicitarDesinternamentoDestinatario.TestePesquisaChaveAcesso();
            }
            Global.TirarScreenshot("ErroDesinternamento", "SolicitarDesinternamento");
        }
    }
}