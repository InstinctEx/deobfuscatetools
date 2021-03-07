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
string licensekey = "$m|+m#}E1sg.Ld-^!lh]:U9WW|d6ClTTRFioiGwkyJcw3;{5JrK!T%!9[\x00b6s4)-/}}F=;[.gJxF[Aslm:Jj3I8UJG~H.BwPgo`[N!:-'jeR;nPOoqo6noF|J-xP}g(:39jqH`7-N\x00a7@(-6?:Vx_sLd~/v4DmvU-rw`HqlF;L*rUNU$4Dy:x9'?.v)%|)#h?gD^vG^];oy7q~(7)kv_$g7|rYDewmmnZ/V(IlPaR:^JWJW8^KPa=wYsLQ\x00b6{mIp/Dlod#:\x00b6L6]G(b9E.RWet2pGv+OOY,\x00a7Lqyl_,XpJz{JqPZ_rFeqv^0f[h#[#-MU#tW!&pFC9j^Gj/dCxhn~dWs$@n.!be1sDKi0j#kH6q{Rl|Y4fhh@bf4caJo]kQh0w314f+D5.m|C(3'de?7dEG+\x00b6OSMC^IJ8Z}@C!$6$levqS*X\x00a7&k6&e\x00a7I\x00b6lM]YnqeE?+PO%0b0^$jz8c[EJB2ks47y4kTVtVrT&1%MBoB0X]C&1/O!.TNot]!1j+HT@oxF=%8n^Gs-l|^O!~3t0`|aZc*q/=E3%NzQgp=A3=0!Ib~k1ry{Y4I'K/zpshz,Uc,;]Ld&@WE'HihklM";
ReadLicenseKey rlk = new ReadLicenseKey();
rlk.Process(licensekey);

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
