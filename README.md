# Tile Game Maker
#### Toolkit for pseudo-8-bit tile-based game creation

The goal of this project is to deliver a toolkit for the development of pseudo-8-bit tile-based games. It was heavily inspired by two classic game engines: [ZZT](https://en.wikipedia.org/wiki/ZZT) and [MegaZeux](https://github.com/AliceLR/megazeux), as well as early 8-bit computer systems such as the [ZX Spectrum](https://en.wikipedia.org/wiki/ZX_Spectrum), [MSX](https://en.wikipedia.org/wiki/MSX) and [Atari 800](https://en.wikipedia.org/wiki/Atari_8-bit_family). A more recent game engine called [Bitsy](https://ledoux.itch.io/bitsy) is also a source of inspiration.

This repository contains a Visual Studio solution comprised of two C# projects targeting the .NET Framework 4.6.1 and above:

- **TileGameLib** (TGL for short) is a library project that generates a .NET DLL file, which is used throughout the toolkit and can also be used in any other projects if desired. It provides several building blocks typically found in early tile-based games, as well as an 8-bit graphics emulation system, WinForms components and other utilities.

- **TileGameMaker** is a Windows desktop application project built using the TileGameLib that generates a .NET executable file. It contains a couple of design tools mainly focused on graphics editing and object map creation. It can export map files that can be loaded using the framework provided in TileGameLib.

If you just want to use the toolkit and don't need or don't care about the source code you can find the precompiled TileGameLib.dll and TileGameMaker.exe inside the "Binaries" folder.

#### Screenshot:

<img src="/Screenshots/tgm.png?raw=true" />

#### Special thanks to:

- [John Nesky](https://github.com/johnnesky), developer of the great music creation tool [BeepBox](https://beepbox.co/)
