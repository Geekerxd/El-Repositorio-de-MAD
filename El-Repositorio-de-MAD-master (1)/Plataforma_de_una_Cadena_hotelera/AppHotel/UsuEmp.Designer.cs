namespace AppHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuEmp));
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Ver2StripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.cancelarReservaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeOcupaciónPorHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.B_HacReservación = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_CheckIn = new System.Windows.Forms.Button();
            this.B_CheckOut = new System.Windows.Forms.Button();
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
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Ver2StripSplitButton1
            // 
            this.Ver2StripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelarReservaciónToolStripMenuItem,
            this.reporteDeOcupaciónPorHotelToolStripMenuItem});
            this.Ver2StripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("Ver2StripSplitButton1.Image")));
            this.Ver2StripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ver2StripSplitButton1.Name = "Ver2StripSplitButton1";
            this.Ver2StripSplitButton1.Size = new System.Drawing.Size(106, 22);
            this.Ver2StripSplitButton1.Text = "Ver Acciones";
            // 
            // cancelarReservaciónToolStripMenuItem
            // 
            this.cancelarReservaciónToolStripMenuItem.Name = "cancelarReservaciónToolStripMenuItem";
            this.cancelarReservaciónToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.cancelarReservaciónToolStripMenuItem.Text = "Cancelar Reservación";
            // 
            // reporteDeOcupaciónPorHotelToolStripMenuItem
            // 
            this.reporteDeOcupaciónPorHotelToolStripMenuItem.Name = "reporteDeOcupaciónPorHotelToolStripMenuItem";
            this.reporteDeOcupaciónPorHotelToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.reporteDeOcupaciónPorHotelToolStripMenuItem.Text = "Reporte de Ocupación por Hotel";
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
            this.groupBox1.TabIndex = 4;
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
            // 
            // B_CheckOut
            // 
            this.B_CheckOut.Location = new System.Drawing.Point(84, 272);
            this.B_CheckOut.Name = "B_CheckOut";
            this.B_CheckOut.Size = new System.Drawing.Size(339, 43);
            this.B_CheckOut.TabIndex = 3;
            this.B_CheckOut.Text = "Check Out";
            this.B_CheckOut.UseVisualStyleBackColor = true;
            // 
            // UsuEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton Ver2StripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem cancelarReservaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeOcupaciónPorHotelToolStripMenuItem;
        private System.Windows.Forms.Button B_HacReservación;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_CheckIn;
        private System.Windows.Forms.Button B_CheckOut;
    }
}