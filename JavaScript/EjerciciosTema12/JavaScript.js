// JavaScript source code
alert("Hola wena tarde")

window.onload = inicializaEventos;

function inicializaEventos() {

    document.getElementById("btnTitulo").addEventListener("click", cambiarTitulo, false);

}
function cambiarTitulo() {

    var miBoton;

    document.getElementById("titulo").innerHTML = "Fortnite Battlepass";
    miBoton = document.getElementById("btnTitulo");
    miBoton.value = "Ya has cambiado el titulo";
    miBoton.disabled = true;
}