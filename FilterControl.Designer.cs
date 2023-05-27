namespace ProcesamientoDeImagenes
{
    partial class FilterControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbPreviewBtn_05 = new System.Windows.Forms.PictureBox();
            this.pbPreviewBtn_04 = new System.Windows.Forms.PictureBox();
            this.pbPreviewBtn_03 = new System.Windows.Forms.PictureBox();
            this.pbPreviewBtn_02 = new System.Windows.Forms.PictureBox();
            this.pbPreviewBtn_01 = new System.Windows.Forms.PictureBox();
            this.pbPreviewBtn_00 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHistRGB = new System.Windows.Forms.Label();
            this.pbHist = new System.Windows.Forms.PictureBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnOpenVideo = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.panelVideoControls = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_00)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHist)).BeginInit();
            this.panelVideoControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_aplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aplicar.ForeColor = System.Drawing.Color.DarkGray;
            this.btn_aplicar.Location = new System.Drawing.Point(534, 14);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(82, 87);
            this.btn_aplicar.TabIndex = 2;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.UseVisualStyleBackColor = true;
            this.btn_aplicar.Click += new System.EventHandler(this.btn_aplicar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btn_aplicar);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 340);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbPreviewBtn_05);
            this.panel1.Controls.Add(this.pbPreviewBtn_04);
            this.panel1.Controls.Add(this.pbPreviewBtn_03);
            this.panel1.Controls.Add(this.pbPreviewBtn_02);
            this.panel1.Controls.Add(this.pbPreviewBtn_01);
            this.panel1.Controls.Add(this.pbPreviewBtn_00);
            this.panel1.Location = new System.Drawing.Point(6, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 87);
            this.panel1.TabIndex = 0;
            // 
            // pbPreviewBtn_05
            // 
            this.pbPreviewBtn_05.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbPreviewBtn_05.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewBtn_05.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPreviewBtn_05.Image = global::ProcesamientoDeImagenes.Properties.Resources.girasoles_ExpNoise;
            this.pbPreviewBtn_05.Location = new System.Drawing.Point(435, 0);
            this.pbPreviewBtn_05.Name = "pbPreviewBtn_05";
            this.pbPreviewBtn_05.Padding = new System.Windows.Forms.Padding(5);
            this.pbPreviewBtn_05.Size = new System.Drawing.Size(87, 87);
            this.pbPreviewBtn_05.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewBtn_05.TabIndex = 5;
            this.pbPreviewBtn_05.TabStop = false;
            this.pbPreviewBtn_05.Click += new System.EventHandler(this.pbPreviewBtn_05_Click);
            // 
            // pbPreviewBtn_04
            // 
            this.pbPreviewBtn_04.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbPreviewBtn_04.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewBtn_04.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPreviewBtn_04.Image = global::ProcesamientoDeImagenes.Properties.Resources.girasoles_HistEq;
            this.pbPreviewBtn_04.Location = new System.Drawing.Point(348, 0);
            this.pbPreviewBtn_04.Name = "pbPreviewBtn_04";
            this.pbPreviewBtn_04.Padding = new System.Windows.Forms.Padding(5);
            this.pbPreviewBtn_04.Size = new System.Drawing.Size(87, 87);
            this.pbPreviewBtn_04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewBtn_04.TabIndex = 4;
            this.pbPreviewBtn_04.TabStop = false;
            this.pbPreviewBtn_04.Click += new System.EventHandler(this.pbPreviewBtn_04_Click);
            // 
            // pbPreviewBtn_03
            // 
            this.pbPreviewBtn_03.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbPreviewBtn_03.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewBtn_03.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPreviewBtn_03.Image = global::ProcesamientoDeImagenes.Properties.Resources.girasoles_GaussainBlur;
            this.pbPreviewBtn_03.Location = new System.Drawing.Point(261, 0);
            this.pbPreviewBtn_03.Name = "pbPreviewBtn_03";
            this.pbPreviewBtn_03.Padding = new System.Windows.Forms.Padding(5);
            this.pbPreviewBtn_03.Size = new System.Drawing.Size(87, 87);
            this.pbPreviewBtn_03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewBtn_03.TabIndex = 3;
            this.pbPreviewBtn_03.TabStop = false;
            this.pbPreviewBtn_03.Click += new System.EventHandler(this.pbPreviewBtn_03_Click);
            // 
            // pbPreviewBtn_02
            // 
            this.pbPreviewBtn_02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbPreviewBtn_02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewBtn_02.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPreviewBtn_02.Image = global::ProcesamientoDeImagenes.Properties.Resources.girasoles_invert;
            this.pbPreviewBtn_02.Location = new System.Drawing.Point(174, 0);
            this.pbPreviewBtn_02.Name = "pbPreviewBtn_02";
            this.pbPreviewBtn_02.Padding = new System.Windows.Forms.Padding(5);
            this.pbPreviewBtn_02.Size = new System.Drawing.Size(87, 87);
            this.pbPreviewBtn_02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewBtn_02.TabIndex = 2;
            this.pbPreviewBtn_02.TabStop = false;
            this.pbPreviewBtn_02.Click += new System.EventHandler(this.pbPreviewBtn_02_Click);
            // 
            // pbPreviewBtn_01
            // 
            this.pbPreviewBtn_01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbPreviewBtn_01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewBtn_01.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPreviewBtn_01.Image = global::ProcesamientoDeImagenes.Properties.Resources.girasoles_gray;
            this.pbPreviewBtn_01.Location = new System.Drawing.Point(87, 0);
            this.pbPreviewBtn_01.Name = "pbPreviewBtn_01";
            this.pbPreviewBtn_01.Padding = new System.Windows.Forms.Padding(5);
            this.pbPreviewBtn_01.Size = new System.Drawing.Size(87, 87);
            this.pbPreviewBtn_01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewBtn_01.TabIndex = 1;
            this.pbPreviewBtn_01.TabStop = false;
            this.pbPreviewBtn_01.Click += new System.EventHandler(this.pbPreviewBtn_01_Click);
            // 
            // pbPreviewBtn_00
            // 
            this.pbPreviewBtn_00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pbPreviewBtn_00.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPreviewBtn_00.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPreviewBtn_00.Image = global::ProcesamientoDeImagenes.Properties.Resources.girasoles;
            this.pbPreviewBtn_00.Location = new System.Drawing.Point(0, 0);
            this.pbPreviewBtn_00.Name = "pbPreviewBtn_00";
            this.pbPreviewBtn_00.Padding = new System.Windows.Forms.Padding(5);
            this.pbPreviewBtn_00.Size = new System.Drawing.Size(87, 87);
            this.pbPreviewBtn_00.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreviewBtn_00.TabIndex = 0;
            this.pbPreviewBtn_00.TabStop = false;
            this.pbPreviewBtn_00.Click += new System.EventHandler(this.pbPreviewBtn_00_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblHistRGB);
            this.groupBox2.Controls.Add(this.pbHist);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(642, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 231);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Histograma RGB";
            // 
            // lblHistRGB
            // 
            this.lblHistRGB.AutoSize = true;
            this.lblHistRGB.Location = new System.Drawing.Point(7, 171);
            this.lblHistRGB.Name = "lblHistRGB";
            this.lblHistRGB.Size = new System.Drawing.Size(0, 13);
            this.lblHistRGB.TabIndex = 1;
            // 
            // pbHist
            // 
            this.pbHist.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbHist.Location = new System.Drawing.Point(7, 20);
            this.pbHist.Name = "pbHist";
            this.pbHist.Size = new System.Drawing.Size(168, 144);
            this.pbHist.TabIndex = 0;
            this.pbHist.TabStop = false;
            this.pbHist.Click += new System.EventHandler(this.pbHist_Click);
            this.pbHist.Paint += new System.Windows.Forms.PaintEventHandler(this.pbHist_Paint);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenImage.ForeColor = System.Drawing.Color.DarkGray;
            this.btnOpenImage.Location = new System.Drawing.Point(642, 247);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(181, 37);
            this.btnOpenImage.TabIndex = 5;
            this.btnOpenImage.Text = "Abrir Imagen";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // btnOpenVideo
            // 
            this.btnOpenVideo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnOpenVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenVideo.ForeColor = System.Drawing.Color.DarkGray;
            this.btnOpenVideo.Location = new System.Drawing.Point(642, 354);
            this.btnOpenVideo.Name = "btnOpenVideo";
            this.btnOpenVideo.Size = new System.Drawing.Size(181, 37);
            this.btnOpenVideo.TabIndex = 6;
            this.btnOpenVideo.Text = "Abrir Video";
            this.btnOpenVideo.UseVisualStyleBackColor = true;
            this.btnOpenVideo.Click += new System.EventHandler(this.btnOpenVideo_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Enabled = false;
            this.btnSaveImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.ForeColor = System.Drawing.Color.DarkGray;
            this.btnSaveImage.Location = new System.Drawing.Point(642, 290);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(181, 37);
            this.btnSaveImage.TabIndex = 7;
            this.btnSaveImage.Text = "Guardar Imagen";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.ForeColor = System.Drawing.Color.DarkGray;
            this.btnPlay.Location = new System.Drawing.Point(0, 0);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(292, 22);
            this.btnPlay.TabIndex = 8;
            this.btnPlay.Text = "play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // panelVideoControls
            // 
            this.panelVideoControls.Controls.Add(this.btnStop);
            this.panelVideoControls.Controls.Add(this.btnPlay);
            this.panelVideoControls.Location = new System.Drawing.Point(10, 312);
            this.panelVideoControls.Name = "panelVideoControls";
            this.panelVideoControls.Size = new System.Drawing.Size(620, 22);
            this.panelVideoControls.TabIndex = 10;
            this.panelVideoControls.Visible = false;
            this.panelVideoControls.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.Color.DarkGray;
            this.btnStop.Location = new System.Drawing.Point(292, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(328, 22);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(10, 10);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(620, 300);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.panelVideoControls);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnOpenVideo);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pbPreview);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(844, 450);
            this.Load += new System.EventHandler(this.FilterControl_Load);
            this.Leave += new System.EventHandler(this.FilterControl_Leave);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBtn_00)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHist)).EndInit();
            this.panelVideoControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btn_aplicar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbPreviewBtn_02;
        private System.Windows.Forms.PictureBox pbPreviewBtn_01;
        private System.Windows.Forms.PictureBox pbPreviewBtn_00;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.PictureBox pbPreviewBtn_04;
        private System.Windows.Forms.PictureBox pbPreviewBtn_03;
        private System.Windows.Forms.Button btnOpenVideo;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.PictureBox pbPreviewBtn_05;
        private System.Windows.Forms.PictureBox pbHist;
        private System.Windows.Forms.Label lblHistRGB;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Panel panelVideoControls;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel panel1;
    }
}
