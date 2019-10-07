using NSubstitute;
using NUnit.Framework;
using PuzzleItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.TestPuzzle
{
    class TestPuzzle
    {
       [Test]
       public void Constructor_ShouldCreateCorrectNumberOfRowsGroupsAndColumnsAndCells()
       {
            var puzzle = new PuzzleItems.Puzzle();

            Assert.AreEqual(9,puzzle.Rows.Count);
            Assert.AreEqual(9,puzzle.Columns.Count);
            Assert.AreEqual(9,puzzle.Groups.Count);
            Assert.AreEqual(81, puzzle.AllCells.Count) ;
       }
        
       [Test]
       public void Constructor_GivenInputStringWithBlanks_ShouldPopulateCellsCorrectly()
       {
            var parsedString = PuzzleItems.Puzzle.ParseString(@$"1,2,3,4,5,6,7,8,9| 
                                                                 1,2,3,4,5,6,7,8,_|
                                                                 1,2,3,4,5,6,7,8,9|
                                                                 1,2,3,4,5,6,7,8,9|
                                                                 1,2,3,4,5,6,7,8,9|
                                                                 1,2,3,4,5,6,7,8,9|
                                                                 1,2,3,4,5,6,7,8,9|
                                                                 1,2,3,7,5,6,4,8,9|
                                                                 1,2,3,4,_,6,7,8,9");

            Assert.AreEqual(7, parsedString[7,3]);
            Assert.AreEqual(4, parsedString[7,6]);
            Assert.AreEqual(0, parsedString[8,4]);
            Assert.AreEqual(0, parsedString[1,8]);           
       }   
        
        [Test]
       public void Constructor_GivenInputString_ShouldPopulateRowsCellsCorrectly()
       {
            var puzzle = new PuzzleItems.Puzzle(@$"1,2,3,4,5,6,7,8,9| 
                                                   1,2,3,4,5,6,7,8,5|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,7,5,6,4,8,9|
                                                   1,2,3,4,9,6,7,8,9");

            Assert.AreEqual(7,puzzle.Rows[7].Cells[3].Value);
            Assert.AreEqual(4,puzzle.Rows[7].Cells[6].Value);
            Assert.AreEqual(9,puzzle.Rows[8].Cells[4].Value);
            Assert.AreEqual(5,puzzle.Rows[1].Cells[8].Value);           
       }    
        
       [Test]
       public void Constructor_GivenInputString_ShouldPopulateColumnCellsCorrectly()
       {
            var puzzle = new PuzzleItems.Puzzle(@$"1,2,3,4,5,6,7,8,9| 
                                                   1,2,3,4,5,6,7,8,5|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,7,5,6,4,8,9|
                                                   1,2,3,4,9,6,7,8,9");

            Assert.AreEqual(7,puzzle.Columns[3].Cells[7].Value);
            Assert.AreEqual(4,puzzle.Columns[6].Cells[7].Value);
            Assert.AreEqual(9,puzzle.Columns[4].Cells[8].Value);
            Assert.AreEqual(5,puzzle.Columns[8].Cells[1].Value);           
       }     
        
       [Test]
       public void Constructor_GivenInputString_ShouldPopulateGroupCellsCorrectly()
       {
            var puzzle = new PuzzleItems.Puzzle(@$"1,2,3,4,5,6,7,8,9| 
                                                   1,2,3,4,5,6,7,8,5|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,4,5,6,7,8,9|
                                                   1,2,3,7,5,6,4,8,9|
                                                   1,2,3,4,9,6,7,8,9");

            Assert.AreEqual(5,puzzle.Groups[2].Cells[5].Value);
            Assert.AreEqual(4,puzzle.Groups[8].Cells[3].Value);
            Assert.AreEqual(7,puzzle.Groups[7].Cells[3].Value);
            Assert.AreEqual(9,puzzle.Groups[7].Cells[7].Value);           
       }

        [Test]
        public void InsertGuesses_GivenPuzzleWithBlanks_ShouldInsertValuesInBlankCells()
        {
            var sut = new PuzzleItems.Puzzle(@$"1,2,3,4,5,6,7,8,9| 
                                                1,2,3,4,5,6,7,8,_|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,_,5,6,_,8,9|
                                                1,2,3,4,_,6,7,8,9");

            Assert.AreEqual(0, sut.Columns[3].Cells[7].Value);
            Assert.AreEqual(0, sut.Columns[6].Cells[7].Value);
            Assert.AreEqual(0, sut.Columns[4].Cells[8].Value);
            Assert.AreEqual(0, sut.Columns[8].Cells[1].Value);
            
            sut.InsertGuesses();

            Assert.AreNotEqual(0, sut.Columns[3].Cells[7].Value);
            Assert.AreNotEqual(0, sut.Columns[6].Cells[7].Value);
            Assert.AreNotEqual(0, sut.Columns[4].Cells[8].Value);
            Assert.AreNotEqual(0, sut.Columns[8].Cells[1].Value);

        }

        [Test]
        public void InsertGuesses_GivenPuzzleWithBlanks_ShouldHaveIsInitialValueFalseForBlankCells()
        {
            var sut = new PuzzleItems.Puzzle(@$"1,2,3,4,5,6,7,8,9| 
                                                1,2,3,4,5,6,7,8,_|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,4,5,6,7,8,9|
                                                1,2,3,_,5,6,_,8,9|
                                                1,2,3,4,_,6,7,8,9");

            Assert.IsFalse(sut.Columns[3].Cells[7].IsInitialCell);
            Assert.IsFalse(sut.Columns[6].Cells[7].IsInitialCell);
            Assert.IsFalse(sut.Columns[4].Cells[8].IsInitialCell);
            Assert.IsFalse(sut.Columns[8].Cells[1].IsInitialCell);
        }

        [Test]
        public void IsValid_GivenRowsColumnsAndGroupsWithAllAreValid_ShouldReturnValid()
        {
            var sut = new Puzzle();

            sut.Rows[0] = CreateValidCellCollection();
            sut.Rows[1] = CreateValidCellCollection();
            sut.Rows[2] = CreateValidCellCollection();
            sut.Rows[3] = CreateValidCellCollection();
            sut.Rows[4] = CreateValidCellCollection();
            sut.Rows[5] = CreateValidCellCollection();
            sut.Rows[6] = CreateValidCellCollection();
            sut.Rows[7] = CreateValidCellCollection();
            sut.Rows[8] = CreateValidCellCollection();

            sut.Columns[0] = CreateValidCellCollection();
            sut.Columns[1] = CreateValidCellCollection();
            sut.Columns[2] = CreateValidCellCollection();
            sut.Columns[3] = CreateValidCellCollection();
            sut.Columns[4] = CreateValidCellCollection();
            sut.Columns[5] = CreateValidCellCollection();
            sut.Columns[6] = CreateValidCellCollection();
            sut.Columns[7] = CreateValidCellCollection();
            sut.Columns[8] = CreateValidCellCollection();

            sut.Groups[0] = CreateValidCellCollection();
            sut.Groups[1] = CreateValidCellCollection();
            sut.Groups[2] = CreateValidCellCollection();
            sut.Groups[3] = CreateValidCellCollection();
            sut.Groups[4] = CreateValidCellCollection();
            sut.Groups[5] = CreateValidCellCollection();
            sut.Groups[6] = CreateValidCellCollection();
            sut.Groups[7] = CreateValidCellCollection();
            sut.Groups[8] = CreateValidCellCollection();

            Assert.IsTrue(sut.IsValid());
        }

        [Test]
        public void IsValid_GivenPuzzleWithAnInvalidRow_ShouldReturnValid()
        {
            var sut = new Puzzle();

            sut.Rows[0] = CreateInValidCellCollection();
            sut.Rows[1] = CreateValidCellCollection();
            sut.Rows[2] = CreateValidCellCollection();
            sut.Rows[3] = CreateValidCellCollection();
            sut.Rows[4] = CreateValidCellCollection();
            sut.Rows[5] = CreateValidCellCollection();
            sut.Rows[6] = CreateValidCellCollection();
            sut.Rows[7] = CreateValidCellCollection();
            sut.Rows[8] = CreateValidCellCollection();

            sut.Columns[0] = CreateValidCellCollection();
            sut.Columns[1] = CreateValidCellCollection();
            sut.Columns[2] = CreateValidCellCollection();
            sut.Columns[3] = CreateValidCellCollection();
            sut.Columns[4] = CreateValidCellCollection();
            sut.Columns[5] = CreateValidCellCollection();
            sut.Columns[6] = CreateValidCellCollection();
            sut.Columns[7] = CreateValidCellCollection();
            sut.Columns[8] = CreateValidCellCollection();

            sut.Groups[0] = CreateValidCellCollection();
            sut.Groups[1] = CreateValidCellCollection();
            sut.Groups[2] = CreateValidCellCollection();
            sut.Groups[3] = CreateValidCellCollection();
            sut.Groups[4] = CreateValidCellCollection();
            sut.Groups[5] = CreateValidCellCollection();
            sut.Groups[6] = CreateValidCellCollection();
            sut.Groups[7] = CreateValidCellCollection();
            sut.Groups[8] = CreateValidCellCollection();

            Assert.IsTrue(sut.IsValid());
        }

        private CellCollection CreateInValidCellCollection()
        {
            var cellCollection = Substitute.For<CellCollection>("");
            cellCollection.IsValid().Returns(false);
            return cellCollection;
        }

        private static CellCollection CreateValidCellCollection()
        {
            var cellCollection = Substitute.For<CellCollection>("");
            cellCollection.IsValid().Returns(true);
            return cellCollection;
        }
    }
}
