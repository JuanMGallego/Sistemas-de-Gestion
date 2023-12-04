namespace Entidades
{
    public class clsDepartamento
    {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }

        public clsDepartamento()
        {
            idDepartamento = 0;
            nombreDepartamento = string.Empty;
        }

        public clsDepartamento(int idDepartamento, string nombreDepartamento)
        {
            this.idDepartamento = idDepartamento;
            this.nombreDepartamento = nombreDepartamento;
        }
    }
}
