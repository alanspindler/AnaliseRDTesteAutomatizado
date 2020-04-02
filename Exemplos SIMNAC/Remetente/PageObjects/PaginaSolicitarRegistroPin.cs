using OpenQA.Selenium;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using System;

namespace Lampp.AnaliseRD.Teste.Automatizado.Remetente.PageObjects
{
    [TestClass]
    public class PaginaSolicitarRegistroPin : PaginaBase
    {

        #region Declaração de variáveis públicas da classe

        public By campoCnpjDestinatario = By.Id("txtcnpjDestinatarioo");
        public By campoRazaoSocial = By.Id("txtRazaoSocial");
        public By comboUfDestino = By.Id("selectUfDestinatario");
        public By comboTipoPesquisa = By.Id("ufx");
        public By campoNotaFiscalChaveAcesso = By.Id("txtNotaFiscalChaveAcesso");
        public By campoDataInicio = By.Id("dtEmissaoInicio");
        public By campoDataFim = By.Id("dtEmissaoFinal");
        public By comboSituacao = By.Id("drop-list");
        public By botaoBuscar = By.Id("btnBuscar");
        public By botaoLimpar = By.ClassName("fa-eraser");
        public By botaoOcultarFiltros = By.Id("fa-magic");
        public By botaoExibirFiltros = By.Id("fa-magic");
        public By botaoFecharMensagemConfirmacaoNenhumRegistroEncontrado = By.XPath("(//button[@type='button'])[11]");
        public By botaoSolicitarRegistroPin = By.ClassName("fa-save");
        public By botaoExcluirNfe = By.ClassName("btn-danger");
        public By botaoConfirmarOperacao = By.ClassName("fa-check");
        public By botaoCancelarOperacao = By.ClassName("fa-times");
        public By botaoFecharMensagemRetornoRegistroPin = By.XPath("//section[@id='content']/section/section/section/section/app-solicitar-registro-pin/app-modal-nfe-mensagem-impedida-ingresso/div[1]/div/div/div[3]/button");
        //public By botaoFecharMensagemRetornoRegistroPin = By.XPath("//section[contains(text(), 'Fechar')]");
        //public By botaoFecharMensagemRetornoRegistroPin = By.



        public By modalConfirmacaoPin = By.Id("ajudaModalLabel");

        #endregion

        #region Métodos públicos

        public PaginaSolicitarRegistroPin(RemoteWebDriver driver) : base(driver)
        {

        }

        public void PreparaNotasParaSolicitacao()
        {
            var bancodeDados = new BancodeDados(driver);
            bancodeDados.executarComandoSQL("UPDATE dbo.AnaliseRD_NFE SET AnaliseRD_NFE.NFE_NU_CNPJ_REMETENTE = '13881630000164', AnaliseRD_NFE.NFE_NU_CNPJ_DESTINATARIO = '03134910000236', AnaliseRD_NFE.NFE_DH_EMISSAO = getdate(), dbo.AnaliseRD_NFE.NFE_DT_LIMITE_VISTORIA = getdate() + 120");
            bancodeDados.executarComandoSQL("DELETE FROM AnaliseRD_ITEM_SOLICITACAO WHERE AnaliseRD_ITEM_SOLICITACAO.SOL_ID IN (SELECT SOL_ID FROM dbo.AnaliseRD_SOLICITACAO_PIN  WHERE  AnaliseRD_SOLICITACAO_PIN.NFE_ID IN(SELECT NFE_ID FROM dbo.AnaliseRD_NFE_SITUACAO WHERE AnaliseRD_NFE_SITUACAO.SIT_ST_PROCESSO = 3))");
            bancodeDados.executarComandoSQL("DELETE FROM AnaliseRD_NFE_SITUACAO_HIST WHERE  NFE_ID IN(SELECT NFE_ID FROM dbo.AnaliseRD_NFE_SITUACAO WHERE AnaliseRD_NFE_SITUACAO.SIT_ST_PROCESSO = 3)");
            bancodeDados.executarComandoSQL("DELETE FROM AnaliseRD_SOLICITACAO_PIN WHERE   NFE_ID IN(SELECT NFE_ID FROM dbo.AnaliseRD_NFE_SITUACAO WHERE AnaliseRD_NFE_SITUACAO.SIT_ST_PROCESSO = 3)");
            bancodeDados.executarComandoSQL("UPDATE AnaliseRD_NFE_SITUACAO SET AnaliseRD_NFE_SITUACAO.SIT_ST_PROCESSO = 2 WHERE AnaliseRD_NFE_SITUACAO.SIT_ST_PROCESSO = 3");
        }
        #endregion

