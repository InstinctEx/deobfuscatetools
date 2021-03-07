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
string licensekey = "$m|+k{`wO7i'cMy0T~6U0§1YJ[f=Uthz2x=9sP-m%1T*9DUR%%TaU&§&{FO^MC~5¶Wlm(6_]x@Ck)(9@'v(/#v:({:R];tL.-0,cQS6lq6'PPgT=NKws~'wpV`x:TlI]9c$Oi?X%.X[}6§ey=m&Ttd|~N}csSHIoDtsQx;;+!F73XQ.~$jl!MNlCX.8mDnW.UU'g4M21(DA94kg!30TU:§C#9yoyoN`n/X?@.r$%m!iIWh]}Fft'o*-3k(P#25-?vdgv'`Hw0V7@#+tz|q[gX{]t/33glOwxW5PO+#GS~Je|&¶|/s-qR|yRK?Ef.`wWaW[)mk$AOJF!P_/_v.'^7ee*MNG~O?x87-HbdRNJQ¶3J[Oz&kzP4f2A8WN§~L??Nv(RNIsx%U¶r§DiNyPL[@i¶eKKT'&fj&*go!ZdSo8lmDnc0wLq0lT#:D*SjKE:z.7nh_taxDH=jfsrDZt1$EsTBA/W^j}yUktbU~=7V#Uwq5$&lncl:=y^8hdF8+`§{#4;71&=^K?![_QNhwd¶8KA|aKAq|DQRc(Ot/sD?b$oaRXeN//c]|&LNO{XcF=DJ4n?fEfx¶AATl";
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
