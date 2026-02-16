/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*ExpenseType*/
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (1, N'Mesada Tuluá')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (2, N'Mercado')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (3, N'Arriendo')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (4, N'Celular Gustavo')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (5, N'Disney')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (6, N'Youtube')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (7, N'Chat Gpt')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (8, N'Clases Tenis')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (9, N'Torneos Tenis')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (10, N'Peluqueria')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (11, N'Gustos')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (12, N'Prepagada')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (13, N'Refuerzo Math')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (14, N'Clases Bajo')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (15, N'Energia')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (16, N'Gas')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (17, N'Agua')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (18, N'Internet')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (19, N'Gasolina')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (20, N'Onces Santiago')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (21, N'Ahorro Carro')
INSERT [dbo].[ExpenseType] ([Id], [Description]) VALUES (22, N'Ahorro Vacaciones')

/*Time*/
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (1, 2026, 3)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (2, 2026, 4)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (3, 2026, 5)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (4, 2026, 6)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (5, 2026, 7)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (6, 2026, 8)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (8, 2026, 9)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (9, 2026, 10)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (10, 2026, 11)
INSERT [dbo].[Time] ([Id], [Year], [Month]) VALUES (11, 2026, 12)
