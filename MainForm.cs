using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesamientoDeImagenes
{

    public partial class MainForm : Form
    {
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        UserControl Panel;
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Panel != null) Panel.Dispose();
            Panel = new FilterControl();
            UC_panel.Controls.Add(Panel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Panel != null) Panel.Dispose();
            Panel = new WebcamControl();
            UC_panel.Controls.Add(Panel);
        }

        private void btn_FaceDetect_Click(object sender, EventArgs e)
        {
            if (Panel != null) Panel.Dispose();
            Panel = new FaceDetectionControl();
            UC_panel.Controls.Add(Panel);
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Window_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void winbtn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void winbtn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Panel != null) Panel.Dispose();
            Panel = new FilterControl();
            UC_panel.Controls.Add(Panel);
        }
    }
}
