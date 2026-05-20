namespace игра
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox bg1;
        private System.Windows.Forms.PictureBox bg2;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox enemy1;
        private System.Windows.Forms.PictureBox enemy2;
        private System.Windows.Forms.PictureBox fish1;
        private System.Windows.Forms.Label coins;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.Label labalLose;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Timer timer1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bg1 = new System.Windows.Forms.PictureBox();
            this.bg2 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.enemy1 = new System.Windows.Forms.PictureBox();
            this.enemy2 = new System.Windows.Forms.PictureBox();
            this.fish1 = new System.Windows.Forms.PictureBox();
            this.coins = new System.Windows.Forms.Label();
            this.labelRecord = new System.Windows.Forms.Label();
            this.labalLose = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fish1)).BeginInit();
            this.SuspendLayout();

            // bg1
            this.bg1.Location = new System.Drawing.Point(0, 0);
            this.bg1.Size = new System.Drawing.Size(850, 650);
            this.bg1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg1.TabIndex = 0;
            this.bg1.TabStop = false;

            // bg2
            this.bg2.Location = new System.Drawing.Point(0, -650);
            this.bg2.Size = new System.Drawing.Size(850, 650);
            this.bg2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bg2.TabIndex = 1;
            this.bg2.TabStop = false;

            // player
            this.player.Location = new System.Drawing.Point(385, 550);
            this.player.Size = new System.Drawing.Size(80, 60);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.TabIndex = 2;
            this.player.TabStop = false;

            // enemy1
            this.enemy1.Location = new System.Drawing.Point(250, -400);
            this.enemy1.Size = new System.Drawing.Size(50, 50);
            this.enemy1.TabIndex = 3;
            this.enemy1.TabStop = false;

            // enemy2
            this.enemy2.Location = new System.Drawing.Point(400, -130);
            this.enemy2.Size = new System.Drawing.Size(50, 50);
            this.enemy2.TabIndex = 4;
            this.enemy2.TabStop = false;

            // fish1
            this.fish1.Location = new System.Drawing.Point(300, -50);
            this.fish1.Size = new System.Drawing.Size(40, 40);
            this.fish1.TabIndex = 5;
            this.fish1.TabStop = false;

            // coins
            this.coins.AutoSize = true;
            this.coins.BackColor = System.Drawing.Color.Transparent;
            this.coins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.coins.ForeColor = System.Drawing.Color.White;
            this.coins.Location = new System.Drawing.Point(20, 20);
            this.coins.Text = "Рыбки: 0";
            this.coins.TabIndex = 6;

            // labelRecord
            this.labelRecord.AutoSize = true;
            this.labelRecord.BackColor = System.Drawing.Color.Transparent;
            this.labelRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelRecord.ForeColor = System.Drawing.Color.White;
            this.labelRecord.Location = new System.Drawing.Point(150, 20);
            this.labelRecord.Text = "Рекорд: 0";
            this.labelRecord.TabIndex = 7;

            // labalLose
            this.labalLose.AutoSize = true;
            this.labalLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.labalLose.ForeColor = System.Drawing.Color.Red;
            this.labalLose.Location = new System.Drawing.Point(300, 280);
            this.labalLose.Text = "GAME OVER";
            this.labalLose.Visible = false;
            this.labalLose.TabIndex = 8;

            // buttonRestart
            this.buttonRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonRestart.Location = new System.Drawing.Point(350, 350);
            this.buttonRestart.Size = new System.Drawing.Size(150, 50);
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.Visible = false;
            this.buttonRestart.TabIndex = 9;
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);

            // timer1
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // Form1
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.labalLose);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.coins);
            this.Controls.Add(this.fish1);
            this.Controls.Add(this.enemy2);
            this.Controls.Add(this.enemy1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.bg2);
            this.Controls.Add(this.bg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Игра";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.bg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fish1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}