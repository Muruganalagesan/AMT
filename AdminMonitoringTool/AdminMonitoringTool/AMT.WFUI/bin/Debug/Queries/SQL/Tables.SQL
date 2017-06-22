CREATE TABLE [Service](


[AcceptPause] [nvarchar](255) NULL
,[AcceptStop] [nvarchar](255) NULL,
[Caption] [nvarchar](255) NULL,
[Description] [nvarchar](800) NULL,
[DesktopInteract] [nvarchar](255) NULL,
[DisplayName] [nvarchar](255) NULL,
[Name] [nvarchar](255) NOT NULL
,[PathName] [nvarchar](255) NULL,
[ProcessId] [nvarchar](255) NULL,
[ServiceType] [nvarchar](255) NULL,
[Started] [nvarchar](255) NULL,
[StartMode] [nvarchar](255) NULL,
[StartName] [nvarchar](255) NULL,
[State] [nvarchar](255) NULL,
[Status] [nvarchar](255) NULL
,[SystemName] [nvarchar](255) NOT NULL,
[TimeStamp] [nvarchar](255) NOT NULL

,PRIMARY KEY  ([TimeStamp],[SystemName] ,[Name])
) ; ###SEP###







CREATE TABLE [QuickFix](
	[Caption] [nvarchar](255) NULL,
	[CSName] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[FixComments] [nvarchar](255) NULL,
	[HotFixID] [nvarchar](255) NOT NULL,
	[InstallDate] [nvarchar](255) NULL,
	[InstalledBy] [nvarchar](255) NULL,
	[InstalledOn] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[ServicePackInEffect] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[SystemName] [nvarchar](255) NOT NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[HotFixID] 
)
) ;
###SEP###
CREATE TABLE [Products](
	[Caption] [nvarchar](255) NULL,
	[InstallDate] [nvarchar](255) NULL,
	[InstallSource] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NOT NULL,
	[RegCompany] [nvarchar](255) NULL,
	[RegOwner] [nvarchar](255) NULL,
	[URLInfoAbout] [nvarchar](255) NULL,
	[URLUpdateInfo] [nvarchar](255) NULL,
	[Vendor] [nvarchar](255) NULL,
	[Version] [nvarchar](255) NULL,
	[SystemName] [nvarchar](255) NOT NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[Name] 
))
;
###SEP###
CREATE TABLE [OperatingSystem](
	[BootDevice] [nvarchar](255) NULL,
	[BuildNumber] [nvarchar](255) NULL,
	[BuildType] [nvarchar](255) NULL,
	[Caption] [nvarchar](255) NULL,
	[CSDVersion] [nvarchar](255) NULL,
	[FreePhysicalMemory] [nvarchar](255) NULL,
	[FreeSpaceInPagingFiles] [nvarchar](255) NULL,
	[FreeVirtualMemory] [nvarchar](255) NULL,
	[InstallDate] [nvarchar](255) NULL,
	[LastBootUpTime] [nvarchar](255) NULL,
	[LocalDateTime] [nvarchar](255) NULL,
	[Manufacturer] [nvarchar](255) NULL,
	[MaxProcessMemorySize] [nvarchar](255) NULL,
	[MUILanguages] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[NumberOfProcesses] [nvarchar](255) NULL,
	[OSArchitecture] [nvarchar](255) NULL,
	[NumberOfUsers] [nvarchar](255) NULL,
	[RegisteredUser] [nvarchar](255) NULL,
	[SerialNumber] [nvarchar](255) NOT NULL,
	[ServicePackMajorVersion] [nvarchar](255) NULL,
	[ServicePackMinorVersion] [nvarchar](255) NULL,
	[SizeStoredInPagingFiles] [nvarchar](255) NULL,
	[SystemDevice] [nvarchar](255) NULL,
	[SystemDirectory] [nvarchar](255) NULL,
	[SystemDrive] [nvarchar](255) NULL,
	[TotalVirtualMemorySize] [nvarchar](255) NULL,
	[TotalVisibleMemorySize] [nvarchar](255) NULL,
	[Version] [nvarchar](255) NULL,
	[WindowsDirectory] [nvarchar](255) NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
	[SystemName] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[SerialNumber] 
))
;
###SEP###
CREATE TABLE [NetworkList](
	[DomainName] [nvarchar](255) NULL,
	[ServerName] [nvarchar](255) NULL,
	[ServerType] [nvarchar](20) NULL,
	[MajorVersion] [nvarchar](20) NULL,
	[MinorVersion] [nvarchar](20) NULL,
	[PlatformId] [nvarchar](20) NULL,
	[Comment] [nvarchar](255) NULL,
	[TimeStamp] [nvarchar](35) NULL)