        #region Metodos Publicos

        //Clica no botão OcultarFiltros
        public void OcultarFiltros()
        {
            ClicarElementoPagina(botaoOcultarFiltros);
            Thread.Sleep(1500);
        }

        //Clica no botão Exibir Filtros
        public void ExibirFiltros()
        {
            ClicarElementoPagina(botaoExibirFiltros);
            AguardarProcessando();
        }

        public void Limpar()
        {
            ClicarElementoPagina(botaoLimpar);
            Thread.Sleep(500);
            
        }

        public void FecharTelaConfirmacao()
        {
            AguardarProcessando();
            //ZoomOut();
            //Thread.Sleep(300);         
            ClicarElementoPagina(botaoFecharMensagemRetornoRegistroPin);
            AguardarProcessando();
        }

        ///// <summary>
        ///// Valida a quantidade de linhas exibidas no grid
        ///// </summary>
        ///// <remarks>Escrita por Alan Spindler em 12/01/2016</remarks>
        //public new void ValidarLinhasGrid(int valorEsperado)
        //{
        //    AguardarProcessando();
        //    var quantidadeLinhasGridRetornada = RetornarQuantidadeLinhasGrid() - 4;
        //    Assert.AreEqual(valorEsperado, quantidadeLinhasGridRetornada, "Valor inválido! Números e linhas esperadas: " + valorEsperado + " linhas retornadas: " + quantidadeLinhasGridRetornada);

        //}

        public By RetornaItemResultadoPesquisa(int linha, int item)
        {
            return By.XPath($"//section[@id='content']/section/section/section/section/app-solicitar-registro-pin/div/div[4]/div/section/app-nfe-grid/app-grid/section/div/table/tbody/tr[{linha}]/td[{item}]");
            //xpath =//section[@id='content']/section/section/section/section/app-solicitar-registro-pin/div/div[4]/div/section/app-nfe-grid/app-grid/section/div/table/tbody/tr[{linha}]/td[{item}]");
        }

        public By RetornaCheckboxResultadoPesquisa(int linha)
        {
            return By.XPath($"//section[@id='content']/section/section/section/section/app-solicitar-registro-pin/div/div[4]/div/section/app-nfe-grid/app-grid/section/div/table/tbody/tr[{linha}]/td[1]");
        }

        public By RetornaVisualizarItemResultadoPesquisa(int linha)
        {
            return By.XPath($"//section[@id='content']/section/section/section/section/app-solicitar-registro-pin/div/div[4]/div/section/app-nfe-grid/app-grid/section/div/table/tbody/tr[{linha}]/td[2]");
        }

        public By RetornaMensagemResultadoRegistroPin(int linha)
        {
            return By.XPath($"//section[@id='content']/section/section/section/section/app-solicitar-registro-pin/app-modal-nfe-mensagem-impedida-ingresso/div/div/div/div[2]/form/section/article/div/div/app-modal-nfe-mensagem-impedida-ingresso-grid/div/table/tbody/tr[{linha}]/td[4]");
        }

