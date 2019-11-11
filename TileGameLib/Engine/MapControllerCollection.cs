﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Util;

namespace TileGameLib.Engine
{
    public class MapControllerCollection
    {
        private readonly Dictionary<ObjectMap, MapController> Controllers;

        public MapControllerCollection()
        {
            Controllers = new Dictionary<ObjectMap, MapController>();
        }

        public MapController Get(string mapName)
        {
            foreach (var mapAndController in Controllers)
            {
                if (mapAndController.Key.Name.Equals(mapName))
                    return mapAndController.Value;
            }

            return null;
        }

        public string AddController(string mapFile, MapController controller)
        {
            controller.Map = MapFile.Load(mapFile);
            controller.MapFile = mapFile;
            Controllers.Add(controller.Map, controller);

            return controller.Map.Name;
        }
    }
}
