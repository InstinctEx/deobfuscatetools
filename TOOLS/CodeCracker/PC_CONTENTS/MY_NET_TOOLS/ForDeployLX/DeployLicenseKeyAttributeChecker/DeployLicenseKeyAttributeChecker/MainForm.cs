/*
 * Created by SharpDevelop.
 * User: Mihai
 * Date: 12.07.2013
 * Time: 19:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DeployLicenseKeyAttributeChecker
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
		
		public string DirectoryName = "";
		void Button1Click(object sender, EventArgs e)
		{
		OpenFileDialog fdlg = new OpenFileDialog();
		fdlg.Title = "Browse for files";
		fdlg.InitialDirectory = @"c:\";
		fdlg.Multiselect=true;
		if (DirectoryName!="") fdlg.InitialDirectory = DirectoryName;
		fdlg.Filter = "All files (*.*)|*.*;";
		fdlg.FilterIndex = 2;
		fdlg.RestoreDirectory = true;
		if(fdlg.ShowDialog() == DialogResult.OK)
		{
		for (int i=0;i<fdlg.FileNames.Length;i++)
		{
		string FileName = fdlg.FileNames[i];
		bool IsAlready=false;
		for (int a = 0; a < assemblieslist.Items.Count; a++)
		{
		if (FileName == assemblieslist.Items[a].SubItems[1].Text)
		{
		IsAlready=true;
		break;
		}
		}
		
		if (!IsAlready)
		{
		 Graphics g = assemblieslist.CreateGraphics();
         Font objFont = new Font("Microsoft Sans Serif", 8);
         SizeF stringSize = new SizeF();
         stringSize = g.MeasureString(FileName, objFont);
         int assemblieslenght = (int)(stringSize.Width+assemblieslist.Margin.Horizontal*2);
         
         if (assemblieslenght>assemblies.Width)
         {
         assemblies.Width=assemblieslenght;
         }
         
		int lastslash = FileName.LastIndexOf("\\");
		if (lastslash!=-1) DirectoryName = FileName.Remove(lastslash,FileName.Length-lastslash);
		if (DirectoryName.Length==2) DirectoryName=DirectoryName+"\\";
		string[] prcdetails = new string[]{"",FileName};
        ListViewItem proc = new ListViewItem(prcdetails);
        assemblieslist.Items.Add(proc);
		}
		}
		}
		}
		
		void Button9Click(object sender, EventArgs e)
		{
System.Windows.Forms.FolderBrowserDialog browse =
new System.Windows.Forms.FolderBrowserDialog();
browse.ShowNewFolderButton = false;
browse.Description="Select the folder of files:";
if (DirectoryName!="")
browse.SelectedPath=DirectoryName;
else
browse.SelectedPath="C:\\";

	if (browse.ShowDialog()==System.Windows.Forms.DialogResult.OK)
	{
	DirectoryName=browse.SelectedPath;
	DirectoryInfo di = new DirectoryInfo(browse.SelectedPath);
	FileInfo[] rgFiles = di.GetFiles();
 
 foreach(FileInfo fi in rgFiles)
 {
 		string FileName = fi.FullName;
 		bool IsAlready=false;
		for (int i = 0; i < assemblieslist.Items.Count; i++)
		{
		if (FileName == assemblieslist.Items[i].SubItems[1].Text)
		{
		IsAlready=true;
		break;
		}
		}
		
		if (!IsAlready)
		{
		 Graphics g = assemblieslist.CreateGraphics();
         Font objFont = new Font("Microsoft Sans Serif", 8);
         SizeF stringSize = new SizeF();
         stringSize = g.MeasureString(FileName, objFont);
         int assemblieslenght = (int)(stringSize.Width+assemblieslist.Margin.Horizontal*2);
         
         if (assemblieslenght>assemblies.Width)
         {
         assemblies.Width=assemblieslenght;
         }
		string[] prcdetails = new string[]{"",FileName};
        ListViewItem proc = new ListViewItem(prcdetails);
        assemblieslist.Items.Add(proc);
 		}	


 }
}

		}
		
		void Button11Click(object sender, EventArgs e)
		{
System.Windows.Forms.FolderBrowserDialog browse =
new System.Windows.Forms.FolderBrowserDialog();
browse.ShowNewFolderButton = false;
browse.Description="Select the folder of files:";
if (DirectoryName!="")
browse.SelectedPath=DirectoryName;
else
browse.SelectedPath="C:\\";

	if (browse.ShowDialog()==System.Windows.Forms.DialogResult.OK)
	{
	DirectoryName=browse.SelectedPath;
	DirectoryInfo di = new DirectoryInfo(browse.SelectedPath);
	AddFileRecursive(di);
    }
		}
		
				public void AddFileRecursive(DirectoryInfo dirinfo)
		{

FileInfo[] rgFiles = dirinfo.GetFiles();
 
 foreach(FileInfo fi in rgFiles)
 {
 		string FileName = fi.FullName;
 		bool IsAlready=false;
		for (int i = 0; i < assemblieslist.Items.Count; i++)
		{
		if (FileName == assemblieslist.Items[i].SubItems[1].Text)
		{
		IsAlready=true;
		break;
		}
		}
		
		if (!IsAlready&&fi.Extension.ToLower()!=".bak")
		{
		 Graphics g = assemblieslist.CreateGraphics();
         Font objFont = new Font("Microsoft Sans Serif", 8);
         SizeF stringSize = new SizeF();
         stringSize = g.MeasureString(FileName, objFont);
         int assemblieslenght = (int)(stringSize.Width+assemblieslist.Margin.Horizontal*2);
         
         if (assemblieslenght>assemblies.Width)
         {
         assemblies.Width=assemblieslenght;
         }
		string[] prcdetails = new string[]{"",FileName};
        ListViewItem proc = new ListViewItem(prcdetails);
        assemblieslist.Items.Add(proc);
 		}	


 }
 
 DirectoryInfo[] directories = dirinfo.GetDirectories();
 foreach( DirectoryInfo di in directories)
 {
 AddFileRecursive(di);
 }
 
		}
		
		void Button7Click(object sender, EventArgs e)
		{
		assemblieslist.Items.Clear();
		assemblies.Width=168;
		result.Width=100;
		}
		
		void Button8Click(object sender, EventArgs e)
		{
		Application.Exit();
		}
		
		void Button2Click(object sender, EventArgs e)
		{
		for (int f = 0; f < assemblieslist.Items.Count; f++)
		{
		string FileName = assemblieslist.Items[f].SubItems[1].Text;
		
		FileStream input=new FileStream(FileName, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite);
		BinaryReader reader=new BinaryReader(input);
		MetadataReader mr = new MetadataReader();
		bool isok = mr.Intialize(reader);
		bool containAttribute = false;
		
   		if (isok)
		{
int deployLXDll = -1;
int licensekeyclass = -1;
int licensekeymember = -1;
for (int i = 0; i < mr.TableLengths[0x23]; i++)
{
	string name=mr.ReadName((int)mr.tables[0x23].members[i][6]);	
	if (name=="DeployLX.Licensing.v4"||name=="DeployLX.Licensing.v5"||
	    name=="DeployLX.Licensing.v3")
	deployLXDll = ((i+1)<<2)+2;

}

if (deployLXDll!=-1)
{
for (int i = 0; i < mr.TableLengths[01]; i++)  // TypeRef
{
if (deployLXDll!=-1&&(int)mr.tables[01].members[i][0]==deployLXDll)
{
string name=mr.ReadName((int)mr.tables[01].members[i][1]);
string namespaces=mr.ReadName((int)mr.tables[01].members[i][2]);
		
if (name=="LicenseKeyAttribute"&&
    (namespaces=="DeployLX.Licensing.v4"||namespaces=="DeployLX.Licensing.v5"
    ||namespaces=="DeployLX.Licensing.v3"))
licensekeyclass = ((i+1)<<3)+1;
}
}

if (licensekeyclass!=-1)
{
for (int j = 0; j < mr.TableLengths[0x0A]; j++)  // MemberRef
{
if (licensekeyclass!=-1&&
	    (int)mr.tables[0x0A].members[j][0]==licensekeyclass)
{
string name=mr.ReadName((int)mr.tables[0x0A].members[j][1]);
if (name==".ctor")
{
byte[] signature = mr.ReadBlob((int)mr.tables[0x0A].members[j][2]);
if (signature.Length==0x5&&signature[1]==0x020&&signature[2]==0x01&&signature[3]==0x01&&signature[4]==0x0E)
{
licensekeymember = ((j+1)<<3)+3;
break;
}
}
}
}

if (licensekeymember!=-1)
{
for (int j = 0; j < mr.TableLengths[0x0C]; j++)  // CustomAtribute
{
if ((int)mr.tables[0x0C].members[j][1]==licensekeymember)
{
if ((int)mr.tables[0x0C].members[j][0]==0x02E)  // assembly 1
{
containAttribute = true;
break;
}
}
}
}
}
}

    	if (containAttribute)
    	assemblieslist.Items[f].SubItems[0].Text="Contains attribute!";
    	else
    	assemblieslist.Items[f].SubItems[0].Text="No attribute!";
    	
		}
		else
		{
assemblieslist.Items[f].SubItems[0].Text="Invalid assembly!";
		
		}
		
		reader.Close();
		input.Close();
		}
		}
	}
}
