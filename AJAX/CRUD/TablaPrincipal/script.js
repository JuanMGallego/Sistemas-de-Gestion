const search = document.querySelector('.input-group input'),
    table_rows = document.querySelectorAll('tbody tr'),
    table_headings = document.querySelectorAll('thead th');

// 1. Searching for specific data of HTML table
search.addEventListener('input', searchTable);

table_headings.forEach((head, i) => {
    let sort_asc = true;
    head.onclick = () => {
        table_headings.forEach(head => head.classList.remove('active'));
        head.classList.add('active');

        document.querySelectorAll('td').forEach(td => td.classList.remove('active'));
        table_rows.forEach(row => {
            row.querySelectorAll('td')[i].classList.add('active');
        })

        head.classList.toggle('asc', sort_asc);
        sort_asc = head.classList.contains('asc') ? false : true;

        sortTable(i, sort_asc);
    }
})

function pedirDatos() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/Personas");

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPersonas = JSON.parse(miLlamada.responseText);
            crearTablaPersonas(arrayPersonas);
        }
    };

    miLlamada.send();
}

function formatearFecha(fecha) {
    var fechaObj = new Date(fecha);
    var year = fechaObj.getFullYear();
    var month = ("0" + (fechaObj.getMonth() + 1)).slice(-2); // El mes es devuelto de 0 a 11, por eso se suma 1
    var day = ("0" + fechaObj.getDate()).slice(-2); // Asegura que el día siempre tenga dos dígitos

    return year + "/" + month + "/" + day;
}

function crearTablaPersonas(arrayPersonas) {
    var tabla = document.querySelector("tbody");

    tabla.innerHTML = '';

    arrayPersonas.forEach(function (persona) {
        var fila = document.createElement('tr');

        var celdaFoto = document.createElement('td');
        var imagen = document.createElement('img');

        // Verifica si la URL de la foto es válida
        if (isValidUrl(persona.foto)) {
            imagen.src = persona.foto;
        } else {
            // Si la URL no es válida, asigna una imagen por defecto
            imagen.src = "images/avatar-default-icon.png"; // Cambia 'imagen_por_defecto.jpg' por la URL de tu imagen por defecto
        }

        imagen.alt = "Foto de " + persona.nombre;
        imagen.classList.add('foto-marco', 'foto-circular');
        celdaFoto.appendChild(imagen);
        fila.appendChild(celdaFoto);

        var celdaNombre = document.createElement('td');
        celdaNombre.textContent = persona.nombre;
        fila.appendChild(celdaNombre);

        var celdaApellidos = document.createElement('td');
        celdaApellidos.textContent = persona.apellidos;
        fila.appendChild(celdaApellidos);

        var celdaFechaNac = document.createElement('td');
        celdaFechaNac.textContent = formatearFecha(persona.fechaNac);
        fila.appendChild(celdaFechaNac);

        var celdaTelefono = document.createElement('td');
        celdaTelefono.textContent = persona.telefono;
        fila.appendChild(celdaTelefono);

        var celdaDireccion = document.createElement('td');
        celdaDireccion.textContent = persona.direccion;
        fila.appendChild(celdaDireccion);

        // Crear los botones clickeables
        var celdaBotones = document.createElement('td');
        var botonEditar = document.createElement('button');
        botonEditar.textContent = 'Editar';
        botonEditar.addEventListener('click', function() {
            // Lógica para editar la persona
            console.log('Editar persona: ' + persona.nombre);
        });
        var botonEliminar = document.createElement('button');
        botonEliminar.textContent = 'Eliminar';
        botonEliminar.addEventListener('click', function() {
            // Lógica para eliminar la persona
            console.log('Eliminar persona: ' + persona.nombre);
        });
        celdaBotones.appendChild(botonEditar);
        celdaBotones.appendChild(botonEliminar);

        tabla.appendChild(fila);
    });
}

// Función para verificar si una cadena es una URL válida
function isValidUrl(url) {
    try {
        new URL(url);
        return true;
    } catch (error) {
        return false;
    }
}

function searchTable() {
    table_rows.forEach((row, i) => {
        let table_data = row.textContent.toLowerCase(),
            search_data = search.value.toLowerCase();

        row.classList.toggle('hide', table_data.indexOf(search_data) < 0);
        row.style.setProperty('--delay', i / 25 + 's');
    })

    document.querySelectorAll('tbody tr:not(.hide)').forEach((visible_row, i) => {
        visible_row.style.backgroundColor = (i % 2 == 0) ? 'transparent' : '#0000000b';
    });
}

function sortTable(column, sort_asc) {
    [...table_rows].sort((a, b) => {
        let first_row = a.querySelectorAll('td')[column].textContent.toLowerCase(),
            second_row = b.querySelectorAll('td')[column].textContent.toLowerCase();

        return sort_asc ? (first_row < second_row ? 1 : -1) : (first_row < second_row ? -1 : 1);
    })
        .map(sorted_row => document.querySelector('tbody').appendChild(sorted_row));
}

