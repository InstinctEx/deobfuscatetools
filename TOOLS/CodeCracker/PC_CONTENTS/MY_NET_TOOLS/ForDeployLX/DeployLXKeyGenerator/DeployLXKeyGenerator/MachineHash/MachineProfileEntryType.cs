namespace DeployLX.Licensing.v4
{
    using System;

    public enum MachineProfileEntryType
    {
        CDRom = 5,
        Cpu = 1,
        Custom1 = 100,
        Custom2 = 0x65,
        Custom3 = 0x66,
        Custom4 = 0x67,
        Ide = 8,
        MACAddress = 3,
        Memory = 2,
        Motherboard = 9,
        NotSet = 0,
        PartialFlag = 0x40000000,
        Scsi = 7,
        SystemDrive = 4,
        TypeMask = 0xfffffff,
        VideoCard = 6
    }
}

