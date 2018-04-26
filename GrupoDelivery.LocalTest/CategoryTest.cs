using System;
using GrupoDelivery.Entidades;
using GrupoDelivery.Negocios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrupoDelivery.LocalTest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void Category_CreateCategory_Test()
        {
            #region LocalMethods
            void ValidateNewCategory(Category category)
            {
                Assert.IsNotNull(category);
                Assert.IsTrue(category.Description == "TESTE DESCRICAO");
                Assert.IsTrue(category.Name == "TESTE NOME");
            }

            void ValidateAlterCategory(Category category)
            {
                Assert.IsNotNull(category);
                Assert.IsTrue(category.Description == "TESTE DESCRICAO ALTERADA");
                Assert.IsTrue(category.Name == "TESTE NOME ALTERADO");
            }
            #endregion

            using (CategoryBusiness categoryBusiness = new CategoryBusiness())
            {
                Category category = new Category();

                category.CreateCategory("TESTE NOME", "TESTE DESCRICAO");

                ValidateNewCategory(category);

                category.AlterName("TESTE NOME ALTERADO");
                category.AlterDescription("TESTE DESCRICAO ALTERADA");
            }
        }

        [TestMethod]
        public void Category_InsertCategory_Test()
        {
            #region LocalMethods
            void ValidateCategory(Category category)
            {
                Assert.IsNotNull(category);
                Assert.IsTrue(category.IdCategory == 1);
                Assert.IsTrue(category.Description == "TESTE DESCRICAO");
                Assert.IsTrue(category.Name == "TESTE NOME");
            }

            #endregion

            using (CategoryBusiness categoryBusiness = new CategoryBusiness())
            {
                Category category = new Category();

                category.CreateCategory("TESTE NOME", "TESTE DESCRICAO");

                categoryBusiness.InsertCategory(category);
            }
        }

        [TestMethod]
        public void Category_SelectCategoryById_Test()
        {
            #region LocalMethods
            void ValidateCategory(Category category)
            {
                Assert.IsNotNull(category);
                Assert.IsTrue(category.IdCategory == 1);
                Assert.IsTrue(category.Description == "TESTE DESCRICAO");
                Assert.IsTrue(category.Name == "TESTE NOME");
            }

            #endregion

            using (CategoryBusiness categoryBusiness = new CategoryBusiness())
            {
                Category category = categoryBusiness.SelectCategoryById(1);

                ValidateCategory(category);
            }
        }

        [TestMethod]
        public void Category_SelectCategoryByName_Test()
        {
            #region LocalMethods
            void ValidateCategory(Category category)
            {
                Assert.IsNotNull(category);
                Assert.IsTrue(category.IdCategory == 1);
                Assert.IsTrue(category.Description == "TESTE DESCRICAO");
                Assert.IsTrue(category.Name == "TESTE NOME");
            }

            #endregion

            using (CategoryBusiness categoryBusiness = new CategoryBusiness())
            {
                Category category = categoryBusiness.SelectCategoryByName("TESTE NOME");

                ValidateCategory(category);
            }
        }
    }
}
