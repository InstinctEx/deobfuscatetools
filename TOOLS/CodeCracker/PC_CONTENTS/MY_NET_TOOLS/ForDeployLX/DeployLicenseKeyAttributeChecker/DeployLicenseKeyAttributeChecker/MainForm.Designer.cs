/*
 * Created by SharpDevelop.
 * User: Mihai
 * Date: 12.07.2013
 * Time: 19:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DeployLicenseKeyAttributeChecker
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button11 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.assemblieslist = new System.Windows.Forms.ListView();
			this.result = new System.Windows.Forms.ColumnHeader();
			this.assemblies = new System.Windows.Forms.ColumnHeader();
			this.button8 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(261, 12);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(156, 23);
			this.button11.TabIndex = 77;
			this.button11.Text = "Files from directory recursive";
			this.button11.UseVisualStyleBackColor = true;
			this.button11.Click += new System.EventHandler(this.Button11Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(121, 12);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(122, 23);
			this.button9.TabIndex = 73;
			this.button9.Text = "Files from directory";
			this.button9.UseVisualStyleBackColor = true;
			this.button9.Click += new System.EventHandler(this.Button9Click);
			// 
			// assemblieslist
			// 
			this.assemblieslist.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.assemblieslist.AllowDrop = true;
			this.assemblieslist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.assemblieslist.AutoArrange = false;
			this.assemblieslist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.result,
									this.assemblies});
			this.assemblieslist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.assemblieslist.FullRowSelect = true;
			this.assemblieslist.GridLines = true;
			this.assemblieslist.Location = new System.Drawing.Point(22, 52);
			this.assemblieslist.Name = "assemblieslist";
			this.assemblieslist.Size = new System.Drawing.Size(605, 326);
			this.assemblieslist.TabIndex = 76;
			this.assemblieslist.UseCompatibleStateImageBehavior = false;
			this.assemblieslist.View = System.Windows.Forms.View.Details;
			// 
			// result
			// 
			this.result.Text = "Result";
			this.result.Width = 100;
			// 
			// assemblies
			// 
			this.assemblies.Text = "Files";
			this.assemblies.Width = 168;
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(552, 13);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(75, 22);
			this.button8.TabIndex = 74;
			this.button8.Text = "Exit";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.Button8Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(440, 12);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(75, 23);
			this.button7.TabIndex = 75;
			this.button7.Text = "Clear list";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(22, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 22);
			this.button1.TabIndex = 72;
			this.button1.Text = "Add file";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button2.Location = new System.Drawing.Point(22, 384);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(122, 24);
			this.button2.TabIndex = 78;
			this.button2.Text = "Check for attribute";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 418);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button11);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.assemblieslist);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Deploy LicenseKey Attribute Checker";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.ColumnHeader assemblies;
		private System.Windows.Forms.ColumnHeader result;
		private System.Windows.Forms.ListView assemblieslist;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button11;
	}
}
