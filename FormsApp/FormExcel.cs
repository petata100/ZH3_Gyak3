using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class FormExcel : Form
    {
        public FormExcel()
        {
            InitializeComponent();

            UserControl uc = new ucExcel();
            panel1.Controls.Add(uc);
            panel1.Dock = DockStyle.Fill;
            uc.Dock = DockStyle.Fill;
        }
    }
}
