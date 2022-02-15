
namespace ConnectFour.WinFormUI
{
    partial class GameSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label labelPlayers;
            System.Windows.Forms.Label labelBoardSize;
            System.Windows.Forms.Label labelNumOfRows;
            System.Windows.Forms.Label labelNumOfCols;
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.textboxPlayer1 = new System.Windows.Forms.TextBox();
            this.textboxPlayer2 = new System.Windows.Forms.TextBox();
            this.labelPlayer2 = new System.Windows.Forms.Label();
            this.checkboxPlayer2 = new System.Windows.Forms.CheckBox();
            this.startGameButton = new System.Windows.Forms.Button();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.labelPlayer2NameError = new System.Windows.Forms.Label();
            this.labelPlayer1NameError = new System.Windows.Forms.Label();
            this.labelRowsError = new System.Windows.Forms.Label();
            this.labelColsError = new System.Windows.Forms.Label();
            labelPlayers = new System.Windows.Forms.Label();
            labelBoardSize = new System.Windows.Forms.Label();
            labelNumOfRows = new System.Windows.Forms.Label();
            labelNumOfCols = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayers
            // 
            labelPlayers.AutoSize = true;
            labelPlayers.Location = new System.Drawing.Point(17, 16);
            labelPlayers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelPlayers.Name = "labelPlayers";
            labelPlayers.Size = new System.Drawing.Size(59, 16);
            labelPlayers.TabIndex = 5;
            labelPlayers.Text = "Players:";
            // 
            // labelBoardSize
            // 
            labelBoardSize.AutoSize = true;
            labelBoardSize.Location = new System.Drawing.Point(17, 166);
            labelBoardSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelBoardSize.Name = "labelBoardSize";
            labelBoardSize.Size = new System.Drawing.Size(82, 16);
            labelBoardSize.TabIndex = 7;
            labelBoardSize.Text = "Board Size:";
            // 
            // labelNumOfRows
            // 
            labelNumOfRows.AccessibleDescription = "";
            labelNumOfRows.AutoSize = true;
            labelNumOfRows.Location = new System.Drawing.Point(47, 204);
            labelNumOfRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelNumOfRows.Name = "labelNumOfRows";
            labelNumOfRows.Size = new System.Drawing.Size(46, 16);
            labelNumOfRows.TabIndex = 9;
            labelNumOfRows.Text = "Rows:";
            labelNumOfRows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNumOfCols
            // 
            labelNumOfCols.AccessibleDescription = "";
            labelNumOfCols.AutoSize = true;
            labelNumOfCols.Location = new System.Drawing.Point(209, 204);
            labelNumOfCols.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelNumOfCols.Name = "labelNumOfCols";
            labelNumOfCols.Size = new System.Drawing.Size(39, 16);
            labelNumOfCols.TabIndex = 11;
            labelNumOfCols.Text = "Cols:";
            labelNumOfCols.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AccessibleDescription = "";
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(47, 54);
            this.labelPlayer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(60, 16);
            this.labelPlayer1.TabIndex = 0;
            this.labelPlayer1.Text = "Player 1";
            this.labelPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxPlayer1
            // 
            this.textboxPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPlayer1.Location = new System.Drawing.Point(119, 50);
            this.textboxPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.textboxPlayer1.Name = "textboxPlayer1";
            this.textboxPlayer1.Size = new System.Drawing.Size(202, 22);
            this.textboxPlayer1.TabIndex = 1;
            // 
            // textboxPlayer2
            // 
            this.textboxPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPlayer2.Enabled = false;
            this.textboxPlayer2.Location = new System.Drawing.Point(119, 108);
            this.textboxPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.textboxPlayer2.Name = "textboxPlayer2";
            this.textboxPlayer2.Size = new System.Drawing.Size(202, 22);
            this.textboxPlayer2.TabIndex = 3;
            this.textboxPlayer2.Text = "[Computer]";
            // 
            // labelPlayer2
            // 
            this.labelPlayer2.AccessibleDescription = "";
            this.labelPlayer2.AutoSize = true;
            this.labelPlayer2.Location = new System.Drawing.Point(47, 112);
            this.labelPlayer2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer2.Name = "labelPlayer2";
            this.labelPlayer2.Size = new System.Drawing.Size(60, 16);
            this.labelPlayer2.TabIndex = 2;
            this.labelPlayer2.Text = "Player 2";
            this.labelPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkboxPlayer2
            // 
            this.checkboxPlayer2.AutoSize = true;
            this.checkboxPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkboxPlayer2.Location = new System.Drawing.Point(23, 116);
            this.checkboxPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.checkboxPlayer2.Name = "checkboxPlayer2";
            this.checkboxPlayer2.Size = new System.Drawing.Size(12, 11);
            this.checkboxPlayer2.TabIndex = 4;
            this.checkboxPlayer2.UseVisualStyleBackColor = true;
            this.checkboxPlayer2.CheckedChanged += new System.EventHandler(this.checkboxPlayer2_CheckedChanged);
            // 
            // StartGameButton
            // 
            this.startGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startGameButton.Location = new System.Drawing.Point(23, 265);
            this.startGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.startGameButton.Name = "StartGameButton";
            this.startGameButton.Size = new System.Drawing.Size(299, 28);
            this.startGameButton.TabIndex = 6;
            this.startGameButton.Text = "Start Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownRows.Location = new System.Drawing.Point(119, 202);
            this.numericUpDownRows.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(52, 22);
            this.numericUpDownRows.TabIndex = 12;
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownCols.Location = new System.Drawing.Point(269, 202);
            this.numericUpDownCols.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(52, 22);
            this.numericUpDownCols.TabIndex = 13;
            // 
            // labelPlayer2NameError
            // 
            this.labelPlayer2NameError.AutoSize = true;
            this.labelPlayer2NameError.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer2NameError.Location = new System.Drawing.Point(47, 138);
            this.labelPlayer2NameError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer2NameError.Name = "labelPlayer2NameError";
            this.labelPlayer2NameError.Size = new System.Drawing.Size(185, 16);
            this.labelPlayer2NameError.TabIndex = 14;
            this.labelPlayer2NameError.Text = "Error: field cannot be empty";
            this.labelPlayer2NameError.Visible = false;
            // 
            // labelPlayer1NameError
            // 
            this.labelPlayer1NameError.AutoSize = true;
            this.labelPlayer1NameError.ForeColor = System.Drawing.Color.Red;
            this.labelPlayer1NameError.Location = new System.Drawing.Point(47, 81);
            this.labelPlayer1NameError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPlayer1NameError.Name = "labelPlayer1NameError";
            this.labelPlayer1NameError.Size = new System.Drawing.Size(185, 16);
            this.labelPlayer1NameError.TabIndex = 15;
            this.labelPlayer1NameError.Text = "Error: field cannot be empty";
            this.labelPlayer1NameError.Visible = false;
            // 
            // labelRowsError
            // 
            this.labelRowsError.AutoSize = true;
            this.labelRowsError.ForeColor = System.Drawing.Color.Red;
            this.labelRowsError.Location = new System.Drawing.Point(47, 230);
            this.labelRowsError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRowsError.Name = "labelRowsError";
            this.labelRowsError.Size = new System.Drawing.Size(124, 16);
            this.labelRowsError.TabIndex = 16;
            this.labelRowsError.Text = "Invalid rows value";
            this.labelRowsError.Visible = false;
            // 
            // labelColsError
            // 
            this.labelColsError.AutoSize = true;
            this.labelColsError.ForeColor = System.Drawing.Color.Red;
            this.labelColsError.Location = new System.Drawing.Point(209, 230);
            this.labelColsError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColsError.Name = "labelColsError";
            this.labelColsError.Size = new System.Drawing.Size(119, 16);
            this.labelColsError.TabIndex = 17;
            this.labelColsError.Text = "Invalid cols value";
            this.labelColsError.Visible = false;
            // 
            // GameSettingsForm
            // 
            this.AcceptButton = this.startGameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(351, 308);
            this.Controls.Add(this.labelColsError);
            this.Controls.Add(this.labelRowsError);
            this.Controls.Add(this.labelPlayer1NameError);
            this.Controls.Add(this.labelPlayer2NameError);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(labelNumOfCols);
            this.Controls.Add(labelNumOfRows);
            this.Controls.Add(labelBoardSize);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(labelPlayers);
            this.Controls.Add(this.checkboxPlayer2);
            this.Controls.Add(this.textboxPlayer2);
            this.Controls.Add(this.labelPlayer2);
            this.Controls.Add(this.textboxPlayer1);
            this.Controls.Add(this.labelPlayer1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox textboxPlayer1;
        private System.Windows.Forms.TextBox textboxPlayer2;
        private System.Windows.Forms.Label labelPlayer2;
        private System.Windows.Forms.CheckBox checkboxPlayer2;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Label labelPlayer2NameError;
        private System.Windows.Forms.Label labelPlayer1NameError;
        private System.Windows.Forms.Label labelRowsError;
        private System.Windows.Forms.Label labelColsError;
    }
}