//Constantes para para la barra de búsqueda y las cabeceras de las tablas
const search = document.querySelector('.input-group input'),
    table_headings = document.querySelectorAll('thead tr th');

// Evento para buscar en la tabla
search.addEventListener('input', searchTable);

//Función qpara buscar en la tabla, filtra en ella y oculta los elementos no deseados
function searchTable() {
    var table_rows = document.querySelectorAll('tbody tr');

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

//Bucle para colocar los eventos que llaman al ordenado de columnas
table_headings.forEach((head, i) => {

    var table_rows = document.querySelectorAll('tbody tr')

    if (i != 0 && i != 4 && i != 7) { //Excluye las columnas de Foto, Teléfono y la de los botones
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
    }
});

//Función para ordenar de forma ascendente o descendente la columna que le entra por parámetros
function sortTable(column, sort_asc) {
    var table_rows = document.querySelectorAll('tbody tr');

    let rowsArray = Array.from(table_rows);

    rowsArray.sort((a, b) => {
        let first_row = a.querySelectorAll('td')[column].textContent.toLowerCase(),
            second_row = b.querySelectorAll('td')[column].textContent.toLowerCase();

        return sort_asc ? (first_row < second_row ? -1 : 1) : (first_row < second_row ? 1 : -1);
    });

    // Remover las filas actuales de la tabla
    table_rows.forEach(row => row.parentNode.removeChild(row));

    // Agregar las filas ordenadas a la tabla
    rowsArray.forEach(row => document.querySelector('tbody').appendChild(row));
}

// función inicial para hacer el GET de las personas a la API
function pedirDatosPersonas() {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/Personas");

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPersonas = JSON.parse(miLlamada.responseText);
            pedirDatosDepartamentos(arrayPersonas);
        }
    };

    miLlamada.send();

}

// función para hacer el GET de los departamentos a la API
function pedirDatosDepartamentos(arrayPersonas) {
    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/Departamentos");

    //Definicion estados
    miLlamada.onreadystatechange = function () {
        if (miLlamada.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayDepartamentos = JSON.parse(miLlamada.responseText);
            crearTablaPersonas(arrayPersonas, arrayDepartamentos);
        }
    };

    miLlamada.send();

}

// función para cambiar el formato de la fecha a una más adecuada
function formatearFecha(fecha) {
    var fechaObj = new Date(fecha);
    var year = fechaObj.getFullYear();
    var month = ("0" + (fechaObj.getMonth() + 1)).slice(-2); // El mes es devuelto de 0 a 11, por eso se suma 1
    var day = ("0" + fechaObj.getDate()).slice(-2); // Asegura que el día siempre tenga dos dígitos

    return year + "-" + month + "-" + day;
}

