namespace ProcesamientoDeImagenes
{
    partial class WebcamControl
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
            this.components = new System.ComponentModel.Container();
            this.WebCamView_PB = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_device = new System.Windows.Forms.Button();
            this.TimerUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnShutDown = new System.Windows.Forms.Button();
            this.DetectedFace_PB = new System.Windows.Forms.PictureBox();
            this.DetectBtn = new System.Windows.Forms.Button();
            this.lblStatic01 = new System.Windows.Forms.Label();
            this.lblPersonasCount = new System.Windows.Forms.Label();
            this.TextB_Nombre = new System.Windows.Forms.TextBox();
            this.btnAgregarPersona = new System.Windows.Forms.Button();
            this.FacePB1 = new System.Windows.Forms.PictureBox();
            this.FacePB2 = new System.Windows.Forms.PictureBox();
            this.groupFaceDetection = new System.Windows.Forms.GroupBox();
            this.lblFaceText01 = new System.Windows.Forms.Label();
            this.btnStopCompare = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WebCamView_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedFace_PB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePB2)).BeginInit();
            this.groupFaceDetection.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebCamView_PB
            // 
            this.WebCamView_PB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebCamView_PB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.WebCamView_PB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WebCamView_PB.Location = new System.Drawing.Point(10, 33);
            this.WebCamView_PB.Margin = new System.Windows.Forms.Padding(0);
            this.WebCamView_PB.Name = "WebCamView_PB";
            this.WebCamView_PB.Size = new System.Drawing.Size(570, 310);
            this.WebCamView_PB.TabIndex = 1;
            this.WebCamView_PB.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Camara";
            // 
            // btn_device
            // 
            this.btn_device.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_device.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_device.ForeColor = System.Drawing.Color.DarkGray;
            this.btn_device.Location = new System.Drawing.Point(10, 356);
            this.btn_device.Name = "btn_device";
            this.btn_device.Size = new System.Drawing.Size(119, 34);
            this.btn_device.TabIndex = 3;
            this.btn_device.Text = "Encender Camara";
            this.btn_device.UseVisualStyleBackColor = true;
            this.btn_device.Click += new System.EventHandler(this.btn_device_Click);
            // 
            // TimerUpdate
            // 
            this.TimerUpdate.Interval = 1000;
            this.TimerUpdate.Tick += new System.EventHandler(this.TimerUpdate_Tick);
            // 
            // btnShutDown
            // 
            this.btnShutDown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnShutDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShutDown.ForeColor = System.Drawing.Color.DarkGray;
            this.btnShutDown.Location = new System.Drawing.Point(133, 356);
            this.btnShutDown.Name = "btnShutDown";
            this.btnShutDown.Size = new System.Drawing.Size(119, 34);
            this.btnShutDown.TabIndex = 7;
            this.btnShutDown.Text = "Apagar Camara";
            this.btnShutDown.UseVisualStyleBackColor = true;
            this.btnShutDown.Click += new System.EventHandler(this.btnShutDown_Click);
            // 
            // DetectedFace_PB
            // 
            this.DetectedFace_PB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DetectedFace_PB.Image = global::ProcesamientoDeImagenes.Properties.Resources.placeholder;
            this.DetectedFace_PB.Location = new System.Drawing.Point(6, 19);
            this.DetectedFace_PB.Name = "DetectedFace_PB";
            this.DetectedFace_PB.Size = new System.Drawing.Size(113, 92);
            this.DetectedFace_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DetectedFace_PB.TabIndex = 8;
            this.DetectedFace_PB.TabStop = false;
            // 
            // DetectBtn
            // 
            this.DetectBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.DetectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetectBtn.ForeColor = System.Drawing.Color.DarkGray;
            this.DetectBtn.Location = new System.Drawing.Point(10, 396);
            this.DetectBtn.Name = "DetectBtn";
            this.DetectBtn.Size = new System.Drawing.Size(242, 34);
            this.DetectBtn.TabIndex = 9;
            this.DetectBtn.Text = "Detectar Rostro";
            this.DetectBtn.UseVisualStyleBackColor = true;
            this.DetectBtn.Click += new System.EventHandler(this.DetectBtn_Click);
            // 
            // lblStatic01
            // 
            this.lblStatic01.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatic01.AutoSize = true;
            this.lblStatic01.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblStatic01.Location = new System.Drawing.Point(128, 19);
            this.lblStatic01.Name = "lblStatic01";
            this.lblStatic01.Size = new System.Drawing.Size(110, 13);
            this.lblStatic01.TabIndex = 10;
            this.lblStatic01.Text = "Personas detectadas:";
            // 
            // lblPersonasCount
            // 
            this.lblPersonasCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPersonasCount.AutoSize = true;
            this.lblPersonasCount.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblPersonasCount.Location = new System.Drawing.Point(128, 42);
            this.lblPersonasCount.Name = "lblPersonasCount";
            this.lblPersonasCount.Size = new System.Drawing.Size(13, 13);
            this.lblPersonasCount.TabIndex = 11;
            this.lblPersonasCount.Text = "0";
            // 
            // TextB_Nombre
            // 
            this.TextB_Nombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TextB_Nombre.Location = new System.Drawing.Point(123, 58);
            this.TextB_Nombre.Name = "TextB_Nombre";
            this.TextB_Nombre.Size = new System.Drawing.Size(113, 20);
            this.TextB_Nombre.TabIndex = 12;
            // 
            // btnAgregarPersona
            // 
            this.btnAgregarPersona.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregarPersona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAgregarPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPersona.ForeColor = System.Drawing.Color.DarkGray;
            this.btnAgregarPersona.Location = new System.Drawing.Point(123, 84);
            this.btnAgregarPersona.Name = "btnAgregarPersona";
            this.btnAgregarPersona.Size = new System.Drawing.Size(113, 26);
            this.btnAgregarPersona.TabIndex = 13;
            this.btnAgregarPersona.Text = "Agregar Persona";
            this.btnAgregarPersona.UseVisualStyleBackColor = true;
            this.btnAgregarPersona.Click += new System.EventHandler(this.btnAgregarPersona_Click);
            // 
            // FacePB1
            // 
            this.FacePB1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FacePB1.Image = global::ProcesamientoDeImagenes.Properties.Resources.placeholder;
            this.FacePB1.Location = new System.Drawing.Point(8, 306);
            this.FacePB1.Name = "FacePB1";
            this.FacePB1.Size = new System.Drawing.Size(113, 92);
            this.FacePB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FacePB1.TabIndex = 14;
            this.FacePB1.TabStop = false;
            this.FacePB1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FacePB2
            // 
            this.FacePB2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FacePB2.Image = global::ProcesamientoDeImagenes.Properties.Resources.placeholder;
            this.FacePB2.Location = new System.Drawing.Point(125, 306);
            this.FacePB2.Name = "FacePB2";
            this.FacePB2.Size = new System.Drawing.Size(113, 92);
            this.FacePB2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FacePB2.TabIndex = 15;
            this.FacePB2.TabStop = false;
            this.FacePB2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // groupFaceDetection
            // 
            this.groupFaceDetection.Controls.Add(this.label3);
            this.groupFaceDetection.Controls.Add(this.label1);
            this.groupFaceDetection.Controls.Add(this.lblFaceText01);
            this.groupFaceDetection.Controls.Add(this.btnStopCompare);
            this.groupFaceDetection.Controls.Add(this.btnCompare);
            this.groupFaceDetection.Controls.Add(this.FacePB1);
            this.groupFaceDetection.Controls.Add(this.btnAgregarPersona);
            this.groupFaceDetection.Controls.Add(this.FacePB2);
            this.groupFaceDetection.Controls.Add(this.TextB_Nombre);
            this.groupFaceDetection.Controls.Add(this.DetectedFace_PB);
            this.groupFaceDetection.Controls.Add(this.lblPersonasCount);
            this.groupFaceDetection.Controls.Add(this.lblStatic01);
            this.groupFaceDetection.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupFaceDetection.Location = new System.Drawing.Point(589, 26);
            this.groupFaceDetection.Name = "groupFaceDetection";
            this.groupFaceDetection.Size = new System.Drawing.Size(242, 404);
            this.groupFaceDetection.TabIndex = 16;
            this.groupFaceDetection.TabStop = false;
            this.groupFaceDetection.Text = "Deteccion de rostros";
            // 
            // lblFaceText01
            // 
            this.lblFaceText01.AutoSize = true;
            this.lblFaceText01.Location = new System.Drawing.Point(5, 262);
            this.lblFaceText01.Name = "lblFaceText01";
            this.lblFaceText01.Size = new System.Drawing.Size(123, 13);
            this.lblFaceText01.TabIndex = 18;
            this.lblFaceText01.Text = "Comparacion de Rostros";
            // 
            // btnStopCompare
            // 
            this.btnStopCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStopCompare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnStopCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopCompare.ForeColor = System.Drawing.Color.DarkGray;
            this.btnStopCompare.Location = new System.Drawing.Point(4, 164);
            this.btnStopCompare.Name = "btnStopCompare";
            this.btnStopCompare.Size = new System.Drawing.Size(232, 26);
            this.btnStopCompare.TabIndex = 17;
            this.btnStopCompare.Text = "Detener Comparacion";
            this.btnStopCompare.UseVisualStyleBackColor = true;
            this.btnStopCompare.Click += new System.EventHandler(this.btnStopCompare_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCompare.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.ForeColor = System.Drawing.Color.DarkGray;
            this.btnCompare.Location = new System.Drawing.Point(4, 132);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(232, 26);
            this.btnCompare.TabIndex = 16;
            this.btnCompare.Text = "Comparar Rostros";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Deteccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Etiquetado";
            // 
            // WebcamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.groupFaceDetection);
            this.Controls.Add(this.DetectBtn);
            this.Controls.Add(this.btnShutDown);
            this.Controls.Add(this.btn_device);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WebCamView_PB);
            this.Name = "WebcamControl";
            this.Size = new System.Drawing.Size(844, 450);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WebCamView_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetectedFace_PB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacePB2)).EndInit();
            this.groupFaceDetection.ResumeLayout(false);
            this.groupFaceDetection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox WebCamView_PB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_device;
        private System.Windows.Forms.Timer TimerUpdate;
        private System.Windows.Forms.Button btnShutDown;
        private System.Windows.Forms.PictureBox DetectedFace_PB;
        private System.Windows.Forms.Button DetectBtn;
        private System.Windows.Forms.Label lblStatic01;
        private System.Windows.Forms.Label lblPersonasCount;
        private System.Windows.Forms.TextBox TextB_Nombre;
        private System.Windows.Forms.Button btnAgregarPersona;
        private System.Windows.Forms.PictureBox FacePB1;
        private System.Windows.Forms.PictureBox FacePB2;
        private System.Windows.Forms.GroupBox groupFaceDetection;
        private System.Windows.Forms.Label lblFaceText01;
        private System.Windows.Forms.Button btnStopCompare;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
