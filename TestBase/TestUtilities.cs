using NSubstitute;
using PuzzleItems;
using System;

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
            return Substitute.For<Location>(Substitute.For<CellCollection>(""), Substitute.For<CellCollection>(""));
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
