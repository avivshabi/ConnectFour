
namespace ConnectFour.WinFormUI
{
    partial class GameBoardForm
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
            this.panelGameControllers = new System.Windows.Forms.Panel();
            this.panelGameBoard = new System.Windows.Forms.Panel();
            this.panelScoreBoard = new System.Windows.Forms.Panel();
            this.buttonQuitRound = new System.Windows.Forms.Button();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.panelScoreBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGameControllers
            // 
            this.panelGameControllers.BackColor = System.Drawing.Color.Transparent;
            this.panelGameControllers.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGameControllers.Location = new System.Drawing.Point(0, 0);
            this.panelGameControllers.Name = "panelGameControllers";
            this.panelGameControllers.Size = new System.Drawing.Size(800, 73);
            this.panelGameControllers.TabIndex = 0;
            // 
            // panelGameBoard
            // 
            this.panelGameBoard.BackColor = System.Drawing.Color.Transparent;
            this.panelGameBoard.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelGameBoard.Location = new System.Drawing.Point(0, 73);
            this.panelGameBoard.Name = "panelGameBoard";
            this.panelGameBoard.Size = new System.Drawing.Size(800, 270);
            this.panelGameBoard.TabIndex = 1;
            // 
            // panelScoreBoard
            // 
            this.panelScoreBoard.BackColor = System.Drawing.Color.Transparent;
            this.panelScoreBoard.Controls.Add(this.buttonQuitRound);
            this.panelScoreBoard.Controls.Add(this.labelPlayer2Name);
            this.panelScoreBoard.Controls.Add(this.labelPlayer1Name);
            this.panelScoreBoard.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelScoreBoard.Location = new System.Drawing.Point(0, 349);
            this.panelScoreBoard.Name = "panelScoreBoard";
            this.panelScoreBoard.Size = new System.Drawing.Size(800, 100);
            this.panelScoreBoard.TabIndex = 2;
            // 
            // buttonQuitRound
            // 
            this.buttonQuitRound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonQuitRound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQuitRound.FlatAppearance.BorderSize = 0;
            this.buttonQuitRound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuitRound.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonQuitRound.Location = new System.Drawing.Point(338, 77);
            this.buttonQuitRound.Name = "buttonQuitRound";
            this.buttonQuitRound.Size = new System.Drawing.Size(95, 23);
            this.buttonQuitRound.TabIndex = 3;
            this.buttonQuitRound.Text = "Quit Round";
            this.buttonQuitRound.UseVisualStyleBackColor = false;
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer2Name.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPlayer2Name.Location = new System.Drawing.Point(444, 47);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(64, 16);
            this.labelPlayer2Name.TabIndex = 2;
            this.labelPlayer2Name.Text = "Player 2:";
            this.labelPlayer2Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayer1Name.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPlayer1Name.Location = new System.Drawing.Point(260, 47);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(64, 16);
            this.labelPlayer1Name.TabIndex = 1;
            this.labelPlayer1Name.Text = "Player 1:";
            this.labelPlayer1Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConnectFour.WinFormUI.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelScoreBoard);
            this.Controls.Add(this.panelGameBoard);
            this.Controls.Add(this.panelGameControllers);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameBoardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four";
            this.Load += new System.EventHandler(this.GameBoardForm_Load);
            this.panelScoreBoard.ResumeLayout(false);
            this.panelScoreBoard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelGameControllers;
        private System.Windows.Forms.Panel panelGameBoard;
        private System.Windows.Forms.Panel panelScoreBoard;
        private System.Windows.Forms.Label labelPlayer2Name;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Button buttonQuitRound;
    }
}