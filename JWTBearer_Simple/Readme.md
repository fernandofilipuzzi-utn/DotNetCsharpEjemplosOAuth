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
curl -X POST -d "guid=guid&frase=frase" http://localhost:7777/identity/token

## CONSUMIENDO SERVICIO
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido


# EJEMPLO DE LLAMADAS AL SERVER AUTORIZATION

### con token correcto

$ curl -X POST -d "guid=guid&frase=frase" http://localhost:7777/identity/token
{    "access_token": "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiZ3VpZCIsImV4cCI6MTcwNjUzNTEwNH0.pHnvt6akEUdmNPTDbK4NRTYFuQ00rk7gncYMOBu07Iw",
    "token_type": "Bearer"
}

$ curl -H "Authorization: Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiZ3VpZCIsImV4cCI6MTcwNjUzNTEwNH0.pHnvt6akEUdmNPTDbK4NRTYFuQ00rk7gncYMOBu07Iw" http://localhost:7778/api/Ej/MiServicioProtegido

