using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_beadando.Entities
{
	public class Futo: Label 
	{
		public Futo()
		{
			AutoSize = false;
			Width = 50;
			Height = Width;
			Paint += Futo_Paint;
		}

		private void Futo_Paint(object sender, PaintEventArgs e)
		{
			DrawImage(e.Graphics);
		}

		protected void DrawImage(Graphics g)
		{
			Image imageFile = Image.FromFile("Images/runner.png");
			g.DrawImage(imageFile, new Rectangle(0,0,Width,Height));
		}

		public void MoveFuto()
		{
			Left += 1;
		}
	}
}
