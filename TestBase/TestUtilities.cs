using NSubstitute;
using PuzzleItems;
using System;
using System.Collections.Generic;

namespace TestBase
{
    public static class TestUtilities
    {
        public static int GenerateRandomInt(int min = 0, int max= 1000)
        {
            return (new Random()).Next(min, max);
        }

        public static Location CreateLocation()
        {
            var location = Substitute.For<Location>(Substitute.For<CellCollection>(""), Substitute.For<CellCollection>(""));
            location.RandomAvailableValues.Returns(new List<int> { new Random().Next(1,9)});
            return location;
        }
        public static Cell CreateCell(int initialValue)
        {
            return new Cell(TestUtilities.CreateLocation(), initialValue);
        }
        public static Cell CreateCell()
        {
            return new Cell(TestUtilities.CreateLocation());
        }

        public static Cell GetInitialCell()
        {
            return CreateCell(TestUtilities.GenerateRandomInt());
        }

        public static Cell GetNonInitialCell()
        {
            return CreateCell();
        }

    }
}
