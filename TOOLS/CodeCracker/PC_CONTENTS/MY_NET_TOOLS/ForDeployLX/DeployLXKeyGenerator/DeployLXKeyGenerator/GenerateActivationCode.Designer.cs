/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 06.07.2013
 * Time: 19:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DeployLXKeyGenerator
{
	partial class GenerateActivationCode
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
			this.button1 = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(29, 244);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Generate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(255, 44);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(166, 20);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(255, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 14);
			this.label1.TabIndex = 2;
			this.label1.Text = "Code Expires:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(29, 44);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(210, 20);
			this.textBox1.TabIndex = 11;
			this.textBox1.Text = "STD-";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(29, 28);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Prefix:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(29, 185);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 18);
			this.label3.TabIndex = 9;
			this.label3.Text = "Character Set:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(29, 206);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(456, 20);
			this.textBox4.TabIndex = 8;
			this.textBox4.Text = "U9VWT2FG3Q7RS0AC1DEYMNX6P8HJ4KL5";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(29, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 11);
			this.label4.TabIndex = 12;
			this.label4.Text = "Serial Number:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(29, 95);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(456, 20);
			this.textBox2.TabIndex = 13;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(29, 150);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(456, 20);
			this.textBox3.TabIndex = 15;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(29, 136);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(131, 11);
			this.label5.TabIndex = 14;
			this.label5.Text = "Machine Hash Code:";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(139, 229);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 14);
			this.label6.TabIndex = 16;
			this.label6.Text = "Machine ID:";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(139, 247);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(113, 20);
			this.textBox5.TabIndex = 17;
			this.textBox5.Text = "2";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(29, 280);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 15);
			this.label7.TabIndex = 18;
			this.label7.Text = "Activation Code:";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(29, 298);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(456, 20);
			this.textBox6.TabIndex = 19;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(154, 124);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(85, 23);
			this.button2.TabIndex = 20;
			this.button2.Text = "Default Hash";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// GenerateActivationCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 383);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.button1);
			this.Name = "GenerateActivationCode";
			this.Text = "Generate Activation Unlock Code";
			this.Shown += new System.EventHandler(this.GenerateActivationCodeShown);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button1;
	}
}