        public enum IndiceResultadoPesquisa
        {
            UF = 3,
            CnpjDestinatario = 4,
            InscricaoCadastral = 5,
            RazaoSocial = 6,
            NumeroNota = 7,
            ValorNota = 8,
            DataEmissao = 9,
            DataLimiteVistoria = 10,
            QtdeDiasVistoria = 11,
            Situacao = 12,
            QtdeItens = 13
        }

        public void SolicitarUmRegistroPin(int linha)
        {
            AguardarProcessando();
            MarcarCheckbox(RetornaCheckboxResultadoPesquisa(linha), RetornaCheckboxResultadoPesquisa(linha), true);
            ClicarElementoPagina(botaoSolicitarRegistroPin);
            Thread.Sleep(1000);
            ClicarElementoPagina(botaoConfirmarOperacao);
            AguardarProcessando();
        }

        public void ValidarMensagemRetornoRegistroPin(int linha, bool sucesso, string textoFalha = "")
        {
            if (sucesso)
            {
                ValidarTexto("Solicitação registrada com sucesso.", RetornaMensagemResultadoRegistroPin(linha));
            }
            else
            {
                ValidarTexto(textoFalha, RetornaMensagemResultadoRegistroPin(linha));
            }
        }


        //Faz a pesquisa da capacidade da NF
        public void PesquisarNFparaSolicitacao(string cnpjDestinatario, string ufDestino, string tipoPesquisa, string valorPesquisa, string dataInicial, string dataFinal, int situacao = 0)
        {
            AguardarProcessando();
            AguardarElemento(botaoBuscar);
            if (cnpjDestinatario != "")
            {
                PreencherCampo(campoCnpjDestinatario, cnpjDestinatario);
            }
            if (ufDestino != "")
            {
                SelecionarItemCombo(comboUfDestino, ufDestino);
            }
            if (tipoPesquisa != "" && tipoPesquisa != "Nenhum")
            {
                SelecionarItemCombo(comboTipoPesquisa, tipoPesquisa);
                Thread.Sleep(300);
                PreencherCampo(campoNotaFiscalChaveAcesso, valorPesquisa);
            }
            if (dataFinal != "" && dataFinal != "")
            {
                PreencherCampo(campoDataInicio, dataInicial);
                PreencherCampo(campoDataFim, dataFinal);
            }
            if (situacao == 2)
            {
                SelecionarItemCombo(comboSituacao, "NF-e Aguardando Solicitação do Registro do PIN pelo Remetente");
            }
            if (situacao == 3)
            {
                SelecionarItemCombo(comboSituacao, "NF-e Aguardando Confirmação do Registro do PIN pelo Destinatario");
            }

            ClicarElementoPagina(botaoBuscar);
            AguardarProcessando();
            if (IsElementDisplayed(driver, botaoFecharMensagemConfirmacaoNenhumRegistroEncontrado))
            {
                ClicarElementoPagina(botaoFecharMensagemConfirmacaoNenhumRegistroEncontrado);
                AguardarProcessando();
            }
            AguardarProcessando();
        }

        //Valida o campo informado todos os itens exibidos pelo grid.
        //Utilizado para verificar se ao filtrar por um campo, todos os resultados são filtrados.
        public void ValidarTodosItensFiltroSelecionado(string campo, string texto)
        {
            int quantidadeLinhasGridRetornada = RetornarQuantidadeLinhasGrid() - 1;
            int i = 1;
            int indice = 0;
            IndiceResultadoPesquisa enumCampo = (IndiceResultadoPesquisa)Enum.Parse(typeof(IndiceResultadoPesquisa), campo);
            indice = (int)enumCampo;
            for (i = 1; i <= quantidadeLinhasGridRetornada; i++)
            {
                ValidarTexto(texto, RetornaItemResultadoPesquisa(i, indice));
                //driver.SwitchTo().Frame(driver.FindElement(By.ClassName("fancybox-iframe")));
            }
        }

        #endregion
    }
}





