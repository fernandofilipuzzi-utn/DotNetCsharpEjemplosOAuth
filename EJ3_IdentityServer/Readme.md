





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



https://www.codementor.io/@himanshudewangan/jwt-authentication-and-authorization-on-web-api-using-owin-pipeline-and-oauth-grant-16s0za6tqu
https://stackoverflow.com/questions/54722236/how-do-i-implement-a-authentication-and-authorization-webapi-2-net-appication
ese
https://odetocode.com/blogs/scott/archive/2015/01/15/using-json-web-tokens-with-katana-and-webapi.aspx
https://developers.google.com/identity/protocols/oauth2#serviceaccount


providers
https://github.com/IdentityServer/IdentityServer3.Samples/blob/master/source/AspNetIdentity/WebHost/Startup.cs


curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=client1&client_secret=secret&scope=api1" https://localhost:44316/identity/connect/token

$ curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=client1&client_secret=secret&scope=api1" https://localhost:44316/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMxNi9pZGVudGl0eSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzE2L2lkZW50aXR5L3Jlc291cmNlcyIsImV4cCI6MTcwNTk3MDA2MywibmJmIjoxNzA1OTY2NDYzLCJjbGllbnRfaWQiOiJjbGllbnQxIiwic2NvcGUiOiJhcGkxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTcwNTk2NjQ2MywiaWRwIjoiaWRzcnYiLCJhbXIiOlsicGFzc3dvcmQiXX0.W2w-kZWh19NWVSgfdncEzwdKHZOPNzIcgj0TPLV8c5dUrX18e59NqNfeKH3divrl2zBCRfWZltMEc1dNcgOACqL4dxoUVR51nVe-E-nB-MC98Qd3M3aFVNgGtb5P2HxqLxAnGCnoMlOGmcKRvLerkKZuAkhau7LBpicOA2HLNhFqMhBK8EMjT9QrLzwALadszb5uNKPvaFxpQYyYWNrGTckezy1twiCCMPLdKnEk_yS3urQ7QtOJ4CtVjIORTGi3o6JyZJ2PwdC_7lNtigwspsvQ6HXsUeejKruWOdevCb1f1kFkQD_z-sH_bV3xUKiZSPANykf4oPa5AHfxWl5Avg","expires_in":3600,"token_type":"Bearer"}

{
  "typ": "JWT",
  "alg": "RS256",
  "x5t": "HFlKVQYrFq16_7iec5CXi16-5Ks",
  "kid": "HFlKVQYrFq16_7iec5CXi16-5Ks"
}

{
  "iss": "https://localhost:44316/identity",
  "aud": "https://localhost:44316/identity/resources",
  "exp": 1705970063,
  "nbf": 1705966463,
  "client_id": "client1",
  "scope": "api1",
  "sub": "1",
  "auth_time": 1705966463,
  "idp": "idsrv",
  "amr": [
    "password"
  ]
}

ultimo token generado

fernando@tsp MINGW64 ~
$ curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=client1&client_secret=secret&scope=api1" https://localhost:44316/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMxNi9pZGVudGl0eSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzE2L2lkZW50aXR5L3Jlc291cmNlcyIsImV4cCI6MTcwNTk3NjQyMywibmJmIjoxNzA1OTcyODIzLCJjbGllbnRfaWQiOiJjbGllbnQxIiwic2NvcGUiOiJhcGkxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTcwNTk3MjgyMywiaWRwIjoiaWRzcnYiLCJhbXIiOlsicGFzc3dvcmQiXX0.hteGYjXQDrOLGrStXxhJMzndsw7eY4Y8ejOOPTA7HxRGB5H2ansQ3JmvG3RhGIzIhLNjxeL_0ymATSsOOiWiFH-jA8v_U6ZIMN21AKGYXq8S1RV7IHQNRrBGMOP4nu46kXlfav6CR5YJsrIU8vkf3GYU-Ecq354gbFP90zRINWP3m8pSZQ4bXA-q5iuCqLcitrqE9QVOX1nVeQx7VQCj-uYyvDXnU7uij5NOIopF9fCbt_UKV6YANpBv5FL2QUa1edRi7DPA2tpPVOOFwxoXmRLSRxPT3VXejMYVisOCdqgZV-k9IdH-RxqKWHhu3RIQmMV4DXSSj4gygfYgHbdlJg","expires_in":3600,"token_type":"Bearer"}

