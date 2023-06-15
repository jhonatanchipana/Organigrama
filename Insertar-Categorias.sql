SET IDENTITY_INSERT [Organigrama].[WorkStation] ON 
GO
INSERT [Organigrama].[WorkStation] ([Id], [Name], [Description], [CreateBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [LevelId]) VALUES (1, N'Director Ejecutivo', NULL, N'Admin', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 1)
GO
INSERT [Organigrama].[WorkStation] ([Id], [Name], [Description], [CreateBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [LevelId]) VALUES (2, N'Director(a) de Ventas', NULL, N'admin', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 2)
GO
INSERT [Organigrama].[WorkStation] ([Id], [Name], [Description], [CreateBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [LevelId]) VALUES (3, N'Director(a) de Marketing', NULL, N'admin', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 2)
GO
INSERT [Organigrama].[WorkStation] ([Id], [Name], [Description], [CreateBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [LevelId]) VALUES (4, N'Agente de Ventas', NULL, N'admin', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 3)
GO
INSERT [Organigrama].[WorkStation] ([Id], [Name], [Description], [CreateBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [LevelId]) VALUES (5, N'Diseñador(a)', NULL, N'admin', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 3)
GO
INSERT [Organigrama].[WorkStation] ([Id], [Name], [Description], [CreateBy], [CreationDate], [ModifiedBy], [ModificationDate], [IsActive], [LevelId]) VALUES (8, N'Redactor(a)', NULL, N'admin', CAST(N'2023-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 3)
GO
SET IDENTITY_INSERT [Organigrama].[WorkStation] OFF
GO