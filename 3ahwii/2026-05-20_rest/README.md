## Rest

`Representational State Transfer` oder
`Representation of State`

rest client vscode plugin

## http methoden und ihre Verwandschaft mit CRUD operationen

create / read / update / delete

- GET -> read (select)
- POST -> create (insert)
- PUT -> update eines ganzen Objektes (evtl. id gleich) (update)
- PATCH -> update (update)
- DELETE -> delete (delete)

## was ist "idempotent"?

`auch wenn ich es 100x mache, gleiches Ergebnis`

idempotent bedeutet, dass eine Operation mehrfach hintereinander ausgeführt werden kann, ohne dass sich das Ergebnis ändert. Zum Beispiel ist die GET-Methode idempotent, da sie immer das gleiche Ergebnis zurückgibt, unabhängig davon, wie oft sie aufgerufen wird. Die POST-Methode hingegen ist nicht idempotent, da sie jedes Mal ein neues Objekt erstellt und somit das Ergebnis ändert.

## http status codes 

- immer 3-stellig
- 1xx -> informational
- 2xx -> success (200 ok, 201 created, 204 no content)
- 3xx -> (grundsätzlich ok, aber client muss noch was tun) redirection
- 4xx -> client error (400 bad request, 401 unauthorized, 403 forbidden, 404 not found)
- 5xx -> server error (500 internal server error, 502 bad gateway, 503 service unavailable)

## URL Parameter

- query parameter -> ?key=value&key2=value2
- path parameter -> /users/{id}
