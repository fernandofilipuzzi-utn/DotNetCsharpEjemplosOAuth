
#montaje, 
APIEjService corre en el IIS como http://localhost:7778
Auth2.0Service corre en el IIS como http://locahost:7777

AppDemoCliente, consume ambos servicios.

# para revisar el token 
https://jwt.io/
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDU2NzM0MzQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9hcGkvdG9rZW4iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzgvYXBpL0VqL01pU2VydmljaW9Qcm90ZWdpZG8ifQ.gmQPz3zhCKgmMH3OCiNcDZV7YfXNQ8bOsxfSXEwSzqE
# Pruebas con curl

## para conseguir el token
curl -X POST -d "client_id=client_id&client_secret=mi_secreto&username=user&password=123" http://localhost:7777/api/token

## para revisar el token
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido

## Ejemplo

### con token correcto

fernando@tsp MINGW64 ~
$ curl -X POST -d "client_id=client_id&client_secret=mi_secreto&username=user&password=123" http://localhost:7777/api/token
{"access_token":"eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MjI4OTEzOTUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9hcGkvdG9rZW4iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzgvYXBpL0VqL01pU2VydmljaW9Qcm90ZWdpZG8ifQ.Y4hkof-8DrY_saluTX-vlgUWcpDj8MFt1t-SXwVILTQ","token_type":"Bearer"}


fernando@tsp MINGW64 ~
$ curl -H "Authorization: Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MjI4OTEzOTUsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9hcGkvdG9rZW4iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzgvYXBpL0VqL01pU2VydmljaW9Qcm90ZWdpZG8ifQ.Y4hkof-8DrY_saluTX-vlgUWcpDj8MFt1t-SXwVILTQ" http://localhost:7778/api/Ej/M
iServicioProtegido
"¡Bienvenido al servicio protegido!"

### con token incorrecto
$ curl -H "Authorization: Bearer iyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDU2NjM0MzAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9hcGkvdG9rZW4iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzgvYXBpL0VqL01pU2VydmljaW9Qcm90ZWdpZG8ifQ.bjLDyZ8_mx2BQ5h5gVTB5tt0ZzDaWE3AiwtAoTgR6kw" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"Se ha denegado la autorización para esta solicitud."}

