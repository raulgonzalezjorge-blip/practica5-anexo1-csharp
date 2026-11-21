# Práctica V · Anexo I (C#)

Wiki del proyecto. Aquí se describe qué tiene que hacer cada desarrollador y cómo debe trabajar con Git.

## Equipo y roles
| Rol | Persona | GitHub |
|-----|---------|--------|
| Jefe de proyecto (Scrum Master) | Raúl | [raulgonzalezjorge-blip](https://github.com/raulgonzalezjorge-blip) |
| Desarrollador/a de este repositorio | Adrián | [adriangalvan649](https://github.com/adriangalvan649) |
| Product Owner | El profesor | |

## Enlaces
- Repositorio: <https://github.com/raulgonzalezjorge-blip/practica5-anexo1-csharp>
- Tablero (pizarra ágil): <https://github.com/users/raulgonzalezjorge-blip/projects/2>
- Tareas (issues): <https://github.com/raulgonzalezjorge-blip/practica5-anexo1-csharp/issues>

Resto de repositorios de la práctica:
- [Anexo II (SQL Steam)](https://github.com/raulgonzalezjorge-blip/practica5-anexo2-sql)
- [Sitio web](https://github.com/raulgonzalezjorge-blip/practica5-sitio-web)

## Páginas de esta wiki
- [Tareas de Adrián](Tareas-Adrian.md)
- [Flujo de trabajo con Git](Flujo-de-trabajo-Git.md)
- [Scrum: daily y cierre de sprint](Scrum.md)

## Normas del equipo
- **Nunca** se desarrolla en `main` ni directamente en `develop`.
- `main` = versión entregada al final de cada sprint. `develop` = integración (rama por defecto).
- Cada tarea se hace en su propia rama `feature/<nº-issue>-<descripcion-corta>` creada desde `develop`.
- Todos trabajamos sobre un **fork** propio y llevamos los cambios al repositorio oficial con **Pull Request** hacia `develop`.
- El jefe de proyecto revisa y fusiona cada Pull Request. Al final del sprint fusiona `develop` → `main` (también por PR).
- Commits pequeños y con mensaje descriptivo: `tipo(ámbito): descripción en presente (#issue)`.
  - Tipos: `feat` (funcionalidad), `fix` (corrección), `docs` (documentación), `style` (formato/CSS), `refactor`, `test`, `chore` (configuración).
- Cada desarrollador mantiene su tarjeta actualizada en el tablero: **TO DO → DOING → DONE**.
- Etiquetas de tamaño: `low` (< 2 h), `medium` (2-5 h), `high` (grande: **se divide** antes de entrar al sprint).
- Cada repositorio debe tener contribuciones de **al menos dos desarrolladores** a lo largo del proyecto.

## Definición de Hecho · Sprint 1
- La solución `Anexo1.sln` compila sin errores (`dotnet build`).
- Los 4 proyectos (`Arrays`, `Numeros`, `Cadenas`, `Decimales`) muestran su menú.
- El proyecto `Arrays` tiene sus 7 funcionalidades operativas desde el menú.
- Todo está fusionado en `develop` mediante Pull Request revisado por el jefe.

> La definición de hecho se revisa al final de cada sprint y se actualiza en esta página.
