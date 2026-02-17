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
MERGE dbo.ExpenseType AS TARGET
USING (VALUES
    (1,  N'Mesada Tuluá'),
    (2,  N'Mercado'),
    (3,  N'Arriendo'),
    (4,  N'Celular Gustavo'),
    (5,  N'Disney'),
    (6,  N'Youtube'),
    (7,  N'Chat Gpt'),
    (8,  N'Clases Tenis'),
    (9,  N'Torneos Tenis'),
    (10, N'Peluqueria'),
    (11, N'Gustos'),
    (12, N'Prepagada'),
    (13, N'Refuerzo Math'),
    (14, N'Clases Bajo'),
    (15, N'Energia'),
    (16, N'Gas'),
    (17, N'Agua'),
    (18, N'Internet'),
    (19, N'Gasolina'),
    (20, N'Onces Santiago'),
    (21, N'Ahorro Carro'),
    (22, N'Ahorro Vacaciones')
) AS SOURCE (Id, Description)

ON TARGET.Id = SOURCE.Id

WHEN NOT MATCHED THEN
    INSERT (Id, Description)
    VALUES (SOURCE.Id, SOURCE.Description)

WHEN MATCHED AND TARGET.Description <> SOURCE.Description THEN
    UPDATE SET TARGET.Description = SOURCE.Description;

/*Time*/
MERGE dbo.[Time] AS TARGET
USING (VALUES
    (1,  2026, 1, 1),
    (2,  2026, 2, 2),
    (3,  2026, 3, 3),
    (4,  2026, 4, 3),
    (5,  2026, 5, 3),
    (6,  2026, 6, 3),
    (7,  2026, 7, 3),
    (8,  2026, 8, 3),
    (9,  2026, 9, 3),
    (10,  2026, 10, 3),
    (11, 2026, 11, 3),
    (12, 2026, 12, 3)
) AS SOURCE (Id, [Year], [Month], TimeTense)

ON TARGET.Id = SOURCE.Id

WHEN NOT MATCHED THEN
    INSERT (Id, [Year], [Month], TimeTense)
    VALUES (SOURCE.Id, SOURCE.[Year], SOURCE.[Month], SOURCE.TimeTense)

WHEN MATCHED AND (
       TARGET.[Year] <> SOURCE.[Year]
    OR TARGET.[Month] <> SOURCE.[Month]
    OR TARGET.TimeTense <> SOURCE.TimeTense
) THEN
    UPDATE SET 
        TARGET.[Year] = SOURCE.[Year],
        TARGET.[Month] = SOURCE.[Month],
        TARGET.TimeTense = SOURCE.TimeTense;

