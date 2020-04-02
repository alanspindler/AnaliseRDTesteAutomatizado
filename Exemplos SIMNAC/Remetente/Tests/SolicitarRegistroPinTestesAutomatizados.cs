using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lampp.AnaliseRD.Teste.Automatizado.Remetente.PageObjects;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Lampp.AnaliseRD.Teste.Automatizado.Login.PageObjects;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace Lampp.AnaliseRD.Teste.Automatizado.Cadastros.Tests
{
    [TestClass]
    class SolicitarRegistroPinTestesAutomatizados
    {
        public Global Global { get; set; }
        public PaginaBase PaginaBase { get; set; }
        public PaginaInicial PaginaInicial { get; set; }
        public PaginaSolicitarRegistroPin paginaSolicitarRegistroPin { get; set; }
        private string urlPaginaInicial = "http://localhost:4200/#/solicitar-registro-pin";
        Global selenium;

        [TestInitialize]
        public void IniciarTeste()
        {
            selenium = Global.obterInstancia();
            paginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
            //Abre a pagina inicial
            PaginaBase = new PaginaBase(selenium.driver);
            PaginaInicial = new PaginaInicial(selenium.driver);
            PaginaInicial.AbrirPagina(urlPaginaInicial);
            //Reinicia as notas que foram solicitadas
            paginaSolicitarRegistroPin.PreparaNotasParaSolicitacao();
            //Faz Login
            PaginaInicial.FazerLogin("13881630000164", "123");
            paginaSolicitarRegistroPin.AguardarProcessando();   
        }

        [TestCleanup]
        public void FinalizarTeste()
        {
            selenium.EncerrarTeste();
        }

        [TestMethod]
        public void PesquisarNotasPorCNPJ()
        {
            //Chama a função de efetuar a pesquisa por nome do texto que deve ser selecionado.            
            paginaSolicitarRegistroPin.PesquisarNFparaSolicitacao("03.134.910/0002-36", "", "", "", "", "");
            //Valida a quantidade de resultados exibidos
            paginaSolicitarRegistroPin.ValidarLinhasGrid(10);
            paginaSolicitarRegistroPin.ValidarTodosItensFiltroSelecionado("CnpjDestinatario", "03.134.910/0002-36");     
            //Clica no botão Limpar
            paginaSolicitarRegistroPin.Limpar();
            paginaSolicitarRegistroPin.ValidarLinhasGrid(0);
            paginaSolicitarRegistroPin.ValidarTexto("", paginaSolicitarRegistroPin.campoCnpjDestinatario);
            paginaSolicitarRegistroPin.ValidarCampoSomenteLeitura(paginaSolicitarRegistroPin.campoRazaoSocial);
            paginaSolicitarRegistroPin.ValidarCampoSomenteLeitura(paginaSolicitarRegistroPin.campoNotaFiscalChaveAcesso);
        }

        [TestMethod]
        public void PesquisarNotasPorCNPJ2()
        {
            //Chama a função de efetuar a pesquisa por nome do texto que deve ser selecionado.            
            paginaSolicitarRegistroPin.PesquisarNFparaSolicitacao("03.134.910/0002-36", "", "", "", "", "");
            //Valida a quantidade de resultados exibidos
            paginaSolicitarRegistroPin.ValidarLinhasGrid(10);
            paginaSolicitarRegistroPin.ValidarTodosItensFiltroSelecionado("CnpjDestinatario", "03.134.910/0002-36");
            paginaSolicitarRegistroPin.SolicitarUmRegistroPin(1);
            paginaSolicitarRegistroPin.ValidarMensagemRetornoRegistroPin(1, true);
            paginaSolicitarRegistroPin.FecharTelaConfirmacao();
            //Clica no botão Limpar
            paginaSolicitarRegistroPin.Limpar();
            paginaSolicitarRegistroPin.ValidarLinhasGrid(0);
            paginaSolicitarRegistroPin.ValidarTexto("", paginaSolicitarRegistroPin.campoCnpjDestinatario);
            paginaSolicitarRegistroPin.ValidarCampoSomenteLeitura(paginaSolicitarRegistroPin.campoRazaoSocial);
            paginaSolicitarRegistroPin.ValidarCampoSomenteLeitura(paginaSolicitarRegistroPin.campoNotaFiscalChaveAcesso);

        }

        //[TestMethod]
        //public void IncluirNovaCapacidade()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    //Faz login
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Clica no botão Adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Seleciona os valres das combos, preenche a quantidade de notas e clicar em salvar. Também confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de êxito.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Faz a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    ////Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //// Valida se o valor escolhido está na combo
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("MANAUS",
        //        PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Vistoriador Interno",
        //        PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Todas",
        //        PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    //Exclui o item selecionado. O parametro true é para confirmar a exclusão.
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida que o grid foi atualizado e não contém itens.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //Clica no botão Limpar
        //    PaginaSolicitarRegistroPin.Limpar();
        //    //Valida se o valor da combo volta ao padrão após limpar
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Selecione uma Opção",
        //        PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    //// Aqui o valor deveria ser 0, mas a função de limpar do protótipo não limpa o grid de pesquisa
        //    //PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    ////Valida o Texto do botão antes de pressionar
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Ocultar Filtros", PaginaSolicitarRegistroPin.botaoOcultarFiltros);
        //    ////Clica em Ocultar FIltros
        //    PaginaSolicitarRegistroPin.OcultarFiltros();
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo não está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    ////Valida se texto do botão Ocultar FIltros foi alterado
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Exibir Filtros", PaginaSolicitarRegistroPin.botaoExibirFiltros);
        //    ////Clica novamente no botão para voltar a exibir os filtros
        //    PaginaSolicitarRegistroPin.ExibirFiltros();
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    //////Clicar em Exportar em PDF - Não faz nada nesse prototipo
        //    ////PaginaSolicitarRegistroPin.ExportarPDF();
        //    //// Fecha o navegador            
        //    selenium.EncerrarTeste();
        //}

        //[TestMethod]
        //public void IncluirCapacidadeDuplicada()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    //Faz login
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //    //Chama a função de efetuar a pesquisa por nome do texto que deve ser selecionado.
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Faz a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Exclui todos os itens, caso encontre (caso outro teste não finalize corretamente e deixe itens cadastrados.
        //    PaginaSolicitarRegistroPin.ExcluirTodosItens();
        //    //Clica em Adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Preenche os dados da capacidade de Perfil, clica em Salvar e Confirma
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Fecha a mensagem de sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Faz a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    ////Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Clica em adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //    //Preenche os dados da capacidade de perfil, clica em Salvar e Confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "400");
        //    //Valida retorno do erro.
        //    PaginaSolicitarRegistroPin.ValidarTexto(
        //        "Já existe uma capacidade cadastrada para o Posto de Vistoria, Perfil e Carga Horária informados.",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de erro.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //    //Clica em Cancelar para voltar à pagina de pesquisa.
        //    PaginaSolicitarRegistroPin.CancelarCadastro();
        //    //Efetua novamente a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    ////Valida a quantidade de resultados exibidos. Deve ser 1, pois o segundo cadastro gerou erro.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //// Exclui o item
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida se item foi corretamente excluido.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //Clica no botão Limpar
        //    PaginaSolicitarRegistroPin.Limpar();
        //    //Valida se o valor da combo volta ao padrão após limpar
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Selecione uma Opção",
        //        PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    //// Aqui o valor deveria ser 0, mas a função de limpar do protótipo não limpa o grid de pesquisa
        //    //PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    ////Valida o Texto do botão antes de pressionar
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Ocultar Filtros", PaginaSolicitarRegistroPin.botaoOcultarFiltros);
        //    ////Clica em Ocultar FIltros
        //    PaginaSolicitarRegistroPin.OcultarFiltros();
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo não está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    ////Valida se texto do botão Ocultar FIltros foi alterado
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Exibir Filtros", PaginaSolicitarRegistroPin.botaoExibirFiltros);
        //    ////Clica novamenten o botão para voltar a exibir os filtros
        //    PaginaSolicitarRegistroPin.ExibirFiltros();
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);

        //    //////Clicar em Exportar em PDF - Não faz nada nesse prototipo
        //    ////PaginaSolicitarRegistroPin.ExportarPDF();
        //    //// Fecha o navegador            
        //    selenium.EncerrarTeste();
        //}

        //[TestMethod]
        //public void IncluirDuasCapacidadesExcluirUma()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    //Faz login
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Clica em Adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Preenche os dados, clica em Salvar e Confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha mensagem de sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Efetua a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Clica em Adicionar.
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //    //Preenche os dados, clica em Salvar e Confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Externo", "8hs",
        //        "400");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //    //Faz a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Todos", "Todas");
        //    ////Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(2);
        //    //Valida as duas linhas retornadas, para verificar se os dados estão corretos.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Externo", "8",
        //        "400");
        //    //Exclui o primeiro item
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida que só existe um item após a exclusão.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Exclui o item restante.
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida que não existem mais itens.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //Clica no botão Limpar
        //    PaginaSolicitarRegistroPin.Limpar();
        //    //Valida se o valor da combo volta ao padrão após limpar
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Selecione uma Opção",
        //        PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    //// Aqui o valor deveria ser 0, mas a função de limpar do protótipo não limpa o grid de pesquisa
        //    //PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    ////Valida o Texto do botão antes de pressionar
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Ocultar Filtros", PaginaSolicitarRegistroPin.botaoOcultarFiltros);
        //    ////Clica em Ocultar FIltros
        //    PaginaSolicitarRegistroPin.OcultarFiltros();
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo não está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    ////Valida se texto do botão Ocultar FIltros foi alterado
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Exibir Filtros", PaginaSolicitarRegistroPin.botaoExibirFiltros);
        //    ////Clica novamenten o botão para voltar a exibir os filtros
        //    PaginaSolicitarRegistroPin.ExibirFiltros();
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    //////Clicar em Exportar em PDF - Não faz nada nesse prototipo
        //    ////PaginaSolicitarRegistroPin.ExportarPDF();
        //    //// Fecha o navegador            
        //    selenium.EncerrarTeste();
        //}

        //[TestMethod]
        //public void AlterarCapacidadePerfil()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    //Faz login
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Clica em Incluir.
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Inclui os dados, clica em Salvar e Confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de confirmação.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Faz a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida se resultado da pesquisa está de acordo com item cadastrado.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    //Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Clica em Alterar.
        //    PaginaSolicitarRegistroPin.AbrirAlterar(1);
        //    //Altera a Quantidade de BF e Insere Justificativa. CLica em Salvar e em Confirmar.
        //    PaginaSolicitarRegistroPin.AlterarCapacidadePesquisa(true, "650", "Teste Alteracao para 650");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha Mensagem de Sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //    //Faz a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida valores alterados no resultado da pesquisa.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "650");
        //    //Valida a quantidade de itens exibidos.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Exclui o item.
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida se o item foi realmente foi excluido.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //Encerra o Selenium.
        //    selenium.EncerrarTeste();
        //}

        //[TestMethod]
        //public void ValidarHistoricoInclusao()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    //Faz login.
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Clica no botão Adicionar.
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Inclui os dados, clica em Salvar e em Confirmar.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de confirmação.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Faz a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida a quantidade de itens exibidos.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Valida os dados do item exibido.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    //Clica no botao do Historico do Item            
        //    PaginaSolicitarRegistroPin.AbrirHistorico(1);
        //    //Valida os itens do histórico
        //    PaginaSolicitarRegistroPin.ValidarItensHistorico(1, "MANAUS", "Vistoriador Interno", "6", "300",
        //        "Inclusão", "");
        //    //Valida se o item do histórico e o item da pesquisa são exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(2);
        //    //Fecha o histórico
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFechar);
        //    //Clica em Alterar
        //    PaginaSolicitarRegistroPin.AbrirAlterar(1);
        //    //Altera a quantidade de NF
        //    PaginaSolicitarRegistroPin.AlterarCapacidadePesquisa(true, "650", "Teste Alteracao para 650");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de confirmação.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //    //Efetua a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida o texto do item da pesquisa
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "650");
        //    //Abrir histórico do item exibido
        //    PaginaSolicitarRegistroPin.AbrirHistorico(1);
        //    //Valida a primeira linha do histórico
        //    PaginaSolicitarRegistroPin.ValidarItensHistorico(1, "MANAUS", "Vistoriador Interno", "6", "300",
        //        "Inclusão", "");
        //    //Valida a segunda linha do histórico
        //    PaginaSolicitarRegistroPin.ValidarItensHistorico(2, "MANAUS", "Vistoriador Interno", "6", "650",
        //        "Alteração", "Teste Alteracao para 650");
        //    //Conta as linhas de histórico + resultado da pesquisa.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(3);
        //    //Fecha o histórico
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFechar);
        //    //Exclui o item
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    selenium.EncerrarTeste();
        //}


        //[TestMethod]
        //public void IncluirDuasCapacidadesExcluirASegunda()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //    //Chama a função de efetuar a pesquisa por nome do texto que deve ser selecionado.
        //    PaginaBase.AguardarProcessando();
        //    //Clicar em Adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Preenche os dados, clica em Salvar e confirmar o cadastro.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha mensagem de confirmação.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Faz a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Clica em Adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //    //Preenche os dados, clica em Salvar e confirmar o cadastro.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "8hs",
        //        "400");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //    //Faz a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(2);
        //    //Valida os dados do primeiro item da pesquisa.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    //Valida os dados do segundo item da pesquisa.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Interno", "8",
        //        "400");
        //    //Excluir o segundo item da pesquisa.
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 2);
        //    //Valida os dados do primeiro item da pesquisa.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    //Valida a quantidade de itens retornados.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Exclui o item restante.
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida a exclusão do item.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //Clica no botão Limpar
        //    PaginaSolicitarRegistroPin.Limpar();
        //    //Valida se o valor da combo volta ao padrão após limpar
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Selecione uma Opção",
        //        PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    //// Aqui o valor deveria ser 0, mas a função de limpar do protótipo não limpa o grid de pesquisa
        //    //PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    ////Valida o Texto do botão antes de pressionar
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Ocultar Filtros", PaginaSolicitarRegistroPin.botaoOcultarFiltros);
        //    ////Clica em Ocultar FIltros
        //    PaginaSolicitarRegistroPin.OcultarFiltros();
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo não está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    ////Valida se texto do botão Ocultar FIltros foi alterado
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Exibir Filtros", PaginaSolicitarRegistroPin.botaoExibirFiltros);
        //    ////Clica novamenten o botão para voltar a exibir os filtros
        //    PaginaSolicitarRegistroPin.ExibirFiltros();
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);

        //    //////Clicar em Exportar em PDF - Não faz nada nesse prototipo
        //    ////PaginaSolicitarRegistroPin.ExportarPDF();
        //    //// Fecha o navegador                        
        //    selenium.EncerrarTeste();
        //}

        //[TestMethod]
        //public void ValidarOrdenacaoPesquisa()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //PaginaInicial.AbrirPagina("http://localhost:4200/#/capacidade-perfil");
        //    //Faz login
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Clica em Adicionar
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Preenche os dados, clica em Salvar e Confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Interno", "6hs",
        //        "300");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha mensagem de sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    //Efetua a pesquisa
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Vistoriador Interno", "Todas");
        //    //Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Clica em Adicionar.
        //    PaginaBase.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoAdicionar);
        //    //Preenche os dados, clica em Salvar e Confirma.
        //    PaginaSolicitarRegistroPin.IncluirCapacidadePesquisa(true, "MANAUS", "Vistoriador Externo", "8hs",
        //        "400");
        //    //Valida mensagem de sucesso
        //    PaginaSolicitarRegistroPin.ValidarTexto("Operação realizada com sucesso!",
        //        PaginaSolicitarRegistroPin.MensagemRetorno);
        //    //Fecha a mensagem de sucesso.
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.botaoFecharMensagemConfirmacaoCadastro);
        //    //Faz a pesquisa.
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Todos", "Todas");
        //    ////Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(2);
        //    //Valida as duas linhas retornadas, para verificar se os dados estão corretos.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Externo", "8",
        //        "400");
        //    //Orderna o resultado da pesquisa por Tipo de Vistoriador
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.OrdernarCargaHoraria);
        //    Thread.Sleep(2000);
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Externo", "8",
        //        "400");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.OrdernarCargaHoraria);
        //    Thread.Sleep(2000);
        //    //Valida as duas linhas retornadas, para verificar se os dados estão corretos.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Externo", "8",
        //        "400");
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.OrdernarPerfil);
        //    Thread.Sleep(2000);
        //    //Valida as duas linhas retornadas, para verificar se os dados estão corretos.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Externo", "8",
        //        "400");
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.OrdernarPerfil);
        //    Thread.Sleep(2000);
        //    //Valida as duas linhas retornadas, para verificar se os dados estão corretos.
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Externo", "8",
        //        "400");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ClicarElementoPagina(PaginaSolicitarRegistroPin.OrdernarPerfil);
        //    Thread.Sleep(2000);
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(1, "MANAUS", "Vistoriador Interno", "6",
        //        "300");
        //    PaginaSolicitarRegistroPin.ValidarItensResultadoPesquisa(2, "MANAUS", "Vistoriador Externo", "8",
        //        "400"); //Exclui o primeiro item
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida que só existe um item após a exclusão.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(1);
        //    //Exclui o item restante.
        //    PaginaSolicitarRegistroPin.ExcluirItemLinhaSelecionada(true, 1);
        //    //Valida que não existem mais itens.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //Clica no botão Limpar
        //    PaginaSolicitarRegistroPin.Limpar();
        //    //Valida se o valor da combo volta ao padrão após limpar
        //    PaginaSolicitarRegistroPin.ValidarTextoElementoSelecionadoCombo("Selecione uma Opção",
        //        PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    //// Aqui o valor deveria ser 0, mas a função de limpar do protótipo não limpa o grid de pesquisa
        //    //PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    ////Valida o Texto do botão antes de pressionar
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Ocultar Filtros", PaginaSolicitarRegistroPin.botaoOcultarFiltros);
        //    ////Clica em Ocultar FIltros
        //    PaginaSolicitarRegistroPin.OcultarFiltros();
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar não está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo não está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoNaoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    ////Valida se texto do botão Ocultar FIltros foi alterado
        //      PaginaSolicitarRegistroPin.AguardarProcessando();
        //    PaginaSolicitarRegistroPin.ValidarTextoElemento("Exibir Filtros", PaginaSolicitarRegistroPin.botaoExibirFiltros);
        //    ////Clica novamenten o botão para voltar a exibir os filtros
        //    PaginaSolicitarRegistroPin.ExibirFiltros();
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoBuscar);
        //    ////Valida que o botão Buscar está sendo exibido
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.botaoLimpar);
        //    ////Valida que a combo está mais sendo exibida
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPostoVistoria);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboPerfil);
        //    PaginaSolicitarRegistroPin.ValidarElementoPresente(PaginaSolicitarRegistroPin.comboCargaHoraria);
        //    //////Clicar em Exportar em PDF - Não faz nada nesse prototipo
        //    ////PaginaSolicitarRegistroPin.ExportarPDF();
        //    //// Fecha o navegador            
        //    selenium.EncerrarTeste();
        //}

        //[TestMethod]
        //public void ExcluirTodosCapacidadePerfil()
        //{
        //    //Inicializa instância do driver do Selenium
        //    var selenium = Global.obterInstancia();
        //    var PaginaSolicitarRegistroPin = new PaginaSolicitarRegistroPin(selenium.driver);
        //    //Abre a pagina inicial
        //    PaginaBase = new PaginaBase(selenium.driver);
        //    PaginaInicial = new PaginaInicial(selenium.driver);
        //    PaginaInicial.AbrirPagina(urlPaginaInicial);
        //    //Faz login
        //    PaginaInicial.FazerLogin("04621975000198", "123");
        //    PaginaBase.AguardarProcessando();
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Todos", "Todas");
        //    ////Valida a quantidade de resultados exibidos
        //    PaginaSolicitarRegistroPin.ExcluirTodosItensGrid(true);
        //    PaginaSolicitarRegistroPin.PesquisarCapacidadePerfil("MANAUS", "Todos", "Todas");
        //    //Valida que o grid foi atualizado e não contém itens.
        //    PaginaSolicitarRegistroPin.ValidarLinhasGrid(0);
        //    //// Fecha o navegador            
        //    selenium.EncerrarTeste();
        //}

    }
}

