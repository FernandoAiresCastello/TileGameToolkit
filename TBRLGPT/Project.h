/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2020 Developed by Fernando Aires Castello

=============================================================================*/

#pragma once

#include <string>
#include <vector>
#include "Global.h"

namespace TBRLGPT
{
	class Map;
	class Palette;
	class Charset;

	class TBRLGPT_API Project
	{
	public:
		Project();
		~Project();

		bool Load(std::string filename);
		std::vector<Map*>& GetMaps();
		class Palette* GetPalette();
		class Charset* GetCharset();
		std::string GetProgram();
		int GetEngineWindowCols();
		int GetEngineWindowRows();
		int GetEngineWindowMagnification();
		int GetEngineWindowWidth();
		int GetEngineWindowHeight();

	private:
		std::string Path;
		std::string Name;
		std::string CreationDate;
		class Palette* Palette;
		class Charset* Charset;
		std::vector<Map*> Maps;
		std::string Program;
		int EngineWindowCols;
		int EngineWindowRows;
		int EngineWindowMagnification;
		int EngineWindowWidth;
		int EngineWindowHeight;
	};
}