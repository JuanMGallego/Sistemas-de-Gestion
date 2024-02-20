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

    return year + "-" + month + "-" + day;
}

// Luego, en tu función crearTablaPersonas, puedes llamar a esta función para formatear la fecha de nacimiento:
function crearTablaPersonas(arrayPersonas) {
    var tabla = document.querySelector("#table tbody");
    arrayPersonas.forEach(function(persona) {
        var fila = document.createElement('tr');

        var celdaFoto = document.createElement('td');
        var imagen = document.createElement('img');
        imagen.src = persona.foto; // Establecer la URL de la imagen
        imagen.alt = "Foto de " + persona.nombre; // Agregar texto alternativo para accesibilidad
        imagen.classList.add('foto-marco', 'foto-circular'); // Agregar clases CSS
        celdaFoto.appendChild(imagen); // Agregar la imagen a la celda
        fila.appendChild(celdaFoto); // Agregar la celda a la fila

        var celdaNombre = document.createElement('td');
        celdaNombre.textContent = persona.nombre;
        fila.appendChild(celdaNombre);

        var celdaApellidos = document.createElement('td');
        celdaApellidos.textContent = persona.apellidos;
        fila.appendChild(celdaApellidos);

        var celdaFechaNac = document.createElement('td');
        celdaFechaNac.textContent = formatearFecha(persona.FechaNac); // Formatear la fecha de nacimiento
        fila.appendChild(celdaFechaNac);

        var celdaTelefono = document.createElement('td');
        celdaTelefono.textContent = persona.telefono;
        fila.appendChild(celdaTelefono);

        var celdaDireccion = document.createElement('td');
        celdaDireccion.textContent = persona.direccion;
        fila.appendChild(celdaDireccion);

        tabla.appendChild(fila);
    });
}