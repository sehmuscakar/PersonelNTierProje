using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using LogicLayer;
namespace OOPNTierDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlisttele_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> PerList = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = PerList;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent=new EntityPersonel();
            ent.Adı = txtad.Text;
            ent.Soyadı = txtsoyad.Text;
            ent.Sehir = txtsehir.Text;
          //  ent.Maas = Convert.ToInt16(txtmaas.Text);
            ent.Maas = short.Parse(txtmaas.Text);
            ent.Gorev= txtgorev.Text;
            LogicPersonel.LLPersonelEkle(ent);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            EntityPersonel ent =new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
            LogicPersonel.LLPersonelSil(ent.Id);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Id = Convert.ToInt32(textBox1.Text);
           ent.Adı=txtad.Text;
           ent.Soyadı=txtsoyad.Text;
           ent.Sehir=txtsehir.Text;
           ent.Gorev=txtgorev.Text;
           ent.Maas=Convert.ToInt16(txtmaas.Text);
            LogicPersonel.LLPersonelGuncelle(ent);

        }
    }
}
