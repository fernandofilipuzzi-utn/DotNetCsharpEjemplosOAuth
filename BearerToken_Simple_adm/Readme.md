# NUGET
clientservices: Newtonsoft.Json, RestSharp, System.IdentityModel.Tokens.Jwt
resource api:
authorization:

# POSTMAN
https://www.postman.com/fernandofilipuzziutn/workspace/jwtbearer-simple


# IMPLEMENTACIÓN PARA PRUEBAS
APIEjService corre en el IIS como http://localhost:7778
Auth2.0Service corre en el IIS como http://locahost:7777

AppDemoCliente, consume ambos servicios.

# RESUMEN LLAMADAS 

## SOLICITUD DE TOKEN
curl -X POST -d "guid=guid_generado&frase=frase" http://localhost:7777/auth/token

## CONSUMIENDO SERVICIO
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido


# EJEMPLO DE LLAMADAS AL SERVER AUTORIZATION

### con token correcto
#dar de alta un cliente en http://localhost:7777/admin/credenciales

$ curl -X POST -d "guid=1853f26d-716d-4db8-b815-03b3847c00a7&frase=clave123" http://localhost:7777/auth/token
{"access_token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiMTg1M2YyNmQtNzE2ZC00ZGI4LWI4MTUtMDNiMzg0N2MwMGE3Iiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA2Nzg4MzI2fQ.mgdab2cH1JkJydIEVnyqID2d7Kz9tOrViszaKx3p9I0","token_type":"Bearer"}

$ curl -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiMTg1M2YyNmQtNzE2ZC00ZGI4LWI4MTUtMDNiMzg0N2MwMGE3Iiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA2Nzg4MzI2fQ.mgdab2cH1JkJydIEVnyqID2d7Kz9tOrViszaKx3p9I0" http://localhost:7778/api/Ejemplos/MiServicioProtegido
{"mensaje":"No autorizado"}{mensaje:'probando!'}

# Consultas
 https://stackoverflow.com/questions/43403941/how-to-read-asp-net-core-response-body
 https://stackoverflow.com/questions/48396746/asp-net-response-filter-on-the-entire-content-full-response
 https://weblog.west-wind.com/posts/2009/Nov/13/Capturing-and-Transforming-ASPNET-Output-with-ResponseFilter

 ## modificando respuestas del middleware
 https://copyprogramming.com/howto/changing-the-response-object-from-owin-middleware