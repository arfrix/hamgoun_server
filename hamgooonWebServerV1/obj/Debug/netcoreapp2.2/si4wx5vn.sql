IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Post] (
    [Id] bigint NOT NULL IDENTITY,
    [UniqueUrl] nvarchar(max) NULL,
    [PublisherId] bigint NOT NULL,
    [Title] nvarchar(max) NULL,
    [Body] nvarchar(max) NULL,
    [PostSummary] nvarchar(max) NULL,
    [FirstTag] nvarchar(max) NULL,
    [SecondTag] nvarchar(max) NULL,
    [ThirdTag] nvarchar(max) NULL,
    [FourthTag] nvarchar(max) NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [User] (
    [Id] bigint NOT NULL IDENTITY,
    [UserName] nvarchar(max) NULL,
    [Pass] nvarchar(max) NULL,
    [Firstname] nvarchar(max) NULL,
    [Lastname] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [PhoneNumber] bigint NOT NULL,
    [ProfileImgUrl] nvarchar(max) NULL,
    [PhoneVerifed] bit NOT NULL,
    [SMSCode] int NOT NULL,
    [EmailVerifed] bit NOT NULL,
    [EmailCode] int NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190801114735_InitialCreate', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Post] ADD [MainCategory] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Post] ADD [Number] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Post] ADD [SubCategory] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190801171552_ralation_model__and__post_changed', N'2.2.6-servicing-10079');

GO

CREATE TABLE [Relation] (
    [Id] bigint NOT NULL,
    [FollowerId] bigint NOT NULL,
    [FollowedId] bigint NOT NULL,
    [EngagementRate] int NOT NULL,
    [MainCategory] int NOT NULL,
    [SubCategory] int NOT NULL,
    [LastSeenPostNumber] int NOT NULL,
    [TotalPostNumber] int NOT NULL,
    CONSTRAINT [PK_Relation] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190801174327_Relation', N'2.2.6-servicing-10079');

GO

CREATE TABLE [Comment] (
    [Id] bigint NOT NULL,
    [PublisherId] bigint NOT NULL,
    [PostId] bigint NOT NULL,
    [IsReply] bit NULL,
    [ParentCommentId] bigint NULL,
    [CommentText] nvarchar(max) NOT NULL,
    [Number] int NOT NULL,
    CONSTRAINT [PK_Comment] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190802224812_Comment_Model', N'2.2.6-servicing-10079');

GO

ALTER TABLE [User] ADD [Book_category1Name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Book_category2Name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Edu_highSchool] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Edu_subject] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Edu_univercity] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Languge_dialect] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Languge_forthLangName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Languge_motherTongue] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Languge_secondLangName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Languge_thirdLangName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Location_livingCountry] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Location_livingTown] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Location_motherTown] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Movie_category1Name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Movie_category2Name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Music_category1Name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Music_category2Name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Relation] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Skill_mainSkillName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Skill_secondSkillName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Sport_name] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Sport_playerName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Sport_teamName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [StickerUrl1] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [StickerUrl2] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [StickerUrl3] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [StickerUrl4] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [StickerUrl5] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Teach_mainTeachName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Teach_secondTeachName] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Work_company] nvarchar(max) NULL;

GO

ALTER TABLE [User] ADD [Work_job] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190803173549_user_model_complete', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Post] ADD [IsDrafted] bit NOT NULL DEFAULT 1;

GO

ALTER TABLE [Post] ADD [Kind] int NOT NULL DEFAULT 0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190809093610_Post_kind_and_IsDrafted', N'2.2.6-servicing-10079');

GO

ALTER TABLE [Post] ADD [PublisherUsername] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190809101711_post_publisherusrname', N'2.2.6-servicing-10079');

GO

CREATE TABLE [Image] (
    [Id] bigint NOT NULL IDENTITY,
    [PublisherId] bigint NOT NULL,
    [url] nvarchar(max) NULL,
    CONSTRAINT [PK_Image] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190810091921_image', N'2.2.6-servicing-10079');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190817142731_InitialCreate1', N'2.2.6-servicing-10079');

GO

