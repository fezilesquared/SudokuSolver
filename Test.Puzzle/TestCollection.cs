using NSubstitute;
using NUnit.Framework;
using PuzzleItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestBase;

namespace Test.TestPuzzle
{
    class TestCollection
    {
        
        [Test]
        public void IsValid_GivenCollectionWithWithCellsWithValues1to9_ReturnTrue()
        {
      
            var sut = new CellCollection("");
            sut.Cells.Add(TestUtilities.CreateCell(1));
            sut.Cells.Add(TestUtilities.CreateCell(2));
            sut.Cells.Add(TestUtilities.CreateCell(3));
            sut.Cells.Add(TestUtilities.CreateCell(4));
            sut.Cells.Add(TestUtilities.CreateCell(5));
            sut.Cells.Add(TestUtilities.CreateCell(6));
            sut.Cells.Add(TestUtilities.CreateCell(7));
            sut.Cells.Add(TestUtilities.CreateCell(8));
            sut.Cells.Add(TestUtilities.CreateCell(9));
    

            var result = sut.IsValid();
            Assert.IsTrue(result);
        }


        [Test]
        public void IsValid_GivenCollectionWithWithoutAllCellsWithValues1to9_ReturnFalse()
        {

            var sut = new CellCollection("");
            sut.Cells.Add(TestUtilities.CreateCell(1));
            sut.Cells.Add(TestUtilities.CreateCell(2));
            sut.Cells.Add(TestUtilities.CreateCell(3));
            sut.Cells.Add(TestUtilities.CreateCell(4));

            sut.Cells.Add(TestUtilities.CreateCell(6));
            sut.Cells.Add(TestUtilities.CreateCell(7));

            sut.Cells.Add(TestUtilities.CreateCell(9));

            var result = sut.IsValid();
            Assert.IsFalse(result);
        }

        
    }
}
