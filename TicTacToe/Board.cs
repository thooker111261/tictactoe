using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        private const string EMPTY = "+";

        private readonly int _ColumnCount;
        private readonly int _RowCount;
        private readonly string[] _Marks;

        private string[,] _Map;

        public string Winner { get; set; } = string.Empty;
        
        public Board(int columns = 3, int rows = 3, params string[] marks)
        {
            _ColumnCount = columns;
            _RowCount = rows;
            _Marks = marks;

            InitializeMap();
        }

        public bool TryToMarkBoard(int column, int row, string mark = null)
        {
            if (mark == null)
            {
                throw new NotImplementedException();
            }

            column = column - 1;
            row = row - 1;

            string CurrentMarkOnBoard = _Map[column, row];
            if (CurrentMarkOnBoard == EMPTY)
            {
                _Map[column, row] = mark;
                Winner = GetWinner();
                return true;
            }
            return false;
        }

        private string GetWinner()
        {
            List<string> MarkList = new List<string>();
 
            //vertical
            for (int columnIndex = 0; columnIndex < _ColumnCount; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < _RowCount; rowIndex++)
                {
                    MarkList.Add(_Map[rowIndex, columnIndex]);
                }
                for (int markIndex = 1; markIndex < _RowCount; markIndex++)
                {
                    if (MarkList[markIndex] != MarkList[0])
                    {
                        return string.Empty;
                    }
                }
            }
            if (MarkList[0] != EMPTY)
            {
                return MarkList[0];
            }
            else
            {
                return string.Empty;
            }
            //horizontal

            //diagonal


            //throw new NotImplementedException();
            //GameOver = true;
        }
        public string Display(bool legend = false)
        {
            StringBuilder boardState = new StringBuilder();
            for (int rowIndex = 0; rowIndex <= _RowCount; rowIndex++)
            {
                boardState.AppendLine();
                if (legend)
                {
                    if (rowIndex == 0)
                    {
                        boardState.Append("   ");
                    }
                    else
                    {
                        boardState.Append($" {rowIndex} ");
                    }
                }
                for (int columnIndex = 0; columnIndex < _ColumnCount; columnIndex++)
                {
                    if (rowIndex == 0)
                    {
                        if (legend)
                        {
                            boardState.Append($" {columnIndex + 1} ");
                        }
                    }
                    else
                    {
                        boardState.Append($" {_Map[rowIndex - 1, columnIndex]} ");
                    }
                }
            }
            return boardState.ToString();
        }

        private void InitializeMap()
        {
            _Map = new string[_ColumnCount, _RowCount];

            for (int columnIndex = 0; columnIndex < _ColumnCount; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < _RowCount; rowIndex++)
                {
                    _Map[columnIndex, rowIndex] = EMPTY;
                }
            }
        }
    }
}
