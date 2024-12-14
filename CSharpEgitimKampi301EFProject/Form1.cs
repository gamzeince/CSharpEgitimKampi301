using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
         
            var values = db.Guide_Tb.ToList();

            dataGridView1.DataSource = values;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide_Tb guide = new Guide_Tb();    
            guide.GuideName  = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            db.Guide_Tb.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Kaydedildi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var removeValue = db.Guide_Tb.Find(id);
            db.Guide_Tb.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Silindi");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Guide_Tb.Find(id);

            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber Başarıyla Güncellendi" , "Uyarı" , MessageBoxButtons.OK, MessageBoxIcon.Warning);



        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guide_Tb.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
