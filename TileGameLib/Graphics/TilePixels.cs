﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Util;

namespace TileGameLib.Graphics
{
    public class TilePixels
    {
        public static readonly int RowCount = 8;
        public static readonly int RowLength = 8;
        public static readonly int PixelCount = RowCount * RowLength;

        public byte[] PixelRows { set; get; } = new byte[RowCount];

        public static TilePixels Blank => new TilePixels();

        public TilePixels()
        {
            Clear();
        }

        public TilePixels(byte row1, byte row2, byte row3, byte row4,
            byte row5, byte row6, byte row7, byte row8)
        {
            Set(row1, row2, row3, row4, row5, row6, row7, row8);
        }

        public TilePixels(TilePixels other)
        {
            SetEqual(other);
        }

        public void Clear()
        {
            for (int i = 0; i < RowCount; i++)
                PixelRows[i] = 0;
        }

        public void Set(byte row1, byte row2, byte row3, byte row4,
            byte row5, byte row6, byte row7, byte row8)
        {
            PixelRows[0] = row1;
            PixelRows[1] = row2;
            PixelRows[2] = row3;
            PixelRows[3] = row4;
            PixelRows[4] = row5;
            PixelRows[5] = row6;
            PixelRows[6] = row7;
            PixelRows[7] = row8;
        }

        public void Invert()
        {
            for (int i = 0; i < PixelRows.Length; i++)
                PixelRows[i] = PixelRows[i].InvertBits();
        }

        public void FlipHorizontal()
        {
            for (int i = 0; i < PixelRows.Length; i++)
                PixelRows[i] = PixelRows[i].ReverseBits();
        }

        public void FlipVertical()
        {
            TilePixels flipped = new TilePixels();
            int flippedRowIx = 0;
            for (int i = PixelRows.Length - 1; i >= 0; i--)
                flipped.PixelRows[flippedRowIx++] = PixelRows[i];

            SetEqual(flipped);
        }

        public void RotateRight()
        {
            for (int i = 0; i < PixelRows.Length; i++)
                PixelRows[i] = PixelRows[i].RotateRight();
        }

        public void RotateLeft()
        {
            for (int i = 0; i < PixelRows.Length; i++)
                PixelRows[i] = PixelRows[i].RotateLeft();
        }

        public void RotateUp()
        {
            byte firstRow = PixelRows[0];

            for (int i = 1; i < RowCount; i++)
                PixelRows[i - 1] = PixelRows[i];

            PixelRows[RowCount - 1] = firstRow;
        }

        public void RotateDown()
        {
            byte lastRow = PixelRows[RowCount - 1];

            for (int i = RowCount - 2; i >= 0; i--)
                PixelRows[i + 1] = PixelRows[i];

            PixelRows[0] = lastRow;
        }

        public void SetEqual(TilePixels pixels)
        {
            for (int i = 0; i < PixelRows.Length; i++)
                PixelRows[i] = pixels.PixelRows[i];
        }

        public string ToBinaryString()
        {
            StringBuilder str = new StringBuilder();
            foreach (byte row in PixelRows)
                str.Append(row.ToBinaryString());
                
            return str.ToString();
        }

        public string ToCsvString()
        {
            StringBuilder str = new StringBuilder();
            foreach (byte row in PixelRows)
                str.Append(row.ToString() + ",");

            string csv = str.ToString();
            return csv.Substring(0, csv.Length - 1);
        }

        public string ToHexCsvString()
        {
            StringBuilder str = new StringBuilder();
            foreach (byte row in PixelRows)
                str.Append(row.ToString("X2") + ",");

            string csv = str.ToString();
            return csv.Substring(0, csv.Length - 1);
        }

        public override int GetHashCode()
        {
            return PixelRows.GetHashCode();
        }
    }
}
