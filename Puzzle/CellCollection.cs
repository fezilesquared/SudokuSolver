using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleItems
{
    public class CellCollection
    {
        private readonly IEnumerable<int> RequiredValues = new HashSet<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public CellCollection(string name)
        {
            Name = name;
            Cells = new List<Cell>();
        }
        public string Name { get; }
        public List<Cell> Cells { get; }
 
        public IEnumerable<int> GetCellValues() => Cells.Select(c => c.Value);
        public IEnumerable<int> AvailableCellValues => RequiredValues.Except(GetCellValues());

        public virtual bool IsValid()
        {
            return RequiredValues.Intersect(GetCellValues()).Count() == 9;
        }
    }
}