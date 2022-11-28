CREATE TABLE [dbo].[TB_Disputas](
	[Id] [int] IDENTITY(1,1) NOT NULL constraint PK_Disputas primary key,
	[Dt_Disputa] [datetime2](7) NULL,
	[AtacanteId] [int] NOT NULL,
	[OponenteId] [int] NOT NULL,
	[Tx_Narracao] [nvarchar](max) NULL)