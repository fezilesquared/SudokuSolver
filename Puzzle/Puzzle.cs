using System;
using System.Collections.Generic;
using System.Linq;

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
                    Rows[i].Cells.Add(cell);
                    Columns[j].Cells.Add(cell);
                    AllCells.Add(cell);

                    var k = GetGroupIndex(i, j);
                    cell.Location.Group = Groups[k];
                    Groups[k].Cells.Add(cell);
                    
                }
        }
        private int GetGroupIndex(int row, int column)
        {
            if (IsStart(column))
            {
                if (IsStart(row)) return 0;
                if (IsMiddle(row)) return 3;
                return 6;//Is End
            }
            if (IsMiddle(column))
            {
                if (IsStart(row)) return 1;
                if (IsMiddle(row)) return 4;
                return 7;//Is End
            }
            //Is End
            if (IsStart(row)) return 2;
            if (IsMiddle(row)) return 5;
            
            return 8;//Is End
        }

        
        private static bool IsMiddle(int rowOrColumnIndex)
        {
            return rowOrColumnIndex >= 3 && rowOrColumnIndex < 6;
        }

        private static bool IsStart(int rowOrColumnIndex)
        {
            return rowOrColumnIndex < 3;
        }

        private Cell GetCell(int i, int j, int? initialValue = null)
        {
            if(initialValue == null)
                return new Cell(new Location(Rows[i], Columns[j]));

            return new Cell(new Location(Rows[i], Columns[j]), initialValue.GetValueOrDefault());
        }

        public static int[,] ParseString(string puzzleString)
        {
            var parsedInput = new int[9, 9];
            if (puzzleString == null) return parsedInput;

            var rows = puzzleString.Split('|').Select(p => p.Split(',').Select(i => GetIntOrDefault(i)).ToArray()).ToArray();

            for (var i = 0; i < 9; i++)
                for (var j = 0; j < 9; j++)
                    parsedInput[i, j] = rows[i][j];

            return parsedInput;
        }

        private static int GetIntOrDefault(string i)
        {
            return i.Trim() == "_" ? 0 : int.Parse(i);
        }

        private static CellCollection CreateCellCollection(int i)
        {
            return new CellCollection(i.ToString());
        }

        public List<CellCollection> Rows { get; }
        public List<CellCollection> Columns { get; }
        public List<CellCollection> Groups { get; }
        public List<Cell> AllCells { get; }
    }
}
