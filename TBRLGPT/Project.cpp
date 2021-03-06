/*=============================================================================

	 TBRLGPT
	 Tile-Based Retro-Looking Game Project Toolkit

	 2018-2021 Developed by Fernando Aires Castello

=============================================================================*/

#include "Project.h"
#include "Palette.h"
#include "Charset.h"
#include "Char.h"
#include "Map.h"
#include "ObjectLayer.h"
#include "File.h"
#include "Util.h"
#include "StringUtils.h"

#define NEXT_STRING data[ptr++]
#define NEXT_NUMBER String::ToInt(data[ptr++])

namespace TBRLGPT
{
	Project::Project()
	{
		Palette = new class Palette();
		Charset = new class Charset();
	}

	Project::~Project()
	{
		DeleteContents();
	}

	void Project::DeleteContents()
	{
		delete Palette;
		delete Charset;

		for (int i = 0; i < Maps.size(); i++) {
			delete Maps[i];
		}

		Maps.clear();
	}

	void Project::AddMap(Map* map)
	{
		Maps.push_back(map);
		map->SetProject(this);
	}

	bool Project::Load(std::string filename)
	{
		DeleteContents();

		std::string text = File::ReadText(filename);
		if (text.empty())
			return false;

		std::vector<std::string> data = String::Split(text, '�');
		int ptr = 0;

		// === FILE HEADER ===
		std::string header = NEXT_STRING;
		if (header != "TGLPRO01") {
			return false;
		}

		// === PROJECT METADATA ===
		Name = NEXT_STRING;
		CreationDate = NEXT_STRING;

		// === PALETTE ===
		int paletteSize = NEXT_NUMBER;
		Palette = new class Palette();
		Palette->Clear();
		for (int i = 0; i < paletteSize; i++) {
			int r = NEXT_NUMBER;
			int g = NEXT_NUMBER;
			int b = NEXT_NUMBER;
			Palette->Set(i, r, g, b);
		}

		// === TILESET ===
		int tilesetSize = NEXT_NUMBER;
		Charset = new class Charset();
		Charset->Clear();
		for (int i = 0; i < tilesetSize; i++) {
			byte* ch = Charset->Get(i);
			for (int bit = 0; bit < Char::Width; bit++)
				ch[bit] = NEXT_NUMBER;
		}

		// === MAPS ===
		int mapCount = NEXT_NUMBER;
		for (int mi = 0; mi < mapCount; mi++) {
			std::string id = NEXT_STRING;
			std::string name = NEXT_STRING;
			int width = NEXT_NUMBER;
			int height = NEXT_NUMBER;
			int backColor = NEXT_NUMBER;
			int layerCount = NEXT_NUMBER;

			Map* map = new Map(this, name, width, height, layerCount);
			map->SetId(id);
			map->SetBackColor(backColor);

			// === LAYERS ===
			for (int i = 0; i < layerCount; i++) {
				ObjectLayer* layer = map->GetLayer(i);
				for (int y = 0; y < layer->GetHeight(); y++) {
					for (int x = 0; x < layer->GetWidth(); x++) {
						// === OBJECT ===
						Object* o = layer->GetObject(x, y);
						int exists = NEXT_NUMBER;
						if (exists == 1) {
							o->SetVoid(false);
							int visible = NEXT_NUMBER;
							o->SetVisible(visible <= 0 ? false : true);
							ObjectAnim& anim = o->GetAnimation();
							anim.Clear();
							int animSize = NEXT_NUMBER;
							for (int ai = 0; ai < animSize; ai++) {
								int ix = NEXT_NUMBER;
								int fgc = NEXT_NUMBER;
								int bgc = NEXT_NUMBER;
								anim.AddFrame(ObjectChar(ix, fgc, bgc));
							}
							std::string objectData = "";
							int propCount = NEXT_NUMBER;
							for (int propIndex = 0; propIndex < propCount; propIndex++) {
								std::string key = NEXT_STRING;
								std::string value = NEXT_STRING;
								o->SetProperty(key, value);
							}
						}
						else {
							o->SetVoid(true);
						}
					}
				}
			}

			// === OUT-OF-BOUNDS OBJECT ===
			int hasOobc = NEXT_NUMBER;
			if (hasOobc == 1) {
				Object* oob = map->GetOutOfBoundsObject();
				ObjectAnim& anim = oob->GetAnimation();
				anim.Clear();
				int animSize = NEXT_NUMBER;
				for (int i = 0; i < animSize; i++) {
					int ix = NEXT_NUMBER;
					int fgc = NEXT_NUMBER;
					int bgc = NEXT_NUMBER;
					anim.AddFrame(ObjectChar(ix, fgc, bgc));
				}
			}

			Maps.push_back(map);
		}

		return true;
	}

	std::vector<Map*>& Project::GetMaps()
	{
		return Maps;
	}

	Map* Project::FindMapById(std::string id)
	{
		for (int i = 0; i < Maps.size(); i++)
		{
			Map* map = Maps[i];
			if (map->GetId() == id)
				return map;
		}

		return NULL;
	}

	Map* Project::FindMapByName(std::string name)
	{
		for (int i = 0; i < Maps.size(); i++)
		{
			Map* map = Maps[i];
			if (map->GetName() == name)
				return map;
		}

		return NULL;
	}

	Palette* Project::GetPalette()
	{
		return Palette;
	}

	Charset* Project::GetCharset()
	{
		return Charset;
	}

	void Project::SetPalette(class Palette* palette)
	{
		Palette = palette;
	}

	void Project::SetCharset(class Charset* charset)
	{
		Charset = charset;
	}
}
