using NSubstitute;
using PuzzleItems;
using System;
using System.Collections.Generic;
using Base;

namespace TestBase
{
    public static class TestUtilities
    {
        public static int GenerateRandomInt(int min = 0, int max= 1000)
        {
            return Utilities.GenerateRandomInteger(min, max);
        }

        public static Location CreateLocation()
        {
            var location = Substitute.For<Location>(Substitute.For<CellCollection>(""), Substitute.For<CellCollection>(""));
            location.GetRandomAvailableValue().Returns(1);
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
