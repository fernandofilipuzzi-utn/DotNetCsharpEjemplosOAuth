
var elementosACopiar = document.querySelectorAll('.copy-paste');

elementosACopiar.forEach(function (elemento)
{
    var boton = document.createElement('button');
    boton.className = 'btn fas fa-copy ml-2';
    boton.addEventListener('click', function () {
        copiarAlPortapapeles(elemento);
    });
    elemento.parentNode.insertBefore(boton, elemento.nextSibling);
});

function copiarAlPortapapeles(elemento)
{
    var texto = elemento.getAttribute('data-copiar-texto') || elemento.textContent;
    var inputTemporal = document.createElement('input');
    inputTemporal.style.position = 'absolute';
    inputTemporal.style.left = '-9999px';
    document.body.appendChild(inputTemporal);
    inputTemporal.value = texto;
    inputTemporal.select();
    document.execCommand('copy');
    document.body.removeChild(inputTemporal);
    //alert('¡Texto copiado al portapapeles!');
}