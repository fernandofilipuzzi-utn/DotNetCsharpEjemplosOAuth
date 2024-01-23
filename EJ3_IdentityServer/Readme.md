

# Librerias
cliente:
System.IdentityModel.Tokens.Jw



# MONTAJE
APIEjService corre en el IIS como http://localhost:7778
Auth2.0Service corre en el IIS como http://locahost:7777

# RESUMEN LLAMADAS 

## SOLICITUD DE TOKEN
curl -X POST -d "client_id=client_id&client_secret=mi_secreto&username=user&password=123" http://localhost:7777/api/token

## CONSUMIENDO SERVICIO
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido


# EJEMPLO DE LLAMADAS AL SERVER AUTORIZATION

fernando@tsp MINGW64 ~
$ curl -X POST -d "client_id=client&client_secret=secret&username=usuario1&password=clave123"  http://localhost:7777/identity/connect/token
{"error":"invalid_client"}

$ curl -X POST -d "client_id=client1&client_secret=secret&username=usuario1&password=clave123"  http://localhost:7777/identity/connect/token
{"error":"unsupported_grant_type"}

$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123"  http://localhost:7777/identity/connect/token
{"error":"invalid_scope"}

$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1"  http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI1ODczLCJuYmYiOjE3MDYwMjQ2NzMsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MDI0NjczLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.lYhtnfHUoI5bAdO8NrpxaSLzYvBVranHEKNlTnzLusrg8kWhcToYYSvKyg3CfJdengqBdx_wwfl2_EJ-9MqDkbsUYAmF6s7OEeLup_injDTSw7Cshws-NJOzF0M8zaEgm_zTUXJUt7p-MAOkxjlqWHU8sM9sK_q2rYI4Z3GDNcgPtI52dyOKaG-b2_CkIE9mHfp1A_hFuUlPd44SA6mviLiPHws_q-kiL1fxLg4yDqxpsDxBF0Z4ifCw-O4nZPNcYsUyTdE95h6-yIO2qyufiLT36lHr-ddRubwgqID93zsxOBQ8opW1CY6wFzlU1d7nlFJXCfONX_FJp1tBSyXt-w","expires_in":1200,"token_type":"Bearer"}

# EJEMPLO DE LLAMADAS AL SERVER RESOURCE

$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1"  http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI1ODczLCJuYmYiOjE3MDYwMjQ2NzMsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MDI0NjczLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.lYhtnfHUoI5bAdO8NrpxaSLzYvBVranHEKNlTnzLusrg8kWhcToYYSvKyg3CfJdengqBdx_wwfl2_EJ-9MqDkbsUYAmF6s7OEeLup_injDTSw7Cshws-NJOzF0M8zaEgm_zTUXJUt7p-MAOkxjlqWHU8sM9sK_q2rYI4Z3GDNcgPtI52dyOKaG-b2_CkIE9mHfp1A_hFuUlPd44SA6mviLiPHws_q-kiL1fxLg4yDqxpsDxBF0Z4ifCw-O4nZPNcYsUyTdE95h6-yIO2qyufiLT36lHr-ddRubwgqID93zsxOBQ8opW1CY6wFzlU1d7nlFJXCfONX_FJp1tBSyXt-w","expires_in":1200,"token_type":"Bearer"}
$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI1ODczLCJuYmYiOjE3MDYwMjQ2NzMsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MDI0NjczLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.lYhtnfHUoI5bAdO8NrpxaSLzYvBVranHEKNlTnzLusrg8kWhcToYYSvKyg3CfJdengqBdx_wwfl2_EJ-9MqDkbsUYAmF6s7OEeLup_injDTSw7Cshws-NJOzF0M8zaEgm_zTUXJUt7p-MAOkxjlqWHU8sM9sK_q2rYI4Z3GDNcgPtI52dyOKaG-b2_CkIE9mHfp1A_hFuUlPd44SA6mviLiPHws_q-kiL1fxLg4yDqxpsDxBF0Z4ifCw-O4nZPNcYsUyTdE95h6-yIO2qyufiLT36lHr-ddRubwgqID93zsxOBQ8opW1CY6wFzlU1d7nlFJXCfONX_FJp1tBSyXt-w" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"No autenticado"}

