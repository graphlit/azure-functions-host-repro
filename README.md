
To reproduce:
- build and run FunctionApp1, should be running on port 7060

```
Azure Functions Core Tools
Core Tools Version:       4.0.5611 Commit hash: N/A +591b8aec842e333a87ea9e23ba390bb5effe0655 (64-bit)
Function Runtime Version: 4.31.1.22191

[2024-05-01T05:55:24.906Z] Found C:\Projects\FunctionApp1\FunctionApp1.csproj. Using for user secrets file configuration.

Functions:

        Function1: [GET,POST] http://localhost:7060/api/Function1

For detailed output, run func with --verbose flag.

```

- open Postman
- assign `x-function-key` in headers to the master key
- HTTP GET http://localhost:7060/admin/host/status
- should get 200 OK, and return something like this:

```
GET /admin/host/status HTTP/1.1
x-functions-key: redacted
User-Agent: PostmanRuntime/7.37.3
Accept: */*
Cache-Control: no-cache
Postman-Token: b89c588d-c6a4-49c0-9e1a-0ae8f4be20f6
Host: localhost:7060
Accept-Encoding: gzip, deflate, br
Connection: keep-alive
 
HTTP/1.1 200 OK
Content-Length: 278
Content-Type: application/json; charset=utf-8
Date: Wed, 01 May 2024 05:57:40 GMT
Server: Kestrel
 
{"id":"devuslaxsu01-1661637753","state":"Running","version":"4.31.1.22191","versionDetails":"4.31.1+eb76715a57649d269232d1375a7a2c23ee73dd0a","platformVersion":"","instanceId":"","computerName":"DEV-USLAXSU01","processUptime":25209411,"functionAppContentEditingState":"Unknown"}
```

- go to FunctionsStartup.cs
- uncomment the line `builder.Services.AddAuthorization();`
- rebuild and run FunctionApp1
- HTTP GET http://localhost:7060/admin/host/status
- get 500 error 

```
GET /admin/host/status HTTP/1.1
x-functions-key: redacted
User-Agent: PostmanRuntime/7.37.3
Accept: */*
Cache-Control: no-cache
Postman-Token: f020c56e-3725-4bb9-9552-65091bea83ee
Host: localhost:7060
Accept-Encoding: gzip, deflate, br
Connection: keep-alive
 
HTTP/1.1 500 Internal Server Error
Content-Length: 0
Date: Wed, 01 May 2024 05:56:24 GMT
Server: Kestrel
```
