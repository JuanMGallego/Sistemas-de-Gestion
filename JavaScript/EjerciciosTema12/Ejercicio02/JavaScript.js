// JavaScript source code

window.onload = inicializaEventos;

class Persona{
    constructor(nombre, apellidos) {
        this.nombre = nombre;
        this.apellidos = apellidos;
    }
}

function inicializaEventos() {

    document.getElementById("btnEnviar").addEventListener("click", lanzarAlert, false);

}

function lanzarAlert() {

    var miCampoNombre = document.getElementById("inpNombre").value;
    var miCampoApellidos = document.getElementById("inpApellidos").value;

    var persona = new Persona(miCampoNombre, miCampoApellidos);

    alert(persona.nombre + " " + persona.apellidos);
}