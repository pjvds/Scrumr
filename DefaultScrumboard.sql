INSERT INTO [Scrumboards] ([Id])VALUES('1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')

INSERT INTO [Stages] ([Id],[Name],[Scrumboard_Id])VALUES('721D2E19-2B8A-41B5-A7C6-71D8E65B5AEF','In Progress','1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')
INSERT INTO [Stages] ([Id],[Name],[Scrumboard_Id])VALUES('64A2B8E2-D6CD-4693-9AD3-85C395BA3ACE','To Do','1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')
INSERT INTO [Stages] ([Id],[Name],[Scrumboard_Id])VALUES('16BCC073-F74B-4CD3-B64C-9ACDBFA0C57D','To Verify','1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')
INSERT INTO [Stages] ([Id],[Name],[Scrumboard_Id])VALUES('6346A9A0-EAD2-46B4-AF27-AD20BA5D5450','Done','1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')

INSERT INTO [Stories] ([Id],[Description],[Scrumboard_Id])VALUES('0C8BE19D-1C12-4AB2-857A-65A420958E2B','Second story','1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')
INSERT INTO [Stories] ([Id],[Description],[Scrumboard_Id])VALUES('1DA432D7-B3C5-4835-8C99-A8B69EFA38A2','My first story','1BCDB4DC-D234-4AC0-9AFA-1EDABF7C4D31')

INSERT INTO [Tasks] ([Id],[Description],[Story_Id],[Stages_Id])VALUES('10AF7FC3-C4C3-4009-B9D8-149ACC52149A','Task 1','0C8BE19D-1C12-4AB2-857A-65A420958E2B','6346A9A0-EAD2-46B4-AF27-AD20BA5D5450')
INSERT INTO [Tasks] ([Id],[Description],[Story_Id],[Stages_Id])VALUES('AB5FD440-8BD9-4704-AF17-6FB94B27F284','Task 1','1DA432D7-B3C5-4835-8C99-A8B69EFA38A2','721D2E19-2B8A-41B5-A7C6-71D8E65B5AEF')
INSERT INTO [Tasks] ([Id],[Description],[Story_Id],[Stages_Id])VALUES('6F6E8F81-B55E-4988-B1F2-ADD761A698BE','Task 2','1DA432D7-B3C5-4835-8C99-A8B69EFA38A2','64A2B8E2-D6CD-4693-9AD3-85C395BA3ACE')