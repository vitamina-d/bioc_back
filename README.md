# 🧬 bioc_back

Backend del proyecto **Vitamina-D**.

## 📋 Descripción

**bioc_back** está desarrollado con ASP.NET Core 8.0. Actúa como capa de integración entre el frontend y los servicios bioinformáticos, proporcionando una API REST unificada para el acceso a datos genómicos, análisis de secuencias y predicción de estructuras proteicas.

## ✨ Funcionalidades Principales

### 🔌 Integración de Servicios
- **Bioconductor (R)** - Consulta de secuencias genómicas vía Plumber API
- **Ensembl** - Acceso a la API pública de Ensembl para datos genómicos
- **BLAST** - Ejecución de análisis de alineamiento de secuencias
- **BioPython** - Procesamiento de secuencias y análisis complementarios
- **NeuroSnap** - Predicción de plegamiento de proteínas mediante IA

### 🎯 Endpoints Principales

#### Controlador Plumber (BSGenome)
```http
GET /api/Plumber/seq?chrom={chrom}&start={start}&end={end}
```
Obtiene secuencias genómicas desde el contenedor R con Bioconductor.

```http
GET /api/Plumber/align
```
Realiza alineamiento de secuencias usando herramientas de R.

#### Controlador Public (Ensembl API)
```http
GET /api/Public/ensembl?chrom={chrom}&start={start}&end={end}
```
Consulta secuencias desde la API pública de Ensembl.

```http
GET /api/Public/gene?id={entrezId}
```
Obtiene información detallada de genes por Entrez ID desde NCBI.

```http
GET /api/Public/protein?id={uniprotId}
```
Recupera datos de proteínas desde UniProt.

#### Controlador Blast
```http
POST /api/Blast/blastx
```
Ejecuta análisis BLASTx contra bases de datos de proteínas.

#### Controlador Folding
```http
POST /api/Folding/predict
```
Predice estructura 3D de proteínas usando NeuroSnap API.

#### Controlador Python
```http
POST /api/Python/process
```
Ejecuta procesamiento de secuencias con BioPython.

## 🏗️ Arquitectura

El proyecto implementa **Clean Architecture** con separación de responsabilidades:

```
bioc_back/
├── Presentation/         # Capa de presentación (API)
│   ├── Controllers/      # Controladores REST
│   │   ├── BlastController.cs
│   │   ├── FoldingController.cs
│   │   ├── PlumberController.cs
│   │   ├── PublicController.cs
│   │   └── PythonController.cs
│   ├── Middleware/       # Middleware personalizado
│   ├── Utils/            # Utilidades
│   └── Program.cs        # Punto de entrada
├── Application/          # Lógica de aplicación
│   └── UseCase/          # Casos de uso
├── Infrastructure/       # Capa de infraestructura
│   └── Query/            # Clientes API externos
├── Domain/               # Lógica de dominio
└── docker-compose.yml    # Orquestación de servicios
```

### Principios de Diseño
- **Clean Architecture** - Separación de capas y dependencias
- **Dependency Injection** - Inversión de control
- **Repository Pattern** - Abstracción de acceso a datos
- **CORS** - Comunicación con frontend

## 🛠️ Stack Tecnológico

### Backend
- **ASP.NET Core 8.0** - Framework web
- **C# (.NET 8)** - Lenguaje de programación
- **Swagger/OpenAPI** - Documentación automática de API

### Integraciones
- **HttpClient** - Cliente HTTP para APIs externas
- **Dependency Injection** - Contenedor IoC nativo

### DevOps
- **Docker** - Contenedorización
- **Docker Compose** - Orquestación multi-contenedor

## 🚀 Inicio Rápido

### Con Docker Compose (Recomendado)

El proyecto incluye un `docker-compose.yml` que orquesta los servicios:

```bash
docker-compose up -d
```

#### Servicios Orquestados

| Servicio | Puerto | Descripción |
|----------|--------|-------------|
| `presentation` | 8081 | API Backend (este proyecto) |
| `web` | 5173 | Frontend React |
| `bioc` | 8000, 8787 | Servicio R con RStudio |
| `blast` | 8001 | Servicio BLAST |
| `biopython` | 8002 | Servicio BioPython |

## 📡 Documentación API

Una vez iniciado el servidor, la documentación de Swagger está disponible en:

```
http://localhost:8081/swagger/index.html
```

## 🔗 Integración con el Ecosistema

**bioc_back** es el hub central que integra:

- **[bioc_front](https://github.com/vitamina-d/bioc_front)** - Frontend web en React
- **[bioc_r](https://github.com/vitamina-d/bioc_r)** - Servicio R/Bioconductor
- **[bioc_blast](https://github.com/vitamina-d/bioc_blast)** - Servicio BLAST
- **[doc](https://github.com/vitamina-d/doc)** - Documentación del proyecto

### Flujo de Datos

```
┌─────────────┐
│  Frontend   │
│ (React/TS)  │
└──────┬──────┘
       │ HTTP/REST
       ▼
┌─────────────┐
│  bioc_back  │◄─────── Ensembl API (pública)
│ (ASP.NET)   │◄─────── NCBI API (pública)
└──────┬──────┘◄─────── UniProt API (pública)
       │
       ├──────► bioc_r (Bioconductor/R)
       ├──────► bioc_blast (BLAST)
       ├──────► biopython (Python)
       └──────► NeuroSnap (AI Folding)
```

## 📝 Licencia

Este proyecto tiene fines educativos y forma parte del Proyecto Integrador Profesional (PIP).
