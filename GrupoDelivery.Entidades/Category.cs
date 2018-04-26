using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrupoDelivery.Entidades.Mapping;
using GrupoDelivery.Nucleo.Helpers;

namespace GrupoDelivery.Entidades
{
    public class Category : CategoryMap
    {
        private Int32 _idCategory;
        private String _name;
        private String _description;

        #region Public Properties
        public Int32 IdCategory { get => _idCategory; private set => _idCategory = value; }

        public String Name
        {
            get => _name;
            private set
            {
                if (value.Length > 50)
                    throw ErroMessage.Operation("Limite de 50 caracteres para o Nome da Categoria ultrapassados!");

                _name = value;
            }
        }

        public String Description
        {
            get => _description;
            private set
            {
                if (value.Length > 150)
                    throw ErroMessage.Operation("Limite de 150 caracteres para a Descrição da Categoria ultrapassados!");

                _description = value;
            }
        }
        #endregion

        #region Public Methods
        public void CreateCategory(String name, String description)
        {
            this.Name = name;
            this.Description = description;
        }

        public void AlterName(String name)
        {
            this.Name = name;
        }

        public void AlterDescription(String description)
        {
            this.Description = description;
        }
        #endregion

        public static List<Category> FixDataTable(DataTable table)
        {
            try
            {
                if (table != null)
                {
                    return (from DataRow row in table.Rows
                            select new Category
                            {
                                _description = ParseToString(row, mDescription),
                                _idCategory = ParseToInt32(row, mIdCategory),
                                _name = ParseToString(row, mName)
                            }).ToList();
                }
                return new List<Category>();
            }
            catch (System.Exception ex)
            {
                throw ErroMessage.ProgramException("FixDataTable [Category]", ex);
            }
        }
    }
}
