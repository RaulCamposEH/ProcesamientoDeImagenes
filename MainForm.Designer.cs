namespace ProcesamientoDeImagenes
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel5 = new System.Windows.Forms.Panel();
            this.winbtn_exit = new System.Windows.Forms.Button();
            this.winbtn_min = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Captures = new System.Windows.Forms.Button();
            this.btn_Filters = new System.Windows.Forms.Button();
            this.UC_panel = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Controls.Add(this.winbtn_exit);
            this.panel5.Controls.Add(this.winbtn_min);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(920, 50);
            this.panel5.TabIndex = 3;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            this.panel5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Window_MouseUp);
            // 
            // winbtn_exit
            // 
            this.winbtn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.winbtn_exit.BackColor = System.Drawing.Color.IndianRed;
            this.winbtn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winbtn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winbtn_exit.Location = new System.Drawing.Point(878, 13);
            this.winbtn_exit.Name = "winbtn_exit";
            this.winbtn_exit.Size = new System.Drawing.Size(30, 23);
            this.winbtn_exit.TabIndex = 2;
            this.winbtn_exit.UseVisualStyleBackColor = false;
            this.winbtn_exit.Click += new System.EventHandler(this.winbtn_exit_Click);
            // 
            // winbtn_min
            // 
            this.winbtn_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.winbtn_min.BackColor = System.Drawing.Color.DarkKhaki;
            this.winbtn_min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winbtn_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winbtn_min.Location = new System.Drawing.Point(842, 13);
            this.winbtn_min.Name = "winbtn_min";
            this.winbtn_min.Size = new System.Drawing.Size(30, 23);
            this.winbtn_min.TabIndex = 0;
            this.winbtn_min.UseVisualStyleBackColor = false;
            this.winbtn_min.Click += new System.EventHandler(this.winbtn_min_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atomic Filters";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openfiledialog";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel1.Controls.Add(this.btn_Captures);
            this.panel1.Controls.Add(this.btn_Filters);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 450);
            this.panel1.TabIndex = 4;
            // 
            // btn_Captures
            // 
            this.btn_Captures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Captures.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Captures.FlatAppearance.BorderSize = 0;
            this.btn_Captures.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btn_Captures.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Captures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Captures.ForeColor = System.Drawing.Color.Silver;
            this.btn_Captures.Location = new System.Drawing.Point(0, 60);
            this.btn_Captures.Name = "btn_Captures";
            this.btn_Captures.Size = new System.Drawing.Size(76, 60);
            this.btn_Captures.TabIndex = 1;
            this.btn_Captures.Text = "Camara";
            this.btn_Captures.UseVisualStyleBackColor = false;
            this.btn_Captures.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Filters
            // 
            this.btn_Filters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_Filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Filters.FlatAppearance.BorderSize = 0;
            this.btn_Filters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btn_Filters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Filters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Filters.ForeColor = System.Drawing.Color.Silver;
            this.btn_Filters.Location = new System.Drawing.Point(0, 0);
            this.btn_Filters.Name = "btn_Filters";
            this.btn_Filters.Size = new System.Drawing.Size(76, 60);
            this.btn_Filters.TabIndex = 0;
            this.btn_Filters.Text = "Filtros";
            this.btn_Filters.UseVisualStyleBackColor = false;
            this.btn_Filters.Click += new System.EventHandler(this.button1_Click);
            // 
            // UC_panel
            // 
            this.UC_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UC_panel.Location = new System.Drawing.Point(76, 50);
            this.UC_panel.Name = "UC_panel";
            this.UC_panel.Size = new System.Drawing.Size(844, 450);
            this.UC_panel.TabIndex = 6;
            this.UC_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.UC_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Window_MouseMove);
            this.UC_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Window_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(920, 500);
            this.Controls.Add(this.UC_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Captures;
        private System.Windows.Forms.Button btn_Filters;
        private System.Windows.Forms.Panel UC_panel;
        private System.Windows.Forms.Button winbtn_exit;
        private System.Windows.Forms.Button winbtn_min;
    }
}

