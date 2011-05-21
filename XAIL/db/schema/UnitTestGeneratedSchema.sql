
    if exists (select * from dbo.sysobjects where id = object_id(N'News') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table News

    if exists (select * from dbo.sysobjects where id = object_id(N'Users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table Users

    create table News (
        NewsId INT IDENTITY NOT NULL,
       Title NVARCHAR(255) not null,
       Body NVARCHAR(MAX) null,
       CreatedAt DATETIME not null,
       primary key (NewsId)
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
