
```sql
--建表语句
CREATE TABLE [dbo].[UserInfo](
	[Id] [BIGINT] IDENTITY(1,1) NOT NULL,
	[Name] [NVARCHAR](50) NULL,
	[Age] [INT] NULL,
	[Gender] [NCHAR](10) NULL,
	[Address] [NVARCHAR](50) NULL,
	[CreateTime] [DATETIME] NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```

```sql
--手动插入一条数据，之后批量执行

INSERT INTO	 dbo.UserInfo
(
    Name,
    Age,
    Gender,
    Address,
    CreateTime
)

SELECT 
       [Name]
      ,[Age]
      ,[Gender]
      ,[Address]
      ,[CreateTime]
  FROM [dbo].[UserInfo]

GO 10--执行10次
```