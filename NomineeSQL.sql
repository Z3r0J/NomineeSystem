USE [NomineeProject]
GO
/****** Object:  Table [dbo].[Deduction]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deduction](
	[IdDeduction] [int] IDENTITY(1,1) NOT NULL,
	[DeductionName] [nvarchar](max) NULL,
	[Apply] [bit] NOT NULL,
	[State] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED 
(
	[IdDeduction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[departmentName] [nvarchar](max) NULL,
	[location] [nvarchar](max) NULL,
	[departmentLeader] [nvarchar](max) NULL,
	[PayrollIdPayroll] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[IdEmployee] [int] IDENTITY(1,1) NOT NULL,
	[Documents] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DepartmentId] [int] NOT NULL,
	[JobPositionId] [int] NOT NULL,
	[MonthlySalary] [float] NOT NULL,
	[UsersIdUsers] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[IdEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Income]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Income](
	[incomeId] [int] IDENTITY(1,1) NOT NULL,
	[incomeName] [nvarchar](max) NULL,
	[apply] [bit] NOT NULL,
	[state] [nvarchar](max) NULL,
 CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED 
(
	[incomeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobPosition]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobPosition](
	[IdPosition] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](max) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[RiskLevel] [nvarchar](max) NULL,
	[MaxSalary] [int] NOT NULL,
	[MinSalary] [int] NOT NULL,
 CONSTRAINT [PK_JobPosition] PRIMARY KEY CLUSTERED 
(
	[IdPosition] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[IdPayroll] [int] IDENTITY(1,1) NOT NULL,
	[payName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payroll] PRIMARY KEY CLUSTERED 
(
	[IdPayroll] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionRegister]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionRegister](
	[IdTransaction] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeIdEmployee] [int] NULL,
	[IdDeductionOrIncome] [int] NOT NULL,
	[TypeTransactionIdTypeTransaction] [int] NULL,
	[Date] [datetime2](7) NOT NULL,
	[Amount] [bigint] NOT NULL,
	[State] [bit] NOT NULL,
 CONSTRAINT [PK_TransactionRegister] PRIMARY KEY CLUSTERED 
(
	[IdTransaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeTransaction]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeTransaction](
	[IdTypeTransaction] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeTransaction] PRIMARY KEY CLUSTERED 
(
	[IdTypeTransaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 4/21/2022 12:49:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUsers] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUsers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_PayrollId] FOREIGN KEY([PayrollIdPayroll])
REFERENCES [dbo].[Payroll] ([IdPayroll])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_PayrollId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Department_DepartmentId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_JobPosition_JobPositionId] FOREIGN KEY([JobPositionId])
REFERENCES [dbo].[JobPosition] ([IdPosition])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_JobPosition_JobPositionId]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Users_UsersIdUsers] FOREIGN KEY([UsersIdUsers])
REFERENCES [dbo].[Users] ([IdUsers])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Users_UsersIdUsers]
GO
ALTER TABLE [dbo].[JobPosition]  WITH CHECK ADD  CONSTRAINT [FK_JobPosition_Department_IdDepartment] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[JobPosition] CHECK CONSTRAINT [FK_JobPosition_Department_IdDepartment]
GO
ALTER TABLE [dbo].[TransactionRegister]  WITH CHECK ADD  CONSTRAINT [FK_TransactionRegister_Employees_EmployeeIdEmployee] FOREIGN KEY([EmployeeIdEmployee])
REFERENCES [dbo].[Employees] ([IdEmployee])
GO
ALTER TABLE [dbo].[TransactionRegister] CHECK CONSTRAINT [FK_TransactionRegister_Employees_EmployeeIdEmployee]
GO
ALTER TABLE [dbo].[TransactionRegister]  WITH CHECK ADD  CONSTRAINT [FK_TransactionRegister_TypeTransaction_TypeTransactionIdTypeTransaction] FOREIGN KEY([TypeTransactionIdTypeTransaction])
REFERENCES [dbo].[TypeTransaction] ([IdTypeTransaction])
GO
ALTER TABLE [dbo].[TransactionRegister] CHECK CONSTRAINT [FK_TransactionRegister_TypeTransaction_TypeTransactionIdTypeTransaction]
GO
