
    if exists (select * from dbo.sysobjects where id = object_id(N'News') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table News

    create table News (
        NewsId INT IDENTITY NOT NULL,
       Title NVARCHAR(255) not null,
       Body NVARCHAR(MAX) null,
       CreatedAt DATETIME not null,
       primary key (NewsId)
    )
