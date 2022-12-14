using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class FormHozzaadas : Form
    {
        public FormHozzaadas()
        {
            InitializeComponent();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex r = new Regex("[0-9]");

            if (!r.IsMatch(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Mennyiségnek számot adj meg!");
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
