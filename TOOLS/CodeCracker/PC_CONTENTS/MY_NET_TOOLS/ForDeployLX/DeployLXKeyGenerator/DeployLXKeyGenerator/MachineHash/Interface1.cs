/*
 * Created by SharpDevelop.
 * User: Bogdan
 * Date: 10.07.2013
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace DeployLX.Licensing.v4
{
internal interface Interface1
{
    // Methods
    string[] imethod_0(MachineProfileEntryType machineProfileEntryType_0);
}

public interface IChange
{
    // Events
    event ChangeEventHandler Changed;

    // Methods
    void MakeReadOnly();
}

public delegate void ChangeEventHandler(object sender, ChangeEventArgs e);
 

}
