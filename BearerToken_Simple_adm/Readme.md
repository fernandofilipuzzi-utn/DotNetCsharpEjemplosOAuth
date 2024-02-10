# Escenario de autentificación y autorización utilizando bearer token

<div align="center">
        <img style="width:60%;" src="esquema_sistema.jpg"/>
        <p>Figura 1. Escenario de prueba del sistema</p>
</div>

## Dependendencias NUGET

```
clientservices: Newtonsoft.Json, RestSharp, System.IdentityModel.Tokens.Jwt
resource api:
authorization:
```

## POSTMAN

https://www.postman.com/fernandofilipuzziutn/workspace/dotnetcsharpejemplosbdsensillos/overview


## Implementación del escenario

Requiere implementar en el IIS los siguientes proyectos

### Servicio autenticador

<details>
        <summary>servicio autenticador: BearerToken_Simple_adm/auth_server/BearerToken_SimpleServer_adm como http://localhost:7777</summary>

<div align="center">
        <img style="width:60%;" src="pantallazo_admin_credenciales.jpg"/>
        <p>Figura 2. Escenario de prueba del sistema</p>
</div>

<div align="center">
        <img style="width:60%;" src="pantallazo_alta_cliente.jpg"/>
        <p>Figura 3. Alta de credenciales</p>
</div>
        
</details>

### Servicio de recursos tokenizados

<details>
        <summary>servicio de recursos tokenizados: BearerToken_Simple_adm/resources_server/ResourceAPIServer como http://locahost:7778</summary>
</details>

Luego como aplicaciones cliente están:

### Clientes

<details>
        <summary></summary>

```
        apliación cliente desktop: BearerToken_Simple_adm/clientes/AppDemoCliente
        apliación cliente web: BearerToken_Simple_adm/clientes/AppWebDemoCliente
```
</details>

## Resumen de llamadas 

### 1. Solicitud del token
```bash
curl -X POST -d "guid=guid_generado&frase=frase" http://localhost:7777/auth/token
```

### 3. llamada al método tokenido en el servidor de autenticación
```bash
curl -H "Authorization: Bearer <token_generado>" http://localhost:7778/api/Ej/MiServicioProtegido
```

## Ejemplos CURL

### 1-2. solicitud de un token
Requiere primero dar de alta las credenciales de un cliente en http://localhost:7777/admin/credenciales
```bash
$ curl -X POST --header 'Content-Type: application/json' \
          --header 'Accept: application/json' \
          -d '{ "guid": "cbf25e40-b0da-4aa2-8a51-e2d701390ba1", "clave": "pFb2MKucltUts" }' \
          'http://localhost:7777/auth/token'

{
 "access_token":"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiY2JmMjVlNDAtYjBkYS00YWEyLThhNTEtZTJkNzAxMzkwYmExIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA3NjAxMzY1fQ.nOEuoKPPn9agf7_mNa16dXeQrYp6ciYWVeCwBgi5-Nc",
 "token_type":"Bearer"
}
```

### 3-4. llamando a un método tokenizado en el servicio de autenticación

```bash
$ curl -X GET --header 'Accept: application/json' \
          --header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiY2JmMjVlNDAtYjBkYS00YWEyLThhNTEtZTJkNzAxMzkwYmExIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA3NjA4MDAwfQ.en5n1ZL0MWse6VD7SaW4FFp7Y3ZYlNvkGikl04b-u6M' 'https://localhost:7778/auth/modulosurls/cbf25e40-b0da-4aa2-8a51-e2d701390ba1'

[
    {"Id":1,"Descripcion":"prueba1","Url":"http://localhost/prueba1"},
    {"Id":2,"Descripcion":"prueba2","Url":"http://localhost/prueba2"}
]
```

### 5-6. llamando a un método tokenizado en el servicio de recursos tokenizados

```bash
$ curl -X GET --header 'Accept: application/json' \
          --header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiY2JmMjVlNDAtYjBkYS00YWEyLThhNTEtZTJkNzAxMzkwYmExIiwic2NvcGUiOiJhcGkxIiwiZXhwIjoxNzA3NjA4MDAwfQ.en5n1ZL0MWse6VD7SaW4FFp7Y3ZYlNvkGikl04b-u6M' \
          'http://localhost:7778/api/Ejemplos/MiServicioProtegido'
"¡Bienvenido al servicio protegido! "
```

### 7-8. solicitud de una página tokenizada

```bash
$ curl  http://localhost:7778/web_tokenizada/PaginaTokenizada.aspx?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJnd
WlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyG
Csvt-RW72c0-w50u0RR2BWsm2fj4w
<html><head><title>Object moved</title></head><body>
<h2>Object moved to <a href="/web_tokenizada/PaginaTokenizada?embedToken=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJndWlkIjoiNzViYzM2MmQtOWZhNi00NWNhLTgyMjAtYTQ5ZmVkYTFkODgyIiwic2NvcGUiOiJnZGEgZ2RpIiwiZXhwIjoxNzA2NzUzOTEzfQ.Ey8YeRk3nQobyGCsvt-RW72c0-w50u0RR2BWsm2fj4w">here</a>.</h2>
</body></html>
```


## Consultas

 https://stackoverflow.com/questions/43403941/how-to-read-asp-net-core-response-body
 
 https://stackoverflow.com/questions/48396746/asp-net-response-filter-on-the-entire-content-full-response
 
 https://weblog.west-wind.com/posts/2009/Nov/13/Capturing-and-Transforming-ASPNET-Output-with-ResponseFilter
 

 ## modificando respuestas del middleware
 
 https://copyprogramming.com/howto/changing-the-response-object-from-owin-middleware
