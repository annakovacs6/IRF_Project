using IRF_beadando.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_beadando
{
	public partial class Form2 : Form
	{
		Database1Entities6 context = new Database1Entities6();
		Felhasznalo felhasznalo;
		Stopwatch stopwatch = new Stopwatch();

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
			Stopwatch stopwatch = new Stopwatch();

			

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

		public void btnStart_Click(object sender, EventArgs e)
		{
			createTimer.Enabled = true;
			conveyorTimer.Enabled = true;

			Stopwatch sw = new Stopwatch();
			stopwatch.Start();
		}

		public void btnStop_Click(object sender, EventArgs e)
		{
			createTimer.Enabled = false;
			conveyorTimer.Enabled = false;

			stopwatch.Stop();
		
			Idomero ido = new Idomero();

			string beirtFelhnev = felhasznalo.FELH_NEV;
			ido.FELH_NEV_FK = beirtFelhnev;

			TimeSpan ts = stopwatch.Elapsed;
			ido.MERT_IDO = ts;

			context.Idomero.Add(ido);

			try
			{
				context.SaveChanges();
				
				MessageBox.Show("Az idő sikeresen elmentődött");
				var meres = (from x in context.Idomero
							 select x).ToList();
				bindingSource1.DataSource = meres;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}


		}

	
	}
}
