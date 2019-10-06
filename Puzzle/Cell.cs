
using System;

namespace PuzzleItems
{
    public class Cell
    {
        public Cell(Location location)
        {
            Location = location;
            IsInitialCell = false;
        }

        public Cell(Location location,int value)
        {
            Location = location;
            Value = value;
            IsInitialCell = true;
        }

        public Location Location { get; }

        public CellCollection Column => Location.Column;
        public string ColumnName => Location.Column.Name;
        public CellCollection Row => Location.Row;
        public string RowName => Location.Row.Name;   
        
        public CellCollection Group => Location.Group;
        public string GroupName => Location.Group.Name;
        public int Value { get; private set; }

        public bool IsInitialCell { get; }

        public void InsertGuess()
        {
            if (IsInitialCell) return;

            Value = new Random().Next();
        }
    }
}