fernando@tsp MINGW64 ~
$ curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=client1&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA1OTc2NjMxLCJuYmYiOjE3MDU5NzMwMzEsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA1OTczMDMxLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.yTzaep_B2eUESLV7ymsKn006YZK0E3ATmIxAotT_WlY7gizfnWXzm0I7ITwwbN2cRt1QeZyGZzYsgiOEWIsZgKKGbRniRijI5-CwmDWX0nmnxYFLN6_JGFZfHsAlmN8XwpHGh00DqkXT6GZiWeLerUPJN3KCJnyLhIU4NyLNk-KEZSMU4Ns5s_V0G5TwMPmoR1Y2vnFWwWZxdSlzpLNAFuOw-vGKgVU1-dZt2P_vt5drpgSk7buv_UBvqKV27fhTY7RGgIVVmXOPmP7b_AiTF7adFdFfYZkkABQPso0YJAMholo4ByFZesfIK-8GrIvMZI8UCH-utMyDHOg9AfG14Q","expires_in":3600,"token_type":"Bearer"}

$ curl -X POST -d "grant_type=password&username=usuario1&password=clave123&client_id=client1&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA1OTc2NjMxLCJuYmYiOjE3MDU5NzMwMzEsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA1OTczMDMxLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.yTzaep_B2eUESLV7ymsKn006YZK0E3ATmIxAotT_WlY7gizfnWXzm0I7ITwwbN2cRt1QeZyGZzYsgiOEWIsZgKKGbRniRijI5-CwmDWX0nmnxYFLN6_JGFZfHsAlmN8XwpHGh00DqkXT6GZiWeLerUPJN3KCJnyLhIU4NyLNk-KEZSMU4Ns5s_V0G5TwMPmoR1Y2vnFWwWZxdSlzpLNAFuOw-vGKgVU1-dZt2P_vt5drpgSk7buv_UBvqKV27fhTY7RGgIVVmXOPmP7b_AiTF7adFdFfYZkkABQPso0YJAMholo4ByFZesfIK-8GrIvMZI8UCH-utMyDHOg9AfG14Q","expires_in":3600,"token_type":"Bearer"}


curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA1OTgzNjgwLCJuYmYiOjE3MDU5ODAwODAsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA1OTgwMDgwLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.zyo-gJ_auHAtIGYn5xhJvaDDDLYbjJSzB7sdTy0Bivc-twHVCRD0qxqSP5R8-08Zq3lMCAVUFaEaj1XL6JOzPyvBpyawfe4rFZJ_VW6kTG9IlsNzenqbdyAVJTxQPG8ucUyMhtzsSxb3T7dMjObZGAYByyV2SXn0UVdDwq7ZO9pahMVE7tvaU7kER00z5Q0LRnhxQrRFhmZ9tEv8le2nudY-iFSisAm8b17fDtfLdJPO_BfFvzgXSuItW8GMHEUSnL79ridtpd4f7RocJYoBa0mf-OWf21uUsGFCCYFJWGOg4lpj7ngv6DlHwIMNWxyJ-8IdnKrQyqOd-4tfLJZIOw" http://localhost:7778/api/Ej/MiServicioProtegido




$ curl -X POST -d "grant_type=password&username=usuario2&password=clave123&client_id=client2&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA1OTc5MjMxLCJuYmYiOjE3MDU5NzU2MzEsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA1OTc1NjMxLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.gpOw8age1xewsjg7pFrQKwIuzveJRbHiY5lvPSzaQXoaJpBQpBDqPkmWugJgMDEqAIMEBS5CrQcswdmnhSQvUGJyCxOQS4tZgD0yGj4SUW0UIcixkQuowykeBJN2_Hvfj_31_X-9cqlBra1Ibw65hozg2DdRY7UaKvEqPOn5JK_hAXmcvY9finvEuKmW5_f5KARgFnVwM5BBPn4TYbd0pKWvE0u2q89Nkczn64LQysfvNiIo6FRj_5clqONVUAyQQqMyXRJtumCwZ47sTwcM2UjDtuZtuTHRA9UDbo5OhYPZEM_71e8CqbY4fOW4Z_vqySnUc7yqsyjizsCBZdtGbg","expires_in":3600,"token_type":"Bearer"}




