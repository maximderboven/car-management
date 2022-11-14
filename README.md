# Project .NET Framework  

* Onderwerp: Driver - Car  

## Sprint 3

### Beide zoekcriteria ingevuld
```
SELECT "d"."SocialNumber", "d"."DateOfBirth", "d"."FirstName", "d"."LastName"
FROM "Drivers" AS "d"
WHERE ((@__ToLower_0 = '') OR (instr(lower(("d"."FirstName" || ' ') || "d"."LastName"), @__ToLower_0) > 0)) AND (@__dateofbirth_1 = rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', "d"."DateOfBirth", 'start of day'), '0'), '.'))
```

### Enkel zoeken op naam
```
SELECT "d"."SocialNumber", "d"."DateOfBirth", "d"."FirstName", "d"."LastName"
FROM "Drivers" AS "d"
WHERE (@__ToLower_0 = '') OR (instr(lower(("d"."FirstName" || ' ') || "d"."LastName"), @__ToLower_0) > 0)
```

### Enkel zoeken op geboortedatum
```
SELECT "d"."SocialNumber", "d"."DateOfBirth", "d"."FirstName", "d"."LastName"
FROM "Drivers" AS "d"
WHERE @__dateofbirth_0 = rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', "d"."DateOfBirth", 'start of day'), '0'), '.')
```

### Beide zoekcriteria leeg
```
SELECT "d"."SocialNumber", "d"."DateOfBirth", "d"."FirstName", "d"."LastName"
FROM "Drivers" AS "d"
```

## Sprint 6

### Nieuwe garage

#### Request
```
POST https://localhost:5001/api/Garages HTTP/1.1
Accept: application/json
Content-Type: application/json

{
  "Name":"Volkswagen AG",
  "Adress":"Groeningenlei 4, 2550 Kontich",
  "Telnr":"034508050"
}
```

#### Response
```
Response code: 200 (OK); Time: 192ms; Content length: 0 bytes
```

### Aanpassen van de garage (success)

#### Request
```
PUT https://localhost:5001/api/Garages HTTP/1.1
Accept: application/json
Content-Type: application/json

{
  "id": 1,
  "Name":"test",
  "Adress":"test address",
  "Telnr":"0488857339"
}
```

#### Response
```
Response code: 200 (OK); Time: 241ms; Content length: 0 bytes
```


### Aanpassen van de garage (fail)

#### Request
```
PUT https://localhost:5001/api/Garages HTTP/1.1
Accept: application/json
Content-Type: application/json

{
  "id": 1,
  "Name":"t",
  "Adress":"test address",
  "Telnr":"0488857339"
}
```

#### Response
```
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-6deb3ae337e4124fac38a38a33294140-75f57c44bb7c1d44-00",
  "errors": {
    "Name": [
      "Error: Name min. 2 CHAR & max. 2 CHAR "
    ]
  }
}

Response code: 400 (Bad Request); Time: 87ms; Content length: 252 bytes
```
