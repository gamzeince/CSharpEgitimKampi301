using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301EFProject
{
    public partial class lblMustafinceLocationCount : Form
    {
        public lblMustafinceLocationCount()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
           
            lblLocationCount.Text = db.Location_Tb.Count().ToString();
            lblSumCapacity.Text = db.Location_Tb.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide_Tb.Count().ToString();
            lblAvgCapacity.Text = db.Location_Tb.Average(x => x.Capacity).ToString();

            var averagePrice = db.Location_Tb.Average(x => (double)x.Price);
            lblAvgLocationPrice.Text = averagePrice.ToString("F2") + " TL";

            int lastCountryId = db.Location_Tb.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location_Tb.Where(x => x.LocationId == lastCountryId).Select( y=> y.Country).FirstOrDefault();

            lblCappadociaLocationCapaticy.Text = db.Location_Tb.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeAvgCapacity.Text = db.Location_Tb.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();

            var parisGuideID = db.Location_Tb.Where(x => x.City == "Lyon - Paris").Select(y => y.GuideId).FirstOrDefault();
            lblParisGuideName.Text = db.Guide_Tb.Where(x => x.GuideId == parisGuideID).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location_Tb.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location_Tb.Where(x => x.Capacity == maxCapacity).Select(y => y.City).FirstOrDefault().ToString();


            var maxPrice = db.Location_Tb.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location_Tb.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();


            var guidedIdByNameMustafa = db.Guide_Tb.Where(x=> x.GuideName == "Mustafa" && x.GuideSurname == "İnce").Select
                (y=> y.GuideId).FirstOrDefault();

            lblMustafaLocationCount.Text = db.Location_Tb.Where(x=> x.GuideId == guidedIdByNameMustafa).Count().ToString();

        }

        private void lblMaxCapacityLocation_Click(object sender, EventArgs e)
        {

        }
    }
}