$ curl -X POST -d "grant_type=password&username=usuario2&password=clave123&client_id=client2&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA1OTgwNDg5LCJuYmYiOjE3MDU5NzY4ODksImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA1OTc2ODg5LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.jM5HLQuPR1HKkBj_ljbo5ABN4CEL4851GCf0uVgkvcsE4JqAiFjwmQLmSVHaLrB1XkUqsXzxq-Q5qV69giSl9IOqmHmThlMOfmDAzdT8YC6MIuhOdcZSIzLFlOcU9TlGEHoomIocJYWm_TiXuqMIY4-U047WKXEo7IPbHdpiuwE--2UmIjpHWNplVdS1BJjsL9GChR3zAZRiN3qAdE_wp_6WeCJ9RM8bEsukbZZ8fHoYFrCMI-MjJs7NiYcCMzkxOLTv48vfFfCHWCdu7jZaaPhYF3UI3qolGl6V8P8B9TriVelaFpoXcMKcWwM8ub_eWWlYkURP2Vj-gFfg6FT0Bw","expires_in":3600,"token_type":"Bearer"}


curl -X POST -d "grant_type=password&username=usuario2&password=clave123&client_id=client2&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token

$ curl -X POST -d "grant_type=password&username=usuario2&password=clave123&client_id=client2&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA1OTgwNTU5LCJuYmYiOjE3MDU5NzY5NTksImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA1OTc2OTU5LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.KYH-EtWgm987DQhLGW4RnPfMqhcaE8CYacel8s4DK1LkLLjyIla-M_hvzD-3Ad5ljdw4wxNdxR95DRNnlPQ_Xh3Wxs6kTPqs51wEgsALbeHlAmW9qKIBH_89oE-6k6onyAKdqarzVeHfhTRmI_p-uH9lKMkUpek7e0_eYAlKBOY_c5CbHNLnwumRdxp7XKp_ntvpmLo85f4hyZiEF-5KefJpWdPFfa2CBCVbCWlu8Jl2KLQB1OmcbJBkr351Jv9n40wUYozQ-RgkJp5WqoWkFSKXXGRTwztOD3eaI9aezUMMMA3_SkYEIQV7m1Yz7baSueB9AemRvXFd74ayRmXm6g","expires_in":3600,"token_type":"Bearer"}


usando un handler
//https://www.enmilocalfunciona.io/construyendo-una-web-api-rest-segura-con-json-web-token-en-net-parte-ii/
cors
Microsoft.Owin.Cors
Microsoft.AspNet.WebApi.Cors
https://medium.com/@uppilivasanthi/web-api-token-based-authentication-using-microsoft-owin-77ab0645f156


leer 
https://medium.com/@giorgos.dyrrahitis/asp-net-core-api-authentication-with-jwt-140a4858b5bd
https://bitoftech.net/2014/10/27/json-web-token-asp-net-web-api-2-jwt-owin-authorization-server/

sobre el machinekey
https://bitoftech.net/2014/09/24/decouple-owin-authorization-server-resource-server-oauth-2-0-web-api/


cliente
https://stackoverflow.com/questions/52947929/owin-how-to-validate-bearer-token-for-roles-after-its-returned-by-auth-server

listo esto



