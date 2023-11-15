using EjsU7_SG.Models.Entidades;

namespace EjsU7_SG.Models.DAL
{
    public static class clsListadoDepartamentos
    {
        /// <summary>
        /// Método que crea y devuelve una lista rellena de objetos de tipo clsDsepartamento
        /// </summary>
        /// <returns>Lista de clsDepartamento</returns>
        public static List<clsDepartamento> listadoDepartamentos()
        {

            List<clsDepartamento> listaDepts = new List<clsDepartamento>()
        {
            new clsDepartamento() {IdDepartamento=1, NombreDepartamento="Recursos Humanos"},
            new clsDepartamento() {IdDepartamento=2, NombreDepartamento="Cookie Clicker"},
            new clsDepartamento() {IdDepartamento=3, NombreDepartamento="Producción"},
            new clsDepartamento() {IdDepartamento=4, NombreDepartamento="Finanzas"}
        };

            return listaDepts;
        }
    }
}
