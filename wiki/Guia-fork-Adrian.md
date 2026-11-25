# Guía paso a paso para Adrián (Anexo I): fork y Pull Request del manual de uso

Esta guía es para hacerlo **por primera vez**. Sigue los pasos en orden y no te saltes ninguno.
Al final habrás subido un cambio al repositorio oficial **desde tu propio fork**, que es lo que pide el enunciado.

**Tus datos:** usuario `adriangalvan649` · repositorio oficial `practica5-anexo1-csharp` · tarea **#17 Manual de uso del Anexo I (MANUAL.md con capturas de cada menú)**.

| Qué | Enlace |
|-----|--------|
| Repositorio oficial | https://github.com/raulgonzalezjorge-blip/practica5-anexo1-csharp |
| Tu fork (existe **después** del paso 1) | https://github.com/adriangalvan649/practica5-anexo1-csharp |
| Tablero de tareas | https://github.com/users/raulgonzalezjorge-blip/projects/2/views/2 |

## Capturas

No hace falta repetir las capturas del fork: ya están en el apartado 2.4 del documento. En esta tarea las capturas van **dentro del manual** (paso 5).

## Antes de empezar: qué es cada cosa

- **Repositorio oficial**: el de Raúl (`raulgonzalezjorge-blip/practica5-anexo1-csharp`). Solo entra código en él mediante Pull Request.
- **Fork**: tu copia del repositorio oficial en tu cuenta (`adriangalvan649/practica5-anexo1-csharp`). Ahí puedes subir lo que quieras sin romper nada.
- **Rama**: una línea de trabajo dentro del repositorio. Cada tarea va en su rama `feature/<nº>-<descripción>`.
- **Pull Request (PR)**: la petición para que el jefe revise tu rama y la meta en `develop` del repositorio oficial.

## Paso 0. Instalar y configurar Git (solo la primera vez)

1. Instala Git desde <https://git-scm.com/download/win> (siguiente, siguiente… con las opciones por defecto).
2. Abre **Git Bash** (o la terminal de VS Code) y dile a Git quién eres. Usa el **email de tu cuenta de GitHub**:
```
git config --global user.name "Tu Nombre Apellido"
git config --global user.email "el-email-de-tu-cuenta-de-github"
git config --global core.autocrlf true
```
`core.autocrlf true` evita que Windows y Linux se peleen por los saltos de línea.

Comprueba que está bien:
```
git config --global --list
```

## Paso 1. Hacer el fork (en la web)

1. Inicia sesión en GitHub y entra en el repositorio oficial: `https://github.com/raulgonzalezjorge-blip/practica5-anexo1-csharp`
2. Pulsa el botón **Fork**, arriba a la derecha, al lado de **Star**:

![Botón Fork en la página del repositorio](https://raw.githubusercontent.com/raulgonzalezjorge-blip/practica5-sitio-web/develop/wiki/img/guia-fork.png)

3. En la pantalla siguiente deja todo como está y pulsa **Create fork**.
4. Ahora estás en `https://github.com/adriangalvan649/practica5-anexo1-csharp`. Debajo del nombre pone «forked from raulgonzalezjorge-blip/practica5-anexo1-csharp». Ese es tu fork.

## Paso 2. Clonar tu fork en tu ordenador

Clona **tu fork** (no el de Raúl) y entra en la carpeta:
```
cd ~/Documents
git clone https://github.com/adriangalvan649/practica5-anexo1-csharp.git
cd practica5-anexo1-csharp
```
La primera vez que hagas `push`, Windows abrirá una ventana para iniciar sesión en GitHub: acepta.

## Paso 3. Enlazar el repositorio oficial como `upstream`

Así podrás traerte lo último que haya en el oficial:
```
git remote add upstream https://github.com/raulgonzalezjorge-blip/practica5-anexo1-csharp.git
git remote -v
```
Debes ver cuatro líneas: `origin` apunta a tu fork y `upstream` al de Raúl.

## Paso 4. Ponerte al día y crear la rama de tu tarea

1. En el tablero (enlace «Tablero de tareas» de la tabla de arriba) mueve tu tarea de **TO DO** a **DOING**.
2. Trae lo último de `develop` y crea tu rama desde ahí:
```
git switch develop
git pull upstream develop
git switch -c feature/17-manual-uso
```
`develop` ya viene creada al clonar tu fork: no hay que crearla, solo traer lo último de `upstream`.
Comprueba que estás en tu rama: `git branch` tiene que marcar con `*` la línea `feature/17-manual-uso`.

## Paso 5. Hacer el cambio

1. Comprueba que la solución compila y prueba cada menú (tienes que tener el **.NET 10 SDK**):
```
dotnet build UT5.sln
dotnet run --project AnexoI/Array
```
Repite `dotnet run` con `AnexoI/Numero`, `AnexoI/String` y `AnexoI/Decimales`.
2. Haz una captura del menú de cada proyecto (**Windows + Mayús + S**) y guárdalas **dentro de la carpeta que clonaste**, en `docs/img/`, con estos nombres exactos: `menu-array.png`, `menu-numero.png`, `menu-string.png` y `menu-decimales.png`. Crea la carpeta si no existe:
```
mkdir -p docs/img
ls docs/img
```
`ls` tiene que listar los 4 `.png` (ojo con `.png.png`: Windows oculta las extensiones).
3. Crea `MANUAL.md` en la raíz del repositorio (al lado de `UT5.sln`) con: requisitos, cómo compilar, cómo ejecutar cada proyecto, qué hace cada opción de cada menú y su captura. Para que una captura se vea en el manual:
```
![Menú de Array](docs/img/menu-array.png)
```
4. Prepara **solo** el manual y las capturas y haz el commit. Nunca subas `bin/` ni `obj/` (los crea `dotnet build`; el `.gitignore` ya los excluye):
```
git status
git add MANUAL.md docs/img
git commit -m "docs(manual): añade el manual de uso del Anexo I (#17)"
git log --oneline -1
```
- `git status` tiene que enseñar en rojo `MANUAL.md` y `docs/` antes del `git add`, y en verde después.
- Si el commit dice `nothing to commit`, **no se ha guardado nada**: los archivos no están dentro de la carpeta del repositorio. No sigas al paso 6 hasta que `git log --oneline -1` muestre tu commit.

## Paso 6. Subir la rama a tu fork
```
git push -u origin feature/17-manual-uso
```
Si sale `Permission denied` o `403`, estás subiendo a `upstream`: sube a `origin`.

## Paso 7. Abrir el Pull Request

1. Entra en tu fork en GitHub. Arriba saldrá un aviso amarillo con el botón **Compare & pull request**: púlsalo.
2. Comprueba la línea de arriba **antes de crear nada**:
   `base repository: raulgonzalezjorge-blip/practica5-anexo1-csharp` · `base: develop` ← `head repository: adriangalvan649/practica5-anexo1-csharp` · `compare: feature/17-manual-uso`
3. Título: qué hace el cambio. En la descripción escribe `Closes #17` y marca el checklist.
4. Pulsa **Create pull request**.

Así se ven los Pull Request ya fusionados del Anexo I:

![Lista de Pull Request fusionados](https://raw.githubusercontent.com/raulgonzalezjorge-blip/practica5-sitio-web/develop/wiki/img/guia-prs.png)

## Paso 8. Si el jefe pide cambios

Haz los cambios en la **misma rama**, `git add`, `git commit` y `git push`. El Pull Request se actualiza solo; no abras otro.

## Paso 9. Cuando el jefe lo fusione

La tarea se cierra sola gracias a `Closes #17` y pasa a **DONE**. Actualiza tu copia y borra la rama:
```
git switch develop
git pull upstream develop
git push origin develop
git branch -d feature/17-manual-uso
```

## Errores frecuentes

| Mensaje | Qué pasa | Solución |
|---------|----------|----------|
| `rejected ... fetch first` | El remoto tiene cambios que tú no tienes | `git pull upstream develop`, resuelve conflictos y `git push` |
| `CONFLICT (content)` | Tú y otra persona tocasteis las mismas líneas | Abre el archivo, deja el código bueno entre `<<<<<<<`, `=======` y `>>>>>>>`, borra las marcas, `git add` y `git commit` |
| `Permission denied` / `403` | Estás subiendo al repositorio de Raúl | Sube a `origin` (tu fork) |
| `fatal: not a git repository` | No estás dentro de la carpeta del repositorio | `cd practica5-anexo1-csharp` |
| `pathspec '…' did not match any files` | El archivo no está donde dices o se llama distinto | `ls` para ver dónde está y cómo se llama de verdad (ojo con `.png.png`) |
| `nothing to commit, working tree clean` | Git no ve ningún cambio: no se guarda nada | El archivo tiene que estar dentro de la carpeta del repositorio; revisa con `git status` |
| `Please tell me who you are` | Falta configurar tu nombre o email | Repite el paso 0 y vuelve a hacer el `git commit` |
| `has no upstream branch` | Has hecho `git push` sin `-u origin <rama>` | `git push -u origin <tu rama>` |
| `fatal: a branch named 'develop' already exists` | Intentas crear `develop` y ya existe | Usa `git switch develop` (paso 4) |
| He trabajado en `develop` sin rama | — | `git switch -c feature/<nº>-<nombre>`: los cambios se pasan a la rama nueva |

Si te atascas, ejecuta esto en la carpeta del repositorio y pásale a Raúl **todo** lo que salga:
```
pwd
git status
git branch
git remote -v
git log --oneline -3
```