$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2MjE3LCJuYmYiOjE3MDYwMjUwMTcsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MDE3LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.WG8FkZ3AaXeYnN3WY_6IbXL2pgTrW8BBgdNy_oUvMeKeo5WuTvLYVgIM2cFSUIG7Bb-k-tYazXo05ZrIrBqf5D9gkxP5cVzUzXY2qExoC2TJY1zUh0t4BVAtQNgR05UASwOwe2d5n9RBbRBPBc6Z0ztczBVrqEmiv-zih9sAEd9jXDjMyurl2JcI2CdyGz0YdBaO0gso-ryNArR7KD455whQObv2SUawbXdM6wCchp5OsuAm5FGJUNJBuaXbHJDr8keOmCK25r6-W7VkMHSPF-MgpesJngYmbYOlkLoF7UQQZDY-2FB0Sl05yGgIx2aDrqYDnlDRnfhCY7FVfLKFtg" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"Se ha denegado la autorización para esta solicitud."}

###
$ curl -X POST -d "grant_type=password&client_id=client2&client_secret=secret&username=usuario2&password=clave123&scope=
api1"  http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2MjE3LCJuYmYiOjE3MDYwMjUwMTcsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MDE3LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.WG8FkZ3AaXeYnN3WY_6IbXL2pgTrW8BBgdNy_oUvMeKeo5WuTvLYVgIM2cFSUIG7Bb-k-tYazXo05ZrIrBqf5D9gkxP5cVzUzXY2qExoC2TJY1zUh0t4BVAtQNgR05UASwOwe2d5n9RBbRBPBc6Z0ztczBVrqEmiv-zih9sAEd9jXDjMyurl2JcI2CdyGz0YdBaO0gso-ryNArR7KD455whQObv2SUawbXdM6wCchp5OsuAm5FGJUNJBuaXbHJDr8keOmCK25r6-W7VkMHSPF-MgpesJngYmbYOlkLoF7UQQZDY-2FB0Sl05yGgIx2aDrqYDnlDRnfhCY7FVfLKFtg","expires_in":1200,"token_type":"Bearer"}
$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2MjE3LCJuYmYiOjE3MDYwMjUwMTcsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MDE3LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.WG8FkZ3AaXeYnN3WY_6IbXL2pgTrW8BBgdNy_oUvMeKeo5WuTvLYVgIM2cFSUIG7Bb-k-tYazXo05ZrIrBqf5D9gkxP5cVzUzXY2qExoC2TJY1zUh0t4BVAtQNgR05UASwOwe2d5n9RBbRBPBc6Z0ztczBVrqEmiv-zih9sAEd9jXDjMyurl2JcI2CdyGz0YdBaO0gso-ryNArR7KD455whQObv2SUawbXdM6wCchp5OsuAm5FGJUNJBuaXbHJDr8keOmCK25r6-W7VkMHSPF-MgpesJngYmbYOlkLoF7UQQZDY-2FB0Sl05yGgIx2aDrqYDnlDRnfhCY7FVfLKFtg" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"Se ha denegado la autorización para esta solicitud."}

