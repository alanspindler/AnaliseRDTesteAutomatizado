using OpenQA.Selenium;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace Lampp.AnaliseRD.Teste.Automatizado.Cadastros.PageObjects
{
    [TestClass]
    public class PaginaManterBibliotecaGlosas : PaginaBase
    {
        #region Declaração de variáveis públicas da classe

        public By campoDescricaoGlosa = By.Id("descricao-glosa");
        public By comboModalidade = By.Id("drop-list");
        public By botaoBuscar = By.ClassName("fa-search");
        public By botaoLimpar = By.ClassName("fa-eraser");
        public By botaoNovo = By.ClassName("fa-plus");
        public By tabelaResultadoPesquisa = By.ClassName("table-striped");
        //public By comboCargaHoraria = By.Id("cargaHoraria");
        //public By botaoAdicionar = By.ClassName("fa-plus");
        //public By botaoAlterar = By.ClassName("fa-pencil");
        //public By botaoSalvar = By.ClassName("fa-save");
        //public By botaoCancelar = By.ClassName("fa-long-arrow-left");
        //public By botaoBuscar = By.ClassName("fa-search");
        //public By botaoLimpar = By.ClassName("fa-eraser");
        //public By botaoOcultarFiltros = By.XPath("(//button[@type='button'])[2]");
        //public By botaoExibirFiltros = By.XPath("//button[@type='button']");
        //public By botaoConfirmar = By.ClassName("fa-check");
        //public By botaoNaoConfirmar = By.ClassName("fa-times");
        //public By botaoFechar = By.ClassName("fa-times");
        //public By botaoFecharMensagemConfirmacaoCadastro = By.ClassName("fa-times");
        //public By botaoFecharMensagemConfirmacao = By.XPath("//app-modal-resposta/div/div/div[3]/button");
        //public By botaoFecharMensagemConfirmacaoNenhumRegistroEncontrado = By.XPath("//app-modal/div/div/div[3]/button");
        //public By comboPostoVistoriaCadastro = By.XPath("//form[@id='formulario']/div/div/app-drop-list/select");
        //public By comboTipoVistoriadorCadastro = By.Name("tipoVistoriador");
        //public By campoCargaHorariaCadastro = By.Id("cargaHoraria");
        //public By campoQtdadeNF = By.Id("capacidade");
        //public By campoObservacao = By.Id("observacao");
        //public By mensagemRetorno = By.XPath("//p");
        //public By ordernarPostoVistoria = By.XPath("//section[@id='content']/section/section/section/section/app-manter-capacidade-perfil/div/div[3]/div/app-manter-capacidade-perfil-grid/app-grid/section/div/table/thead/tr/th[1]/app-ordenacao/div");
        //public By ordernarPerfil = By.XPath("//section[@id='content']/section/section/section/section/app-manter-capacidade-perfil/div/div[3]/div/app-manter-capacidade-perfil-grid/app-grid/section/div/table/thead/tr/th[2]/app-ordenacao/div");
        //public By ordernarCargaHoraria = By.XPath("//section[@id='content']/section/section/section/section/app-manter-capacidade-perfil/div/div[3]/div/app-manter-capacidade-perfil-grid/app-grid/section/div/table/thead/tr/th[3]/app-ordenacao/div");
        //public By ordernarQtdadeNF = By.XPath("//section[@id='content']/section/section/section/section/app-manter-capacidade-perfil/div/div[3]/div/app-manter-capacidade-perfil-grid/app-grid/section/div/table/thead/tr/th[4]/app-ordenacao/div");
        //public By tabelaResultadoPesquisa = By.ClassName("table-striped");


        #endregion

        #region Métodos públicos

        public PaginaManterBibliotecaGlosas(RemoteWebDriver driver) : base(driver)
        { }
        public void PesquisarGlosa(string Descricao = "", string Modalidade = "")
        {
            AguardarProcessando();
            AguardarElemento(botaoBuscar);
            AguardarTexto(comboModalidade, "Selecione uma opção");
            if (Descricao != "")
            {
                PreencherCampo(campoDescricaoGlosa, Descricao);
            }
            if (Modalidade != "")
            {
                SelecionarItemCombo(comboModalidade, Modalidade);
            }
            AguardarProcessando();
            ClicarDuploElementoPagina(botaoBuscar);
        }

        #endregion

    }
}
