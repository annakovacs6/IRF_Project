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
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace IRF_beadando
{
	public partial class Form2 : Form
	{
		Database1Entities6 context = new Database1Entities6();
		Felhasznalo felhasznalo;
		Stopwatch stopwatch = new Stopwatch();

		List<Budapest_10km> Budapest_10Kms;
		List<Nyar_koszonto_futas> Nyar_Koszonto_Futas;
		List<Mikulas_futas> Mikulas_Futas;

		Excel.Application xlApp;
		Excel.Workbook xlWB;
		Excel.Worksheet xlSheet;

		private List<Futo> _futos = new List<Futo>();

		string[] headers = new string[]{
				"Esemény",
				"Táv",
				"Helyezés",
				"Futóazonosító",
				"Idő" };

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

			listBoxEsemeny.DisplayMember = "NEV";

			this.listEsemenyek();
			this.LoadData();

		}

		public void listEsemenyek()
		{
			var esemeny = (from x in context.Esemeny
							 select x).ToList();

			listBoxEsemeny.DataSource = esemeny;
		}

		private void LoadData() 
		{
			Budapest_10Kms = context.Budapest_10km.ToList();
			Nyar_Koszonto_Futas = context.Nyar_koszonto_futas.ToList();
			Mikulas_Futas = context.Mikulas_futas.ToList();
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
				
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}


		}

		private void btnMentes_Click(object sender, EventArgs e)
		{

		}

		public void CreateExcel()
		{
			try
			{
				xlApp = new Excel.Application();

				xlWB = xlApp.Workbooks.Add(Missing.Value);

				xlSheet = xlWB.ActiveSheet;

				//CreateTable();

				xlApp.Visible = true;
				xlApp.UserControl = true;

			}
			catch (Exception ex)
			{
				string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
				MessageBox.Show(errMsg, "Error");

				xlWB.Close(false, Type.Missing, Type.Missing);
				xlApp.Quit();
				xlWB = null;
				xlApp = null;
			}
		}

		public void CreateTable()
		{

			for (int i = 1; i < headers.Length; i++)
			{
				xlSheet.Cells[1, i] = headers[i-1];
			}

			object[,] values = new object[Budapest_10Kms.Count, headers.Length];

			int counter = 0;
			foreach (Budapest_10km bp in Budapest_10Kms)
			{
				values[counter, 0] = (from x in context.Esemeny
									  where x.ESEMENY_ID == bp.ESEMENY_FK
									  select x.NEV).FirstOrDefault();
				values[counter, 1] = bp.TAV;
				values[counter, 2] = bp.HELYEZES;
				values[counter, 3] = (from x in context.Felhasznalo
									  where x.FELH_NEV == bp.FELH_NEV_FK
									  select x.FUTO_AZONOSITO).FirstOrDefault();
				values[counter, 4] = bp.IDO;
				counter++;
			}
		}

		private string GetCell (int x, int y)
		{
			string ExcelCoordinate = "";
			int dividend = y;
			int modulo;

			while (dividend>0)
			{
				modulo = (dividend - 1) % 26;
				ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
				dividend = (int)((dividend - modulo) / 26);

			}

			ExcelCoordinate += x.ToString();

			return ExcelCoordinate;
		}
	}
}
