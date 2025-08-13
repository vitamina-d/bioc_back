# bioc_back
Este proyecto tiene fines educativos para consumir secuencias genómicas desde el contenedor local o un servicio público y mostrarlas en un frontend.

ASP.NET Core expone una API REST que se conecta con:

- Un servicio en R con Plumber (Docker).
- La API pública de Ensembl.

## 🚀 Endpoints disponibles

### 1. `GET /api/genome/seq`

Devuelve una secuencia genómica utilizando el contenedor de Plumber en `host.docker.internal`.

**Ejemplo**:
```http
GET https://localhost:32773/api/Genome/seq?chrom=chr11&start=100100&end=100200
```
---
### 2. `GET /api/genome/ensembl`

Devuelve una secuencia genómica desde la API pública de Ensembl.

**Ejemplo**:
```http
GET https://localhost:32773/api/Genome/ensembl?chrom=chr11&start=100100&end=100200
```

**Parámetros (query)**:
- `chrom` (string): nombre del cromosoma.
- `start` (int): posición inicial.
- `end` (int): posición final.
