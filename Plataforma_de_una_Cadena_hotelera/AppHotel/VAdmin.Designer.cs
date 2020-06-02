namespace AppHotel
{
    partial class VAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VAdmin));
            this.label4 = new System.Windows.Forms.Label();
            this.B_RepSistema = new System.Windows.Forms.Button();
            this.B_CancReserv = new System.Windows.Forms.Button();
            this.B_Hote = new System.Windows.Forms.Button();
            this.B_AgNuevHote = new System.Windows.Forms.Button();
            this.B_Modi = new System.Windows.Forms.Button();
            this.B_regTipoHab = new System.Windows.Forms.Button();
            this.B_RepVent = new System.Windows.Forms.Button();
            this.B_CreaUsuEmp = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.VerStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.verTiposDeHabitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verHotelesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialDelClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.ciudadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ventana de Adimistrador";
            // 
            // B_RepSistema
            // 
            this.B_RepSistema.Location = new System.Drawing.Point(167, 84);
            this.B_RepSistema.Name = "B_RepSistema";
            this.B_RepSistema.Size = new System.Drawing.Size(410, 43);
            this.B_RepSistema.TabIndex = 0;
            this.B_RepSistema.Text = "Reportes del Sistema";
            this.B_RepSistema.UseVisualStyleBackColor = true;
            this.B_RepSistema.Click += new System.EventHandler(this.B_RepSistema_Click);
            // 
            // B_CancReserv
            // 
            this.B_CancReserv.Location = new System.Drawing.Point(167, 133);
            this.B_CancReserv.Name = "B_CancReserv";
            this.B_CancReserv.Size = new System.Drawing.Size(410, 43);
            this.B_CancReserv.TabIndex = 1;
            this.B_CancReserv.Text = "Cancelar Reservaciones";
            this.B_CancReserv.UseVisualStyleBackColor = true;
            this.B_CancReserv.Click += new System.EventHandler(this.B_CancReserv_Click);
            // 
            // B_Hote
            // 
            this.B_Hote.Location = new System.Drawing.Point(167, 182);
            this.B_Hote.Name = "B_Hote";
            this.B_Hote.Size = new System.Drawing.Size(177, 43);
            this.B_Hote.TabIndex = 2;
            this.B_Hote.Text = "Hoteles";
            this.B_Hote.UseVisualStyleBackColor = true;
            this.B_Hote.Click += new System.EventHandler(this.B_Hote_Click);
            // 
            // B_AgNuevHote
            // 
            this.B_AgNuevHote.Location = new System.Drawing.Point(350, 182);
            this.B_AgNuevHote.Name = "B_AgNuevHote";
            this.B_AgNuevHote.Size = new System.Drawing.Size(140, 43);
            this.B_AgNuevHote.TabIndex = 3;
            this.B_AgNuevHote.Text = "Agregar Nuevo Hotel";
            this.B_AgNuevHote.UseVisualStyleBackColor = true;
            this.B_AgNuevHote.Click += new System.EventHandler(this.B_AgNuevHote_Click);
            // 
            // B_Modi
            // 
            this.B_Modi.Location = new System.Drawing.Point(496, 182);
            this.B_Modi.Name = "B_Modi";
            this.B_Modi.Size = new System.Drawing.Size(81, 43);
            this.B_Modi.TabIndex = 4;
            this.B_Modi.Text = "Modificar";
            this.B_Modi.UseVisualStyleBackColor = true;
            this.B_Modi.Click += new System.EventHandler(this.B_Modi_Click);
            // 
            // B_regTipoHab
            // 
            this.B_regTipoHab.Location = new System.Drawing.Point(167, 231);
            this.B_regTipoHab.Name = "B_regTipoHab";
            this.B_regTipoHab.Size = new System.Drawing.Size(410, 43);
            this.B_regTipoHab.TabIndex = 5;
            this.B_regTipoHab.Text = "Registro de tipo de habitación";
            this.B_regTipoHab.UseVisualStyleBackColor = true;
            this.B_regTipoHab.Click += new System.EventHandler(this.B_regTipoHab_Click);
            // 
            // B_RepVent
            // 
            this.B_RepVent.Location = new System.Drawing.Point(167, 280);
            this.B_RepVent.Name = "B_RepVent";
            this.B_RepVent.Size = new System.Drawing.Size(410, 43);
            this.B_RepVent.TabIndex = 6;
            this.B_RepVent.Text = "Reportes de ventas";
            this.B_RepVent.UseVisualStyleBackColor = true;
            this.B_RepVent.Click += new System.EventHandler(this.B_RepVent_Click);
            // 
            // B_CreaUsuEmp
            // 
            this.B_CreaUsuEmp.Location = new System.Drawing.Point(167, 329);
            this.B_CreaUsuEmp.Name = "B_CreaUsuEmp";
            this.B_CreaUsuEmp.Size = new System.Drawing.Size(410, 43);
            this.B_CreaUsuEmp.TabIndex = 7;
            this.B_CreaUsuEmp.Text = "Crear Usuario empleado";
            this.B_CreaUsuEmp.UseVisualStyleBackColor = true;
            this.B_CreaUsuEmp.Click += new System.EventHandler(this.B_CreaUsuEmp_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerStripDropDownButton1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // VerStripDropDownButton1
            // 
            this.VerStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verTiposDeHabitaciónToolStripMenuItem,
            this.verHotelesToolStripMenuItem,
            this.historialDelClienteToolStripMenuItem});
            this.VerStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("VerStripDropDownButton1.Image")));
            this.VerStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.VerStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VerStripDropDownButton1.Name = "VerStripDropDownButton1";
            this.VerStripDropDownButton1.Size = new System.Drawing.Size(103, 22);
            this.VerStripDropDownButton1.Text = "Ver opciones";
            // 
            // verTiposDeHabitaciónToolStripMenuItem
            // 
            this.verTiposDeHabitaciónToolStripMenuItem.Name = "verTiposDeHabitaciónToolStripMenuItem";
            this.verTiposDeHabitaciónToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.verTiposDeHabitaciónToolStripMenuItem.Text = "Ver Tipos de Habitación";
            // 
            // verHotelesToolStripMenuItem
            // 
            this.verHotelesToolStripMenuItem.Name = "verHotelesToolStripMenuItem";
            this.verHotelesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.verHotelesToolStripMenuItem.Text = "Ver Hoteles";
            // 
            // historialDelClienteToolStripMenuItem
            // 
            this.historialDelClienteToolStripMenuItem.Name = "historialDelClienteToolStripMenuItem";
            this.historialDelClienteToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.historialDelClienteToolStripMenuItem.Text = "Historial del Cliente";
            this.historialDelClienteToolStripMenuItem.Click += new System.EventHandler(this.historialDelClienteToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciudadToolStripMenuItem1,
            this.paisToolStripMenuItem1});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(96, 22);
            this.toolStripDropDownButton1.Text = "Registrar otros";
            // 
            // ciudadToolStripMenuItem1
            // 
            this.ciudadToolStripMenuItem1.Name = "ciudadToolStripMenuItem1";
            this.ciudadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.ciudadToolStripMenuItem1.Text = "Ciudad";
            this.ciudadToolStripMenuItem1.Click += new System.EventHandler(this.ciudadToolStripMenuItem1_Click);
            // 
            // paisToolStripMenuItem1
            // 
            this.paisToolStripMenuItem1.Name = "paisToolStripMenuItem1";
            this.paisToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.paisToolStripMenuItem1.Text = "Pais";
            this.paisToolStripMenuItem1.Click += new System.EventHandler(this.paisToolStripMenuItem1_Click);
            // 
            // VAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.B_CreaUsuEmp);
            this.Controls.Add(this.B_RepVent);
            this.Controls.Add(this.B_regTipoHab);
            this.Controls.Add(this.B_Modi);
            this.Controls.Add(this.B_AgNuevHote);
            this.Controls.Add(this.B_Hote);
            this.Controls.Add(this.B_CancReserv);
            this.Controls.Add(this.B_RepSistema);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana de Administrador";
            this.Load += new System.EventHandler(this.VAdmin_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button B_RepSistema;
        private System.Windows.Forms.Button B_CancReserv;
        private System.Windows.Forms.Button B_Hote;
        private System.Windows.Forms.Button B_AgNuevHote;
        private System.Windows.Forms.Button B_Modi;
        private System.Windows.Forms.Button B_regTipoHab;
        private System.Windows.Forms.Button B_RepVent;
        private System.Windows.Forms.Button B_CreaUsuEmp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton VerStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem verTiposDeHabitaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verHotelesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialDelClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem ciudadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem paisToolStripMenuItem1;
    }
}