using Base;
using System.Collections.Generic;
using System.Linq;

namespace PuzzleItems
{
    public class Location
    {
        int randomIntegerToOrderBy = Utilities.GenerateRandomInteger();
        public Location(CellCollection row, CellCollection column)
        {
            Row = row;
            Column = column;
           
        }
        public CellCollection Row { get; set; }
        public CellCollection Column { get; set; }
        public CellCollection Group { get; set; }

        public IEnumerable<int> AvailableValues => Row.AvailableCellValues.Intersect(Column.AvailableCellValues)
                                                               .Intersect(Group.AvailableCellValues)
                                                               .ToArray();
        public virtual int GetRandomAvailableValue()
        {
            var numberOfAvailableValues = AvailableValues.Count();

            return CurrentPuzzleInvalid(numberOfAvailableValues) ? GetRandomAvailableValue(numberOfAvailableValues) : -1;
        }

        private int GetRandomAvailableValue(int numberOfAvailableValues)
        {
            return AvailableValues.Skip(GetRandomAvailableValueIndex(numberOfAvailableValues)).First();
        }

        private static bool CurrentPuzzleInvalid(int numberOfAvailableValues)
        {
            return numberOfAvailableValues > 0;
        }

        private static int GetRandomAvailableValueIndex(int numberOfAvailableValues) => Utilities.GenerateRandomInteger(0, numberOfAvailableValues);
        
    }
}