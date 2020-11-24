using IRF_beadando.Entities;
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

		private List<Futo> _futos = new List<Futo>();

		private FutoAnimacio _animacio;
		public FutoAnimacio Animacio
		{
			get { return _animacio; }
			set { _animacio = value; }
		}
		public Form2(Felhasznalo bejelentkezettFelhasznalo)
		{
			InitializeComponent();
			Animacio = new FutoAnimacio();
			this.felhasznalo = bejelentkezettFelhasznalo;
		}

		private void createTimer_Tick(object sender, EventArgs e)
		{
			var futo = Animacio.CreateNew();
			_futos.Add(futo);
			futo.Left = -futo.Width;
			mainPanel.Controls.Add(futo);
		}

		private void conveyorTimer_Tick(object sender, EventArgs e)
		{
			var maxPosition = 0;
			foreach(var futo in _futos)
			{
				futo.MoveFuto();
				if (futo.Left > maxPosition)
				{
					maxPosition = futo.Left;
				}
			}

			if (maxPosition >1000)
			{
				var oldestFuto = _futos[0];
				mainPanel.Controls.Remove(oldestFuto);
				_futos.Remove(oldestFuto);
			}
		}
	}
}
