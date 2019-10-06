using NUnit.Framework;
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
            Assert.AreEqual(4,parsedString[7,6]);
            Assert.AreEqual(0,parsedString[8,4]);
            Assert.AreEqual(0,parsedString[1,8]);
           
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


    }
}
