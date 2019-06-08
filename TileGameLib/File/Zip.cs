﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using TileGameLib.Exception;

namespace TileGameLib.File
{
    public static class Zip
    {
        public static void Overwrite(string path)
        {
            Create(path, true);
        }

        public static void Create(string path)
        {
            Create(path, false);
        }

        private static void Create(string path, bool overwrite)
        {
            const string emptyFileName = "EMPTY";

            if (!overwrite && System.IO.File.Exists(path))
                throw new FileException($"File {path} already exists");

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    archive.CreateEntry(emptyFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }

            Delete(path, emptyFileName);
        }

        public static void Save(string zipPath, string entryFilename, MemoryFile file)
        {
            using (var zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    var zipEntry = archive.CreateEntry(entryFilename);
                    using (var writer = new BinaryWriter(zipEntry.Open()))
                        writer.Write(file.ToByteArray());
                }
            }
        }

        public static MemoryFile Load(string zipPath, string entryFilename)
        {
            byte[] data;

            using (var zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    var zipEntry = archive.GetEntry(entryFilename);
                    using (var reader = new BinaryReader(zipEntry.Open()))
                        data = reader.ReadBytes((int)zipEntry.Length);
                }
            }

            return new MemoryFile(data);
        }

        public static void Delete(string zipPath)
        {
            System.IO.File.Delete(zipPath);
        }

        public static void Delete(string zipPath, string entryFilename)
        {
            using (var zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach (var entry in archive.Entries)
                    {
                        if (entry.Name.Equals(entryFilename))
                        {
                            entry.Delete();
                            break;
                        }
                    }
                }
            }
        }

        public static List<string> List(string zipPath)
        {
            List<string> list = new List<string>();

            using (var zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (var archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                {
                    foreach (var entry in archive.Entries)
                        list.Add(entry.Name);
                }
            }

            return list;
        }
    }
}