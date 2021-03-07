namespace DeployLX.Licensing.v4
{
    using System;

    [Flags]
    public enum OSEditions
    {
        DomainController = 0x10,
        Home = 0x100000,
        MediaCenter = 8,
        NotSet = 0,
        Professional = 0x200000,
        Server = 2,
        SixtyFourBit = 0x10000,
        TabletPC = 4,
        ThirtyTwoBit = 0x20000,
        Workstation = 1
    }
}

