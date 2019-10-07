using NSubstitute;
using NUnit.Framework;
using PuzzleItems;
using System;
using TestBase;

namespace Test.TestPuzzle
{
    public class TestCell
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Constructor_GivenValueAsInput_ShouldSetIsInitialCellToTrue()
        {     

            var result = TestUtilities.CreateCell(3);

            Assert.IsTrue(result.IsInitialCell);
        }
        
        [Test]
        public void Constructor_GivenValueAsInputAs0_ShouldSetIsInitialCellToFalse()
        {     

            var result = TestUtilities.CreateCell(0);

            Assert.IsFalse(result.IsInitialCell);
        }
        
        [Test]
        public void Constructor_GivenNoInput_ShouldSetIsInitialCellToFalse()
        {
            var result = TestUtilities.CreateCell();

            Assert.IsFalse(result.IsInitialCell);
        }

        [Test]
        public void InsertGuess_GivenCellIsInitialCell_ShouldNotChanrageValue()
        {
            var cell = TestUtilities.GetInitialCell();
            Assert.IsTrue(cell.IsInitialCell);
            var expected = cell.Value;

            cell.InsertGuess();
            
            var result = cell.Value;

            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void InsertGuess_GivenCellIsNotTInitialCell_ShouldChangeValue()
        {
            var cell = TestUtilities.GetNonInitialCell();
            Assert.IsFalse(cell.IsInitialCell);
            var expected = cell.Value;

            cell.InsertGuess();
            
            var result = cell.Value;

            Assert.AreNotEqual(expected, result);
        }

        [Test]
        public void InsertGuess_GivenCellIsNotTInitialCell_ShouldChangeValueToAValueGreaterThanZero()
        {
            var cell = TestUtilities.GetNonInitialCell();
            Assert.IsFalse(cell.IsInitialCell);
            var expected = cell.Value;

            cell.InsertGuess();

            var result = cell.Value;

            Assert.IsTrue(result > 0);
        }


        [Test]
        public void InsertGuess_GivenCellIsNotTInitialCell_ShouldChangeValueToAValueLessThanTen()
        {
            var cell = TestUtilities.GetNonInitialCell();
            Assert.IsFalse(cell.IsInitialCell);
            var expected = cell.Value;

            cell.InsertGuess();

            var result = cell.Value;

            Assert.IsTrue(result < 10);
        }


    }
}