// Función para ggenerar en el html el listado de las personas y utilizar los datos obtenidos de la api para rellenar modales.
function crearTablaPersonas(arrayPersonas, arrayDepartamentos) {

    var tabla = document.querySelector("tbody");

    tabla.innerHTML = ''; // Limpia la tabla

    //Busca en cada persona del JSON obtenido de la API
    arrayPersonas.forEach(function (persona) {
        var fila = document.createElement('tr');

        // Todo lo abajo es cada atributi de un registro de la lista
        var celdaFoto = document.createElement('td');
        var imagen = document.createElement('img');

        // Verifica si la URL de la foto es válida
        if (isValidUrl(persona.foto)) {
            imagen.src = persona.foto;
        } else {
            // Si la URL no es válida, asigna una imagen por defecto
            imagen.src = "images/avatar-default-icon.png";
        }

        imagen.alt = "Foto de " + persona.nombre;
        imagen.className = "fotoPersona"
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

        var celdaDepartamentos = document.createElement('td');
        var nombreDepartamento = "null";

        //Bucle para cambiar el idDepartamento por el nombre
        arrayDepartamentos.forEach(function (departamento) {
            if (persona.idDepartamento == departamento.id){
                nombreDepartamento = departamento.nombre
            }
        })

        celdaDepartamentos.textContent = nombreDepartamento;
        fila.appendChild(celdaDepartamentos);

        // Crear los botones clickeables
        var celdaBotones = document.createElement('td');
        
            // Botón EDITAR
            var botonEditar = document.createElement('button');
            botonEditar.className = 'editButton';
            botonEditar.addEventListener('click', function () {
                mostrarModalEdicion(persona)
            });

                var imgEdit = document.createElement('img');
                imgEdit.src = "images/lapiz.png";
                imgEdit.className = "img_edit";

                botonEditar.appendChild(imgEdit);

            // Botón ELIMINAR
            var botonEliminar = document.createElement('button');
            botonEliminar.className = 'deleteButton';
            botonEliminar.addEventListener('click', function () {
                eliminarPersona(persona.id)
            });

                var imgDelete = document.createElement('img');
                imgDelete.src = "images/basura.png";
                imgDelete.className = "img_delete";

                botonEliminar.appendChild(imgDelete);

            celdaBotones.appendChild(botonEditar);
            celdaBotones.appendChild(botonEliminar);

        fila.appendChild(celdaBotones);

        tabla.appendChild(fila);

        
        
    });

    // Generar la lista de departamentos en el modal de insertar una persona
    var departamentosListModalInsertar = document.querySelector("#departamentoInsertar");

        arrayDepartamentos.forEach(function (departamento) {
            //Se añade también al modal
            var opcionDeptListModal = document.createElement('option');
            opcionDeptListModal.value = departamento.id;
            opcionDeptListModal.text = departamento.nombre;
            departamentosListModalInsertar.appendChild(opcionDeptListModal);
        });

    // Generar la lista de departamentos en el modal de editar una persona
    var departamentosListModalEditar = document.querySelector("#departamentoEditar");

        arrayDepartamentos.forEach(function (departamento) {
            //Se añade también al modal
            var opcionDeptListModal = document.createElement('option');
            opcionDeptListModal.value = departamento.id;
            opcionDeptListModal.text = departamento.nombre;
            departamentosListModalEditar.appendChild(opcionDeptListModal);
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

// ------------ Modal Para INSERTAR ------------
// Obtener la ventana modal y el botón de cierre
var modalInsertar = document.getElementById("myModalInsertar");
var spanInsertar = document.getElementsByClassName("closeInsertar")[0];

// Función para mostrar la ventana modal
function showModalInsertar() {
    modalInsertar.style.display = "block";
}

// Función para ocultar la ventana modal
function closeModalInsertar() {
    modalInsertar.style.display = "none";
}

// Cierra la ventana modal cuando se hace clic en el botón de cierre
spanInsertar.onclick = function () {
    closeModalInsertar();
}

// Cierra la ventana modal cuando se hace clic fuera de ella
window.onclick = function (event) {
    if (event.target == modalInsertar) {
        closeModalInsertar();
    }
}

// Agrega un listener al botón para mostrar la ventana modal
document.getElementById("addButton").addEventListener("click", function () {
    showModalInsertar();
});

document.getElementById("saveButtonInsertar").addEventListener("click", function () {
    // Obtener los valores de los campos del formulario
    var foto = document.getElementById("fotoInsertar").value;
    var nombre = document.getElementById("nombreInsertar").value;
    var apellidos = document.getElementById("apellidosInsertar").value;
    var fechaNac = document.getElementById("fechaNacInsertar").value;
    var telefono = document.getElementById("telefonoInsertar").value;
    var direccion = document.getElementById("direccionInsertar").value;
    var idDepartamento = document.getElementById("departamentoInsertar").value;
    // Otros campos del formulario

    // Crear un objeto Persona con los datos del formulario
    var nuevaPersona = {
        foto: foto,
        nombre: nombre,
        apellidos: apellidos,
        fechaNac: fechaNac,
        telefono: telefono,
        direccion: direccion,
        idDepartamento: idDepartamento
    };

    // Llamar a la función insertar con el objeto Persona
    insertar(nuevaPersona);

    // Cerrar la ventana modal
    closeModalInsertar();
});


// ------------ Modal Para EDITAR ------------
// Obtener la ventana modal y el botón de cierre
var modalEditar = document.getElementById("myModalEditar");
var spanEditar = document.getElementsByClassName("closeEditar")[0];

// Función para mostrar la ventana modal
function showModalEditar() {
    modalEditar.style.display = "block";
}

// Función para ocultar la ventana modal
function closeModalEditar() {
    modalEditar.style.display = "none";
}

// Cierra la ventana modal cuando se hace clic en el botón de cierre
spanEditar.onclick = function () {
    closeModalEditar();
}

// Cierra la ventana modal cuando se hace clic fuera de ella
window.onclick = function (event) {
    if (event.target == modalEditar) {
        closeModalEditar();
    }
}

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
            pedirDatosPersonas();
        }
    };

    miLlamada.send(json);

}

