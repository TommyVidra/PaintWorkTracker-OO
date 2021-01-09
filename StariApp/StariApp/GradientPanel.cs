using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace StariApp
{
    public partial class GradientPanel : UserControl
    {
        public Color FirstColor { get; set; }
        public Color SecondColor { get; set; }
        public float Angle { get; set; }
        public GradientPanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this.FirstColor, this.SecondColor, this.Angle);
            Graphics g = pe.Graphics;
            g.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(pe);
        }
    }
}