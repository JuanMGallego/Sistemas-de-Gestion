window.onload = inicializaEventos;

function inicializaEnventos() {
	let button = documents.getElementById("btnSaludar");

	button.addEventListener("click", saludar, false);
}

function saludar() {
	let miLlamada = new XMLHttpRequest();

	let divMensaje = document.getElementById("divMensaje");

	miLlamada.open("GET", "http://127.0.0.1:5500/Hola.html");

	millamada.onteadystatechange = function() {
		if (miLlamada.readyState < 4) {
			divMensaje.innerHTML = "Cargando..."
		} else if (miLlamada.readyState == 4 && miLlamda.status == 200) {
			let response = miLlamada.responseText;
			divMensaje.innerHTML = response;
		}
	};

	miLlamada.send();

}