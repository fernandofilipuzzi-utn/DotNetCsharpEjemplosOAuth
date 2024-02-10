# NUGET
clientservices: Newtonsoft.Json, RestSharp, System.IdentityModel.Tokens.Jwt
resource api:
authorization:

# POSTMAN
https://www.postman.com/fernandofilipuzziutn/workspace/dotnetcsharpejemplosbdsensillos/overview


# IMPLEMENTACIÓN PARA PRUEBAS
APIEjService corre en el IIS como http://localhost:7778
Auth2.0Service corre en el IIS como http://locahost:7777

AppDemoCliente, consume ambos servicios.

# RESUMEN LLAMADAS 

## SOLICITUD DE TOKEN
curl -X POST -d "guid=guid_generado&frase=frase" http://localhost:7777/auth/token

## CONSUMIENDO SERVICIO
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido


# SERVICIO AUTENTICADOR

### con token correcto
#dar de alta un cliente en http://localhost:7777/admin/credenciales

$ curl -X POST --header 'Content-Type: application/json' \
          --header 'Accept: application/json' \
          -d '{ "guid": "cbf25e40-b0da-4aa2-8a51-e2d701390ba1", "clave": "pFb2MKucltUts" }' \
          'http://localhost:7777/auth/token'

{
 "access_token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiY2JmMjVlNDAtYjBkYS00YWEyLThhNTEtZTJkNzAxMzkwYmExIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA3NjAxMzY1fQ.nOEuoKPPn9agf7_mNa16dXeQrYp6ciYWVeCwBgi5-Nc",
 "token_type":"Bearer"
}


# Probando el método tokenizado - ubicado en el servicio autenticador

$ curl -X GET --header 'Accept: application/json' \
          --header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiY2JmMjVlNDAtYjBkYS00YWEyLThhNTEtZTJkNzAxMzkwYmExIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA3NjA4MDAwfQ.en5n1ZL0MWse6VD7SaW4FFp7Y3ZYlNvkGikl04b-u6M' 'https://localhost:7778/auth/modulosurls/cbf25e40-b0da-4aa2-8a51-e2d701390ba1'

[
    {"Id":1,"Descripcion":"prueba1","Url":"http://localhost/prueba1"},
    {"Id":2,"Descripcion":"prueba2","Url":"http://localhost/prueba2"}
]

# RECURSOS TOKENIZADOS

### con token correcto
http://localhost:7778

# Probando el método tokenizado - ubicado en el servicio de recursos

$ curl -X GET --header 'Accept: application/json' \
          --header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiY2JmMjVlNDAtYjBkYS00YWEyLThhNTEtZTJkNzAxMzkwYmExIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA3NjA4MDAwfQ.en5n1ZL0MWse6VD7SaW4FFp7Y3ZYlNvkGikl04b-u6M' \
          'http://localhost:7778/api/Ejemplos/MiServicioProtegido'
"¡Bienvenido al servicio protegido! "


$ curl  http://localhost:7778/web_tokenizada/PaginaTokenizada.aspx?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnd
WlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyG
Csvt-RW72c0-w50u0RR2BWsm2fj4w
<html><head><title>Object moved</title></head><body>
<h2>Object moved to <a href="/web_tokenizada/PaginaTokenizada?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyGCsvt-RW72c0-w50u0RR2BWsm2fj4w">here</a>.</h2>
</body></html>


# Consultas
 https://stackoverflow.com/questions/43403941/how-to-read-asp-net-core-response-body
 https://stackoverflow.com/questions/48396746/asp-net-response-filter-on-the-entire-content-full-response
 https://weblog.west-wind.com/posts/2009/Nov/13/Capturing-and-Transforming-ASPNET-Output-with-ResponseFilter

 ## modificando respuestas del middleware
 https://copyprogramming.com/howto/changing-the-response-object-from-owin-middleware