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
    public partial class FormTrasporti : Form
    {
        public FormTrasporti()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            //Impedisce la distruzione dell'oggetto
            this.Hide();
            e.Cancel = true;
        }
    }
}
