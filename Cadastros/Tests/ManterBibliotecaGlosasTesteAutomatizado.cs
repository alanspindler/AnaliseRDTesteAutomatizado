using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lampp.AnaliseRD.Teste.Automatizado.Cadastros.PageObjects;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Lampp.AnaliseRD.Teste.Automatizado.Login.PageObjects;
using System.Threading;
using Lampp.AnaliseRD.Teste.Automatizado.Principal.PageObjects;
using System;



namespace Lampp.AnaliseRD.Teste.Automatizado.Cadastros.Tests
{
    [TestClass]
    public class ManterBibliotecaGlosasTesteAutomatizado
    {
        static Global Global { get; set; }
        static PaginaBase PaginaBase { get; set; }
        static PaginaInicial PaginaInicial { get; set; }
        static PaginaPrincipal PaginaPrincipal { get; set; }
        static PaginaManterBibliotecaGlosas paginaManterBibliotecaGlosas { get; set; }
        static string urlPaginaInicial = "http://localhost:4200/#/biblioteca-glosas";
        static Global selenium;

        [TestInitialize]
        public void IniciarTeste()
        {
            //Inicializa instância do driver do Selenium
            selenium = Global.obterInstancia();
            paginaManterBibliotecaGlosas = new PaginaManterBibliotecaGlosas(selenium.driver);
            //Abre a pagina inicial
            PaginaBase = new PaginaBase(selenium.driver);
            PaginaInicial = new PaginaInicial(selenium.driver);
            PaginaPrincipal = new PaginaPrincipal(selenium.driver);
            PaginaInicial.AbrirPagina(urlPaginaInicial);
            //Faz login
            PaginaInicial.FazerLogin(Constantes.USUARIO_COORDENADOR, Constantes.SENHA_COORDENADOR);
            PaginaBase.AguardarProcessando();
        }

        [TestCleanup]
        public void FinalizarTeste()
        {
            //Fecha o navegador            
            selenium.EncerrarTeste();
        }

        [TestMethod]
        public void PesquisarItem()
        {
            //Chama a função de efetuar a pesquisa por nome do texto que deve ser selecionado.            
            paginaManterBibliotecaGlosas.PesquisarGlosa("Moniquete das galaxias", "");
            ////Valida a quantidade de resultados exibidos
            paginaManterBibliotecaGlosas.ValidarLinhasGrid(1); 
        }

    }
}
