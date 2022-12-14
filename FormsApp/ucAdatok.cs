using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormsApp.Models;

namespace FormsApp
{
    public partial class ucAdatok : UserControl
    {
        ReceptContext context = new();

        public ucAdatok()
        {
            InitializeComponent();
            GetFogasok();
            GetNyersanyagok();
        }

        public void GetFogasok()
        {
            var fogasok = from x in context.Fogasok
                          where x.FogasNev.Contains(textBox1.Text)
                          select x;

            listBox1.DisplayMember = "FogasNev";
            listBox1.DataSource = fogasok.ToList();
        }

        public void GetReceptek()
        {
            Fogasok selectedFogas = (Fogasok)listBox1.SelectedItem;

            var receptek = from x in context.Receptek
                           where x.FogasId == selectedFogas.FogasId
                           select new Recept
                           {
                               ReceptId = x.ReceptId,
                               Nyersanyag = x.Nyersanyag.NyersanyagNev,
                               Mennyiség = x.Mennyiseg4fo,
                               Megység = x.Nyersanyag.MennyisegiEgyseg.EgysegNev
                           };

            receptBindingSource.DataSource = receptek.ToList();
        }

        public void GetNyersanyagok()
        {
            var nyersanyagok = from x in context.Nyersanyagok
                               where x.NyersanyagNev.Contains(textBox2.Text)
                               select x;

            listBox2.DisplayMember = "NyersanyagNev";
            listBox2.DataSource = nyersanyagok.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GetFogasok();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            GetNyersanyagok();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetReceptek();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Fogasok selectedFogas = (Fogasok)listBox1.SelectedItem;
            Nyersanyagok selectedNyersanyag = (Nyersanyagok)listBox2.SelectedItem;

            FormHozzaadas form = new();

            if (form.ShowDialog() == DialogResult.OK)
            {
                Receptek ujRecept = new();
                ujRecept.FogasId = selectedFogas.FogasId;
                ujRecept.NyersanyagId = selectedNyersanyag.NyersanyagId;
                ujRecept.Mennyiseg4fo = double.Parse(form.textBox1.Text);

                try
                {
                    context.Receptek.Add(ujRecept);
                    context.SaveChanges();
                    GetReceptek();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            int torlendoId = ((Recept)receptBindingSource.Current).ReceptId;

            var torlendoRecept = (from x in context.Receptek
                                  where x.ReceptId == torlendoId
                                  select x).FirstOrDefault();

            if (MessageBox.Show("Biztos törlöd?", "megerősítés", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            try
            {
                context.Receptek.Remove(torlendoRecept);
                context.SaveChanges();
                GetReceptek();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
