using Sudoku_Solver.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzleItems
{
    public class Puzzle
    {
        public Puzzle(string puzzleString = null)
        {
            Rows = new List<CellCollection>();
            Columns = new List<CellCollection>();
            Groups = new List<CellCollection>();
            AllCells = new List<Cell>();
            CreateCells(puzzleString);
        }

        private void CreateCells(string puzzleString)
        {
            var parsedString = ParseString(puzzleString);
            for (var i = 1; i <= 9; i++)
            {
                Rows.Add(CreateCellCollection(i));
                Columns.Add(CreateCellCollection(i));
                Groups.Add(CreateCellCollection(i));
            }

            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                {
                    var cell = string.IsNullOrEmpty(puzzleString) ? GetCell(i, j) :
                                                                  GetCell(i, j, parsedString[i, j]);
                    cell.Puzzle = this;
                    Rows[i].Cells.Add(cell);
                    Columns[j].Cells.Add(cell);
                    AllCells.Add(cell);

                    var k = GetGroupIndex(i, j);
                    cell.Location.Group = Groups[k];
                    Groups[k].Cells.Add(cell);
                    
                }
            NonInitialCells = AllCells.Where(cell => !cell.IsInitialCell);
        }
        IEnumerable<Cell> NonInitialCells;
        private int GetGroupIndex(int row, int column)
        {
            if (IsStart(column))  return GetStartColumnRows(row);
            
            if (IsMiddle(column)) return GetMiddleColumnRows(row);            
  
            return GetEndColumnRows(row);
        }

        private  int GetEndColumnRows(int row)
        {
            if (IsStart(row)) return 2;
            if (IsMiddle(row)) return 5;

            return 8;//Is End
        }

        private  int GetMiddleColumnRows(int row)
        {
            if (IsStart(row)) return 1;
            if (IsMiddle(row)) return 4;
            return 7;//Is End
        }

        private  int GetStartColumnRows(int row)
        {
            if (IsStart(row)) return 0;
            if (IsMiddle(row)) return 3;
            return 6;//Is End
        }

        private  bool IsMiddle(int rowOrColumnIndex)
        {
            return rowOrColumnIndex >= 3 && rowOrColumnIndex < 6;
        }

        private  bool IsStart(int rowOrColumnIndex)
        {
            return rowOrColumnIndex < 3;
        }

        private Cell GetCell(int i, int j, int? initialValue = null)
        {
            if(initialValue == null)
                return new Cell(new Location(Rows[i], Columns[j]));

            return new Cell(new Location(Rows[i], Columns[j]), initialValue.GetValueOrDefault());
        }

        public static  int[,] ParseString(string puzzleString)
        {
            var parsedInput = new int[9, 9];
            if (puzzleString == null) return parsedInput;

            var rows = puzzleString.Split('|').Select(p => p.Split(',').Select(i => GetIntOrDefault(i)).ToArray()).ToArray();

            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                    parsedInput[i, j] = rows[i][j];

            return parsedInput;
        }

        private  static int GetIntOrDefault(string i)
        {
            return i.Trim() == "_" ? 0 : int.Parse(i);
        }

        private  CellCollection CreateCellCollection(int i)
        {
            return new CellCollection(i.ToString());
        }

        public List<CellCollection> Rows { get; }
        public List<CellCollection> Columns { get; }
        public List<CellCollection> Groups { get; }
        public List<Cell> AllCells { get; }

        public void InsertGuesses()
        {

            foreach (var cell in NonInitialCells)
            {
                var puzzleStateInvalid = !cell.InsertGuess();
                if (puzzleStateInvalid) break;
            }
        }



        public string GetPuzzleAsString()
        {
            var puzzleAsString = "";
            for(var i = 0; i < 9; i++) 
            {
                for (var j = 0; j < 9; j++)
                {
                    puzzleAsString += Rows[i].Cells[j].Value + ",";
                }
                puzzleAsString += "\n";
            }
            return puzzleAsString;               
                    
        }
        
        public void Print()
        {
            for(var i = 0; i < 9; i++) 
            {
                var lineToPrint = "";

                for (var j = 0; j < 9; j++)
                {
                    lineToPrint += Rows[i].Cells[j].Value + ",";
                }
             
                Console.WriteLine($"{lineToPrint}\n");
            }                    
        }

        public bool IsValid()
        {
            return Rows.All(CellCollectionIsValid) 
                   && Columns.All(CellCollectionIsValid)
                   && Groups.All(CellCollectionIsValid);
        }

        private  bool CellCollectionIsValid(CellCollection collection) => collection.IsValid();

        public int Solve()
        {

            var numberOfPuzzleGuesses = 0;
            while (!IsValid())
            {
                numberOfPuzzleGuesses++;
                ClearGuesses();
                InsertGuesses();     
            }

            return numberOfPuzzleGuesses;            
        }

        private void ClearGuesses()
        {
            foreach (var cell in NonInitialCells)
                cell.ClearGuess();
        }
    }
}
