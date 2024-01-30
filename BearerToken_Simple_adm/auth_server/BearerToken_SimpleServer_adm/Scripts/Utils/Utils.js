
function copiarAlPortapapeles()
{
    var contenidoDiv = document.querySelector('#dvContenido').innerText;

    var areaTextoTemporal = document.createElement('textarea');
    areaTextoTemporal.value = contenidoDiv;

    areaTextoTemporal.style.position = 'fixed';
    areaTextoTemporal.style.opacity = 0;

    document.body.appendChild(areaTextoTemporal);

    areaTextoTemporal.select();
    document.execCommand('copy');

    document.body.removeChild(areaTextoTemporal);
}

document.addEventListener('click', function (event) {
    if (event.target.matches('.copy-paste')) {
        var contenidoDiv = document.querySelector('#<%= tbClave.ClientID %>').value;

        var areaTextoTemporal = document.createElement('textarea');
        areaTextoTemporal.value = contenidoDiv;

        areaTextoTemporal.style.position = 'fixed';
        areaTextoTemporal.style.opacity = 0;

        document.body.appendChild(areaTextoTemporal);

        areaTextoTemporal.select();
        document.execCommand('copy');

        document.body.removeChild(areaTextoTemporal);
    }
});