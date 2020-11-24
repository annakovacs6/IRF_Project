
namespace IRF_beadando
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFelhasznalonev = new System.Windows.Forms.TextBox();
			this.txtFutoazonosito = new System.Windows.Forms.TextBox();
			this.btnBelep = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(31, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bejelentkezés";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(106, 141);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(174, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Felhasználónév:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(106, 208);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(159, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Futóazonosító:";
			// 
			// txtFelhasznalonev
			// 
			this.txtFelhasznalonev.Location = new System.Drawing.Point(308, 141);
			this.txtFelhasznalonev.Name = "txtFelhasznalonev";
			this.txtFelhasznalonev.Size = new System.Drawing.Size(220, 22);
			this.txtFelhasznalonev.TabIndex = 3;
			// 
			// txtFutoazonosito
			// 
			this.txtFutoazonosito.Location = new System.Drawing.Point(308, 208);
			this.txtFutoazonosito.Name = "txtFutoazonosito";
			this.txtFutoazonosito.Size = new System.Drawing.Size(220, 22);
			this.txtFutoazonosito.TabIndex = 4;
			// 
			// btnBelep
			// 
			this.btnBelep.BackColor = System.Drawing.Color.White;
			this.btnBelep.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnBelep.Location = new System.Drawing.Point(374, 253);
			this.btnBelep.Name = "btnBelep";
			this.btnBelep.Size = new System.Drawing.Size(154, 37);
			this.btnBelep.TabIndex = 5;
			this.btnBelep.Text = "Bejeletkezés";
			this.btnBelep.UseVisualStyleBackColor = false;
			this.btnBelep.Click += new System.EventHandler(this.btnBelep_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Tan;
			this.ClientSize = new System.Drawing.Size(639, 342);
			this.Controls.Add(this.btnBelep);
			this.Controls.Add(this.txtFutoazonosito);
			this.Controls.Add(this.txtFelhasznalonev);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFelhasznalonev;
		private System.Windows.Forms.TextBox txtFutoazonosito;
		private System.Windows.Forms.Button btnBelep;
	}
}

