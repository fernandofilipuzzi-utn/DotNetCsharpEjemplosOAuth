# NUGET
clientservices: Newtonsoft.Json, RestSharp, System.IdentityModel.Tokens.Jwt
resource api:
authorization: Microsoft.Owin.Cors


# IMPLEMENTACIÓN PARA PRUEBAS
APIEjService corre en el IIS como http://localhost:7778
Auth2.0Service corre en el IIS como http://locahost:7777

AppDemoCliente, consume ambos servicios.

# RESUMEN LLAMADAS 

## SOLICITUD DE TOKEN
curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1" http://localhost:7777/identity/connect/token

## CONSUMIENDO SERVICIO
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido

# PARA VERIFICAR LA ESTRUCTURA DEL TOKEN
https://jwt.io/
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MDU2NzM0MzQsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6Nzc3Ny9hcGkvdG9rZW4iLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzgvYXBpL0VqL01pU2VydmljaW9Qcm90ZWdpZG8ifQ.gmQPz3zhCKgmMH3OCiNcDZV7YfXNQ8bOsxfSXEwSzqE

# EJEMPLO DE LLAMADAS AL SERVER AUTORIZATION

#### EJEMPLO 1 - CLIENTE NO VALIDO
$ curl -X POST -d "client_id=client&client_secret=secret&username=usuario1&password=clave123"  http://localhost:7777/identity/connect/token
{"error":"invalid_client"}

#### EJEMPLO 2 - GRANT NO SOPORTADO
$ curl -X POST -d "client_id=client1&client_secret=secret&username=usuario1&password=clave123"  http://localhost:7777/identity/connect/token
{"error":"unsupported_grant_type"}

#### EJEMPLO 3 - SCOPE NO VALIDO
$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123"  http://localhost:7777/identity/connect/token
{"error":"invalid_scope"}

#### EJEMPLO 4 - NO AUTENTICADO
$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1"  http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI1ODczLCJuYmYiOjE3MDYwMjQ2NzMsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MDI0NjczLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.lYhtnfHUoI5bAdO8NrpxaSLzYvBVranHEKNlTnzLusrg8kWhcToYYSvKyg3CfJdengqBdx_wwfl2_EJ-9MqDkbsUYAmF6s7OEeLup_injDTSw7Cshws-NJOzF0M8zaEgm_zTUXJUt7p-MAOkxjlqWHU8sM9sK_q2rYI4Z3GDNcgPtI52dyOKaG-b2_CkIE9mHfp1A_hFuUlPd44SA6mviLiPHws_q-kiL1fxLg4yDqxpsDxBF0Z4ifCw-O4nZPNcYsUyTdE95h6-yIO2qyufiLT36lHr-ddRubwgqID93zsxOBQ8opW1CY6wFzlU1d7nlFJXCfONX_FJp1tBSyXt-w","expires_in":1200,"token_type":"Bearer"}

#### EJEMPLO 5 - NO AUTENTICADO
$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MTA1MDE0LCJuYmYiOjE3MDYxMDM4MTQsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MTAzODE0LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.RnpbZtrLKUREET0nT9snV0emvrP2_ErD2JQL1ZbNPjUJp8axPbbC1n1wxKylXWesZcHKUE0fjNqNrIM67ONi99zIbZNipMMDI1S-Z5dUgt5iAGmPH4-4R-IJ_A9O4WVlqEdmv_6_-Xqulu2V7C5eTqzB7wyPRsLYu1TJQSIFj_zKCJNc24J0SHOZM0bGAIqe7CZK9BzWwU7si3xH8xuK9q1oeEPvZu4qgppmSaeWrvobTk9jf4QLyN87bm0RBSl_USi3Vh737IJLx8eeIdkvenuj11W8_8L-f8ykZLgm8_mBf2T9xpi0SwaDILf3X7B1YSZLKAyMc0DvDdyr_com5g","expires_in":1200,"token_type":"Bearer"}

$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MTA1MDE0LCJuYmYiOjE3MDYxMDM4MTQsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MTAzODE0LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.RnpbZtrLKUREET0nT9snV0emvrP2_ErD2JQL1ZbNPjUJp8axPbbC1n1wxKylXWesZcHKUE0fjNqNrIM67ONi99zIbZNipMMDI1S-Z5dUgt5iAGmPH4-4R-IJ_A9O4WVlqEdmv_6_-Xqulu2V7C5eTqzB7wyPRsLYu1TJQSIFj_zKCJNc24J0SHOZM0bGAIqe7CZK9BzWwU7si3xH8xuK9q1oeEPvZu4qgppmSaeWrvobTk9jf4QLyN87bm0RBSl_USi3Vh737IJLx8eeIdkvenuj11W8_8L-f8ykZLgm8_mBf2T9xpi0SwaDILf3X7B1YSZLKAyMc0DvDdyr_com5g" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"No autenticado"}

