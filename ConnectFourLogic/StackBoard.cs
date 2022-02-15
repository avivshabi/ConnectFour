using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour.Logic
{
    public class StackBoard
    {
        public const int k_FirstIndex = 0;
        private readonly int r_Rows;
        private readonly int r_Cols;
        private readonly eToken[,] r_Grid;
        private readonly int[] r_NextFreeRow;
        private int m_LastModifiedRow;
        private int m_LastModifiedCol;
        private int m_MaxRowToCheck;
        private int m_MinRowToCheck;
        private int m_MaxColToCheck;
        private int m_MinColToCheck;

        public StackBoard(int i_Rows, int i_Cols)
        {
            r_Rows = i_Rows;
            r_Cols = i_Cols;
            r_Grid = new eToken[r_Rows, r_Cols];
            r_NextFreeRow = new int[r_Cols];
        }

        public eToken this[int i_Row, int i_Col]
        {
            get
            {
                eToken currentToken = eToken.Empty;

                if (!isInvalidCell(i_Row, i_Col))
                {
                    currentToken = r_Grid[i_Row, i_Col];
                }

                return currentToken;
            }
        }

        public int NumOfRows
        {
            get
            {
                return r_Rows;
            }
        }

        public int NumOfColumns
        {
            get
            {
                return r_Cols;
            }
        }

        public List<int> FreeColumns
        {
            get
            {
                List<int> freeColumns = new List<int>();

                for (int i = 0; i < r_Cols; i++)
                {
                    if (r_NextFreeRow[i] >= k_FirstIndex)
                    {
                        freeColumns.Add(i);
                    }
                }

                return freeColumns;
            }
        }

        public bool IsFull
        {
            get
            {
                bool isFull = true;

                foreach (int freeRow in r_NextFreeRow)
                {
                    if (freeRow >= 0)
                    {
                        isFull = !isFull;
                        break;
                    }
                }

                return isFull;
            }
        }

        public void Reset()
        {
            for (int row = 0; row < r_Rows; row++)
            {
                for (int col = 0; col < r_Cols; col++)
                {
                    r_Grid[row, col] = eToken.Empty;
                }
            }

            for (int col = 0; col < r_Cols; col++)
            {
                r_NextFreeRow[col] = r_Rows - 1;
            }
        }

        public StackBoard Copy()
        {
            StackBoard board = new StackBoard(r_Rows, r_Cols);

            for (int row = 0; row < r_Rows; row++)
            {
                for (int col = 0; col < r_Cols; col++)
                {
                    board.r_Grid[row, col] = r_Grid[row, col];
                }
            }

            for (int col = 0; col < r_Cols; col++)
            {
                board.r_NextFreeRow[col] = r_NextFreeRow[col];
            }

            return board;
        }

        public bool TryStack(int i_Col, eToken i_Token)
        {
            bool stacked = !true;

            if (i_Token != eToken.Empty && i_Col >= k_FirstIndex && i_Col < r_Cols && r_NextFreeRow[i_Col] >= k_FirstIndex)
            {
                stack(i_Col, i_Token);
                r_NextFreeRow[i_Col]--;
                stacked = !stacked;
            }

            return stacked;
        }

        public string GetSignAt(int i_Row, int i_Col)
        {
            string sign = " ";

            if (this[i_Row, i_Col] != eToken.Empty)
            {
                sign = this[i_Row, i_Col].ToString();
            }

            return sign;
        }

        public bool FindSequenceWithLength(int i_Length, eToken i_Token)
        {
            m_MaxRowToCheck = m_LastModifiedRow + i_Length;
            m_MinRowToCheck = m_LastModifiedRow - i_Length;
            m_MaxColToCheck = m_LastModifiedCol + i_Length;
            m_MinColToCheck = m_LastModifiedCol - i_Length;

            return findHorizontalSequence(i_Length, i_Token)
                || findVerticalSequence(i_Length, i_Token)
                || findUpRightDiagonalSequence(i_Length, i_Token)
                || findDownRightDiagonalSequence(i_Length, i_Token);
        }

        public override string ToString()
        {
            StringBuilder boardStr = new StringBuilder();
            boardStr.Append(Environment.NewLine);

            for (int i = 1; i <= r_Cols; i++)
            {
                boardStr.Append($"  {i} ");
            }

            boardStr.Append(Environment.NewLine);

            for (int row = 0; row < r_Rows; row++)
            {
                for (int col = 0; col < r_Cols; col++)
                {
                    boardStr.Append($"| { GetSignAt(row, col) } ");
                }

                addBoardLineBreak(ref boardStr, r_Cols);
            }

            return boardStr.ToString();
        }

        private bool isInvalidCell(int i_Row, int i_Col)
        {
            return i_Row < k_FirstIndex || r_Rows <= i_Row || i_Col < k_FirstIndex || r_Cols <= i_Col;
        }

        private void stack(int i_Col, eToken i_Token)
        {
            int row = r_NextFreeRow[i_Col];
            r_Grid[row, i_Col] = i_Token;
            m_LastModifiedRow = row;
            m_LastModifiedCol = i_Col;
        }

        private bool findHorizontalSequence(int i_Length, eToken i_Token)
        {
            bool foundSequence = !true;

            for (int row = m_MinRowToCheck; row < m_MaxRowToCheck && !foundSequence; row++)
            {
                int sequenceLength = 0;

                for (int col = m_MinColToCheck; col < m_MaxColToCheck && !foundSequence; col++)
                {
                    if (this[row, col].Equals(i_Token))
                    {
                        sequenceLength++;
                    }
                    else
                    {
                        sequenceLength = 0;
                    }

                    foundSequence = i_Length == sequenceLength;
                }
            }

            return foundSequence;
        }

        private bool findVerticalSequence(int i_Length, eToken i_Token)
        {
            bool foundSequence = !true;

            for (int col = m_MinColToCheck; col < m_MaxColToCheck && !foundSequence; col++)
            {
                int sequenceLength = 0;

                for (int row = m_MinRowToCheck; row < m_MaxRowToCheck && !foundSequence; row++)
                {
                    if (this[row, col].Equals(i_Token))
                    {
                        sequenceLength++;
                    }
                    else
                    {
                        sequenceLength = 0;
                    }

                    foundSequence = i_Length == sequenceLength;
                }
            }

            return foundSequence;
        }

        private bool findUpRightDiagonalSequence(int i_Length, eToken i_Token)
        {
            bool foundSequence = !true;
            int sequenceLength = 0;
            int row = m_MaxRowToCheck;
            int col = m_MinColToCheck;

            while (!foundSequence && m_MinRowToCheck <= row && col <= m_MaxColToCheck)
            {
                if (this[row, col].Equals(i_Token))
                {
                    sequenceLength++;
                }
                else
                {
                    sequenceLength = 0;
                }

                foundSequence = i_Length == sequenceLength;
                row--;
                col++;
            }

            return foundSequence;
        }

        private bool findDownRightDiagonalSequence(int i_Length, eToken i_Token)
        {
            bool foundSequence = !true;
            int sequenceLength = 0;
            int row = m_MinRowToCheck;
            int col = m_MinColToCheck;

            while (!foundSequence && row <= m_MaxRowToCheck && col <= m_MaxColToCheck)
            {
                if (this[row, col].Equals(i_Token))
                {
                    sequenceLength++;
                }
                else
                {
                    sequenceLength = 0;
                }

                foundSequence = i_Length == sequenceLength;
                row++;
                col++;
            }

            return foundSequence;
        }

        private void addBoardLineBreak(ref StringBuilder io_BoardStr, int i_NumOfCols)
        {
            io_BoardStr.Append($"|{Environment.NewLine}");

            for (int i = 0; i < i_NumOfCols; i++)
            {
                io_BoardStr.Append($"====");
            }

            io_BoardStr.Append($"={Environment.NewLine}");
        }
    }
}
