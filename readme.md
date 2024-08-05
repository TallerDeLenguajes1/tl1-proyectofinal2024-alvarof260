# Conquista y Triunfa

## Descripción

"Conquista y Triunfa" es un juego de rol (RPG) basado en consola donde los jugadores pueden crear personajes, enfrentarse a rivales y mejorar sus habilidades a medida que avanzan en el juego. El juego manteniene un historial de ganadores.

## Características

- **Creación de Personajes**: Los jugadores pueden crear personajes con atributos aleatorios dentro de ciertos rangos.
- **Sistema de Combate**: Los combates se realizan por turnos, y el daño se calcula en función de la destreza, fuerza y nivel del personaje atacante, y la armadura y velocidad del personaje defensor.
- **Mejora de Habilidades**: Los personajes que ganan los combates reciben mejoras en sus estadísticas.
- **Historial de Ganadores**: Se mantiene un registro de los ganadores de las partidas.

## Requisitos del Sistema

- .NET Core SDK 3.1 o superior

## Instalación

1. Clona este repositorio en tu máquina local:

   ```bash
   git clone https://github.com/tu-usuario/tu-repositorio.git
   ```

2. Navega al directorio del proyecto:

   ```bash
   cd tu-repositorio
   ```

3. Restaura los paquetes NuGet necesarios:

   ```bash
   dotnet restore
   ```

## Ejecución

Para ejecutar el juego, utiliza el siguiente comando:

```bash
dotnet run
```

## Menú Principal

El menú principal permite al usuario elegir entre las siguientes opciones:

- Nueva Partida: Inicia una nueva partida.
- Historial: Muestra el historial de ganadores.
- Salir: Sale del juego.

## Crear Partida

Al iniciar una nueva partida, el usuario debe proporcionar:

- Nombre del personaje
- Apodo del personaje
- Fecha de nacimiento del personaje
- Tipo de personaje (Guerrero, Mago, Arquero, etc.)

El juego luego genera una lista de rivales aleatorios y comienza el combate.

## Historial de Ganadores

El historial de ganadores se guarda en un archivo JSON y se puede consultar desde el menú principal.
