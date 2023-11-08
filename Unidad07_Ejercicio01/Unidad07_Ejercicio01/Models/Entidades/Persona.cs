using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using String = System.String;

namespace Unidad07_Ejercicio01.Models.Entidades
{
    public class Persona
    {
        #region atributos
        private String nombre;
        private String apellidos;
        #endregion

        #region constructores
        public Persona()
        {
            nombre = "";
        }
        public Persona(String nombre, String apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }
        
        }
        #endregion

        #region propiedades
        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    public Persona(String nombre, String apellidos, int dept)
    {
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.idDept = dept;
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

    public int IdDept
    get { return idDept; }
    set { idDept = value; }
    public String Direccion { get; set; }
    public String nombreCompleto
    {
    get { return $"Su nombre completo es: {nombre} {apellidos}" }
}
        

}
       