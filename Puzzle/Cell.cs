
using System;
using System.Linq;

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
            IsInitialCell = value != 0;
        }

        public Location Location { get; }
        public Puzzle Puzzle { get; set; }
        public CellCollection Column => Location.Column;
        public string ColumnName => Location.Column.Name;
        public CellCollection Row => Location.Row;
        public string RowName => Location.Row.Name;
        public string LocationName => $"Row: {RowName};Column:{ColumnName};Group:{GroupName}";
        public CellCollection Group => Location.Group;
        public string GroupName => Location.Group.Name;
        public int Value { get; private set; }

        public bool IsInitialCell { get; }

        public bool InsertGuess()
        {
            if (IsInitialCell) return true;

            var guess = GetGuess();
            if (guess == -1) return false;

            Value = guess;
            return true;
        }

        private int GetGuess() => GetRandomAvailableValue();
    
        private int GetRandomAvailableValue()
        {
            return (Location?.GetRandomAvailableValue()).GetValueOrDefault();
        }

        internal void ClearGuess()
        {
            if (!IsInitialCell) Value = 0;
        }
    }
}