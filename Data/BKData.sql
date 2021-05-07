USE [HotelManagementREAL]
GO
SET IDENTITY_INSERT [dbo].[client] ON 

INSERT [dbo].[client] ([id_client], [cli_name], [cli_phone], [cli_code], [cli_gmail]) VALUES (1, N'Cuong', N'0912345678', N'CLI0000001', N'cuongit2k1@gmail.com')
INSERT [dbo].[client] ([id_client], [cli_name], [cli_phone], [cli_code], [cli_gmail]) VALUES (2, N'Toan', N'1234567890', N'CLI0000002', N'Toanit2k1@gmail.com')
INSERT [dbo].[client] ([id_client], [cli_name], [cli_phone], [cli_code], [cli_gmail]) VALUES (3, N'Nhat', N'0987654321', N'CLI0000003', N'Nhatit2k1@gmail.com')
SET IDENTITY_INSERT [dbo].[client] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id_user], [user_name], [user_photo], [user_gmail], [user_phone], [user_gender], [user_activeflag], [user_code]) VALUES (1, N'cuong', 1, N'cuong@gmail.com', N'123456789', 1, 1, N'PVC20011')
INSERT [dbo].[user] ([id_user], [user_name], [user_photo], [user_gmail], [user_phone], [user_gender], [user_activeflag], [user_code]) VALUES (2, N'cuong', 2, N'phanncuongg2001@gmail.com', N'987654321', 0, 1, N'2001PVC')
INSERT [dbo].[user] ([id_user], [user_name], [user_photo], [user_gmail], [user_phone], [user_gender], [user_activeflag], [user_code]) VALUES (3, N'SuperAdmin', 1, N'cuong@gmail.com', N'123456789', 1, 1, N'PVC20011')
INSERT [dbo].[user] ([id_user], [user_name], [user_photo], [user_gmail], [user_phone], [user_gender], [user_activeflag], [user_code]) VALUES (4, N'cuong', 2, N'phanncuongg2001@gmail.com', N'987654321', 0, 1, N'2001PVC')
SET IDENTITY_INSERT [dbo].[user] OFF
GO
SET IDENTITY_INSERT [dbo].[booking] ON 

INSERT [dbo].[booking] ([id_book], [book_bookdate], [book_checkindate], [book_idclient], [book_note], [book_status], [book_deposit], [book_totalprice], [book_paymentdate], [book_iduser]) VALUES (10, CAST(N'2021-03-18' AS Date), CAST(N'2021-03-20' AS Date), 1, N'"Nothing"', N'"Proccess"', 200000, 1000000, CAST(N'2021-03-22' AS Date), 1)
INSERT [dbo].[booking] ([id_book], [book_bookdate], [book_checkindate], [book_idclient], [book_note], [book_status], [book_deposit], [book_totalprice], [book_paymentdate], [book_iduser]) VALUES (12, CAST(N'2021-03-20' AS Date), CAST(N'2021-03-21' AS Date), 2, N'"VIP Client"', N'"Proccess"', 500000, 3000000, CAST(N'2021-03-25' AS Date), 1)
SET IDENTITY_INSERT [dbo].[booking] OFF
GO
SET IDENTITY_INSERT [dbo].[menu] ON 

INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (1, 0, N'/user-management', N'Manage Users', 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (2, 0, N'/room', N'Manage Rooms', 2, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (3, 1, N'/user/list', N'List User', 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (4, 1, N'/user/add', N'Add User', -1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (5, 1, N'/user/edit', N'Edit User', -1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (6, 1, N'/user/delete', N'Delete User', -1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (7, 2, N'/room-management/roomtype/list', N'List roomtype', 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (8, 2, N'/room-management/room/list', N'List rooms', 2, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (9, 2, N'/room-management/roomtype/add', N'Add Roomtype', -1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (10, 2, N'/room-management/roomtype/edit', N'Edit Roomtype', -1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[menu] ([id_menu], [menu_parentid], [menu_url], [menu_name], [menu_orderindex], [menu_activeflag], [menu_createdate], [menu_updatedate]) VALUES (11, 2, N'/room-management/room/add', N'Add Room', -1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

INSERT [dbo].[role] ([id_role], [role_name], [role_description]) VALUES (1, N'Admin', NULL)
INSERT [dbo].[role] ([id_role], [role_name], [role_description]) VALUES (2, N'Clerk', NULL)
INSERT [dbo].[role] ([id_role], [role_name], [role_description]) VALUES (3, N'Service Staff', NULL)
INSERT [dbo].[role] ([id_role], [role_name], [role_description]) VALUES (4, N'Receptionist', NULL)
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[auth] ON 

INSERT [dbo].[auth] ([id_auth], [auth_idrole], [auth_idmenu], [auth_permission], [auth_activeflag], [auth_createdate], [auth_updatedate]) VALUES (1, 1, 1, 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[auth] ([id_auth], [auth_idrole], [auth_idmenu], [auth_permission], [auth_activeflag], [auth_createdate], [auth_updatedate]) VALUES (2, 1, 2, 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[auth] ([id_auth], [auth_idrole], [auth_idmenu], [auth_permission], [auth_activeflag], [auth_createdate], [auth_updatedate]) VALUES (3, 1, 3, 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[auth] ([id_auth], [auth_idrole], [auth_idmenu], [auth_permission], [auth_activeflag], [auth_createdate], [auth_updatedate]) VALUES (4, 1, 4, 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
INSERT [dbo].[auth] ([id_auth], [auth_idrole], [auth_idmenu], [auth_permission], [auth_activeflag], [auth_createdate], [auth_updatedate]) VALUES (5, 1, 5, 1, 1, CAST(N'2021-04-18' AS Date), CAST(N'2021-04-18' AS Date))
SET IDENTITY_INSERT [dbo].[auth] OFF
GO
SET IDENTITY_INSERT [dbo].[user_role] ON 

INSERT [dbo].[user_role] ([id_userol], [userol_iduser], [userol_idrole], [userol_activeflag]) VALUES (1, 1, 1, 1)
INSERT [dbo].[user_role] ([id_userol], [userol_iduser], [userol_idrole], [userol_activeflag]) VALUES (2, 1, 2, 1)
INSERT [dbo].[user_role] ([id_userol], [userol_iduser], [userol_idrole], [userol_activeflag]) VALUES (3, 2, 2, 1)
INSERT [dbo].[user_role] ([id_userol], [userol_iduser], [userol_idrole], [userol_activeflag]) VALUES (4, 2, 3, 1)
SET IDENTITY_INSERT [dbo].[user_role] OFF
GO
SET IDENTITY_INSERT [dbo].[room_type] ON 

INSERT [dbo].[room_type] ([id_roomtype], [roty_name], [roty_description], [roty_currentprice], [roty_capacity]) VALUES (1, N'single room', N'', CAST(1000000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[room_type] ([id_roomtype], [roty_name], [roty_description], [roty_currentprice], [roty_capacity]) VALUES (2, N'double room', N'', CAST(2000000.00 AS Decimal(10, 2)), 4)
INSERT [dbo].[room_type] ([id_roomtype], [roty_name], [roty_description], [roty_currentprice], [roty_capacity]) VALUES (3, N'king room', N'', CAST(5000000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[room_type] ([id_roomtype], [roty_name], [roty_description], [roty_currentprice], [roty_capacity]) VALUES (4, N'queen room', N'', CAST(5000000.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[room_type] ([id_roomtype], [roty_name], [roty_description], [roty_currentprice], [roty_capacity]) VALUES (5, N'family room', N'', CAST(5000000.00 AS Decimal(10, 2)), 7)
INSERT [dbo].[room_type] ([id_roomtype], [roty_name], [roty_description], [roty_currentprice], [roty_capacity]) VALUES (6, N'president room', N'', CAST(1000000.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[room_type] OFF
GO
SET IDENTITY_INSERT [dbo].[ImgStorage] ON 

INSERT [dbo].[ImgStorage] ([id_imgsto], [imgsto_url], [imgsto_idrootyp], [imgsto_iduser]) VALUES (19, N'/home/cuong/vip', 2, NULL)
INSERT [dbo].[ImgStorage] ([id_imgsto], [imgsto_url], [imgsto_idrootyp], [imgsto_iduser]) VALUES (24, N'/home/cuong/oke', 1, NULL)
INSERT [dbo].[ImgStorage] ([id_imgsto], [imgsto_url], [imgsto_idrootyp], [imgsto_iduser]) VALUES (27, N'D:\\C#\\DO_AN\\PBL3REAL\\ImageSource\\OIP.jpg', 1, NULL)
INSERT [dbo].[ImgStorage] ([id_imgsto], [imgsto_url], [imgsto_idrootyp], [imgsto_iduser]) VALUES (28, N'/home/cuong/oke', 1, NULL)
INSERT [dbo].[ImgStorage] ([id_imgsto], [imgsto_url], [imgsto_idrootyp], [imgsto_iduser]) VALUES (29, N'/home/cuong/oke', NULL, 1)
SET IDENTITY_INSERT [dbo].[ImgStorage] OFF
GO
SET IDENTITY_INSERT [dbo].[room] ON 

INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (1, N'A100', N'nothing', 2)
INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (3, N'A103', NULL, 4)
INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (4, N'A104', NULL, 1)
INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (5, N'A105', NULL, 2)
INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (6, N'A106', NULL, 1)
INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (9, N'A102', N'Nothing', 6)
INSERT [dbo].[room] ([id_room], [room_name], [room_description], [room_idroomtype]) VALUES (10, N'ProVIP', N'adadada', 6)
SET IDENTITY_INSERT [dbo].[room] OFF
GO
SET IDENTITY_INSERT [dbo].[status] ON 

INSERT [dbo].[status] ([id_status], [sta_name], [sta_description]) VALUES (1, N'Maintained', N'Room is maintained for better service')
INSERT [dbo].[status] ([id_status], [sta_name], [sta_description]) VALUES (2, N'Bookes', N'This room is being booked')
INSERT [dbo].[status] ([id_status], [sta_name], [sta_description]) VALUES (3, N'Occupied', N'Guests have already taken this room')
SET IDENTITY_INSERT [dbo].[status] OFF
GO
SET IDENTITY_INSERT [dbo].[status_time] ON 

INSERT [dbo].[status_time] ([id_statim], [statim_fromdate], [statim_todate], [statim_idroom], [statim_idstatus]) VALUES (14, CAST(N'2021-03-15' AS Date), CAST(N'2021-03-20' AS Date), 1, 1)
INSERT [dbo].[status_time] ([id_statim], [statim_fromdate], [statim_todate], [statim_idroom], [statim_idstatus]) VALUES (25, CAST(N'2021-05-04' AS Date), CAST(N'2021-05-04' AS Date), 1, 1)
INSERT [dbo].[status_time] ([id_statim], [statim_fromdate], [statim_todate], [statim_idroom], [statim_idstatus]) VALUES (27, CAST(N'2021-05-06' AS Date), CAST(N'2021-05-21' AS Date), 9, 3)
INSERT [dbo].[status_time] ([id_statim], [statim_fromdate], [statim_todate], [statim_idroom], [statim_idstatus]) VALUES (28, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-05' AS Date), 1, 3)
INSERT [dbo].[status_time] ([id_statim], [statim_fromdate], [statim_todate], [statim_idroom], [statim_idstatus]) VALUES (29, CAST(N'2021-05-05' AS Date), CAST(N'2021-05-07' AS Date), 10, 1)
SET IDENTITY_INSERT [dbo].[status_time] OFF
GO
SET IDENTITY_INSERT [dbo].[booking_detail] ON 

INSERT [dbo].[booking_detail] ([id_boodet], [boodet_price], [boodet_idbook], [boodet_idroom], [boodet_note]) VALUES (1, 2000000, 10, 1, N'"Nothing"')
INSERT [dbo].[booking_detail] ([id_boodet], [boodet_price], [boodet_idbook], [boodet_idroom], [boodet_note]) VALUES (2, 4000000, 10, 3, N'"MNone"')
SET IDENTITY_INSERT [dbo].[booking_detail] OFF
GO
