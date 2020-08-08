/****** Object:  Table [dbo].[Foo]    Script Date: 13/11/2019 10:00:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Foos](
	[Id] [uniqueidentifier] NOT NULL,
	[Foo] [varchar](100) NOT NULL,
	[FooBar] [varchar](100) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] INT NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[UpdatedBy] INT NOT NULL,
	[IsDeleted] BIT NOT NULL,
 CONSTRAINT [PK_Foo] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
