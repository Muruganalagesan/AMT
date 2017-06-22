 CREATE TABLE [Service3](
	[AcceptPause] [nvarchar](max) NULL,
	[AcceptStop] [nvarchar](max) NULL,
	[Caption] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[DesktopInteraction] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Path] [nvarchar](max) NULL,
	[ProcessId] [nvarchar](max) NULL,
	[ServiceType] [nvarchar](max) NULL,
	[Started] [nvarchar](max) NULL,
	[StartMode] [nvarchar](max) NULL,
	[RunAsAccount] [nvarchar](max) NULL,
	[State] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[SystemName] [nvarchar](255) not null,
	[ReportStamp] [nvarchar](255) not null
	PRIMARY KEY(ReportStamp,SystemName),
) ;
 Create table NetworkList(DomainName nvarchar(255),ServerName nvarchar(255), ServerType nvarchar(20),MajorVersion nvarchar(20),MinorVersion nvarchar(20),PlatformId nvarchar(20),Comment nvarchar(255), TimeStamp nvarchar(35));


 CREATE TABLE [Service](
	[AcceptPause] [nvarchar](255) NULL,
	[AcceptStop] [nvarchar](255) NULL,
	[Caption] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[DesktopInteract] [nvarchar](255) NULL,
	[DisplayName] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NOT NULL,
	[PathName] [nvarchar](255) NULL,
	[ProcessId] [nvarchar](255) NULL,
	[ServiceType] [nvarchar](255) NULL,
	[Started] [nvarchar](255) NULL,
	[StartMode] [nvarchar](255) NULL,
	[StartName] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
	[SystemName] [nvarchar](255) NOT NULL,
	[TimeStamp] [nvarchar](255) NOT NULL,
PRIMARY KEY  ([TimeStamp],[SystemName] ,[Name]),) ;