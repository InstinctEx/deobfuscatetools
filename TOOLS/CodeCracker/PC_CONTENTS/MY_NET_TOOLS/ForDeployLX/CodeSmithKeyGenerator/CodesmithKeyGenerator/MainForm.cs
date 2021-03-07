/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 05.07.2014
 * Time: 14:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace DeployLXKeyGenerator
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
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

    	/*if (ReadLicenseKey.keySN==null||ReadLicenseKey.keySN.Length==0
   		||ReadLicenseKey.keyA==null||ReadLicenseKey.keyA.Length==0)
		MessageBox.Show("Probable selected assembly doesn't contain the LicenseKey attribute!",
		"Error",
		MessageBoxButtons.OK,
		MessageBoxIcon.Error);
		*/
			if (textBox1.Text==""||textBox2.Text==""
			   ||textBox3.Text==""||textBox4.Text==""
			  ||textBox5.Text==""||textBox6.Text==""
			 ||textBox7.Text=="")
			return;
			
			int[] groupsizes = null;
			if (textBox9.Text!=""&&textBox9.Text.Length>=3&&
			    textBox9.Text.Contains("-"))
			{
			string[] sizes = textBox9.Text.Split('-');
			groupsizes = new int[sizes.Length];
			for (int i = 0; i < sizes.Length; i++)
			{
			groupsizes[i] = Convert.ToInt32(sizes[i]);
			}
			
			}
			
			DeployLXLicensing.SerialNumberFlags flags = GrabFlags();
 			string charset = textBox1.Text;
 			string prefix = textBox2.Text;
 			int seed = Convert.ToInt32(textBox3.Text);
 			int extendLimitOrdinal1 = Convert.ToInt32(textBox4.Text);
 			int extendLimitValue1 = Convert.ToInt32(textBox7.Text);
 			int extendLimitOrdinal2 = Convert.ToInt32(textBox5.Text);
 			int extendLimitValue2 = Convert.ToInt32(textBox6.Text);
 			
 			DeployLXLicensing.CodeAlgorithm algorithm = DeployLXLicensing.CodeAlgorithm.SerialNumber;
  			if (comboBox1.SelectedItem.ToString() == "Serial Number")
  			algorithm = DeployLXLicensing.CodeAlgorithm.SerialNumber;
  			if (comboBox1.SelectedItem.ToString() == "Activation Code")
  			algorithm = DeployLXLicensing.CodeAlgorithm.ActivationCode;
  			if (comboBox1.SelectedItem.ToString() == "Simple")
  			algorithm = DeployLXLicensing.CodeAlgorithm.Simple;
 			if (comboBox1.SelectedItem.ToString() == "Basic")
  			algorithm = DeployLXLicensing.CodeAlgorithm.Basic;
 			if (comboBox1.SelectedItem.ToString() == "Advanced")
  			algorithm = DeployLXLicensing.CodeAlgorithm.Advanced;
 				
 				
 			LicenseKeyGen gen = new LicenseKeyGen();
 			string serialnumber1 = gen.MakeSerialNumber(prefix,seed,flags,extendLimitOrdinal1,
 		    extendLimitValue1, extendLimitOrdinal2,extendLimitValue2,groupsizes,charset,algorithm);
 		    textBox8.Text = serialnumber1;

		}
		
				
	public DeployLXLicensing.SerialNumberFlags GrabFlags()
	{
	bool[] flagsCollection = new bool[8];
	int num5 = 1;
	int theflags = 0;

	if (checkBox1.Checked)
	flagsCollection[0]=true;
	else
	flagsCollection[0]=false;
	
	if (checkBox2.Checked)
	flagsCollection[1]=true;
	else
	flagsCollection[1]=false;
	
	if (checkBox3.Checked)
	flagsCollection[2]=true;
	else
	flagsCollection[2]=false;
	
	if (checkBox4.Checked)
	flagsCollection[3]=true;
	else
	flagsCollection[3]=false;
	
	if (checkBox5.Checked)
	flagsCollection[4]=true;
	else
	flagsCollection[4]=false;
	
	if (checkBox6.Checked)
	flagsCollection[5]=true;
	else
	flagsCollection[5]=false;
	
	if (checkBox7.Checked)
	flagsCollection[6]=true;
	else
	flagsCollection[6]=false;
	
	if (checkBox8.Checked)
	flagsCollection[7]=true;
	else
	flagsCollection[7]=false;
	
	for (int i = 0; i < 8; i++)
    {
        if (flagsCollection[i])
        {
        theflags = (int)theflags|num5;
        }
        num5 = num5 << 1;
    }
	
	return (DeployLXLicensing.SerialNumberFlags)(theflags);
	}
		
		void Button2Click(object sender, EventArgs e)
		{
			GenerateActivationCode gac = new GenerateActivationCode();
			gac.SerialNumber = textBox8.Text;
			gac.Show();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
		comboBox1.SelectedIndex = 0;
		}
		
		public string DirectoryName = "";
		void Button3Click(object sender, EventArgs e)
		{
		OpenFileDialog fdlg = new OpenFileDialog();
		fdlg.Title = "Browse for target assembly";
		fdlg.InitialDirectory = @"c:\";
		if (DirectoryName!="") fdlg.InitialDirectory = DirectoryName;
		fdlg.Filter = "All files (*.exe,*.dll)|*.exe;*.dll";
		fdlg.FilterIndex = 2;
		fdlg.RestoreDirectory = true;
		if(fdlg.ShowDialog() == DialogResult.OK)
		{
		string FileName = fdlg.FileName;
		int lastslash = FileName.LastIndexOf("\\");
		if (lastslash!=-1) DirectoryName = FileName.Remove(lastslash,FileName.Length-lastslash);
        if (DirectoryName.Length==2) DirectoryName=DirectoryName+"\\";
		
        
        FileStream input=new FileStream(FileName, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
		BinaryReader reader=new BinaryReader(input);
		MetadataReader mr = new MetadataReader();
		bool isok = mr.Intialize(reader);
		ReadLicenseKey.keySN=null;
   		ReadLicenseKey.keyA=null;
   		
		if (isok)
		{

string licensekey = "$m|+m#}E1sg.Ld-^!lh]:U9WW|d6ClTTRFioiGwkyJcw3;{5JrK!T%!9[\x00b6s4)-/}}F=;[.gJxF[Aslm:Jj3I8UJG~H.BwPgo`[N!:-'jeR;nPOoqo6noF|J-xP}g(:39jqH`7-N\x00a7@(-6?:Vx_sLd~/v4DmvU-rw`HqlF;L*rUNU$4Dy:x9'?.v)%|)#h?gD^vG^];oy7q~(7)kv_$g7|rYDewmmnZ/V(IlPaR:^JWJW8^KPa=wYsLQ\x00b6{mIp/Dlod#:\x00b6L6]G(b9E.RWet2pGv+OOY,\x00a7Lqyl_,XpJz{JqPZ_rFeqv^0f[h#[#-MU#tW!&pFC9j^Gj/dCxhn~dWs$@n.!be1sDKi0j#kH6q{Rl|Y4fhh@bf4caJo]kQh0w314f+D5.m|C(3'de?7dEG+\x00b6OSMC^IJ8Z}@C!$6$levqS*X\x00a7&k6&e\x00a7I\x00b6lM]YnqeE?+PO%0b0^$jz8c[EJB2ks47y4kTVtVrT&1%MBoB0X]C&1/O!.TNot]!1j+HT@oxF=%8n^Gs-l|^O!~3t0`|aZc*q/=E3%NzQgp=A3=0!Ib~k1ry{Y4I'K/zpshz,Uc,;]Ld&@WE'HihklM";
ReadLicenseKey rlk = new ReadLicenseKey();
rlk.Process(licensekey);

    	if (ReadLicenseKey.keySN==null||ReadLicenseKey.keySN.Length==0
   		||ReadLicenseKey.keyA==null||ReadLicenseKey.keyA.Length==0)
		MessageBox.Show("Probable selected assembly doesn't contain the LicenseKey attribute!",
		"Error",
		MessageBoxButtons.OK,
		MessageBoxIcon.Error);
		}
		else
		{
		MessageBox.Show("Selected assembly is invalid!",
		"Error",
		MessageBoxButtons.OK,
		MessageBoxIcon.Error);
		}
		
		reader.Close();
		input.Close();
		}
		}

	}
}
