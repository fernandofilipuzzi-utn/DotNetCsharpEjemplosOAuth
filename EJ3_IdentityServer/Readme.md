





>curl -X POST -d "client_id=client&client_secret=secret&username=usuario1&password=clave123"  https://localhost:44316/identity/connect/token
{"error":"invalid_client"}


>curl -X POST -d "client_id=client&client_secret=secret&username=usuario1&password=clave123"  https://localhost:44316/identity/connect/token
{"error":"unsupported_grant_type"}

>curl -X POST -d "grant_type=password&client_id=client&client_secret=secret&username=usuario1&password=clave123"  https://localhost:44316/identity/connect/token
{"error":"unauthorized_client"}

curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1" https://localhost:44316/identity/connect/token
curl -X POST -d "grant_type=client_credentials&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1" https://localhost:44316/identity/connect/token



&"K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols="







https://localhost:44316/connect/token

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

### Creando el certificado

fernando@dev:~$ openssl req -newkey rsa:2048 -nodes -keyout private-key.pem -x509 -days 365 -out certificate.pem
Generating a RSA private key
......+++++
............................................+++++
writing new private key to 'private-key.pem'
-----
You are about to be asked to enter information that will be incorporated
into your certificate request.
What you are about to enter is what is called a Distinguished Name or a DN.
There are quite a few fields but you can leave some blank
For some fields there will be a default value,
If you enter '.', the field will be left blank.
-----
Country Name (2 letter code) [AU]:AR
State or Province Name (full name) [Some-State]:Entre Ríos
Locality Name (eg, city) []:Paraná
Organization Name (eg, company) [Internet Widgits Pty Ltd]:fernando
Organizational Unit Name (eg, section) []:develop and research
Common Name (e.g. server FQDN or YOUR name) []:fernando
Email Address []:fernandofilipuzzi.utn@gmail.com

fernando@dev:~$ openssl pkcs12 -export -out certificate.pfx -inkey private-key.pem -in certificate.pem
Enter Export Password:
Verifying - Enter Export Password:

fernando@dev:~$ curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=tuClienteId&client_secret=clave_secreta_mas_larga_y_fuerte&scope=apiScope1" https://localhost:44316/connect/token

curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=tuClienteId&client=secret&scope=api1" https://localhost:44316/identity/connect/token

https://github.com/IdentityServer/IdentityServer3.Samples/blob/master/source/Simplest%20OAuth2%20Walkthrough/Apis/Startup.cs
https://stackoverflow.com/questions/61588752/identityserver4-client-for-password-flow-not-including-testuser-claims-in-access


https://www.scottbrady91.com/identity-server/identity-server-3-using-aspnet-identity
https://github.com/IdentityServer/IdentityServer3.Samples
https://github.com/IdentityServer/IdentityServer3.Samples/blob/master/source/CustomViewService/CustomViewService/Startup.cs


revisar este
https://johanbostrom.se/blog/identityserver-3-starter-kit-part-1-installing-identityserver-3-aspnet-identity-and-entity-framework/
https://github.com/IdentityServer/IdentityServer4/issues/4188

roles,