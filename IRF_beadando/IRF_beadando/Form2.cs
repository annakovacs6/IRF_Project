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
				"Helyezés",
				"Futóazonosító",
				"Idő",
				"Esemény",
				"Táv" };

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

			
			this.LoadData();

			listBoxEsemeny.DataSource = (from x in context.Esemeny
										 select x.NEV).ToList();
		

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
			string valasztott = (from x in context.Esemeny
								 where x.NEV == (string)listBoxEsemeny.SelectedItem
								 select x.ESEMENY_ID).FirstOrDefault();

			try
			{
				xlApp = new Excel.Application();

				xlWB = xlApp.Workbooks.Add(Missing.Value);

				xlSheet = xlWB.ActiveSheet;

				if (valasztott == "BP10K")
				{
					CreateBP10Table();
					FormatTable();
				}
				else
				{
					if(valasztott == "MKLSF")
					{
						CreateMIKULASTable();
						FormatTable();
					}
					else
					{
						if(valasztott == "NYKF")
						{
							CreateNYARTable();
							FormatTable();
						}
						else
						{
							string errMsg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
							MessageBox.Show(errMsg, "Error");
						}
					}
				}
				

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


		public void CreateNYARTable()
		{
			for (int i = 1; i < headers.Length; i++)
			{
				xlSheet.Cells[1, i] = headers[i - 1];
			}

			object[,] values = new object[Nyar_Koszonto_Futas.Count, headers.Length];

			int counter = 0;
			foreach (Nyar_koszonto_futas nyar in Nyar_Koszonto_Futas)
			{
				values[counter, 0] = nyar.HELYEZES;
				values[counter, 1] = (from x in context.Felhasznalo
									 where x.FELH_NEV == nyar.FELH_NEV_FK
									 select x.FUTO_AZONOSITO).FirstOrDefault();
				values[counter, 2] = nyar.IDO;
				values[counter, 3] = (from x in context.Esemeny
									 where x.ESEMENY_ID == nyar.ESEMENY_FK
									 select x.NEV).FirstOrDefault();
				values[counter, 4] = nyar.TAV;
				counter++;
			}

			xlSheet.get_Range(GetCell(2, 1), GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
		}

		public void CreateBP10Table()
		{

			for (int i = 1; i < headers.Length; i++)
			{
				xlSheet.Cells[1, i] = headers[i-1];
			}

			object[,] values = new object[Budapest_10Kms.Count, headers.Length];

			int counter = 0;
			foreach (Budapest_10km bp in Budapest_10Kms)
			{
				values[counter, 0] = bp.HELYEZES; 
				values[counter, 1] = (from x in context.Felhasznalo
									  where x.FELH_NEV == bp.FELH_NEV_FK
									  select x.FUTO_AZONOSITO).FirstOrDefault(); 
				values[counter, 2] = bp.IDO;
				values[counter, 3] = (from x in context.Esemeny
									  where x.ESEMENY_ID == bp.ESEMENY_FK
									  select x.NEV).FirstOrDefault();
				values[counter, 4] = bp.TAV;
				counter++;
			}

			xlSheet.get_Range(GetCell(2, 1), GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
		}

		public void CreateMIKULASTable()
		{
			for (int i = 1; i < headers.Length; i++)
			{
				xlSheet.Cells[1, i] = headers[i - 1];
			}

			object[,] values = new object[Mikulas_Futas.Count, headers.Length];

			int counter = 0;
			foreach (Mikulas_futas dec in Mikulas_Futas)
			{
				values[counter, 0] = dec.HELYEZES;
				values[counter, 1] = (from x in context.Felhasznalo
									 where x.FELH_NEV == dec.FELH_NEV_FK
									 select x.FUTO_AZONOSITO).FirstOrDefault();
				values[counter, 2] = dec.IDO;
				values[counter, 3] = (from x in context.Esemeny
									 where x.ESEMENY_ID == dec.ESEMENY_FK
									 select x.NEV).FirstOrDefault();
				values[counter, 4] = dec.TAV;
				counter++;
			}

			xlSheet.get_Range(GetCell(2, 1), GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
		}


		private string GetCell(int x, int y)
		{
			string ExcelCoordinate = "";
			int dividend = y;
			int modulo;

			while (dividend > 0)
			{
				modulo = (dividend - 1) % 26;
				ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
				dividend = (int)((dividend - modulo) / 26);
			}
			ExcelCoordinate += x.ToString();

			return ExcelCoordinate;
		}
	

		private void FormatTable()
		{
			Excel.Range headerRange = xlSheet.get_Range(GetCell(1, 1), GetCell(1, headers.Length));
			headerRange.Font.Bold = true;
			headerRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
			headerRange.VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
			headerRange.EntireColumn.AutoFit();
			headerRange.RowHeight = 40;
			headerRange.Interior.Color = Color.LightSalmon;
			headerRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

			int lastRowID = xlSheet.UsedRange.Rows.Count;

			Excel.Range tableRange = xlSheet.get_Range(GetCell(1, 1), GetCell(lastRowID, headers.Length));
			tableRange.BorderAround2(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThick);

			Excel.Range firstRange = xlSheet.get_Range(GetCell(2, 1), GetCell(2,headers.Length));
			firstRange.Interior.Color = Color.LightYellow;

			Excel.Range secondRange = xlSheet.get_Range(GetCell(3, 1), GetCell(3, headers.Length));
			secondRange.Interior.Color = Color.LightGray;

			Excel.Range thirdRange = xlSheet.get_Range(GetCell(4, 1), GetCell(4, headers.Length));
			thirdRange.Interior.Color = "#ab8061";

			Excel.Range noPodiumColumn = xlSheet.get_Range(GetCell(5, 1), GetCell(lastRowID, 1));
			noPodiumColumn.Interior.Color = Color.LightBlue;

			Excel.Range firstColumn = xlSheet.get_Range(GetCell(2, 1), GetCell(lastRowID, 1));
			firstColumn.Font.Bold = true;

		}

		
	}
}
