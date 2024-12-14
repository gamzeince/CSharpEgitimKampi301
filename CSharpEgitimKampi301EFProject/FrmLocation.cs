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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Location_Tb.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updateValue = db.Location_Tb.Find(id);
            updateValue.DayNight = txtDayNight.Text;
            updateValue.Price = decimal.Parse(txtPrice.Text);
            updateValue.Capacity = byte.Parse(nudCapacity.Value.ToString());
            updateValue.City = txtCity.Text;
            updateValue.Country = txtCountry.Text;
            updateValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            MessageBox.Show("Başarıyla Güncellendi");


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deleteValue = db.Location_Tb.Find(id);
            db.Location_Tb.Remove(deleteValue);
            db.SaveChanges();
            MessageBox.Show("Başarıyla Silindi");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location_Tb location = new Location_Tb();
            location.Capacity = byte.Parse( nudCapacity.Value.ToString());
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location_Tb.Add(location);
            db.SaveChanges();
            MessageBox.Show("Başarıyla Eklendi");
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.Guide_Tb.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();


            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values ;

        }
    }
}
