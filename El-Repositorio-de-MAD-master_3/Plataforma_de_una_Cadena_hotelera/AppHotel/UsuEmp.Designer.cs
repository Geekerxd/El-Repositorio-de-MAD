﻿namespace AppHotel
{
    partial class UsuEmp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuEmp));
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Ver2StripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.B_HacReservación = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_CheckIn = new System.Windows.Forms.Button();
            this.B_CheckOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(23, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Usuario Empleado.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ver2StripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Ver2StripSplitButton1
            // 
            this.Ver2StripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.Ver2StripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("Ver2StripSplitButton1.Image")));
            this.Ver2StripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ver2StripSplitButton1.Name = "Ver2StripSplitButton1";
            this.Ver2StripSplitButton1.Size = new System.Drawing.Size(106, 22);
            this.Ver2StripSplitButton1.Text = "Ver Acciones";
            // 
            // B_HacReservación
            // 
            this.B_HacReservación.Location = new System.Drawing.Point(84, 101);
            this.B_HacReservación.Name = "B_HacReservación";
            this.B_HacReservación.Size = new System.Drawing.Size(339, 43);
            this.B_HacReservación.TabIndex = 0;
            this.B_HacReservación.Text = "Hacer Reservación";
            this.B_HacReservación.UseVisualStyleBackColor = true;
            this.B_HacReservación.Click += new System.EventHandler(this.B_HacReservación_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(339, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alta a Cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(74, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 121);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // B_CheckIn
            // 
            this.B_CheckIn.Location = new System.Drawing.Point(84, 223);
            this.B_CheckIn.Name = "B_CheckIn";
            this.B_CheckIn.Size = new System.Drawing.Size(339, 43);
            this.B_CheckIn.TabIndex = 2;
            this.B_CheckIn.Text = "Check In";
            this.B_CheckIn.UseVisualStyleBackColor = true;
            this.B_CheckIn.Click += new System.EventHandler(this.B_CheckIn_Click);
            // 
            // B_CheckOut
            // 
            this.B_CheckOut.Location = new System.Drawing.Point(84, 272);
            this.B_CheckOut.Name = "B_CheckOut";
            this.B_CheckOut.Size = new System.Drawing.Size(339, 43);
            this.B_CheckOut.TabIndex = 3;
            this.B_CheckOut.Text = "Check Out";
            this.B_CheckOut.UseVisualStyleBackColor = true;
            this.B_CheckOut.Click += new System.EventHandler(this.B_CheckOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(563, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = ".";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "...";
            // 
            // UsuEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_CheckOut);
            this.Controls.Add(this.B_CheckIn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.B_HacReservación);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Name = "UsuEmp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsuEmp";
            this.Load += new System.EventHandler(this.UsuEmp_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton Ver2StripSplitButton1;
        private System.Windows.Forms.Button B_HacReservación;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_CheckIn;
        private System.Windows.Forms.Button B_CheckOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}