using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConnectFour.WinFormUI
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public int Rows
        {
            get { return (int) this.numericUpDownRows.Value; }
        }
        public int Cols
        {
            get { return (int)this.numericUpDownCols.Value; }
        }

        public List<string> PlayerNames
        {
            get
            {
                List<string> playerNames = new List<string> { this.textboxPlayer1.Text };

                if (!PlayAgainstComputer)
                {
                    playerNames.Add(this.textboxPlayer2.Text);
                }

                return playerNames;
            }
        }

        public bool PlayAgainstComputer
        {
            get { return !this.checkboxPlayer2.Checked; }
        }

        private void checkboxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (sender as CheckBox != null)
            {
                textboxPlayer2.Enabled = !textboxPlayer2.Enabled;
            }
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            hideAllErrors();

            if (!InputValidation.ValidateRowsInput(this.numericUpDownRows.Value.ToString()))
            {
                this.labelRowsError.Show();
            }

            if (!InputValidation.ValidateColsInput(this.numericUpDownCols.Value.ToString()))
            {
                this.labelColsError.Show();
            }

            if (!InputValidation.ValidatePlayerName(this.textboxPlayer1.Text))
            {
                this.labelPlayer1NameError.Show();
            }

            if (!PlayAgainstComputer && !InputValidation.ValidatePlayerName(this.textboxPlayer2.Text))
            {
                this.labelPlayer2NameError.Show();
            }

            if (!this.labelPlayer1NameError.Visible
                && !this.labelPlayer2NameError.Visible
                && !this.labelRowsError.Visible
                && !this.labelColsError.Visible)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void hideAllErrors()
        {
            labelPlayer1NameError.Hide();
            labelPlayer2NameError.Hide();
            labelRowsError.Hide();
            labelColsError.Hide();
        }
    }
}
