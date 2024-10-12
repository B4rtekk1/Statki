namespace statki
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            lblInfAre = new Label();
            btnAva = new Button();
            btnHit = new Button();
            btnSun = new Button();
            btnBlo = new Button();
            lblAva = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblInfo = new Label();
            SuspendLayout();
            // 
            // lblInfAre
            // 
            lblInfAre.AutoSize = true;
            lblInfAre.Location = new Point(487, 9);
            lblInfAre.Name = "lblInfAre";
            lblInfAre.Size = new Size(52, 20);
            lblInfAre.TabIndex = 0;
            lblInfAre.Text = "Kolory";
            // 
            // btnAva
            // 
            btnAva.BackColor = Color.LightBlue;
            btnAva.FlatAppearance.BorderSize = 0;
            btnAva.FlatStyle = FlatStyle.Flat;
            btnAva.Location = new Point(487, 57);
            btnAva.Name = "btnAva";
            btnAva.Size = new Size(25, 25);
            btnAva.TabIndex = 1;
            btnAva.UseVisualStyleBackColor = false;
            // 
            // btnHit
            // 
            btnHit.BackColor = Color.Yellow;
            btnHit.FlatAppearance.BorderSize = 0;
            btnHit.FlatStyle = FlatStyle.Flat;
            btnHit.Location = new Point(487, 88);
            btnHit.Name = "btnHit";
            btnHit.Size = new Size(25, 25);
            btnHit.TabIndex = 2;
            btnHit.UseVisualStyleBackColor = false;
            // 
            // btnSun
            // 
            btnSun.BackColor = Color.Red;
            btnSun.FlatAppearance.BorderSize = 0;
            btnSun.FlatStyle = FlatStyle.Flat;
            btnSun.Location = new Point(487, 119);
            btnSun.Name = "btnSun";
            btnSun.Size = new Size(25, 25);
            btnSun.TabIndex = 3;
            btnSun.UseVisualStyleBackColor = false;
            // 
            // btnBlo
            // 
            btnBlo.BackColor = Color.Gray;
            btnBlo.FlatAppearance.BorderSize = 0;
            btnBlo.FlatStyle = FlatStyle.Flat;
            btnBlo.Location = new Point(487, 150);
            btnBlo.Name = "btnBlo";
            btnBlo.Size = new Size(25, 25);
            btnBlo.TabIndex = 4;
            btnBlo.UseVisualStyleBackColor = false;
            // 
            // lblAva
            // 
            lblAva.AutoSize = true;
            lblAva.Location = new Point(518, 59);
            lblAva.Name = "lblAva";
            lblAva.Size = new Size(107, 20);
            lblAva.TabIndex = 5;
            lblAva.Text = "Dostępne pole";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(518, 88);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 6;
            label2.Text = "Statek trafiony";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(518, 124);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 7;
            label3.Text = "Kolory";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(518, 155);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 8;
            label4.Text = "Kolory";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(36, 88);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(340, 40);
            lblInfo.TabIndex = 9;
            lblInfo.Text = "Zaczyna gracz. Ruchy wykonywane na zmiane.\r\nPo trafionym statku gracz/bot ma dodatkowy ruch";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 260);
            Controls.Add(lblInfo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblAva);
            Controls.Add(btnBlo);
            Controls.Add(btnSun);
            Controls.Add(btnHit);
            Controls.Add(btnAva);
            Controls.Add(lblInfAre);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form2";
            Text = "Jak grać?";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfAre;
        private Button btnAva;
        private Button btnHit;
        private Button btnSun;
        private Button btnBlo;
        private Label lblAva;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblInfo;
    }
}