// Función para mostrar la ventana modal de edición
function mostrarModalEdicion(persona) {
    // Mostrar la ventana modal de edición
    modalEditar.style.display = "block";

    // Llenar los campos del formulario con los datos de la persona a editar
    document.getElementById("fotoEditar").value = persona.foto;
    document.getElementById("nombreEditar").value = persona.nombre;
    document.getElementById("apellidosEditar").value = persona.apellidos;
    document.getElementById("fechaNacEditar").value = formatearFecha(persona.fechaNac);
    document.getElementById("telefonoEditar").value = persona.telefono;
    document.getElementById("direccionEditar").value = persona.direccion;
    document.getElementById("departamentoEditar").value = persona.idDepartamento;

    // Asociar el evento al botón de guardar para realizar la edición
    document.getElementById("saveButtonEditar").addEventListener("click", function () {
        // Obtener los nuevos valores de los campos del formulario
        var nuevaFoto = document.getElementById("fotoEditar").value;
        var nuevoNombre = document.getElementById("nombreEditar").value;
        var nuevosApellidos = document.getElementById("apellidosEditar").value;
        var nuevaFechaNac = document.getElementById("fechaNacEditar").value;
        var nuevoTelefono = document.getElementById("telefonoEditar").value;
        var nuevaDireccion = document.getElementById("direccionEditar").value;
        var nuevoIdDepartamento = document.getElementById("departamentoEditar").value;

        // Actualizar los datos de la persona
        persona.foto = nuevaFoto;
        persona.nombre = nuevoNombre;
        persona.apellidos = nuevosApellidos;
        persona.fechaNac = nuevaFechaNac;
        persona.telefono = nuevoTelefono;
        persona.direccion = nuevaDireccion;
        persona.idDepartamento = nuevoIdDepartamento;

        // Llamar a la función para actualizar la persona
        actualizarPersona(persona);

        // Cerrar la ventana modal
        closeModalEditar();
    });
}

//función que le entra una persona y que hace el PUT a la API para editarla
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
            pedirDatosPersonas();
        })
        .catch(error => console.log('Error al actualizar la persona:', error));
}

//Función usando fetch y tomando la id de la persona a eliminar y hacer el DELETE a la API
function eliminarPersona(id) {

    var alerta = confirm("¿Seguro que quieres eliminar esta persona?");

    if(alerta){
        // URL de la API y ID del recurso que deseas eliminar
        const apiUrl = 'https://crudnervion.azurewebsites.net/api/Personas';
        const resourceId = id;

        // Configurar la solicitud DELETE
        const requestOptions = {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        };

        // Realizar la solicitud DELETE a la API
        fetch(`${apiUrl}/${resourceId}`, requestOptions)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error al realizar la solicitud DELETE');
                }
                return response.json(); // Si la respuesta es exitosa, convierte la respuesta a JSON
            })
            .then(data => {
                //En caso de que sea existoso
                console.log('El recurso se ha eliminado exitosamente:', data);
            })
            .catch(error => {
                //En caso de error
                console.error('Error:', error);
            });

            //Recarga la tabla
            pedirDatosPersonas();

    }
}