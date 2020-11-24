
namespace IRF_beadando
{
	partial class Form2
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
			this.components = new System.ComponentModel.Container();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.createTimer = new System.Windows.Forms.Timer(this.components);
			this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnMentes = new System.Windows.Forms.Button();
			this.listBoxEsemeny = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.mainPanel.Location = new System.Drawing.Point(12, 274);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(776, 164);
			this.mainPanel.TabIndex = 0;
			// 
			// createTimer
			// 
			this.createTimer.Interval = 3000;
			this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
			// 
			// conveyorTimer
			// 
			this.conveyorTimer.Interval = 10;
			this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnStart.Location = new System.Drawing.Point(219, 233);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(164, 35);
			this.btnStart.TabIndex = 0;
			this.btnStart.Text = "Start animáció";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			this.btnStop.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnStop.Location = new System.Drawing.Point(395, 233);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(164, 35);
			this.btnStop.TabIndex = 2;
			this.btnStop.Text = "Stop animáció";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(270, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(252, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Üdvözöljük a futó oldalon!";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(13, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(779, 21);
			this.label2.TabIndex = 5;
			this.label2.Text = "Válasszon ki egy eseményt, majd nyomja meg a mentés gombot az eredmények megtekin" +
    "téséhez.";
			// 
			// btnMentes
			// 
			this.btnMentes.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnMentes.Location = new System.Drawing.Point(316, 169);
			this.btnMentes.Name = "btnMentes";
			this.btnMentes.Size = new System.Drawing.Size(141, 35);
			this.btnMentes.TabIndex = 6;
			this.btnMentes.Text = "Mentés";
			this.btnMentes.UseVisualStyleBackColor = true;
			this.btnMentes.Click += new System.EventHandler(this.btnMentes_Click);
			// 
			// listBoxEsemeny
			// 
			this.listBoxEsemeny.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.listBoxEsemeny.FormattingEnabled = true;
			this.listBoxEsemeny.ItemHeight = 21;
			this.listBoxEsemeny.Location = new System.Drawing.Point(219, 86);
			this.listBoxEsemeny.Name = "listBoxEsemeny";
			this.listBoxEsemeny.Size = new System.Drawing.Size(340, 67);
			this.listBoxEsemeny.TabIndex = 7;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Tan;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.listBoxEsemeny);
			this.Controls.Add(this.btnMentes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnStart);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Timer createTimer;
		private System.Windows.Forms.Timer conveyorTimer;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnMentes;
		private System.Windows.Forms.ListBox listBoxEsemeny;
	}
}