//        //Preenche os campos da capacidade do perfil, e clica em salvar. Confirma ou cancela de acordo com o parametro confirmar.
//        public void IncluirCapacidadePesquisa(bool confirmar, string PostoVistoria, string Perfil, string CargaHoraria, string quantidade)
//        {
//            AguardarElemento(botaoSalvar);
//            AguardarProcessando();
//            SelecionarItemCombo(comboPostoVistoriaCadastro, PostoVistoria);
//            SelecionarItemCombo(comboTipoVistoriadorCadastro, Perfil);
//            SelecionarItemCombo(comboCargaHorariaCadastro, CargaHoraria);
//            PreencherCampo(campoQtdadeNF, quantidade);
//            ClicarElementoPagina(botaoSalvar);
//            if (confirmar)
//            {
//                AguardarProcessando();
//                ClicarElementoPagina(botaoConfirmar);
//            }
//            else
//            {
//                AguardarProcessando();
//                ClicarElementoPagina(botaoNaoConfirmar);
//            }
//            AguardarProcessando();
//        }


//        public void Changesize(string size)
//        {
//            MouseSobre(By.ClassName("replace-2x"));
//            Thread.Sleep(2000);
//            ClicarElementoPagina(By.CssSelector("a.quick-view"));
//            Thread.Sleep(5000);
           
//            SelecionarItemCombo(By.Id("group_1"), size);
//        }





//        //Caso abra tela de histórico ou outra com grid, as linhas do grid passam a ser contadas, então é necessário utilizar esse modificador
//        public void ExcluirTodosItensGrid(bool confirmar, int modificador = 0)
//        {
//            //AguardarElemento(BotaoIncluiBase);

//            var quantidadeLinhasGridRetornada = (RetornarQuantidadeLinhasGrid() - 2) - modificador;
//            while (quantidadeLinhasGridRetornada > 0)
//            {
//                if (confirmar)
//                {
//                    ExcluirItemLinhaSelecionada(true, 1);
//                }
//                else
//                {
//                    ExcluirItemLinhaSelecionada(false, 1);
//                    break;
//                }
//                AguardarProcessando();
//                quantidadeLinhasGridRetornada = RetornarQuantidadeLinhasGrid() - 2 - modificador;
//            }
//        }

//        //Retorna o Xpath do item específico (exemplo Posto de Vistoria) do resultado da pesquisa, usado para fazer assert ce textos do resultados, etc.



//        //Retorna o Xpath do item específico (exemplo Posto de Vistoria) do histórico de inclusão/alteração, usado para fazer assert ce textos do resultados, etc.
//        public By RetornaItemHistorico(int linha, int item)
//        {
//            return By.XPath($"//section[@id='content']/section/section/section/section/app-manter-capacidade-perfil/div/div[3]/div/section/app-manter-capacidade-perfil-grid/app-modal-historico-capacidade-perfil/div/div/div/div[2]/form/section/article/div/div/app-manter-historico-capacidade-perfil-grid/app-grid/div/table/tbody/tr[{linha}]/td[{item}]");
//        }


//        /// <summary>
//        /// Valida a quantidade de linhas exibidas no grid
//        /// </summary>
//        /// <remarks>Escrita por Alan Spindler em 12/01/2016</remarks>
//        public new void ValidarLinhasGrid(int valorEsperado)
//        {
//            var quantidadeLinhasGridRetornada = RetornarQuantidadeLinhasGrid() - 2;
//            Assert.AreEqual(valorEsperado, quantidadeLinhasGridRetornada, "Valor inválido! Números e linhas esperadas: " + valorEsperado + " linhas retornadas: " + quantidadeLinhasGridRetornada);
//        }

//        //Exclui o item da linha selecionado. Confirma a exclusão de acotdo com o parametro confirmar
//        public void ExcluirItemLinhaSelecionada(bool confirmar, int linha)
//        {
//            AguardarProcessando();
//            ClicarElementoPagina(BotaoExcluirLinhaSelecionada(linha));