#### EJEMPLO 6 - SOLICITUD DENEGADA
$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2MjE3LCJuYmYiOjE3MDYwMjUwMTcsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MDE3LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.WG8FkZ3AaXeYnN3WY_6IbXL2pgTrW8BBgdNy_oUvMeKeo5WuTvLYVgIM2cFSUIG7Bb-k-tYazXo05ZrIrBqf5D9gkxP5cVzUzXY2qExoC2TJY1zUh0t4BVAtQNgR05UASwOwe2d5n9RBbRBPBc6Z0ztczBVrqEmiv-zih9sAEd9jXDjMyurl2JcI2CdyGz0YdBaO0gso-ryNArR7KD455whQObv2SUawbXdM6wCchp5OsuAm5FGJUNJBuaXbHJDr8keOmCK25r6-W7VkMHSPF-MgpesJngYmbYOlkLoF7UQQZDY-2FB0Sl05yGgIx2aDrqYDnlDRnfhCY7FVfLKFtg" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"Se ha denegado la autorización para esta solicitud."}

#### EJEMPLO 7 - SOLICITUD DENEGADA
$ curl -X POST -d "grant_type=password&client_id=client2&client_secret=secret&username=usuario2&password=clave123&scope=api1"  http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2MjE3LCJuYmYiOjE3MDYwMjUwMTcsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MDE3LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.WG8FkZ3AaXeYnN3WY_6IbXL2pgTrW8BBgdNy_oUvMeKeo5WuTvLYVgIM2cFSUIG7Bb-k-tYazXo05ZrIrBqf5D9gkxP5cVzUzXY2qExoC2TJY1zUh0t4BVAtQNgR05UASwOwe2d5n9RBbRBPBc6Z0ztczBVrqEmiv-zih9sAEd9jXDjMyurl2JcI2CdyGz0YdBaO0gso-ryNArR7KD455whQObv2SUawbXdM6wCchp5OsuAm5FGJUNJBuaXbHJDr8keOmCK25r6-W7VkMHSPF-MgpesJngYmbYOlkLoF7UQQZDY-2FB0Sl05yGgIx2aDrqYDnlDRnfhCY7FVfLKFtg","expires_in":1200,"token_type":"Bearer"}
$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MDI2MjE3LCJuYmYiOjE3MDYwMjUwMTcsImNsaWVudF9pZCI6ImNsaWVudDIiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIyIiwiYXV0aF90aW1lIjoxNzA2MDI1MDE3LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.WG8FkZ3AaXeYnN3WY_6IbXL2pgTrW8BBgdNy_oUvMeKeo5WuTvLYVgIM2cFSUIG7Bb-k-tYazXo05ZrIrBqf5D9gkxP5cVzUzXY2qExoC2TJY1zUh0t4BVAtQNgR05UASwOwe2d5n9RBbRBPBc6Z0ztczBVrqEmiv-zih9sAEd9jXDjMyurl2JcI2CdyGz0YdBaO0gso-ryNArR7KD455whQObv2SUawbXdM6wCchp5OsuAm5FGJUNJBuaXbHJDr8keOmCK25r6-W7VkMHSPF-MgpesJngYmbYOlkLoF7UQQZDY-2FB0Sl05yGgIx2aDrqYDnlDRnfhCY7FVfLKFtg" http://localhost:7778/api/Ej/MiServicioProtegido
{"Message":"Se ha denegado la autorización para esta solicitud."}

#### EJEMPLO 8 - EXITO!
$ curl -X POST -d "grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api1" http://localhost:7777/identity/connect/token
{"access_token":"eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MTA1NDQyLCJuYmYiOjE3MDYxMDQyNDIsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MTA0MjQyLCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.v1Esdk6TuIkPmXd-NRJd1dNFHrMET5UqL7Na1DcfBQoD4er_GyUEl2q7MLl066KPYJNJDXoNzd4POeYhZ0GogNmvuRhkdGz1o8R8IuE4PeKLva1EPYvfw6SVXjJ_sSpTO8REkEnCqKZZjOOlitqxphuH5FCeaSLD1_IplSiMs7IFj0Q6FrydX2AhmdA5eK0f3fy0deOJMtL6vvsw6X91csme4Uf06TVNNWLSpRhZn9cTuQd_QXcXFFwlti3gMUvqj91yMQL6e0eaVKEa2uIwR7aB7utjza9RljGXYdXF42GZPUajgM1OsFR2EYxucAaywrlrCeF7BuhvJzF-VwgMDg","expires_in":1200,"token_type":"Bearer"}

