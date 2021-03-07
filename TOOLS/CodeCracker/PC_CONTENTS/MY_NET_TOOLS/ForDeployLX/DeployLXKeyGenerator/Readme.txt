
DeployLX Keygenenerator!

First time you must choose "Key from assembly" else no encryption
will be use (like in trial version of DeployLX)!

Parameters for generating a serial number:
(showed when the program starts)

Parameters
groupSizes
The size of each character group in the resulting code.
Each group will be separated by a '-' character.
If Nothing, automatically groups the code into easily used chunks.
On this programs group sizes must be separated by the '-' char!
The prefix lenght must not be entered here!
prefix
The Prefix of the SecureLicense the serial number will be used on to unlock. 
seed
The seed value to use when generating the serial number. Max value is 16777215. Each seed should be unique.
flags
The flags to set in the serial number.
extendLimitOrdinal1
The ordinal of the first IExtendableLimit to initialize with extendLimitValue1. If -1, not used. 
extendLimitOrdinal2
The ordinal of the second IExtendableLimit to initialize with extendLimitValue2. If -1, not used. 
extendLimitValue1
The value to initialize the IExtendableLimit referenced by extendLimitOrdinal1 with when the license is unlocked. 
extendLimitValue2
The value to initialize the IExtendableLimit referenced by extendLimitOrdinal2 with when the license is unlocked. 
characterSet
The character set to use when generating the serial number. Must match the CharacterSet of the target SecureLicense.
If null uses the default character set for the given algorithm
algorithm
The algorithm to use when generating the serial number. Default is CodeAlgorithm.SerialNumber

extendLimitOrdinal1 and extendLimitOrdinal2 maxim value is 31
seed max value is 16777215

When you choose to generate a serial with DeployLX you can choose two limit:
from there you get values of extendLimitOrdinal1,extendLimitValue1,extendLimitOrdinal2,extendLimitValue2
first limit: extendLimitOrdinal1,extendLimitValue1
second limit: extendLimitOrdinal2,extendLimitValue2
On serial generation you can only add limits that implement IExtentableLimit:
Network License

When no Limit is added to project extendLimitOrdinal1 = extendLimitOrdinal2 = -1
and extendLimitValue1=extendLimitValue2=0
These means unused and no reserved space for extendable limit.

When a Limit is added to project but no Limit selected then all values are zero:
extendLimitOrdinal1=extendLimitOrdinal2=extendLimitValue1=extendLimitValue2=0
This means unused but reserved space for extendable limit.


Generating an activation code:
Makes a code that can be used to activate a license containing an ActivationLimit,
tying the software to a specific hardware profile. 
Parameters
prefix
The Prefix of the SecureLicense the code will be used to activate. 
serialNumber
The SerialNumber of the SecureLicense to activate. 
hash
The hash of the MachineProfile to activate.
refid
The refid of the ActivationProfile to unlock (Between 1 & 255).
expires
The day when the activation code expires and cannot be used to unlock a machine. Defaults to 1 week.
characterSet
The character set to use when generating the code. Must match the CharacterSet of the SecureLicense.
If null uses the default character set for the given algorithm. 
algorithm
Must match the algorithm configured by the ActivationLimit.
Return Value
Returns a code that can be used to activate a license for a specific machine profile.

For getting the hash you can use the "Default Hash" button!
refid also called Machine ID is usually 1
For some programs Machine ID is 2
you can find it under Machine ID example Machine ID Desktop (2)


