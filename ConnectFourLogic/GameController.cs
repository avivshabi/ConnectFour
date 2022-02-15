using System;
using System.Collections.Generic;

namespace ConnectFour.Logic
{
    public class GameController
    {
        private const int k_DepthForAIAlgorithm = 2;
        private const int k_SequenceLengthToWin = 4;
        private const string k_AIPlayerName = "Computer";
        private readonly List<Player> r_Players;
        private readonly StackBoard r_StackBoard;
        private readonly Player r_AIPlayer;
        private Player m_CurrentPlayer;
        private Player m_PreviousPlayer;
        private Player m_Winner;
        private bool m_Tie;
        private bool m_ActiveRound;
        public event EventHandler GameOver;
        public event EventHandler BoardChange;
        public event EventHandler PlayerChange;

        public GameController(int i_Rows, int i_Cols, List<string> i_PlayerNames, bool i_PlayWithAI)
        {
            r_StackBoard = new StackBoard(i_Rows, i_Cols);
            r_Players = new List<Player>();

            foreach (string playerName in i_PlayerNames)
            {
                r_Players.Add(new Player(playerName, (eToken)r_Players.Count));
            }

            if (i_PlayWithAI)
            {
                r_AIPlayer = new Player(k_AIPlayerName, (eToken)r_Players.Count, !i_PlayWithAI);
                r_Players.Add(r_AIPlayer);
            }

            Reset();
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                if (!ReferenceEquals(m_CurrentPlayer, value))
                {
                    m_PreviousPlayer = m_CurrentPlayer;
                    m_CurrentPlayer = value;

                    if (m_ActiveRound)
                    {
                        OnPlayerChange();
                    }
                }
            }
        }

        public List<Player> Players
        {
            get
            {
                return r_Players;
            }
        }

        public bool ContinuePlaying
        {
            get
            {
                return m_ActiveRound;
            }
            set
            {
                const bool v_ContinuePlaying = true;

                if (value != v_ContinuePlaying)
                {
                    m_ActiveRound = value;
                    m_PreviousPlayer.Score++;
                    m_Winner = m_PreviousPlayer;
                    OnGameOver();
                }
            }
        }

        public bool EndedWithTie
        {
            get
            {
                return m_Tie;
            }
        }

        public bool EndedWithWin
        {
            get
            {
                return !m_ActiveRound && !m_Tie;
            }
        }

        public Player Winner
        {
            get
            {
                return m_Winner;
            }
        }

        public eToken this[int i_Row, int i_Col]
        {
            get { return r_StackBoard[i_Row, i_Col]; }
        }

        public void Reset()
        {
            r_StackBoard.Reset();
            OnBoardChange();
            m_Winner = null;
            m_Tie = false;
            m_ActiveRound = true;

            if (r_Players.Count > 0)
            {
                m_CurrentPlayer = r_Players[0];
                m_PreviousPlayer = r_Players[r_Players.Count - 1];
                OnPlayerChange();
            }
        }

        public bool IsColumnFree(int i_Col)
        {
            return r_StackBoard.FreeColumns.Contains(i_Col);
        }

        public bool Play(int i_Col)
        {
            bool played = !true;

            if (m_ActiveRound)
            {
                played = r_StackBoard.TryStack(i_Col, m_CurrentPlayer.Token);

                if (played)
                {
                    OnBoardChange();

                    if (checkWin(r_StackBoard, m_CurrentPlayer.Token))
                    {
                        m_Winner = m_CurrentPlayer;
                        m_Winner.Score++;
                        m_ActiveRound = !m_ActiveRound;
                    }
                    else if (checkTie(r_StackBoard))
                    {
                        m_Tie = !m_Tie;
                        m_ActiveRound = !m_ActiveRound;
                    }
                    else
                    {
                        CurrentPlayer = m_PreviousPlayer;
                    }

                    if (!m_ActiveRound)
                    {
                        OnGameOver();
                    }
                }
            }

            return played;
        }

        public void Play()
        {
            bool currentPlayerIsFavoured = true;
            int column = 0;

            if (m_ActiveRound)
            {
                do
                {
                    minimaxAlgorithm(r_StackBoard, k_DepthForAIAlgorithm, currentPlayerIsFavoured, ref column);
                } while (!Play(column));
            }
        }

        protected void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver.Invoke(this, null);
            }
        }

        protected void OnBoardChange()
        {
            if (BoardChange != null)
            {
                BoardChange.Invoke(this, null);
            }
        }

        protected void OnPlayerChange()
        {
            if (PlayerChange != null)
            {
                PlayerChange.Invoke(this, null);
            }
        }

        private int minimaxAlgorithm(StackBoard i_Board, int i_DepthToCheck, bool i_IsFavouredPlayer, ref int io_OptimalColumn)
        {
            int value;
            Random random = new Random();

            if (!i_IsFavouredPlayer && i_Board.FindSequenceWithLength(k_SequenceLengthToWin, m_CurrentPlayer.Token))
            {
                value = int.MaxValue;
            }
            else if (i_IsFavouredPlayer && i_Board.FindSequenceWithLength(k_SequenceLengthToWin, m_PreviousPlayer.Token))
            {
                value = int.MinValue;
            }
            else if (i_Board.IsFull)
            {
                value = 0;
            }
            else if (i_DepthToCheck == 0)
            {
                value = scoreCurrentState(i_Board, m_CurrentPlayer.Token) - scoreCurrentState(i_Board, m_PreviousPlayer.Token);
            }
            else
            {
                List<int> freeColumns = i_Board.FreeColumns;
                io_OptimalColumn = freeColumns[random.Next(freeColumns.Count)];
                predictOptimalPlayerScore(i_Board, i_DepthToCheck, i_IsFavouredPlayer, out value, ref io_OptimalColumn);
            }

            return value;
        }

        private void predictOptimalPlayerScore(StackBoard i_Board, int i_DepthToCheck, bool i_IsFavouredPlayer, out int o_Value, ref int io_OptimalColumn)
        {
            List<int> freeColumns = i_Board.FreeColumns;
            o_Value = i_IsFavouredPlayer ? int.MinValue : int.MaxValue;

            foreach (int col in freeColumns)
            {
                StackBoard board = i_Board.Copy();

                if (!board.TryStack(col, m_CurrentPlayer.Token))
                {
                    continue;
                }

                int score = minimaxAlgorithm(board, i_DepthToCheck - 1, !i_IsFavouredPlayer, ref io_OptimalColumn);

                if (i_IsFavouredPlayer && score > o_Value || !i_IsFavouredPlayer && score < o_Value)
                {
                    o_Value = score;
                    io_OptimalColumn = col;
                }
            }
        }

        private static int scoreCurrentState(StackBoard i_Board, eToken i_PlayerToken)
        {
            int score = 0;

            for (int i = 1; i < k_SequenceLengthToWin; i++)
            {
                if (i_Board.FindSequenceWithLength(i, i_PlayerToken))
                {
                    score += (int)Math.Pow(2, i);
                }
            }

            return score;
        }

        private static bool checkWin(StackBoard i_Board, eToken i_PlayerToken)
        {
            return i_Board.FindSequenceWithLength(k_SequenceLengthToWin, i_PlayerToken);
        }

        private static bool checkTie(StackBoard i_Board)
        {
            return i_Board.IsFull;
        }
    }
}
