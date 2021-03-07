/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 06.07.2013
 * Time: 19:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using DeployLX.Licensing.v4;

namespace DeployLXKeyGenerator
{
	/// <summary>
	/// Description of GenerateActivationCode.
	/// </summary>
	public partial class GenerateActivationCode : Form
	{
		public GenerateActivationCode()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{
		string prefix = textBox1.Text;
		string serialNumber = textBox2.Text;
		string hash = textBox3.Text;
		int refid = 1; // any
		if (textBox5.Text!="")
		refid = Convert.ToInt32(textBox5.Text);
		
		DateTime expires = dateTimePicker1.Value;
		string charset = textBox4.Text;
		DeployLXLicensing.CodeAlgorithm algorithm = DeployLXLicensing.CodeAlgorithm.ActivationCode;
		LicenseKeyGen gen = new LicenseKeyGen();
 		string activationcode = gen.MakeActivationCode(prefix,serialNumber,hash,
		                refid,expires,charset,algorithm);
 		textBox6.Text = activationcode;
		}
		
		public string SerialNumber;
		void GenerateActivationCodeShown(object sender, EventArgs e)
		{
		if (SerialNumber!=null&&SerialNumber.Length>0)
		textBox2.Text=SerialNumber;
		}
		
		void Button2Click(object sender, EventArgs e)
		{

			MachineProfile machine = MachineProfile.GetDefaultProfile();
			textBox3.Text = machine.Hash;
			
		}
	}
}
