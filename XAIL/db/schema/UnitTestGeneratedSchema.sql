
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK6EB9EBDB699353A5]') AND parent_object_id = OBJECT_ID('News'))
alter table News  drop constraint FK6EB9EBDB699353A5


    if exists (select * from dbo.sysobjects where id = object_id(N'News') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table News

    if exists (select * from dbo.sysobjects where id = object_id(N'NewsCategories') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table NewsCategories

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table News (
        NewsId INT IDENTITY NOT NULL,
       Title NVARCHAR(255) not null,
       Body NVARCHAR(MAX) null,
       CreatedAt DATETIME not null,
       NewsCategoryFk INT null,
       primary key (NewsId)
    )

    create table NewsCategories (
        NewsCategoryId INT IDENTITY NOT NULL,
       Name NVARCHAR(255) not null,
       primary key (NewsCategoryId)
    )

    create table Users (
        UserId INT IDENTITY NOT NULL,
       Username NVARCHAR(255) not null,
       Email NVARCHAR(255) not null,
       Password NVARCHAR(255) not null,
       PasswordSalt NVARCHAR(255) not null,
       IsApproved BIT null,
       CreatedOnUtc DATETIME null,
       LastLoginDateUtc DATETIME null,
       LastPasswordChangeDateUtc DATETIME null,
       FailedPasswordAttemptCount INT null,
       primary key (UserId)
    )

    alter table News 
        add constraint FK6EB9EBDB699353A5 
        foreign key (NewsCategoryFk) 
        references NewsCategories