$ curl -H "Authorization: Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MTA1MDE0LCJuYmYiOjE3MDYxMDM4MTQsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MTAzODE0LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.RnpbZtrLKUREET0nT9snV0emvrP2_ErD2JQL1ZbNPjUJp8axPbbC1n1wxKylXWesZcHKUE0fjNqNrIM67ONi99zIbZNipMMDI1S-Z5dUgt5iAGmPH4-4R-IJ_A9O4WVlqEdmv_6_-Xqulu2V7C5eTqzB7wyPRsLYu1TJQSIFj_zKCJNc24J0SHOZM0bGAIqe7CZK9BzWwU7si3xH8xuK9q1oeEPvZu4qgppmSaeWrvobTk9jf4QLyN87bm0RBSl_USi3Vh737IJLx8eeIdkvenuj11W8_8L-f8ykZLgm8_mBf2T9xpi0SwaDILf3X7B1YSZLKAyMc0DvDdyr_com5g" http://localhost:7778/api/Ej/MiServicioProtegido
"¡Bienvenido al servicio protegido! "


# ANALIZANDO ALGUNOS TOKENS - https://jwt.io/
PARA: grant_type=password&client_id=client1&client_secret=secret&username=usuario1&password=clave123&scope=api
TOKEN: eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyIsImtpZCI6IkhGbEtWUVlyRnExNl83aWVjNUNYaTE2LTVLcyJ9.eyJpc3MiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0Ojc3NzcvaWRlbnRpdHkvcmVzb3VyY2VzIiwiZXhwIjoxNzA2MTA1MDE0LCJuYmYiOjE3MDYxMDM4MTQsImNsaWVudF9pZCI6ImNsaWVudDEiLCJzY29wZSI6ImFwaTEiLCJzdWIiOiIxIiwiYXV0aF90aW1lIjoxNzA2MTAzODE0LCJpZHAiOiJpZHNydiIsImFtciI6WyJwYXNzd29yZCJdfQ.RnpbZtrLKUREET0nT9snV0emvrP2_ErD2JQL1ZbNPjUJp8axPbbC1n1wxKylXWesZcHKUE0fjNqNrIM67ONi99zIbZNipMMDI1S-Z5dUgt5iAGmPH4-4R-IJ_A9O4WVlqEdmv_6_-Xqulu2V7C5eTqzB7wyPRsLYu1TJQSIFj_zKCJNc24J0SHOZM0bGAIqe7CZK9BzWwU7si3xH8xuK9q1oeEPvZu4qgppmSaeWrvobTk9jf4QLyN87bm0RBSl_USi3Vh737IJLx8eeIdkvenuj11W8_8L-f8ykZLgm8_mBf2T9xpi0SwaDILf3X7B1YSZLKAyMc0DvDdyr_com5g

HEADER:ALGORITHM & TOKEN TYPE
{
  "typ": "JWT",
  "alg": "HS256",
  "x5t": "HFlKVQYrFq16_7iec5CXi16-5Ks",
  "kid": "HFlKVQYrFq16_7iec5CXi16-5Ks"
}

PAYLOAD:DATA
{
  "iss": "http://localhost:7777/identity",
  "aud": "http://localhost:7777/identity/resources",
  "exp": 1706105014,
  "nbf": 1706103814,
  "client_id": "client1",
  "scope": "api1",
  "sub": "1",
  "auth_time": 1706103814,
  "idp": "idsrv",
  "amr": [
    "password"
  ]
}

VERIFY SIGNATURE
HMACSHA256(
  base64UrlEncode(header) + "." +
  base64UrlEncode(payload),
  
your-256-bit-secret

) secret base64 encoded

### CREANDO CERTIFICADO - REVISAR CARPETA Configuration

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


# EJEMPLOS
##sobre el certificado
https://github.com/IdentityServer/IdentityServer3.Samples/blob/master/source/WebHost%20(Windows%20Auth)/WindowsAuthWebHost/Configuration/Cert.cs
     