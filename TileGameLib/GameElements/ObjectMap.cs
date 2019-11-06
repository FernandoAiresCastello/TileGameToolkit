﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.GameElements
{
    public class ObjectMap
    {
        public string Name { set; get; }
        public List<ObjectLayer> Layers { set; get; } = new List<ObjectLayer>();
        public Tileset Tileset { get; set; } = new Tileset();
        public Palette Palette { get; set; } = new Palette();
        public int BackColor { set; get; }
        public string MusicFile { set; get; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int ImageWidth => Width * TilePixels.RowLength;
        public int ImageHeight => Height * TilePixels.RowCount;
        public bool HasMusic => !string.IsNullOrWhiteSpace(MusicFile);

        public static string DefaultName => RandomID.Generate(8);

        public ObjectMap(int width, int height) : this(DefaultName, width, height, 0)
        {
            BackColor = Palette.White;
        }

        public ObjectMap(string name, int width, int height, int backColor)
        {
            Name = name;
            Width = width;
            Height = height;
            BackColor = backColor;

            AddLayer();
        }

        public ObjectMap(ObjectMap other)
        {
            SetEqual(other);
        }

        public void SetEqual(ObjectMap other)
        {
            Name = other.Name;
            Width = other.Width;
            Height = other.Height;
            BackColor = other.BackColor;
            MusicFile = other.MusicFile;
            Tileset.SetEqual(other.Tileset);
            Palette.SetEqual(other.Palette);
            Layers.Clear();

            foreach (ObjectLayer layer in other.Layers)
            {
                ObjectLayer newLayer = new ObjectLayer(Width, Height);
                newLayer.SetEqual(layer);
                Layers.Add(newLayer);
            }
        }

        public void Resize(int width, int height)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Resize(width, height);

            Width = width;
            Height = height;
        }

        public void AddLayer()
        {
            Layers.Add(new ObjectLayer(Width, Height));
        }

        public void RemoveLayer(int layer)
        {
            Layers.RemoveAt(layer);
        }

        public void AddLayers(int count)
        {
            for (int i = 0; i < count; i++)
                AddLayer();
        }

        public void Clear()
        {
            foreach (ObjectLayer layer in Layers)
                layer.Clear();
        }

        public void Clear(int layer)
        {
            Layers[layer].Clear();
        }

        public void Fill(GameObject o)
        {
            foreach (ObjectLayer layer in Layers)
                layer.Fill(o);
        }

        public void Fill(GameObject o, int layer)
        {
            Layers[layer].Fill(o);
        }

        public void SetObject(GameObject o, ObjectPosition pos)
        {
            Layers[pos.Layer].SetObject(o, pos.X, pos.Y);
        }

        public void CreateNewObject(ObjectPosition pos)
        {
            SetObject(new GameObject(), pos);
        }

        public void DuplicateObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            ObjectCell srcCell = GetCell(srcPos);
            ObjectCell destCell = GetCell(destPos);

            GameObject o = srcCell.GetObject();
            if (o != null)
                destCell.SetObjectEqual(o);
        }

        public void SwapObjects(ObjectPosition pos1, ObjectPosition pos2)
        {
            ObjectCell cell1 = GetCell(pos1);
            ObjectCell cell2 = GetCell(pos2);

            GameObject o1 = cell1.GetObject();
            GameObject o2 = cell2.GetObject();

            if (o1 != null && o2 != null)
            {
                GameObject temp = cell1.GetObject();
                cell1.SetObjectEqual(o2);
                cell2.SetObjectEqual(temp);
            }
        }

        public void DeleteObject(ObjectPosition pos)
        {
            ObjectCell srcCell = GetCell(pos);
            srcCell.DeleteObject();
        }

        public ObjectCell GetCell(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetCell(pos.X, pos.Y);
        }

        public List<ObjectCell> GetCells(List<ObjectPosition> positions)
        {
            List<ObjectCell> cells = new List<ObjectCell>();

            foreach (ObjectPosition pos in positions)
                cells.Add(GetCell(pos));

            return cells;
        }

        public GameObject GetObject(ObjectPosition pos)
        {
            return Layers[pos.Layer].GetObject(pos.X, pos.Y);
        }

        public List<GameObject> GetObjects(List<ObjectPosition> positions)
        {
            List<GameObject> objects = new List<GameObject>();

            foreach (ObjectPosition pos in positions)
                objects.Add(GetObject(pos));

            return objects;
        }

        public GameObject GetObjectUnder(ObjectPosition pos)
        {
            if (pos.Layer <= 0)
                return null;

            ObjectCell cellUnder = GetCell(ObjectPosition.Under(pos));

            return cellUnder.IsEmpty ? null : cellUnder.GetObject();
        }

        public GameObject GetObjectAbove(ObjectPosition pos)
        {
            if (pos.Layer >= Layers.Count - 1)
                return null;

            ObjectCell cellAbove = GetCell(ObjectPosition.Above(pos));

            return cellAbove.IsEmpty ? null : cellAbove.GetObject();
        }

        public GameObject GetObjectAtDistance(ObjectPosition pos, int dx, int dy)
        {
            ObjectCell cell = GetCell(ObjectPosition.AtDistance(pos, dx, dy));

            return cell.IsEmpty ? null : cell.GetObject();
        }

        public ObjectPosition FindObjectById(string id)
        {
            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Id.Equals(id))
                            return new ObjectPosition(layerIndex, x, y);
                    }
                }
            }

            return null;
        }

        public ObjectPosition FindObjectByTag(string tag)
        {
            List<ObjectPosition> objects = FindObjectsByTag(tag);

            if (objects.Count > 1)
                throw new TileGameLibException("Multiple objects found with tag " + tag);
            if (objects.Count == 1)
                return objects[0];

            return null;
        }

        public List<ObjectPosition> FindObjectsByTag(string tag)
        {
            List<ObjectPosition> objects = new List<ObjectPosition>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<ObjectPosition> layerPositions = new List<ObjectPosition>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.HasTag && o.Tag.Equals(tag))
                            layerPositions.Add(new ObjectPosition(layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public List<ObjectPosition> FindObjectsByProperty(string property)
        {
            List<ObjectPosition> objects = new List<ObjectPosition>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<ObjectPosition> layerPositions = new List<ObjectPosition>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Properties.Has(property))
                            layerPositions.Add(new ObjectPosition(layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public List<ObjectPosition> FindObjectsByPropertyValue(string property, object value)
        {
            List<ObjectPosition> objects = new List<ObjectPosition>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<ObjectPosition> layerPositions = new List<ObjectPosition>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Properties.HasValue(property, value))
                            layerPositions.Add(new ObjectPosition(layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public List<ObjectPosition> FindObjectsEqual(GameObject other)
        {
            List<ObjectPosition> objects = new List<ObjectPosition>();

            for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
            {
                ObjectLayer layer = Layers[layerIndex];
                List<ObjectPosition> layerPositions = new List<ObjectPosition>();

                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        if (o != null && o.Equals(other))
                            layerPositions.Add(new ObjectPosition(layerIndex, x, y));
                    }
                }

                objects.AddRange(layerPositions);
            }

            return objects;
        }

        public void ReplaceObjects(GameObject original, GameObject replacement)
        {
            List<ObjectPosition> originalPositions = FindObjectsEqual(original);

            foreach (ObjectPosition originalPos in originalPositions)
                GetObject(originalPos).SetEqual(replacement);
        }

        public void MoveObject(ObjectPosition srcPos, ObjectPosition destPos)
        {
            DuplicateObject(srcPos, destPos);
            DeleteObject(srcPos);
        }

        public GameObject MoveObjectGetPrevious(ObjectPosition srcPos, ObjectPosition destPos)
        {
            GameObject previousObject = null;
            ObjectCell destCell = GetCell(destPos);
            if (!destCell.IsEmpty)
                previousObject = destCell.GetObject();

            MoveObject(srcPos, destPos);

            return previousObject;
        }

        public bool MoveObjectIfDestinationIsEmpty(ObjectPosition srcPos, ObjectPosition destPos)
        {
            ObjectCell destCell = GetCell(destPos);

            if (destCell.IsEmpty)
            {
                MoveObject(srcPos, destPos);
                return true;
            }

            return false;
        }

        public bool MoveObjectIfDestinationHasTag(ObjectPosition srcPos, ObjectPosition destPos, string tag)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.GetObject();

                if (o.HasTag && o.Tag.Equals(tag))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }

        public bool MoveObjectIfDestinationHasProperty(ObjectPosition srcPos, ObjectPosition destPos, string property)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.GetObject();

                if (o.Properties.Has(property))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }

        public bool MoveObjectIfDestinationHasPropertyValue(ObjectPosition srcPos, ObjectPosition destPos, string property, object value)
        {
            ObjectCell destCell = GetCell(destPos);

            if (!destCell.IsEmpty)
            {
                GameObject o = destCell.GetObject();

                if (o.Properties.HasValue(property, value))
                {
                    MoveObject(srcPos, destPos);
                    return true;
                }
            }

            return false;
        }

        public ObjectCollision FindCollisionBetweenIds(string idObject1, string idObject2)
        {
            ObjectPosition posObject1 = FindObjectById(idObject1);
            ObjectPosition posObject2 = FindObjectById(idObject2);

            if (posObject1.X == posObject2.X && posObject1.Y == posObject2.Y)
                return new ObjectCollision(GetObject(posObject1), GetObject(posObject2));

            return null;
        }

        public ObjectCollision FindCollisionBetweenObjects(GameObject object1, GameObject object2)
        {
            return FindCollisionBetweenIds(object1.Id, object2.Id);
        }

        public List<ObjectCollision> FindCollisionsBetweenIdAndTags(string id, string tag)
        {
            ObjectPosition objectPos = FindObjectById(id);
            List<ObjectPosition> taggedObjectsPos = FindObjectsByTag(tag);
            HashSet<ObjectCollision> collisions = new HashSet<ObjectCollision>();

            foreach (ObjectPosition taggedObjectPos in taggedObjectsPos)
            {
                if (objectPos.X == taggedObjectPos.X && objectPos.Y == taggedObjectPos.Y)
                    collisions.Add(new ObjectCollision(GetObject(objectPos), GetObject(taggedObjectPos)));
            }

            return collisions.ToList();
        }

        public List<ObjectCollision> FindCollisionsBetweenTags(string tag1, string tag2)
        {
            List<ObjectPosition> taggedObjectsPos1 = FindObjectsByTag(tag1);
            List<ObjectPosition> taggedObjectsPos2 = FindObjectsByTag(tag2);
            HashSet<ObjectCollision> collisions = new HashSet<ObjectCollision>();

            foreach (ObjectPosition pos1 in taggedObjectsPos1)
            {
                foreach (ObjectPosition pos2 in taggedObjectsPos2)
                {
                    if (pos1.X == pos2.X && pos1.Y == pos2.Y)
                        collisions.Add(new ObjectCollision(GetObject(pos1), GetObject(pos2)));
                }
            }

            return collisions.ToList();
        }
    }
}
