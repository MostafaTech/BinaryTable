namespace BInaryTableDemo
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btnSimple = new System.Windows.Forms.Button();
			this.btnCompressed = new System.Windows.Forms.Button();
			this.btnReadCompressed = new System.Windows.Forms.Button();
			this.btnReadSimple = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(704, 369);
			this.dataGridView1.TabIndex = 0;
			// 
			// btnSimple
			// 
			this.btnSimple.Location = new System.Drawing.Point(12, 387);
			this.btnSimple.Name = "btnSimple";
			this.btnSimple.Size = new System.Drawing.Size(233, 57);
			this.btnSimple.TabIndex = 1;
			this.btnSimple.Text = "Convert to simple Binary Table";
			this.btnSimple.UseVisualStyleBackColor = true;
			this.btnSimple.Click += new System.EventHandler(this.btnSimple_Click);
			// 
			// btnCompressed
			// 
			this.btnCompressed.Location = new System.Drawing.Point(251, 387);
			this.btnCompressed.Name = "btnCompressed";
			this.btnCompressed.Size = new System.Drawing.Size(233, 57);
			this.btnCompressed.TabIndex = 2;
			this.btnCompressed.Text = "Convert to compressed Binary Table";
			this.btnCompressed.UseVisualStyleBackColor = true;
			this.btnCompressed.Click += new System.EventHandler(this.btnCompressed_Click);
			// 
			// btnReadCompressed
			// 
			this.btnReadCompressed.Location = new System.Drawing.Point(251, 450);
			this.btnReadCompressed.Name = "btnReadCompressed";
			this.btnReadCompressed.Size = new System.Drawing.Size(233, 57);
			this.btnReadCompressed.TabIndex = 4;
			this.btnReadCompressed.Text = "Read from compressed Binary Table";
			this.btnReadCompressed.UseVisualStyleBackColor = true;
			this.btnReadCompressed.Click += new System.EventHandler(this.btnReadCompressed_Click);
			// 
			// btnReadSimple
			// 
			this.btnReadSimple.Location = new System.Drawing.Point(12, 450);
			this.btnReadSimple.Name = "btnReadSimple";
			this.btnReadSimple.Size = new System.Drawing.Size(233, 57);
			this.btnReadSimple.TabIndex = 3;
			this.btnReadSimple.Text = "Read from simple Binary Table";
			this.btnReadSimple.UseVisualStyleBackColor = true;
			this.btnReadSimple.Click += new System.EventHandler(this.btnReadSimple_Click);
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(490, 387);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.Size = new System.Drawing.Size(226, 120);
			this.txtLog.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(728, 520);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.btnReadCompressed);
			this.Controls.Add(this.btnReadSimple);
			this.Controls.Add(this.btnCompressed);
			this.Controls.Add(this.btnSimple);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btnSimple;
		private System.Windows.Forms.Button btnCompressed;
		private System.Windows.Forms.Button btnReadCompressed;
		private System.Windows.Forms.Button btnReadSimple;
		private System.Windows.Forms.TextBox txtLog;
	}
}

