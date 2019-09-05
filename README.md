# Tile Game Maker
#### Library and tools for tile-based game creation

The goal of this project is to deliver a toolkit for the development of pseudo-8-bit tile-based games. It was heavily inspired by two classic game engines: [ZZT](https://museumofzzt.com/) and [MegaZeux](https://vault.digitalmzx.net/index.php), as well as early 8-bit computer systems such as the [ZX Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum), [MSX](https://en.wikipedia.org/wiki/MSX) and [Atari 800](https://en.wikipedia.org/wiki/Atari_8-bit_family). A more recent game engine called [Bitsy](https://ledoux.itch.io/bitsy) is also a source of inspiration.

This repository contains a Visual Studio solution comprised of three C# projects targeting the .NET Framework 4.6.1 and above:

- **TileGameLib** (TGL for short) is a library project that generates a .NET DLL file, which is used throughout the toolkit and can also be used in any other projects if desired.

- **TileGameMaker** is a Windows desktop application project built using the TileGameLib that generates a .NET executable file. It contains a couple of design tools mainly focused on graphics editing and object map creation. It can export map files that can be loaded by scripts in the TileGameEngine.

- **TileGameEngine** is another Windows desktop application built using the TileGameLib which contains the implementation of an engine that can run and debug scripts containing game logic. Its core consists of an interpreter for TGML (TileGameMaker Language), which is a low-level, stack-based scripting language. This serves as a standalone application for distributing TileGameMaker games.

#### Screenshots:

*Tile Game Maker main window*

<img src="/Screenshots/tile_game_maker.png?raw=true" />

*Tile Game Engine start window*

<img src="/Screenshots/engine_start.png?raw=true" />

*Tile Game Engine debugger*

<img src="/Screenshots/engine_debugger.png?raw=true" />
