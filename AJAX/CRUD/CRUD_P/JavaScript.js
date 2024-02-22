var idSeleccionado = null;
var filaSeleccionada = null;
var listaPersonas=null;
var modal = document.getElementById("myModal");
var btnInsertar = document.getElementById("insertar");
var btnEditar = document.getElementById("editar");
var btnBorrar = document.getElementById("borrar");
var span = document.getElementsByClassName("close")[0];

span.onclick = function() {
    modal.style.display = "none";
}

btnInsertar.onclick = function() {
    modal.style.display = "flex";

    document.getElementById('addForm').addEventListener('submit', function(event) {
        event.preventDefault();
        var Persona = {
            nombre: document.getElementById('nombre').value,
            apellidos: document.getElementById('apellidos').value,
            fechaNac: new Date(document.getElementById('fechaNac').value).toISOString().split('T')[0] + 'T00:00:00',
            direccion: document.getElementById('direccion').value,
            foto: document.getElementById('foto').value,
            telefono: document.getElementById('telefono').value,
        };
        insertar(Persona);
    });
    
}

function insertar(Persona) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("POST", "https://crudnervion.azurewebsites.net/api/Personas");
    miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(Persona);

    miLlamada.onreadystatechange = function () {
            if(miLlamada.readyState<4){
                //TODO
            }
            else if (miLlamada.status == 200 && miLlamada.readyState == 4) {
                alert("Se insertó exitosamente");
            }
    };

    miLlamada.send(json);
};


btnBorrar.onclick=function(){
    borrar(idSeleccionado);
}

function borrar(id) {
    fetch('https://crudnervion.azurewebsites.net/api/Personas/' + id, {
        method: 'DELETE',
    })
    .then(response => response.text())
    .then(() => {
        cargarPersonas();
    })
    .catch((error) => {
        console.error('Error:', error);
    });
};

btnEditar.onclick=function(){
    modal.style.display = "flex";
    
    // Encuentra la persona con el id seleccionado
    var persona = listaPersonas.find(function(p) {
        return p.id === idSeleccionado;
    });

    // Si la persona existe, rellena los campos del modal con sus datos
    if (persona) {
        document.getElementById('nombre').value=persona.nombre;
        document.getElementById('apellidos').value=persona.apellidos;
        document.getElementById('fechaNac').value=persona.fechaNac;
        document.getElementById('direccion').value=persona.direccion;
        document.getElementById('foto').value=persona.foto;
        document.getElementById('telefono').value=persona.telefono;
    }

    var Persona = {
        nombre: document.getElementById('nombre').value,
        apellidos: document.getElementById('apellidos').value,
        fechaNac: document.getElementById('fechaNac').value,
        direccion: document.getElementById('direccion').value,
        foto: document.getElementById('foto').value,
        telefono: document.getElementById('telefono').value,
        id:idSeleccionado,
    };

    document.getElementById('addForm').addEventListener('submit', function(event) {
        event.preventDefault();
        editar(Persona);
    })
}

function editar(Persona) {
    fetch('https://crudnervion.azurewebsites.net/api/Personas/' + idSeleccionado, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(Persona),
    })
    .then(response => response.json())
    .then(Persona => console.log(Persona))
    .catch((error) => {
        console.error('Error:', error);
    });
};

window.onclick = function(event) {
if (event.target == modal) {
    modal.style.display = "none";
}
}

function cargarPersonas(){
    var miLlamada = new XMLHttpRequest(); //INICIALIZAMOS EL XMLHTTPREQUEST
    var gif=document.getElementById("loading") //REFERENCIA AL GIF
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/Personas");//ABRIMOS LLAMADA

    miLlamada.onreadystatechange = function () {
    if (miLlamada.readyState < 4) {
        gif.style.display="flex"
    }
    else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
        listaPersonas = JSON.parse(miLlamada.responseText);
        mostrarPersonas();
        gif.style.display="none"
    }
    };
    miLlamada.send();
}

function mostrarPersonas() {
    var tabla = document.querySelector(".container table");
    while(tabla.rows.length > 1) {
        tabla.deleteRow(1);
    }
    listaPersonas.forEach(function(persona) {
        var fila = document.createElement("tr");

        fila.addEventListener('click', function() {
            if (filaSeleccionada) {
                filaSeleccionada.classList.remove('selected');
            }
            this.classList.add('selected');
            filaSeleccionada = this;
            idSeleccionado = persona.id;
        });

        var celdaFoto = document.createElement("td");
        var celdaNombre = document.createElement("td");
        var celdaApellidos = document.createElement("td");
        var celdaDireccion = document.createElement("td");
        var celdaTelefono = document.createElement("td");
        var celdaFecha = document.createElement("td");
        var imagen = document.createElement("img");

        if (persona.foto && isValidURL(persona.foto)) {
            imagen.src = persona.foto;
        } else {
            imagen.src = 'defecto.png';
        }
        imagen.height=80
        imagen.width=80
        imagen.classList.add("fdp")
        celdaFoto.appendChild(imagen);
        celdaFoto.classList.add("foto");
        celdaNombre.textContent = persona.nombre;
        celdaApellidos.textContent = persona.apellidos;
        celdaDireccion.textContent = persona.direccion;
        celdaTelefono.textContent = persona.telefono;
        var fecha = new Date(persona.fechaNac);
        var opciones = { year: 'numeric', month: 'long', day: 'numeric' };
        celdaFecha.textContent = fecha.toLocaleDateString("es-ES", opciones);

        fila.appendChild(celdaFoto);
        fila.appendChild(celdaNombre);
        fila.appendChild(celdaApellidos);
        fila.appendChild(celdaDireccion);
        fila.appendChild(celdaTelefono);
        fila.appendChild(celdaFecha);
        tabla.appendChild(fila);
    });
};

function isValidURL(string) {
    var res = string.match(/(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)/gi);
    return (res !== null);
};