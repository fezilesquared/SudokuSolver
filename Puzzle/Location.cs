using System;
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

        public bool IsAt(CellCollection row, CellCollection column)
        {
            return Row.Equals(row) && Column.Equals(column);
        }
    }
}