;
###SEP###
CREATE TABLE [LogicalDisk](
	[Caption] [nvarchar](255) NULL,
	[Compressed] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[DeviceID] [nvarchar](255) NOT NULL,
	[DriveType] [nvarchar](255) NULL,
	[FileSystem] [nvarchar](255) NULL,
	[FreeSpace] [nvarchar](255) NULL,
	[MediaType] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Size] [nvarchar](255) NULL,
	[SupportsFileBasedCompression] [nvarchar](255) NULL,
	[SystemName] [nvarchar](255) NOT NULL,
	[VolumeName] [nvarchar](255) NULL,
	[VolumeSerialNumber] [nvarchar](255) NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[DeviceID] 
))
;
###SEP###
CREATE TABLE [ComputerSystem](
	[Caption] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[DNSHostName] [nvarchar](255) NULL,
	[Domain] [nvarchar](255) NULL,
	[DomainRole] [nvarchar](255) NULL,
	[Manufacturer] [nvarchar](255) NULL,
	[Model] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[NetworkServerModeEnabled] [nvarchar](255) NULL,
	[NumberOfLogicalProcessors] [nvarchar](255) NULL,
	[NumberOfProcessors] [nvarchar](255) NULL,
	[PartOfDomain] [nvarchar](255) NULL,
	[PrimaryOwnerName] [nvarchar](255) NULL,
	[Roles] [nvarchar](255) NULL,
	[SystemType] [nvarchar](255) NULL,
	[TotalPhysicalMemory] [nvarchar](255) NULL,
	[UserName] [nvarchar](255) NULL,
	[Workgroup] [nvarchar](255) NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[Caption] 
))
;
###SEP###
CREATE TABLE [BootConfig](
	[BootDirectory] [nvarchar](255) NULL,
	[Caption] [nvarchar](255) NOT NULL,
	[ConfigurationPath] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[LastDrive] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[ScratchDirectory] [nvarchar](255) NULL,
	[TempDirectory] [nvarchar](255) NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
	[SystemName] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[Caption] 
))
;
###SEP###
CREATE TABLE [BIOS](
	[BIOSVersion] [nvarchar](255) NULL,
	[Manufacturer] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[PrimaryBIOS] [nvarchar](255) NULL,
	[ReleaseDate] [nvarchar](255) NULL,
	[SerialNumber] [nvarchar](255) NOT NULL,
	[SMBIOSBIOSVersion] [nvarchar](255) NULL,
	[SMBIOSMajorVersion] [nvarchar](255) NULL,
	[SMBIOSMinorVersion] [nvarchar](255) NULL,
	[SMBIOSPresent] [nvarchar](255) NULL,
	[Version] [nvarchar](255) NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
	[SystemName] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[SerialNumber] 
))
;
###SEP###
CREATE TABLE [EnvironmentVariables](
	[Caption] [nvarchar](255)  NOT NULL,
	[Description] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[SystemVariable] [nvarchar](255) NULL,
	[UserName] [nvarchar](255) NULL,
	[VariableValue] [nvarchar](255) ,
	[TimeStamp] [nvarchar](255) NOT NULL,
	[SystemName] [nvarchar](255) NOT NULL,
PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[Caption] 
))
;
###SEP###
Create table NetworkAdapter(

         AdapterType [nvarchar](255),

      
         AdapterTypeID [nvarchar](255),

       
         Caption [nvarchar](255),

       
         Description [nvarchar](255),

        
         DeviceID [nvarchar](255) not null,

       
         Installed [nvarchar](255),

        
         MACAddress [nvarchar](255),

       
         Manufacturer [nvarchar](255),

       
         Name [nvarchar](255)  ,

       
         NetConnectionID [nvarchar](255),

        
         NetConnectionStatus [nvarchar](255),

       
         NetEnabled [nvarchar](255),
      
         PhysicalAdapter [nvarchar](255),

        
         PNPDeviceID [nvarchar](255),

       
         PowerManagementSupported [nvarchar](255),

       
         ProductName [nvarchar](255),

       
         ServiceName [nvarchar](255),

       
         Status [nvarchar](255),

       Guid [nvarchar](255),
         

       
         TimeOfLastReset [nvarchar](255),

[SystemName] [nvarchar](255) NOT NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,

PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[DeviceID] 
))
;

###SEP###
Create table NetworkLogin(

         BadPasswordCount [nvarchar](255),

     
       Caption [nvarchar](255),

      
       Comment [nvarchar](255),

      
       Description [nvarchar](255),

      
       Flags [nvarchar](255),

      
       FullName [nvarchar](255),

       
       LastLogoff [nvarchar](255),

      
       LastLogon [nvarchar](255),

       
       LogonHours [nvarchar](255),

     
       LogonServer [nvarchar](255),

      
       MaximumStorage [nvarchar](255),

      
       Name [nvarchar](255)  Not null,

      
       NumberOfLogons [nvarchar](255),

       
       PasswordAge [nvarchar](255),

      
       PasswordExpires [nvarchar](255),

      
       PrimaryGroupId [nvarchar](255),

      
       Privileges [nvarchar](255),

       
       UnitsPerWeek [nvarchar](255),

      
       UserComment [nvarchar](255),

       
       UserId [nvarchar](255),

      
       UserType [nvarchar](255),

[SystemName] [nvarchar](255) NOT NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,

PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[Name] 
))
;

###SEP###
Create table Groups(
        Caption [nvarchar](255),
       
        Description [nvarchar](255),

              Domain [nvarchar](255),
       
        InstallDate [nvarchar](255),

              LocalAccount [nvarchar](255),

             Name [nvarchar](255),
      
        SID [nvarchar](255) Not null,

        SIDType [nvarchar](255),
    
        Status [nvarchar](255),
[SystemName] [nvarchar](255) NOT NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,

PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[SID] 
))
;
###SEP###
Create table Users(
AccountType [nvarchar](255),
Caption [nvarchar](255),
Description [nvarchar](255),
Disabled [nvarchar](255),
Domain [nvarchar](255),
FullName [nvarchar](255),
InstallDate [nvarchar](255),
LocalAccount [nvarchar](255),
Lockout [nvarchar](255),
Name [nvarchar](255),
PasswordChangeable [nvarchar](255),
 PasswordExpires [nvarchar](255),
PasswordRequired [nvarchar](255),
SID [nvarchar](255) Not null,
SIDType [nvarchar](255),
Status [nvarchar](255),
[SystemName] [nvarchar](255) NOT NULL,
[TimeStamp] [nvarchar](255) NOT NULL,

PRIMARY KEY 
(
	[TimeStamp] ,
	[SystemName] ,
	[SID] 
))
;
###SEP###