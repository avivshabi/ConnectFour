using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace ConnectFour.WinFormUI
{
    public partial class GameBoardForm : Form
    {
        private const int k_PictureCellSize = 80;
        private const int k_SpaceFromLeft = 5;
        private const int k_SpaceFromTop = 60;
        private const int k_FontSize = 10;
        private const int k_Delay = 1000;
        private const int k_Win = 0;
        private const int k_Tie = 1;
        private const int k_Change = 2;
        private const int k_Click = 3;

        private readonly Dictionary<int, SoundPlayer> r_Sounds = new Dictionary<int, SoundPlayer>();
        private readonly Timer r_PlayTimer = new Timer();
        private readonly Image r_TopCell;
        private readonly Image r_EmptyCell;
        private readonly Image r_BlueCell;
        private readonly Image r_RedCell;
        private GameController m_GameBoardLogic;

        public GameBoardForm()
        {
            r_PlayTimer.Interval = k_Delay;
            r_TopCell = Properties.Resources.insertToken;
            r_BlueCell = Properties.Resources.blueCell;
            r_RedCell = Properties.Resources.redCell;
            r_EmptyCell = Properties.Resources.emptyCell;
            DoubleBuffered = true;
            InitializeComponent();
        }

        private void GameBoardForm_Load(object sender, EventArgs e)
        {
            GameSettingsForm settingsForm = new GameSettingsForm();
            int height, width;

            settingsForm.ShowDialog();
            
            if (settingsForm.DialogResult != DialogResult.OK)
            {
                this.Close();
            }

            width = (settingsForm.Cols * k_PictureCellSize) + k_SpaceFromLeft;
            height = ((settingsForm.Rows + 1) * k_PictureCellSize) + (k_SpaceFromTop * 2);
            this.Size = new Size(width, height);
            initializeGame(settingsForm);
        }

        private void initializeGame(GameSettingsForm i_SettingsForm)
        {
            m_GameBoardLogic = new GameController(i_SettingsForm.Rows,
                                                  i_SettingsForm.Cols,
                                                  i_SettingsForm.PlayerNames,
                                                  i_SettingsForm.PlayAgainstComputer);
            m_GameBoardLogic.PlayerChange += m_GameBoardLogic_PlayerChange;
            m_GameBoardLogic.GameOver += m_GameBoardLogic_GameOver;
            setSoundEffects();
            initializeGameControllers(i_SettingsForm);
            initializeGameBoard(i_SettingsForm);
            initializeScoreBoard();
            initializeQuitButton();
        }

        private void setSoundEffects()
        {
            r_Sounds[k_Win] = new SoundPlayer(Properties.Resources.applause);
            r_Sounds[k_Tie] = new SoundPlayer(Properties.Resources.gameOver);
            r_Sounds[k_Change] = new SoundPlayer(Properties.Resources.change);
            r_Sounds[k_Click] = new SoundPlayer(Properties.Resources.click);
        }

        private void initializeGameControllers(GameSettingsForm i_SettingsForm)
        {
            for (int j = 0; j < i_SettingsForm.Cols; j++)
            {
                initializeTopBarCell(j);
            }

            this.panelGameControllers.Width = this.Width;
            this.panelGameControllers.Height = k_PictureCellSize;
            this.panelGameControllers.Left = k_SpaceFromLeft;
            this.Controls.Add(this.panelGameControllers);
        }

        private void initializeGameBoard(GameSettingsForm i_SettingsForm)
        {
            m_GameBoardLogic.BoardChange += m_GameBoardLogic_BoardChange;

            for (int i = 0; i < i_SettingsForm.Rows; i++)
            {
                for (int j = 0; j < i_SettingsForm.Cols; j++)
                {
                    initializeBoardCell(i, j);
                }
            }

            this.panelGameBoard.Width = this.Width;
            this.panelGameBoard.Height = i_SettingsForm.Rows * k_PictureCellSize;
            this.panelGameBoard.Top = k_PictureCellSize;
            this.panelGameBoard.Left = k_SpaceFromLeft;
            this.Controls.Add(this.panelGameBoard);
        }

        private void initializeScoreBoard()
        {
            labelPlayer1Name.TextAlign = ContentAlignment.MiddleCenter;
            labelPlayer1Name.Top = k_SpaceFromTop / 2;
            labelPlayer1Name.AutoSize = false;
            labelPlayer1Name.Width = this.Width / 2;
            labelPlayer1Name.Left = 0;
            labelPlayer2Name.TextAlign = ContentAlignment.MiddleCenter;
            labelPlayer2Name.Top = k_SpaceFromTop / 2;
            labelPlayer2Name.AutoSize = false;
            labelPlayer2Name.Width = this.Width / 2;
            labelPlayer2Name.Left = labelPlayer1Name.Right;
            this.panelScoreBoard.Controls.Add(labelPlayer1Name);
            this.panelScoreBoard.Controls.Add(labelPlayer2Name);
            updatePlayerScoreLabels();

            this.panelScoreBoard.Width = this.Width;
            this.panelScoreBoard.Height = k_PictureCellSize + k_SpaceFromLeft;
            this.panelScoreBoard.Top = this.panelGameBoard.Bottom;
            this.Controls.Add(panelScoreBoard);
        }

        private void initializeQuitButton()
        {
            this.buttonQuitRound.Top = this.panelScoreBoard.Height - this.buttonQuitRound.Height;
            this.buttonQuitRound.Left = (this.Width - this.buttonQuitRound.Width) / 2;
            buttonQuitRound.Click += buttonQuitRound_Click;
        }

        private void updatePlayerScoreLabels()
        {
            Player player1 = m_GameBoardLogic.Players[0];
            Player player2 = m_GameBoardLogic.Players[1];

            labelPlayer1Name.Text = $"{player1.Name}: {player1.Score:N0}";
            labelPlayer2Name.Text = $"{player2.Name}: {player2.Score:N0}";

            if (object.ReferenceEquals(player1, m_GameBoardLogic.CurrentPlayer))
            {
                labelPlayer1Name.ForeColor = Color.FromArgb(255, 56, 89);
                labelPlayer2Name.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                labelPlayer2Name.ForeColor = Color.RoyalBlue;
                labelPlayer1Name.ForeColor = Color.WhiteSmoke;
            }
        }

        private void initializeTopBarCell(int i_Col)
        {
            PictureBox columnButton = new PictureBox();
            Point cellLocation = new Point
            {
                X = i_Col * k_PictureCellSize,
                Y = 0
            };

            columnButton.Location = cellLocation;
            columnButton.Top = k_SpaceFromLeft;
            columnButton.Height = k_PictureCellSize - (2 * k_SpaceFromLeft);
            columnButton.Width = k_PictureCellSize - (2 * k_SpaceFromLeft);
            columnButton.SizeMode = PictureBoxSizeMode.StretchImage;
            columnButton.BorderStyle = BorderStyle.None;
            columnButton.Tag = i_Col;
            columnButton.Click += columnButton_Click;
            columnButton.Cursor = Cursors.Hand;
            setControlCellImage(columnButton);
            this.panelGameControllers.Controls.Add(columnButton);
        }

        private void initializeBoardCell(int i_Row, int i_Col)
        {
            PictureBox cell = new PictureBox();
            Point cellLocation = new Point
            {
                X = i_Col * k_PictureCellSize,
                Y = i_Row * k_PictureCellSize
            };

            cell.Location = cellLocation;
            cell.Height = k_PictureCellSize - (2 * k_SpaceFromLeft);
            cell.Width = k_PictureCellSize - (2 * k_SpaceFromLeft);
            cell.SizeMode = PictureBoxSizeMode.StretchImage;
            cell.BorderStyle = BorderStyle.None;
            cell.Tag = new Point(i_Col, i_Row);
            setBoardCellImage(cell);
            this.panelGameBoard.Controls.Add(cell);
        }

        private void setBoardCellImage(PictureBox i_Cell)
        {
            Point coordinates = (Point)i_Cell.Tag;

            switch (m_GameBoardLogic[coordinates.Y, coordinates.X])
            {
                case eToken.Empty:
                    i_Cell.Image = r_EmptyCell;
                    break;
                case eToken.X:
                    i_Cell.Image = r_BlueCell;
                    break;
                case eToken.O:
                    i_Cell.Image = r_RedCell;
                    break;
            }
        }

        private void setControlCellImage(PictureBox i_Cell)
        {
            int columnIndex = (int)i_Cell.Tag;

            if (m_GameBoardLogic.IsColumnFree(columnIndex))
            {
                i_Cell.Image = r_TopCell;
                i_Cell.Show();
            }
            else
            {
                i_Cell.Image = r_TopCell;
                i_Cell.Hide();
            }
        }

        private void columnButton_Click(object sender, EventArgs eventArgs)
        {
            if (sender is PictureBox cell)
            {
                playClickSound();
                m_GameBoardLogic.Play((int)cell.Tag);
            }
        }

        private void buttonQuitRound_Click(object sender, EventArgs eventArgs)
        {
            if (m_GameBoardLogic.CurrentPlayer.IsHuman)
            {
                m_GameBoardLogic.ContinuePlaying = !true;
            }
        }

        private void m_GameBoardLogic_BoardChange(object sender, EventArgs eventArgs)
        {
            foreach (Control control in panelGameBoard.Controls)
            {
                if (control is PictureBox cell && cell.Tag is Point)
                {
                    setBoardCellImage(cell);
                }
            }

            foreach (Control control in panelGameControllers.Controls)
            {
                if (control is PictureBox cell && cell.Tag is int)
                {
                    setControlCellImage(cell);
                }
            }
        }

        private void m_GameBoardLogic_PlayerChange(object sender, EventArgs eventArgs)
        {
            updatePlayerScoreLabels();

            if (m_GameBoardLogic.ContinuePlaying)
            {
                // Note: this condition is only for better UI\UX and does not interfere with the game logic.
                if (!m_GameBoardLogic.CurrentPlayer.IsHuman)
                {
                    panelGameControllers.Hide();
                    buttonQuitRound.Hide();
                    r_PlayTimer.Tick += r_PlayTimer_Tick;
                    r_PlayTimer.Start();
                }
                else
                {
                    panelGameControllers.Show();
                    buttonQuitRound.Show();
                }
            }
        }

        private void m_GameBoardLogic_GameOver(object sender, EventArgs eventArgs)
        {
            DialogResult dialogResult = MessageBox.Show(getExitDialogMessageAndMakeSound(),
                                                        "Game Over!",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                m_GameBoardLogic.Reset();
                updatePlayerScoreLabels();
            }
            else
            {
                this.Close();
            }
        }

        private string getExitDialogMessageAndMakeSound()
        {
            string message;

            if (m_GameBoardLogic.EndedWithTie)
            {
                message = $"It's a Tie! {Environment.NewLine}Another Round?";
                playTieSound();
            }
            else
            {
                message = $"{m_GameBoardLogic.Winner.Name} is the winner of this round! {Environment.NewLine}Another Round?";
                playWinSound();
            }

            return message;
        }

        private void r_PlayTimer_Tick(object sender, EventArgs e)
        {
            m_GameBoardLogic.Play();
            playChangeSound();
            r_PlayTimer.Tick -= r_PlayTimer_Tick;
            r_PlayTimer.Stop();
        }

        private void playWinSound()
        {
            r_Sounds[k_Win].Play();
        }

        private void playTieSound()
        {
            r_Sounds[k_Tie].Play();
        }

        private void playChangeSound()
        {
            r_Sounds[k_Change].Play();
        }

        private void playClickSound()
        {
            r_Sounds[k_Click].Play();
        }
    }
}
