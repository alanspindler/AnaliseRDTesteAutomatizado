using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lampp.AnaliseRD.Teste.Automatizado.Principal.PageObjects;
using Lampp.AnaliseRD.Teste.Automatizado.SharedObjects;
using Lampp.AnaliseRD.Teste.Automatizado.Login.PageObjects;

namespace Lampp.AnaliseRD.Teste.Automatizado.Principal.Tests
{
    [TestClass]
    public class PaginaPrincipalTestesAutomatizados
    {
        private ItensTeste itens;

        private sealed class ItensTeste
        {
            public Global Global { get; set; }
            public PaginaPrincipal PaginaPrincipal { get; set; }
            public PaginaBase PaginaBase { get; set; }
            public PaginaInicial PaginaInicial { get; set; }
        }
    }
}
