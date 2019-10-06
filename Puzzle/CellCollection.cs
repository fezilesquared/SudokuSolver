using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleItems
{
    public class CellCollection
    {
        private readonly int[] RequiredValues = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public CellCollection(string name)
        {
            Name = name;
            Cells = new List<Cell>();
        }
        public string Name { get; }
        public List<Cell> Cells { get; }
 
        public List<int> GetCellValues() => Cells.Select(c => c.Value).ToList();

        public bool IsValid()
        {
            return RequiredValues.ToList().All(v => GetCellValues().Contains(v));
        }
    }
}