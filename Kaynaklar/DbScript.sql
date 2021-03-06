USE [master]
GO
/****** Object:  Database [AkkocDB]    Script Date: 16.06.2021 15:53:18 ******/
CREATE DATABASE [AkkocDB] ON  PRIMARY 
( NAME = N'AkkocDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\AkkocDB.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AkkocDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\AkkocDB_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AkkocDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AkkocDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AkkocDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AkkocDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AkkocDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AkkocDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AkkocDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AkkocDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AkkocDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AkkocDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AkkocDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AkkocDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AkkocDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AkkocDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AkkocDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AkkocDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AkkocDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AkkocDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AkkocDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AkkocDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AkkocDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AkkocDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AkkocDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [AkkocDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AkkocDB] SET RECOVERY FULL 
GO
ALTER DATABASE [AkkocDB] SET  MULTI_USER 
GO
ALTER DATABASE [AkkocDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AkkocDB] SET DB_CHAINING OFF 
GO
USE [AkkocDB]
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_barkodstr]    Script Date: 16.06.2021 15:53:19 ******/
CREATE TYPE [dbo].[nvarchar_barkodstr] FROM [nvarchar](25) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_belgeno]    Script Date: 16.06.2021 15:53:19 ******/
CREATE TYPE [dbo].[nvarchar_belgeno] FROM [nvarchar](20) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_evrakseri]    Script Date: 16.06.2021 15:53:19 ******/
CREATE TYPE [dbo].[nvarchar_evrakseri] FROM [nvarchar](6) NULL
GO
/****** Object:  UserDefinedDataType [dbo].[nvarchar_maxhesapisimno]    Script Date: 16.06.2021 15:53:19 ******/
CREATE TYPE [dbo].[nvarchar_maxhesapisimno] FROM [nvarchar](90) NULL
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Order] [int] NOT NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChangeLog]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChangeLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [int] NOT NULL,
	[EntityName] [varchar](30) NULL,
	[RecordId] [int] NOT NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.ChangeLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogErrors]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogErrors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecId] [int] NOT NULL,
	[EntityName] [varchar](150) NULL,
	[ControllerName] [varchar](30) NULL,
	[ActionName] [varchar](30) NULL,
	[IsAjaxRequest] [bit] NOT NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Message] [varchar](255) NULL,
 CONSTRAINT [PK_dbo.LogErrors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserName] [varchar](8) NOT NULL,
	[Password] [varchar](8) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Surname] [varchar](30) NOT NULL,
	[UserImage] [varchar](50) NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Logins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[Subject] [varchar](30) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Content] [varchar](255) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsRead] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Messages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Price] [float] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Order] [int] NOT NULL,
	[ProductImage] [varchar](50) NULL,
	[ProductThumbImage] [varchar](50) NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](10) NOT NULL,
	[Description] [varchar](255) NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteStatics]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteStatics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AboutTitle] [varchar](100) NOT NULL,
	[AboutDescription] [varchar](8000) NOT NULL,
	[Instagram] [varchar](50) NOT NULL,
	[VideoFile] [varchar](50) NULL,
	[Address] [varchar](20) NOT NULL,
	[Email1] [varchar](100) NOT NULL,
	[Email2] [varchar](100) NULL,
	[Tel1] [varchar](15) NOT NULL,
	[Tel2] [varchar](15) NULL,
	[Location] [nvarchar](1500) NOT NULL,
	[SiteMail] [varchar](100) NOT NULL,
	[MailUserName] [varchar](20) NOT NULL,
	[MailPassword] [varchar](10) NOT NULL,
	[Copyrigth] [varchar](200) NOT NULL,
	[FacebookUrl] [varchar](200) NULL,
	[InstagramUrl] [varchar](200) NULL,
	[PinterestUrl] [varchar](200) NULL,
	[LogoTitle] [varchar](50) NULL,
	[LogoImage] [varchar](50) NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.SiteStatics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 16.06.2021 15:53:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Order] [int] NOT NULL,
	[SliderImage] [varchar](100) NULL,
	[Detail] [varchar](8000) NOT NULL,
	[LastupUser] [varchar](27) NULL,
	[CreateUser] [varchar](28) NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastupDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202106161219393_AutomaticMigration', N'Akkoc.DataContext.AkkocContext', 0x1F8B0800000000000400ED5D5B6FDCB8157E2FD0FF20CC535B783D1E679D38C67817DE71BC301AC786C709FA1670247AAC8D2EB31295DA28FACBFAD09FD4BF5052178A5749D465C6F60A01020F297E47BC9C8F8714CFE1FFFEF3DFF9CF8FBE677D8751EC86C1E964B67F30B16060878E1BAC4F2709BAFFE178F2F34F7FFED3FC83E33F5A5F8AE7DE90E770C9203E9D3C20B439994E63FB01FA20DEF75D3B0AE3F01EEDDBA13F054E383D3C38783F9DCDA610434C309665CD6F9300B93E4C7FE09F8B30B0E10625C0BB0A1DE8C5793ACE59A6A8D627E0C378036C783A39FBF62DB4F7CF0102B814828F68629D792EC02FB284DEFDC40241102280F06B9E7C8EE1124561B05E6E7002F0EE9E36103F770FBC18E6AF7F523EDEB4260787A426D3B260016527310A7D43C0D99BBC69A662F1560D3CA14D871BEF036E64F4446A9D36E0E96401105C87D1D3C412859D2CBC883C48DB1767BAC1FECDF5E27ABF28B567B1797B7434E04143FEED598BC44349044F0398A008787BD64DB2F25CFBEFF0E92EFC0683D320F13CF605F12BE23C2E0127DD44E10646E8E916DEE7AF7DE94CAC295F6E2A16A4C5983259852E03F4E670627DC2C2C1CA83B4FF99CA2F5118C15F6100235C55E7062004A38060C0B40525E9822CF27F210D0F38AC3A13EB0A3C7E84C11A3D6065C1BA72E13E42A748C85FE073E06245C365509440C50B560B3D87B11DB99B6CA468651F1E1D0D21FC3A726054D7C0D5108B08E2C6C67A4C9B8EFC7DE7FAE66FF311C428D9F408858923AA6AD4778DDAB449FDEB241DF720E9323EB391FB9D36CE2F61E84110D4B7CD27F0DD5DA71A2220E29F4E62A37862DD422F7D207E70371903EFE7995F4BB2B98842FF36F4CA8234EFEB1D88D61053F85DA879601926912DBCDA7C5A325B25DFE568667497171AD94E3770F3AEA997D98935674783D0E64DE4DA254D84B8CB86A2DEE38383416AD003F7E643FCD207EBAA2E68D8038D64DD3D24FE6A2B02C789E5E54E2CE59CD1756229E60DEDC452CC3CAD2696C50308D6F063B836B4A48B62E3E4A291B5C430494C072EE9F6ACF14986B9D66565FBB1CFAB25DD423B8C9CAE73E2C85DCF9BBB1A1304D6F10F51144666FC50941AE941AF655D55AC112534353EAB455DC138AE36789A2ECF6BB4260C50147A1E8CB6C174446FC2601B92B08EFE061E6FE1EF098C91B1913152EBABA55637C8EA61C8AD59B1915C35B288A1DC955D4903D75043B32166BAA20571FC4F6C806D5BEE4EB67E974914EC422EE9DCAD2CE1092BA6FADA0BC78ECCFFBC99BF6A43807092723380D2F9D7EC91722B80CF91360284EC4EDB000426136F321315A5C68948238B344E9D81FE02BEA98DACF45A5929E510F5D7AFC6BC247EF9D2D0562B5EA20B4F135ACA0B8DACA491B523536FF51BB4D1D6E57EC09DEF55F2EF2062D3233D415575073AD0D0231B5FC6B71038C664B3DD4534D94E776D3382C8CA8CFCA09175B60A1374E722AFDA6E19446F52D9BBFD2C7D19C408AC23E0775F1C1A4AFEE23A30BC702BDBBD9765E999E3447892AC62A7E1C878B6FD5195CA3DEC416EB5983B585DB941081F0BADAC591F26FEC7D00635DA383B1AA6EB962E82573B99C289D406BB80C3680A11DE602B7098D5E322DC3C452EC6ABACF620A22F800D5761F8ED7354D5E34D853724FA6D08BB71B1418849176D43185E82857513783FFB9B58D078166ADC6430B0D73DD731FDE2959519ED758DAC1D99EA3B3DB7BFA3657D0F4756B3C15C479AFD18A4E7105537D3506BA891AE5F2A5D273E43D6DC89C5CBF8C203EBB8782D3D812F9F6204FDD4B32D3FF3C81E7DDCB3B21F17D8F082D8BCFD5632F9DBA64CBE7AF70E1CD9476F67EFDFFC080F8EDF9336C34AE53DE1266675936FB92BE8AF60C4A886FD00314D7F015E821366524B73CF7F0EECF4CC6B59E0B0BA005E63330FFF58FDF039F420621E3FAE7EFC2A74DC7B977DF9B772FF663DC9269EC57168BB696FF167DACB93C8BCD00F8163D51D4B2ECFB75227952BDC7DEE067718EEE6D3C9DFA4BA54C0D28F09256C794A9AC79D4DC4A9FB3AC8DAD1CA4E769153D8B10D1C598770EB387C0A9EEDB1751E10E7CA4588D705113631906C1AB881ED6E8057F3F642B9864605792F2A41CC39871B18107BA0A63F9A8866FD5EE457A0928426AB6BA1F994195ED5A34EF8B4A41B1CBAEFDFE5D0604E50351F73BACF57256CF935FCB98D38F5BB6F61BCA9FBA289E0E230D616465A36B1904F2FB84449C464D5405DACA5690B572A9FB98AA94D1C38E9D40511AF3D2E8C275639894A5C250D3F1EE5863A1E4A1894466B20321F0CE55B944E1D3518C5396D154A79F2BB1E24FD88AC4228D4B306820C121542A9893500F9375F1506FD865C0341761AB32F432A94E23B531D486ADD2B01F285AF00C00C656974300E42CC633A272251BF1A4CDEF4EDD90129296A83E99A0162F5432441BEB20D1A423C84203743D55CD2643661DEBC18C7150DA0993B18907C2437AE79618953D6A279F3691633224F984F35C125E65760B3C1862F136C224FB19659A489C50F4BF3180C7E8631C5DA50C1B154120A23AC64422ED94A76E0851BC588AC065680AC43168E2F3DC671B446C30A51120DCBDD55A85E5184FCCD4C066CD08D7D9DFE94CD88572A6B9F4C85E93E8D3CD415452D12F0037820526C0B2D422FF103FDACAC2F9D7D8960CB6729CD11B83D1B1688CB688E97EF87B0487952730C76AF800562D39BA3B1DB052C1A9B6E8A964D61329A6A6AABAFA98CC6A637472B57FEDC88A2A932D27C2A8C68C924935447B26279656CA4AA746AE9A6A8855D64AEA7DA92C3A829BBBEE2BAB962DDA547EBAEF479A40016224F7AD9C471C339FFF3D563738C1159177F052C9B3DD2DC4873C27AACA33942D76E2DEC117DD96198AE707267118AB4E628AC232B8BC4A637472BFDD759AC3275D4D85163A5DD8F6E3A4B774ACC55565F74188DCDFDCE05D530C3E8575FE9F60C0BA5D9B3A9C2117DC7B9712CE43547657DC4594436DD4833583F70413DD8AC91A54696E2B7573B5354BE15DB8AA374650722A9FC9301C7529ACF087A94F2EC268B53A61A2C0BE8414C6E354053B7B998A32ED39CCD55249AB58E6289C3249BA939E3E52C6A3A9335D2DA486BDC279F6EAC463F0F99939ABEE8709C266B7F99BABBAD9851D35EB9A6D16FA3DD94ADB0C9CD754D5BF2B97E26A1CEAAFC249B271AAC94B253AADC22294B325BD7A49EA4E282264DDC959A17BEA1FCD0CFD25EA10AB16703BA69517E8EC05C89740587D121D607945BF732E98668DA794BCE351841A5B32657D932B93916E37EC96231C906352E3C2CB98A1689860C32535088745CB516E55081229D61AD42C9DC1B598C2CC508E15042307A87D21391330768AA01C753C7428EE469AAC10E16E728C86D6371396688EA45279F63328B50973E7E1EA1C9CDB1381F3D168DCB68A1C312209F63B060E79CEDB8453B976332EEA8471D3FF068B2199662E9CD248FC6FB68BC0B070A3B5A1DD9E1C3165687A6E030568742C38CB5ABEFE5711F367C1FA71D38BF316ECA62334CDA0949152BD246FEF983F18F740A557C844ACF53E86F7A0A353F015A7FEF997424347B6462E126FA4E8632EF41B6FCDD5B786EBAD82D1EB802817B8FE7F0CC198CF8CC1F0B77A73D9F7BCCA671EC788A13B48C979DC6F96A0BBEC92E69D55AEFE30E9164BF83C87E009114E7ABBBABB10A39F535EEE2D19BB64767A752E5ABBD6381DBB9902A718FDBE1B2FEB40EFE1BF5E39ADB1A4A74635DB9753D617C77D6EBD02EF9D2AA548CE4D6741938F0F174F2AFB4D88975F98FAF65C93D2B1DF527D681F5EFDED53BBD71A0CB5D56F75E08CCD550411141FE7A7FF1C1E35FB74F0C378ABBA9540DC6B757A79BA8FA811F19ED99339AE69CE78BE534FEAEA436BAC61E3D6B6A79B4B90C6934105EA13AA9CF60BE586DE2AE161A4E9966E6138BFA7A9F7E3455BECCA71F5CE5D53DF5836FA481E742033286709B558395A4DC5E2D2EF97925ECC2DDADD374ED9195EAB4EE104371AABAEDD8DC4817626CF6833AC0168870554E4FA8D24538FDAD20A46B6F3AD2C7C89CCFD680529FA57CD114576BFD6C6B13735CB0BF0205511E807CB1FA31C8ECC6DD0ED2132A172454ADC5E6A0C2CD1E7D7D87E85127F87B3BDA58C803AA82EA18E38BD504F9A68CBE4699EE1E0CA57D7AD0428074CB45BDE5D7EE0E8B7E2C4AE1C60AA5D6B5248859DF7DC7DF36D100D5F46E09F5764CA79B23EA21DBDC131168368E5A4C10C235107DF595EA92879E0697EA0A879E4C49E98206F52B9B032BAE5F6800DDF6B2859EA055572BF4042D5DA4D0D3FA58BC3661FC70F7875807A84E53BE58E36710BB67C0933E83AC063A9F12505C07D093C5C007FFEFCD701C49E679914C87A0EE6578D9EC25B6176E5D0A29DB2E907CAB18DA15013F9BF0AED5224CFBAB0ACB5EC66466BA6C2B21D3157178DB86836F35722AC20DF43E72AA02B6C8C2761E645D8EF32B769D328AFA53650CF5EC603866D95588FB3963C68AF0D2A20C4A2392089AA39270A38984AD09C09E8659972B51E6296B611CA1BD3240BB4A0413DABD5E44A1362A19459E46882264B624A16407494099A5C25747D316E1E9077D099DE6A8C0CB98F135F845EC7709BEC850A173E1E4EB04E4B1E1650179865240116A5E00DF464479517DF970D8320D29E67B457C5E6906D865BC7871CCF25163AAAA28E9931045AB79350D82C3CBEE3798E3938018A7D92FBCB272D725C41C6306D0E6D89D3E7319DC87C52423BC51F18874A606016C0C83B308B9F7C04638DBC6EA955E7995DF51F4C15F41E732B84ED02641B8CAD05F79DC5821935595FC34023EFFCEF3EB74A918F75105FC9A2EB1E7AF835F12D72BEF56BA50D8E21A08320BE62B6CD29788ACB4D74F14E953183404CA9B8F4EDE77D0DF78182CBE0E9680AC1ACCDF0D0FBD8F700DECA79BDC8B4A0F52DF117CB3CFCFDD746B2FCE31CAF2F8271EC38EFFF8D3FF01F85AB2C1A3A30000, N'6.4.0')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [Order], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (1, N'Kategori 1', N'Açıklama 1', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Order], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (2, N'Kategori 2', N'Açıklama 2', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [Order], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (3, N'Kategori 3', N'Açıklama 3', 3, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[ChangeLog] ON 

INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (1, 4, N'Category', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (2, 4, N'Category', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (3, 4, N'Category', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (4, 4, N'UserRole', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (5, 4, N'UserRole', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (6, 4, N'LoginUser', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (7, 4, N'LoginUser', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (8, 4, N'Static', 0, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (9, 2, N'Category', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (10, 2, N'Category', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (11, 2, N'Category', 3, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (12, 2, N'UserRole', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (13, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (14, 2, N'ChangeLog', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (15, 2, N'ChangeLog', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (16, 2, N'ChangeLog', 3, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (17, 2, N'ChangeLog', 4, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (18, 2, N'ChangeLog', 5, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (19, 2, N'Category', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (20, 2, N'Category', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (21, 2, N'Category', 3, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (22, 2, N'UserRole', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (23, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (24, 2, N'ChangeLog', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (25, 2, N'ChangeLog', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (26, 2, N'ChangeLog', 3, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (27, 2, N'ChangeLog', 4, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (28, 2, N'ChangeLog', 5, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (29, 2, N'LoginUser', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (30, 2, N'LoginUser', 2, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (31, 2, N'Static', 1, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (32, 2, N'ChangeLog', 6, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (33, 2, N'ChangeLog', 7, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (34, 2, N'ChangeLog', 8, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (35, 2, N'ChangeLog', 9, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (36, 2, N'ChangeLog', 10, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (37, 2, N'ChangeLog', 11, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (38, 2, N'ChangeLog', 12, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (39, 2, N'ChangeLog', 13, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (40, 2, N'ChangeLog', 14, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (41, 2, N'ChangeLog', 15, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (42, 2, N'ChangeLog', 16, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (43, 2, N'ChangeLog', 17, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (44, 2, N'ChangeLog', 18, N'admin', N'admin', CAST(N'2021-06-16T15:19:40.567' AS DateTime), CAST(N'2021-06-16T15:19:40.567' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (45, 16, N'LoginUser', 2, N'admin', N'admin', CAST(N'2021-06-16T15:40:51.677' AS DateTime), CAST(N'2021-06-16T15:40:51.677' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (46, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:40:51.690' AS DateTime), CAST(N'2021-06-16T15:40:51.690' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (47, 16, N'LoginUser', 2, N'admin', N'admin', CAST(N'2021-06-16T15:42:25.570' AS DateTime), CAST(N'2021-06-16T15:42:25.570' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (48, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:42:25.583' AS DateTime), CAST(N'2021-06-16T15:42:25.583' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (49, 16, N'LoginUser', 2, N'admin', N'admin', CAST(N'2021-06-16T15:44:54.390' AS DateTime), CAST(N'2021-06-16T15:44:54.390' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (50, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:44:54.400' AS DateTime), CAST(N'2021-06-16T15:44:54.400' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (51, 16, N'LoginUser', 2, N'admin', N'admin', CAST(N'2021-06-16T15:46:48.447' AS DateTime), CAST(N'2021-06-16T15:46:48.447' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (52, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:46:48.457' AS DateTime), CAST(N'2021-06-16T15:46:48.457' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (53, 16, N'Static', 1, N'admin', N'admin', CAST(N'2021-06-16T15:47:35.430' AS DateTime), CAST(N'2021-06-16T15:47:35.430' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (54, 16, N'LoginUser', 2, N'admin', N'admin', CAST(N'2021-06-16T15:49:36.883' AS DateTime), CAST(N'2021-06-16T15:49:36.883' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (55, 2, N'UserRole', 2, N'admin', N'admin', CAST(N'2021-06-16T15:49:36.900' AS DateTime), CAST(N'2021-06-16T15:49:36.900' AS DateTime), 1)
INSERT [dbo].[ChangeLog] ([Id], [Status], [EntityName], [RecordId], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (56, 16, N'Static', 1, N'admin', N'admin', CAST(N'2021-06-16T15:50:37.340' AS DateTime), CAST(N'2021-06-16T15:50:37.340' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ChangeLog] OFF
SET IDENTITY_INSERT [dbo].[Logins] ON 

INSERT [dbo].[Logins] ([Id], [RoleId], [UserName], [Password], [Name], [Surname], [UserImage], [LastLoginDate], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (1, 1, N'user', N'123456', N'UserName', N'UserSurname', NULL, CAST(N'2021-06-16T15:19:40.450' AS DateTime), N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:19:40.517' AS DateTime), 1)
INSERT [dbo].[Logins] ([Id], [RoleId], [UserName], [Password], [Name], [Surname], [UserImage], [LastLoginDate], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (2, 2, N'admin', N'123456', N'AdminName', N'AdminSurname', NULL, CAST(N'2021-06-16T15:49:36.857' AS DateTime), N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:49:36.883' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Logins] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [RoleName], [Description], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (1, N'user', N'Standart kullanıcı rolü.', N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
INSERT [dbo].[Roles] ([Id], [RoleName], [Description], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (2, N'admin', N'En yetkili kullanıcı rolü.', N'admin', N'admin', CAST(N'2021-06-16T15:19:40.373' AS DateTime), CAST(N'2021-06-16T15:19:40.373' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[SiteStatics] ON 

INSERT [dbo].[SiteStatics] ([Id], [AboutTitle], [AboutDescription], [Instagram], [VideoFile], [Address], [Email1], [Email2], [Tel1], [Tel2], [Location], [SiteMail], [MailUserName], [MailPassword], [Copyrigth], [FacebookUrl], [InstagramUrl], [PinterestUrl], [LogoTitle], [LogoImage], [LastupUser], [CreateUser], [CreateDate], [LastupDate], [IsActive]) VALUES (1, N'About Title', N'About Description', N'Akkoc', N'video1.mp4', N'Adres', N'email1@gmail.com', N'email2@gmail.com', N'(555) 555 55 55', N'(555) 555 55 55', N'<iframe src="https://www.google.com/maps/d/embed?mid=1DhnhfyjdBf_zb89OnW8XhcBMTzA" width="640" height="480"></iframe>', N'akkoc@gmail.com', N'username', N'password', N'Her hakkı saklıdır', N'http://www.facebook.com/akkoc', N'http://www.instagram.com/akkoc', N'http://www.pniterest.com/akkoc', N'Logo Title', N'/Content/images/global/star.png', N'admin', N'admin', CAST(N'2021-06-16T15:19:40.517' AS DateTime), CAST(N'2021-06-16T15:50:37.340' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[SiteStatics] OFF
/****** Object:  Index [IX_RoleId]    Script Date: 16.06.2021 15:53:19 ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[Logins]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryId]    Script Date: 16.06.2021 15:53:19 ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Logins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Logins_dbo.Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logins] CHECK CONSTRAINT [FK_dbo.Logins_dbo.Roles_RoleId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_dbo.Products_dbo.Categories_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [AkkocDB] SET  READ_WRITE 
GO
