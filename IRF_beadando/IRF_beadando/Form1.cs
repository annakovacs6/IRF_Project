using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_beadando
{
	public partial class Form1 : Form
	{
		Database1Entities5 context = new Database1Entities5();
		List<Felhasznalo> Felhasznalos;
		
		public Form1()
		{
			InitializeComponent();
			Felhasznalos = context.Felhasznalo.ToList();
			
		}

		private void btnBelep_Click(object sender, EventArgs e)
		{
			var felhasznalo = (from x in Felhasznalos
							   where txtFelhasznalonev.Text == x.FELH_NEV
							   select x).FirstOrDefault();

			if (felhasznalo != null)
			{
				if (txtFutoazonosito.Text == felhasznalo.FUTO_AZONOSITO)
				{
					Form2 f2 = new Form2(felhasznalo);
					f2.Show();
				}
				else
				{
					MessageBox.Show("Hibás futóazonosító");
				}
			}
			else
			{
				MessageBox.Show("Hibás felhasználónév");
			}
		}
	}
}
