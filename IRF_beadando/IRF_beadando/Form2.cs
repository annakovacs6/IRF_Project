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
	public partial class Form2 : Form
	{
		Database1Entities4 context = new Database1Entities4();
		Felhasznalo felhasznalo;
		public Form2(Felhasznalo bejelentkezettFelhasznalo)
		{
			InitializeComponent();

			this.felhasznalo = bejelentkezettFelhasznalo;
		}
	}
}
