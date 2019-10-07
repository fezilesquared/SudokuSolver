using System;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleItems
{
    public class Location
    {
        public Location(CellCollection row, CellCollection column)
        {
            Row = row;
            Column = column;
           
        }

        public CellCollection Row { get; set; }
        public CellCollection Column { get; set; }
        public CellCollection Group { get; set; }

        public IEnumerable<int> AvailableValues => Row.AvailableCellValues.Intersect(Column.AvailableCellValues).Intersect(Group.AvailableCellValues); 
        public virtual IEnumerable<int> RandomAvailableValues => AvailableValues.OrderBy(v => new Random().Next());
        public bool IsAt(CellCollection row, CellCollection column)
        {
            return Row.Equals(row) && Column.Equals(column);
        }
    }
}