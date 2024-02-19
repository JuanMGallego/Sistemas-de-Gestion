function pedirDatos()

{

    var miLlamada = new XMLHttpRequest();
    miLlamada.open("GET", "https://crudnervion.azurewebsites.net/api/personas");

    //Definicion estados

    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {
        //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else if (miLlamada.readyState == 4 && miLlamada.status == 200) {
            var arrayPersonas = JSON.parse(miLlamada.responseText);
            funcionQueHagaAlgoConLasPersonas(arrayPersonas);
        }

    };

    miLlamada.send();

}