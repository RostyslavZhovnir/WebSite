Database Create Scripts for Tables:
AdTable,ForRent - Tables for data storage depends to site parts 
User - Authorisation Data for User with speccial access modes

/****** Object:  Table [dbo].[AdTable]    Script Date: 21.06.2017 23:25:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AdTable](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nchar](1000) NOT NULL,
	[phone] [varchar](10) NOT NULL,
	[image] [varbinary](max) NULL,
	[image1] [varbinary](max) NULL,
	[image2] [varbinary](max) NULL,
 CONSTRAINT [PK_AdTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[ForRent]    Script Date: 21.06.2017 23:26:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ForRent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nchar](1000) NULL,
	[phone] [varchar](10) NULL,
	[image] [varbinary](max) NULL,
	[image1] [varbinary](max) NULL,
 CONSTRAINT [PK_ForRent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[User]    Script Date: 21.06.2017 23:27:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[role] [char](1) NULL,
	[pass] [varchar](20) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

