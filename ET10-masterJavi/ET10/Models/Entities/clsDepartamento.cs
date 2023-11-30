namespace Entities
{
    public class clsDepartamento
    {
        #region atributos

        public int idDep;
        public string nombreDep;

        #endregion

        public clsDepartamento() { }

        public clsDepartamento(int idDep, string nombreDep)
        { 
            this.idDep = idDep;
            this.nombreDep = nombreDep;
        }



    }
}
