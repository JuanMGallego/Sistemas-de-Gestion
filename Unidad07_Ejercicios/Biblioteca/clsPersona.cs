namespace EjsU7_SG
{
    public class clsPersona
    {
        #region atributos
        private String nombre;
        private String apellidos;
        private DateTime fechaNac;
        private long tlfn;
        private int id;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
        }

        public clsPersona(int id, string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNac, long tlfn)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.tlfn = tlfn;
            this.fechaNac = fechaNac;
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
        public long Tlfn
        {
            get { return tlfn; }
            set { tlfn = value; }
        }
        public String NombreCompleto
        {
            get { return $"{nombre} {apellidos}"; }
        }
        public String Direccion { get; set; }
        #endregion
        #region funciones y metodos
        ///<summary>
        ///Funcion que devuelve la concatenacion del atributo nombre y el atributo apellido
        ///Precondiciones: ninguna
        ///Postcondiciones: primera letra de cada palabra sea mayúscula, que no sea null... etc.
        ///</summary>
        ///<returns>string con el nombre completo</returns>
        public String FuncionNombreCompleto()
        {
            return $"Su nombre completo es: {nombre} {apellidos}";
        }
        #endregion
    }
}