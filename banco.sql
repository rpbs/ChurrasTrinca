USE [ChurrasTrinca]
GO
/****** Object:  Table [dbo].[Churrasco]    Script Date: 1/24/2022 10:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Churrasco](
	[Id] [uniqueidentifier] NOT NULL,
	[Descricao] [varchar](500) NOT NULL,
	[Observacoes] [varchar](500) NULL,
	[Data] [datetime] NOT NULL,
	[ValorComBebida] [decimal](18, 0) NULL,
	[ValorSemBebida] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Churrasco] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participantes]    Script Date: 1/24/2022 10:48:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participantes](
	[Id] [uniqueidentifier] NOT NULL,
	[ChurrascoId] [uniqueidentifier] NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Data] [datetime] NOT NULL,
	[ValorContribuicao] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Participantes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Participantes]  WITH CHECK ADD  CONSTRAINT [FK_Participantes_Churrasco] FOREIGN KEY([ChurrascoId])
REFERENCES [dbo].[Churrasco] ([Id])
GO
ALTER TABLE [dbo].[Participantes] CHECK CONSTRAINT [FK_Participantes_Churrasco]
GO