//            if (confirmar)
//            {
//                ClicarElementoPagina(botaoConfirmar);
//            }
//            else
//            {
//                ClicarElementoPagina(botaoNaoConfirmar);
//            }

//            AguardarProcessando();
//            Thread.Sleep(8000);
//            if (IsElementDisplayed(driver, botaoFecharMensagemConfirmacaoNenhumRegistroEncontrado))
//            {
//                ClicarElementoPagina(botaoFecharMensagemConfirmacaoNenhumRegistroEncontrado);
//            }
//            if (IsElementDisplayed(driver, botaoFecharMensagemConfirmacao))
//            {
//                AguardarProcessando();
//                ClicarElementoPagina(botaoFecharMensagemConfirmacao);
//            }
//            AguardarProcessando();
//        }

//        //Exclui todos os itens até que não restem itens no grid. Utilizado para limpar antes de testes, por exemplo.
//        public void ExcluirTodosItens()
//        {
//            AguardarProcessando();

//            var quantidadeLinhasGridRetornada = RetornarQuantidadeLinhasGrid() - 2;
//            while (quantidadeLinhasGridRetornada > 0)
//            {
//                ExcluirItemLinhaSelecionada(true, 1);
//                AguardarProcessando();
//                quantidadeLinhasGridRetornada = RetornarQuantidadeLinhasGrid() - 2;
//            }
//        }



//        //public void ExportarPDF()
//        //{
//        //    ClicarElementoPagina(botaoExportar);
//        //    Thread.Sleep(700);
//        //    ClicarElementoPagina(botaoSalvarPDF);
//        //}

//        //Na tela de cadastro/alteração, clica em Cancelar.
//        public void CancelarCadastro()
//        {
//            AguardarProcessando();
//            ClicarElementoPagina(botaoCancelar);
//            AguardarProcessando();
//        }

//        //Albre o histórico do item da linha informada.
//        public void AbrirHistorico(int linha)
//        {
//            AguardarProcessando();
//            ClicarElementoPagina(BotaoAbrirHistoricoLinhaSelecionada(linha));
//            AguardarProcessando();
//        }

//        //Abre a tela de alteração do item da linha informada.
//        public void AbrirAlterar(int linha)
//        {
//            AguardarProcessando();
//            ClicarElementoPagina(BotaoAlterarLinhaSelecionada(linha));
//            AguardarProcessando();
//        }

//        //Valida o texto do item do resultado da pesquisa da linha informada. 
//        public void ValidarItensResultadoPesquisa(int linha, string postoVistoria, string perfil, string cargaHoraria, string QtdadeNF)
//        {
//            AguardarProcessando();
//            ValidarTexto(postoVistoria, RetornaItemResultadoPesquisa(linha, 1));
//            ValidarTexto(perfil, RetornaItemResultadoPesquisa(linha, 2));
//            ValidarTexto(cargaHoraria, RetornaItemResultadoPesquisa(linha, 3));
//            ValidarTexto(QtdadeNF, RetornaItemResultadoPesquisa(linha, 4));
//        }

//        //Valida o histórico aberto, na linha informada.
//        public void ValidarItensHistorico(int linha, string PostoVistoria, string Perfil, string CargaHoraria, string QtdadeNF, string Operacao, string Justificativa)
//        {
//            AguardarProcessando();
//            ValidarTexto(PostoVistoria, RetornaItemHistorico(linha, 1));
//            ValidarTexto(Perfil, RetornaItemHistorico(linha, 2));
//            ValidarTexto(CargaHoraria, RetornaItemHistorico(linha, 3));
//            ValidarTexto(QtdadeNF, RetornaItemHistorico(linha, 4));
//            ValidarTexto(Operacao, RetornaItemHistorico(linha, 5));
//            ValidarTexto(Justificativa, RetornaItemHistorico(linha, 8));
//        }

//        #endregion
//    }
//}

