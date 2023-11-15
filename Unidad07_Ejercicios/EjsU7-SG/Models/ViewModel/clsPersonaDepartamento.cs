using EjsU7_SG.Models.DAL;
using EjsU7_SG.Models.Entidades;

namespace EjsU7_SG.Models.ViewModel
{
    public class clsPersonaDepartamento:clsPersona
    {
        #region atributos
        private List<clsPersona> listaPersonas;
        private List<clsDepartamento> listaDepartamentos;
        #endregion

        #region constructores
        public clsPersonaDepartamento()
        {
            listaPersonas = clsListadoPersonas.listadoPersonas();
            listaDepartamentos = clsListadoDepartamentos.listadoDepartamentos();
        }
        #endregion

        #region propiedades
        public List<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }

        }
        public List<clsPersona> ListaDeptPersonas
        {
            get
            {
                return listaPersonas;
            }
        }
        #endregion
    }
}
