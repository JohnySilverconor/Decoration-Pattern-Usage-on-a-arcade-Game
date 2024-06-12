namespace Maze
{
    partial class FormOptions
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chbGhostFaces = new System.Windows.Forms.CheckBox();
            this.chbPlayerFaces = new System.Windows.Forms.CheckBox();
            this.gboxPlayer = new System.Windows.Forms.GroupBox();
            this.gboxGhosts = new System.Windows.Forms.GroupBox();
            this.chbGhostTrackScore = new System.Windows.Forms.CheckBox();
            this.gboxPickups = new System.Windows.Forms.GroupBox();
            this.chbPickupGhostVurneability = new System.Windows.Forms.CheckBox();
            this.chbPickupGhostTempFreeze = new System.Windows.Forms.CheckBox();
            this.chbPickupTrackScore = new System.Windows.Forms.CheckBox();
            this.gboxPlayer.SuspendLayout();
            this.gboxGhosts.SuspendLayout();
            this.gboxPickups.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(126, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(45, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chbGhostFaces
            // 
            this.chbGhostFaces.AutoSize = true;
            this.chbGhostFaces.Location = new System.Drawing.Point(6, 19);
            this.chbGhostFaces.Name = "chbGhostFaces";
            this.chbGhostFaces.Size = new System.Drawing.Size(147, 17);
            this.chbGhostFaces.TabIndex = 0;
            this.chbGhostFaces.Text = "Different movement faces";
            this.chbGhostFaces.UseVisualStyleBackColor = true;
            // 
            // chbPlayerFaces
            // 
            this.chbPlayerFaces.AutoSize = true;
            this.chbPlayerFaces.Location = new System.Drawing.Point(6, 19);
            this.chbPlayerFaces.Name = "chbPlayerFaces";
            this.chbPlayerFaces.Size = new System.Drawing.Size(147, 17);
            this.chbPlayerFaces.TabIndex = 0;
            this.chbPlayerFaces.Text = "Different movement faces";
            this.chbPlayerFaces.UseVisualStyleBackColor = true;
            // 
            // gboxPlayer
            // 
            this.gboxPlayer.Controls.Add(this.chbPlayerFaces);
            this.gboxPlayer.Location = new System.Drawing.Point(12, 12);
            this.gboxPlayer.Name = "gboxPlayer";
            this.gboxPlayer.Size = new System.Drawing.Size(189, 44);
            this.gboxPlayer.TabIndex = 0;
            this.gboxPlayer.TabStop = false;
            this.gboxPlayer.Text = "Player";
            // 
            // gboxGhosts
            // 
            this.gboxGhosts.Controls.Add(this.chbGhostTrackScore);
            this.gboxGhosts.Controls.Add(this.chbGhostFaces);
            this.gboxGhosts.Location = new System.Drawing.Point(12, 62);
            this.gboxGhosts.Name = "gboxGhosts";
            this.gboxGhosts.Size = new System.Drawing.Size(189, 65);
            this.gboxGhosts.TabIndex = 1;
            this.gboxGhosts.TabStop = false;
            this.gboxGhosts.Text = "Ghosts";
            // 
            // chbGhostTrackScore
            // 
            this.chbGhostTrackScore.AutoSize = true;
            this.chbGhostTrackScore.Location = new System.Drawing.Point(6, 42);
            this.chbGhostTrackScore.Name = "chbGhostTrackScore";
            this.chbGhostTrackScore.Size = new System.Drawing.Size(83, 17);
            this.chbGhostTrackScore.TabIndex = 1;
            this.chbGhostTrackScore.Text = "Track score";
            this.chbGhostTrackScore.UseVisualStyleBackColor = true;
            // 
            // gboxPickups
            // 
            this.gboxPickups.Controls.Add(this.chbPickupGhostVurneability);
            this.gboxPickups.Controls.Add(this.chbPickupGhostTempFreeze);
            this.gboxPickups.Controls.Add(this.chbPickupTrackScore);
            this.gboxPickups.Location = new System.Drawing.Point(12, 133);
            this.gboxPickups.Name = "gboxPickups";
            this.gboxPickups.Size = new System.Drawing.Size(189, 93);
            this.gboxPickups.TabIndex = 2;
            this.gboxPickups.TabStop = false;
            this.gboxPickups.Text = "Pickups";
            // 
            // chbPickupGhostVurneability
            // 
            this.chbPickupGhostVurneability.AutoSize = true;
            this.chbPickupGhostVurneability.Location = new System.Drawing.Point(7, 20);
            this.chbPickupGhostVurneability.Name = "chbPickupGhostVurneability";
            this.chbPickupGhostVurneability.Size = new System.Drawing.Size(110, 17);
            this.chbPickupGhostVurneability.TabIndex = 0;
            this.chbPickupGhostVurneability.Text = "Ghost vurneability";
            this.chbPickupGhostVurneability.UseVisualStyleBackColor = true;
            // 
            // chbPickupGhostTempFreeze
            // 
            this.chbPickupGhostTempFreeze.AutoSize = true;
            this.chbPickupGhostTempFreeze.Location = new System.Drawing.Point(7, 45);
            this.chbPickupGhostTempFreeze.Name = "chbPickupGhostTempFreeze";
            this.chbPickupGhostTempFreeze.Size = new System.Drawing.Size(178, 17);
            this.chbPickupGhostTempFreeze.TabIndex = 1;
            this.chbPickupGhostTempFreeze.Text = "Fruit pickups temp freeze ghosts";
            this.chbPickupGhostTempFreeze.UseVisualStyleBackColor = true;
            // 
            // chbPickupTrackScore
            // 
            this.chbPickupTrackScore.AutoSize = true;
            this.chbPickupTrackScore.Location = new System.Drawing.Point(7, 68);
            this.chbPickupTrackScore.Name = "chbPickupTrackScore";
            this.chbPickupTrackScore.Size = new System.Drawing.Size(83, 17);
            this.chbPickupTrackScore.TabIndex = 2;
            this.chbPickupTrackScore.Text = "Track score";
            this.chbPickupTrackScore.UseVisualStyleBackColor = true;
            // 
            // FormOptions
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(214, 263);
            this.Controls.Add(this.gboxPickups);
            this.Controls.Add(this.gboxGhosts);
            this.Controls.Add(this.gboxPlayer);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.gboxPlayer.ResumeLayout(false);
            this.gboxPlayer.PerformLayout();
            this.gboxGhosts.ResumeLayout(false);
            this.gboxGhosts.PerformLayout();
            this.gboxPickups.ResumeLayout(false);
            this.gboxPickups.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chbGhostFaces;
        private System.Windows.Forms.CheckBox chbPlayerFaces;
        private System.Windows.Forms.GroupBox gboxPlayer;
        private System.Windows.Forms.GroupBox gboxGhosts;
        private System.Windows.Forms.GroupBox gboxPickups;
        private System.Windows.Forms.CheckBox chbPickupTrackScore;
        private System.Windows.Forms.CheckBox chbPickupGhostTempFreeze;
        private System.Windows.Forms.CheckBox chbGhostTrackScore;
        private System.Windows.Forms.CheckBox chbPickupGhostVurneability;
    }
}