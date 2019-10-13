using PuzzleItems;
using System;
using Base;
namespace Soduku_Solver
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = new Puzzle(Constants.TEST_PUZZLE_1);

            puzzle.Print();

            var numberOfRuns =puzzle.Solve();

            Console.WriteLine("*****************************************");


            puzzle.Print();

            Console.ReadKey();
        }
    }
}
