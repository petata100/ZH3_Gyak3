namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bAdatok_Click(object sender, EventArgs e)
        {
            FormAdatok form = new();
            form.ShowDialog();
        }

        private void bExcel_Click(object sender, EventArgs e)
        {
            FormExcel form = new();
            form.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Biztos kilépsz", "megerõsítés", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}