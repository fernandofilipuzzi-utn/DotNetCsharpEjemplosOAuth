# NUGET
clientservices: Newtonsoft.Json, RestSharp, System.IdentityModel.Tokens.Jwt
resource api:
authorization:

# IMPLEMENTACIÓN PARA PRUEBAS
APIEjService corre en el IIS como http://localhost:7778
Auth2.0Service corre en el IIS como http://locahost:7777

AppDemoCliente, consume ambos servicios.

# RESUMEN LLAMADAS 

## SOLICITUD DE TOKEN
curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123" http://localhost:7777/identity/connect/token

## CONSUMIENDO SERVICIO
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido


# EJEMPLO DE LLAMADAS AL SERVER AUTORIZATION

### con token correcto

$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123" http://localhost:7777/identity/connect/token
{"access_token":"eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MjMyOTY5MzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9pZGVudGl0eS9jb25uZWN0L3Rva2VuIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3Nzc4L2FwaS9Fai9NaVNlcnZpY2lvUHJvdGVnaWRvIn0.cFKGFip2SxdXX2D-fu68WZX47EQycaZiBk_8Bdutwos","token_type":"Bearer"}

$ curl -H "Authorization: Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MjMyOTY5MzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9pZGVudGl0eS9jb25uZWN0L3Rva2VuIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3Nzc4L2FwaS9Fai9NaVNlcnZpY2lvUHJvdGVnaWRvIn0.cFKGFip2SxdXX2D-fu68WZX47EQycaZiBk_8Bdutwos" http://localhost:7778/api/Ej/MiServicioProtegido
"¡Bienvenido al servicio protegido! "

### con token incorrecto
$ curl -H "Authorization: Bearer eyHhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MjMyOTY5MzksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9pZGVudGl0eS9jb25uZWN0L3Rva2VuIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo3Nzc4L2FwaS9Fai9NaVNlcnZpY2lvUHJvdGVnaWRvIn0.cFKGFip2SxdXX2D-fu68WZX47EQycaZiBk_8Bdutwos" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"No autenticado"}
