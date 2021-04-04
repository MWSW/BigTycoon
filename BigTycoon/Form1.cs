using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigTycoon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region IconaPlus_AggiungiEdificio
        private void OnMouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.plus;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).BackgroundImage = Properties.Resources.cella_vuota;
        }
        #endregion
    }
}