fernando@tsp MINGW64 ~
$ curl -X POST -d "grant_type=password&username=usuario2&password=clave123&client_id=client2&client_secret=secret&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDE0Njc2LCJuYmYiOjE3MDYwMTM0NzYsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDEzNDc2LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.NkfrpTcNLW-KZTvpuhVdPeNeGvks_LvzsoDLFYjetgQfzt_cIwsrHtMR6fsCcEj0HbJ_mONIwN55fksj5ryDMolTzHiwazbldLJfXYJ9Y4-4h8TuofXhMapNcHV2GVAAXQ30DIhNWqCEPx7zqABDg8XLJwvAgBxToTwsjndd-P8nU42Ql1iDzt3udHhpgmJDYbjoDVD-he_fOOkzRg5Cv-dQB1QORccTHy38fl-az0WSHQ_qHjnVBPhBuHR59cuTsg4KQA4ttyDciNpfgyeXKQt6aagYSbS1wzrra8HznnNvrNKD5WyxXqM3uualbXyZL5hulu_QhAXx3p0qbwuyjw","expires_in":1200,"token_type":"Bearer"}
fernando@tsp MINGW64 ~
$ curl -X GET -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDE0Njc2LCJuYmYiOjE3MDYwMTM0NzYsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDEzNDc2LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.NkfrpTcNLW-KZTvpuhVdPeNeGvks_LvzsoDLFYjetgQfzt_cIwsrHtMR6fsCcEj0HbJ_mONIwN55fksj5ryDMolTzHiwazbldLJfXYJ9Y4-4h8TuofXhMapNcHV2GVAAXQ30DIhNWqCEPx7zqABDg8XLJwvAgBxToTwsjndd-P8nU42Ql1iDzt3udHhpgmJDYbjoDVD-he_fOOkzRg5Cv-dQB1QORccTHy38fl-az0WSHQ_qHjnVBPhBuHR59cuTsg4KQA4ttyDciNpfgyeXKQt6aagYSbS1wzrra8HznnNvrNKD5WyxXqM3uualbXyZL5hulu_QhAXx3p0qbwuyjw" https://localhost:44386/api/Ej/MiServicioProtegido
curl: (7) Failed to connect to localhost port 44386 after 2241 ms: Couldn't connect to server

fernando@tsp MINGW64 ~
$

fernando@tsp MINGW64 ~
$ curl -X GET -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDE0Njc2LCJuYmYiOjE3MDYwMTM0NzYsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDEzNDc2LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.NkfrpTcNLW-KZTvpuhVdPeNeGvks_LvzsoDLFYjetgQfzt_cIwsrHtMR6fsCcEj0HbJ_mONIwN55fksj5ryDMolTzHiwazbldLJfXYJ9Y4-4h8TuofXhMapNcHV2GVAAXQ30DIhNWqCEPx7zqABDg8XLJwvAgBxToTwsjndd-P8nU42Ql1iDzt3udHhpgmJDYbjoDVD-he_fOOkzRg5Cv-dQB1QORccTHy38fl-az0WSHQ_qHjnVBPhBuHR59cuTsg4KQA4ttyDciNpfgyeXKQt6aagYSbS1wzrra8HznnNvrNKD5WyxXqM3uualbXyZL5hulu_QhAXx3p0qbwuyjw" http://localhost:7778/api/Ej/MiServicioProtegido
"¡Bienvenido al servicio protegido! "
fernando@tsp MINGW64 ~
$ curl -X GET -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDE0Njc2LCJuYmYiOjE3MDYwMTM0NzYsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDEzNDc2LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.NkfrpTcNLW-KZTvpuhVdPeNeGvks_LvzsoDLFYjetgQfzt_cIwsrHtMR6fsCcEj0HbJ_mONIwN55fksj5ryDMolTzHiwazbldLJfXYJ9Y4-4h8TuofXhMapNcHV2GVAAXQ30DIhNWqCEPx7zqABDg8XLJwvAgBxToTwsjndd-P8nU42Ql1iDzt3udHhpgmJDYbjoDVD-he_fOOkzRg5Cv-dQB1QORccTHy38fl-az0WSHQ_qHjnVBPhBuHR59cuTsg4KQA4ttyDciNpfgyeXKQt6aagYSbS1wzrra8HznnNvrNKD5WyxXqM3uualbXyZL5hulu_QhAXx3p0qbwuyjw" http://localhost:7778/api/Ej/MiServicioProtegido
"¡Bienvenido al servicio protegido! "
fernando@tsp MINGW64 ~