// Obtener la ventana modal y el botón de cierre
var modal = document.getElementById("myModal");
var span = document.getElementsByClassName("close")[0];

// Función para mostrar la ventana modal
function showModal() {
  modal.style.display = "block";
}

// Función para ocultar la ventana modal
function closeModal() {
  modal.style.display = "none";
}

// Cierra la ventana modal cuando se hace clic en el botón de cierre
span.onclick = function() {
  closeModal();
}

// Cierra la ventana modal cuando se hace clic fuera de ella
window.onclick = function(event) {
  if (event.target == modal) {
    closeModal();
  }
}

// Agrega un listener al botón para mostrar la ventana modal
document.getElementById("myButton").addEventListener("click", function() {
  showModal();
});

document.getElementById("saveButton").addEventListener("click", function() {
    // Obtener los valores de los campos del formulario
    var foto = document.getElementById("foto").value;
    var nombre = document.getElementById("nombre").value;
    var apellidos = document.getElementById("apellidos").value;
    var fechaNac = document.getElementById("fechaNac").value;
    var telefono = document.getElementById("telefono").value;
    var direccion = document.getElementById("direccion").value;
    // Otros campos del formulario
    
    // Crear un objeto Persona con los datos del formulario
    var nuevaPersona = {
        foto: foto,
        nombre: nombre,
        apellidos: apellidos,
        fechaNac: fechaNac,
        telefono: telefono,
        direccion: direccion
    };

    // Llamar a la función insertar con el objeto Persona
    insertar(nuevaPersona);

    // Cerrar la ventana modal
    closeModal();
});

function insertar(Persona) {

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("POST", "https://crudnervion.azurewebsites.net/api/Personas");
    miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    var json = JSON.stringify(Persona);

    // Definicion estados

    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        }
        else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            pedirDatos();
        }
    };

    miLlamada.send(json);

}

document.getElementById("editButton").addEventListener("click", function() {
    // Obtener los valores de los campos del formulario
    var foto = document.getElementById("foto").value;
    var nombre = document.getElementById("nombre").value;
    var apellidos = document.getElementById("apellidos").value;
    var fechaNac = document.getElementById("fechaNac").value;
    var telefono = document.getElementById("telefono").value;
    var direccion = document.getElementById("direccion").value;
    // Otros campos del formulario
    
    // Crear un objeto Persona con los datos del formulario
    var nuevaPersona = {
        foto: foto,
        nombre: nombre,
        apellidos: apellidos,
        fechaNac: fechaNac,
        telefono: telefono,
        direccion: direccion
    };

    // Llamar a la función insertar con el objeto Persona
    mostrarModalEdicion(nuevaPersona);

    // Cerrar la ventana modal
    closeModal();
});

// Función para mostrar la ventana modal de edición
function mostrarModalEdicion(persona) {
    // Mostrar la ventana modal de edición
    modal.style.display = "block";

    // Llenar los campos del formulario con los datos de la persona a editar
    document.getElementById("foto").value = persona.foto;
    document.getElementById("nombre").value = persona.nombre;
    document.getElementById("apellidos").value = persona.apellidos;
    document.getElementById("fechaNac").value = persona.fechaNac;
    document.getElementById("telefono").value = persona.telefono;
    document.getElementById("direccion").value = persona.direccion;

    // Asociar el evento al botón de guardar para realizar la edición
    document.getElementById("saveButton").addEventListener("click", function() {
        // Obtener los nuevos valores de los campos del formulario
        var nuevaFoto = document.getElementById("foto").value;
        var nuevoNombre = document.getElementById("nombre").value;
        var nuevosApellidos = document.getElementById("apellidos").value;
        var nuevaFechaNac = document.getElementById("fechaNac").value;
        var nuevoTelefono = document.getElementById("telefono").value;
        var nuevaDireccion = document.getElementById("direccion").value;

        // Actualizar los datos de la persona
        persona.foto = nuevaFoto;
        persona.nombre = nuevoNombre;
        persona.apellidos = nuevosApellidos;
        persona.fechaNac = nuevaFechaNac;
        persona.telefono = nuevoTelefono;
        persona.direccion = nuevaDireccion;

        // Llamar a la función para actualizar la persona
        actualizarPersona(persona);

        // Cerrar la ventana modal
        closeModal();
    });
}

function actualizarPersona(persona) {
    // URL de la API para actualizar la persona
    var url = "https://crudnervion.azurewebsites.net/api/Personas/" + persona.id;

    // Configuración del objeto de solicitud para el método PUT
    var requestOptions = {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(persona),
        redirect: 'follow'
    };

    // Realizar la solicitud para actualizar la persona
    fetch(url, requestOptions)
        .then(response => response.json())
        .then(result => {
            console.log("Persona actualizada:", result);
            // Puedes realizar alguna acción adicional después de actualizar la persona, si es necesario
            // Por ejemplo, volver a cargar la lista de personas actualizada
            pedirDatos();
        })
        .catch(error => console.log('Error al actualizar la persona:', error));
}