namespace игра
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
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
            this.coins = new System.Windows.Forms.Label();
            this.labelRecord = new System.Windows.Forms.Label();
            this.labalLose = new System.Windows.Forms.Label();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            this.coins.AutoSize = true;
            this.coins.Location = new System.Drawing.Point(20, 20);
            this.coins.Text = "Рыбки: 0";

            this.labelRecord.AutoSize = true;
            this.labelRecord.Location = new System.Drawing.Point(150, 20);
            this.labelRecord.Text = "Рекорд: 0";

            this.labalLose.AutoSize = true;
            this.labalLose.Location = new System.Drawing.Point(350, 300);
            this.labalLose.Text = "GAME OVER";
            this.labalLose.Visible = false;

            this.buttonRestart.Location = new System.Drawing.Point(370, 350);
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.Visible = false;

            this.timer1.Interval = 20;
            this.timer1.Enabled = true;

            this.ClientSize = new System.Drawing.Size(850, 650);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.coins);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.labalLose);
            this.Controls.Add(this.buttonRestart);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}