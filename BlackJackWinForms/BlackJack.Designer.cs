namespace BlackJackWinForms
{
    partial class BlackJack
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
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.lbxPlayerHand = new System.Windows.Forms.ListBox();
            this.lblPlayerBust = new System.Windows.Forms.Label();
            this.lbxDealerHand = new System.Windows.Forms.ListBox();
            this.btnStand = new System.Windows.Forms.Button();
            this.lblDealerBust = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDealerScore = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDrawCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPlayerWin = new System.Windows.Forms.Label();
            this.lblDealerWin = new System.Windows.Forms.Label();
            this.lblDraw = new System.Windows.Forms.Label();
            this.lblDealerTotals = new System.Windows.Forms.Label();
            this.lblPlayerTotals = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeal
            // 
            this.btnDeal.Location = new System.Drawing.Point(43, 229);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(75, 23);
            this.btnDeal.TabIndex = 1;
            this.btnDeal.Text = "Deal";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // btnHit
            // 
            this.btnHit.Enabled = false;
            this.btnHit.Location = new System.Drawing.Point(390, 460);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(75, 23);
            this.btnHit.TabIndex = 2;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // lbxPlayerHand
            // 
            this.lbxPlayerHand.FormattingEnabled = true;
            this.lbxPlayerHand.Location = new System.Drawing.Point(354, 307);
            this.lbxPlayerHand.Name = "lbxPlayerHand";
            this.lbxPlayerHand.Size = new System.Drawing.Size(239, 147);
            this.lbxPlayerHand.TabIndex = 3;
            // 
            // lblPlayerBust
            // 
            this.lblPlayerBust.AutoSize = true;
            this.lblPlayerBust.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerBust.ForeColor = System.Drawing.Color.Red;
            this.lblPlayerBust.Location = new System.Drawing.Point(599, 365);
            this.lblPlayerBust.Name = "lblPlayerBust";
            this.lblPlayerBust.Size = new System.Drawing.Size(87, 31);
            this.lblPlayerBust.TabIndex = 4;
            this.lblPlayerBust.Text = "BUST";
            this.lblPlayerBust.Visible = false;
            // 
            // lbxDealerHand
            // 
            this.lbxDealerHand.FormattingEnabled = true;
            this.lbxDealerHand.Location = new System.Drawing.Point(354, 26);
            this.lbxDealerHand.Name = "lbxDealerHand";
            this.lbxDealerHand.Size = new System.Drawing.Size(239, 147);
            this.lbxDealerHand.TabIndex = 5;
            // 
            // btnStand
            // 
            this.btnStand.Enabled = false;
            this.btnStand.Location = new System.Drawing.Point(471, 460);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(75, 23);
            this.btnStand.TabIndex = 6;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // lblDealerBust
            // 
            this.lblDealerBust.AutoSize = true;
            this.lblDealerBust.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerBust.ForeColor = System.Drawing.Color.Red;
            this.lblDealerBust.Location = new System.Drawing.Point(599, 82);
            this.lblDealerBust.Name = "lblDealerBust";
            this.lblDealerBust.Size = new System.Drawing.Size(87, 31);
            this.lblDealerBust.TabIndex = 7;
            this.lblDealerBust.Text = "BUST";
            this.lblDealerBust.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dealers Hand";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 291);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Your Hand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(809, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dealer Score";
            // 
            // lblDealerScore
            // 
            this.lblDealerScore.AutoSize = true;
            this.lblDealerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerScore.Location = new System.Drawing.Point(806, 95);
            this.lblDealerScore.Name = "lblDealerScore";
            this.lblDealerScore.Size = new System.Drawing.Size(29, 31);
            this.lblDealerScore.TabIndex = 11;
            this.lblDealerScore.Text = "0";
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScore.Location = new System.Drawing.Point(806, 378);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(29, 31);
            this.lblPlayerScore.TabIndex = 13;
            this.lblPlayerScore.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(809, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Your Score";
            // 
            // lblDrawCount
            // 
            this.lblDrawCount.AutoSize = true;
            this.lblDrawCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrawCount.Location = new System.Drawing.Point(806, 242);
            this.lblDrawCount.Name = "lblDrawCount";
            this.lblDrawCount.Size = new System.Drawing.Size(29, 31);
            this.lblDrawCount.TabIndex = 15;
            this.lblDrawCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(809, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Draws";
            // 
            // lblPlayerWin
            // 
            this.lblPlayerWin.AutoSize = true;
            this.lblPlayerWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerWin.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblPlayerWin.Location = new System.Drawing.Point(692, 365);
            this.lblPlayerWin.Name = "lblPlayerWin";
            this.lblPlayerWin.Size = new System.Drawing.Size(67, 31);
            this.lblPlayerWin.TabIndex = 16;
            this.lblPlayerWin.Text = "WIN";
            this.lblPlayerWin.Visible = false;
            // 
            // lblDealerWin
            // 
            this.lblDealerWin.AutoSize = true;
            this.lblDealerWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerWin.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblDealerWin.Location = new System.Drawing.Point(692, 82);
            this.lblDealerWin.Name = "lblDealerWin";
            this.lblDealerWin.Size = new System.Drawing.Size(67, 31);
            this.lblDealerWin.TabIndex = 17;
            this.lblDealerWin.Text = "WIN";
            this.lblDealerWin.Visible = false;
            // 
            // lblDraw
            // 
            this.lblDraw.AutoSize = true;
            this.lblDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraw.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblDraw.Location = new System.Drawing.Point(692, 229);
            this.lblDraw.Name = "lblDraw";
            this.lblDraw.Size = new System.Drawing.Size(97, 31);
            this.lblDraw.TabIndex = 18;
            this.lblDraw.Text = "DRAW";
            this.lblDraw.Visible = false;
            // 
            // lblDealerTotals
            // 
            this.lblDealerTotals.AutoSize = true;
            this.lblDealerTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerTotals.Location = new System.Drawing.Point(265, 82);
            this.lblDealerTotals.Name = "lblDealerTotals";
            this.lblDealerTotals.Size = new System.Drawing.Size(0, 25);
            this.lblDealerTotals.TabIndex = 19;
            // 
            // lblPlayerTotals
            // 
            this.lblPlayerTotals.AutoSize = true;
            this.lblPlayerTotals.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerTotals.Location = new System.Drawing.Point(265, 365);
            this.lblPlayerTotals.Name = "lblPlayerTotals";
            this.lblPlayerTotals.Size = new System.Drawing.Size(0, 25);
            this.lblPlayerTotals.TabIndex = 20;
            // 
            // BlackJack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 589);
            this.Controls.Add(this.lblPlayerTotals);
            this.Controls.Add(this.lblDealerTotals);
            this.Controls.Add(this.lblDraw);
            this.Controls.Add(this.lblDealerWin);
            this.Controls.Add(this.lblPlayerWin);
            this.Controls.Add(this.lblDrawCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblDealerScore);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDealerBust);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.lbxDealerHand);
            this.Controls.Add(this.lblPlayerBust);
            this.Controls.Add(this.lbxPlayerHand);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.btnDeal);
            this.Name = "BlackJack";
            this.Text = "BlackJack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.ListBox lbxPlayerHand;
        private System.Windows.Forms.Label lblPlayerBust;
        private System.Windows.Forms.ListBox lbxDealerHand;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Label lblDealerBust;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDealerScore;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDrawCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPlayerWin;
        private System.Windows.Forms.Label lblDealerWin;
        private System.Windows.Forms.Label lblDraw;
        private System.Windows.Forms.Label lblDealerTotals;
        private System.Windows.Forms.Label lblPlayerTotals;
    }
}

