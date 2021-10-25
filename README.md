# Project .NET Framework

* Naam: Maxim Derboven
* Studentennummer: 0145196-84
* Academiejaar: 21-22
* Klasgroep: INF203A
* Onderwerp: Driver - Car


## Sprint 3

### Beide zoekcriteria ingevuld
```
SELECT "d"."SocialNumber", "d"."DateOfBirth", "d"."FirstName", "d"."LastName"
FROM "Drivers" AS "d"
WHERE ((@__ToLower_0 = '') OR (instr(lower((COALESCE("d"."FirstName", '') || ' ') || "d"."LastName"), @__ToLower_0) > 0)) AND (@__dateofbirth_1 = rtrim(rtrim(strftime('%Y-%m-%d %H:%M:%f', "d"."DateOfBirth", 'start of day'), '0'), '.'))
```

### Enkel zoeken op naam
```
SELECT "d"."SocialNumber", "d"."DateOfBirth", "d"."FirstName", "d"."LastName"
FROM "Drivers" AS "d"
WHERE (@__ToLower_0 = '') OR (instr(lower((COALESCE("d"."FirstName", '') || ' ') || "d"."LastName"), @__ToLower_0) > 0)
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