####
$ curl -X POST -d "grant_type=password&client_id=client2&client_secret=secret&username=usuario2&password=clave123&scope=api1"  http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2NTY1LCJuYmYiOjE3MDYwMjUzNjUsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MzY1LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.K1r0hklhgMHnyasoW41LdcaJDFoTQ4_uS3druf4xpa7sj0JzJNATxD9oM_BtqlJLpYhlXHOiO3ZM5Hkd0JdMf0WebOSxTw7NxQ_ipiVRZxGbF7_DJ9hQ_1yQPY_kpPlZRcrxR4ZnF_ZGNZqh2vsDTdY0LtzlD1BpZD5m-_DtoQwxp4MKCLbPDiCC-HxUdu8QFsF2tQijYfFNk7O2LPdE1YY6ZMFCNbI6dh0W5-l5Z5T-FZcnMv3eUNokA3GR51Az_pfdZ5Z82afF_Bjn0Fc_4D85gDObXHzqQthqwLwWF1KNS3awTZ0hmSq_S7mXTRl8W9jqYVXX30GYdma8f9rPTA","expires_in":1200,"token_type":"Bearer"}
$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2NTY1LCJuYmYiOjE3MDYwMjUzNjUsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MzY1LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.K1r0hklhgMHnyasoW41LdcaJDFoTQ4_uS3druf4xpa7sj0JzJNATxD9oM_BtqlJLpYhlXHOiO3ZM5Hkd0JdMf0WebOSxTw7NxQ_ipiVRZxGbF7_DJ9hQ_1yQPY_kpPlZRcrxR4ZnF_ZGNZqh2vsDTdY0LtzlD1BpZD5m-_DtoQwxp4MKCLbPDiCC-HxUdu8QFsF2tQijYfFNk7O2LPdE1YY6ZMFCNbI6dh0W5-l5Z5T-FZcnMv3eUNokA3GR51Az_pfdZ5Z82afF_Bjn0Fc_4D85gDObXHzqQthqwLwWF1KNS3awTZ0hmSq_S7mXTRl8W9jqYVXX30GYdma8f9rPTA" http://localhost:7778/api/Ej/MiServicioProtegido
"¡Bienvenido al servicio protegido! "

# ANALIZANDO ALGUNOS TOKENS - https://jwt.io/
PARA: grant_type=password&client_id=client2&client_secret=secret&username=usuario2&password=clave123&scope=api1
TOKEN:
eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2NTY1LCJuYmYiOjE3MDYwMjUzNjUsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MzY1LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.K1r0hklhgMHnyasoW41LdcaJDFoTQ4_uS3druf4xpa7sj0JzJNATxD9oM_BtqlJLpYhlXHOiO3ZM5Hkd0JdMf0WebOSxTw7NxQ_ipiVRZxGbF7_DJ9hQ_1yQPY_kpPlZRcrxR4ZnF_ZGNZqh2vsDTdY0LtzlD1BpZD5m-_DtoQwxp4MKCLbPDiCC-HxUdu8QFsF2tQijYfFNk7O2LPdE1YY6ZMFCNbI6dh0W5-l5Z5T-FZcnMv3eUNokA3GR51Az_pfdZ5Z82afF_Bjn0Fc_4D85gDObXHzqQthqwLwWF1KNS3awTZ0hmSq_S7mXTRl8W9jqYVXX30GYdma8f9rPTA

HEADER:ALGORITHM & TOKEN TYPE
{
  "typ": "JWT",
  "alg": "RS256",
  "x5t": "HFlKVQYrFq16_7iec5CXi16-5Ks",
  "kid": "HFlKVQYrFq16_7iec5CXi16-5Ks"
}

PAYLOAD:DATA
{
  "iss": "http://localhost:7777/identity",
  "aud": "http://localhost:7777/identity/resources",
  "exp": 1706026565,
  "nbf": 1706025365,
  "client_id": "client2",
  "scope": "api1",
  "sub": "2",
  "auth_time": 1706025365,
  "idp": "idsrv",
  "amr": [
    "password"
  ]
}

### CREANDO CERTIFICADO

$ openssl req -newkey rsa:2048 -nodes -keyout private-key.pem -x509 -days 365 -out certificate.pem
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

$ openssl pkcs12 -export -out certificate.pfx -inkey private-key.pem -in certificate.pem
Enter Export Password:
Verifying - Enter Export Password:
