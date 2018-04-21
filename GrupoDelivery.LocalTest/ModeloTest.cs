using System;
using GrupoDelivery.Entidades;
using GrupoDelivery.Negocios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrupoDelivery.LocalTest
{
    [TestClass]
    public class ModeloTest
    {
        [TestMethod]
        public void Modelo_InsertModelo_Test()
        {
            #region LocalMethods

            void ValidaDadosNovo(Modelo modelo)
            {
                Assert.IsTrue(modelo.DescricaoModelo.Equals("Modelo de Test"));
                Assert.IsTrue(modelo.PrecoModelo.Equals(2.30m));
                Assert.IsTrue(modelo.StatusModelo.Equals(true));
                Assert.IsTrue(modelo.Inteiro64Modelo.Equals(9999));
                Assert.IsTrue(modelo.IdModelo.Equals(0));
            }
            void ValidaDadosAlterados(Modelo modelo)
            {
                Assert.IsTrue(modelo.DescricaoModelo.Equals("Nova Descrição"));
                Assert.IsTrue(modelo.PrecoModelo.Equals(2.50m));
                Assert.IsTrue(modelo.StatusModelo.Equals(false));
                Assert.IsTrue(modelo.Inteiro64Modelo.Equals(8888));
                Assert.IsTrue(modelo.IdModelo.Equals(0));
            }
            #endregion

            using (ModeloNegocio modeloNegocio = new ModeloNegocio())
            {
                Modelo newModelo = new Modelo();
                newModelo.CriaModelo("Modelo de Test", 2.30m, true, 9999);

                ValidaDadosNovo(newModelo);

                newModelo.AtualizaDescricao("Nova Descrição");
                newModelo.AtualizaPreco(2.50m);
                newModelo.AtualizaStatus(false);
                newModelo.AtualizaInteiro64(8888);

                ValidaDadosAlterados(newModelo);
            }
        }
    }
}
