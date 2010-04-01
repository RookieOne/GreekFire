set xact_abort on;
go

begin transaction;
go

set ansi_nulls on;
go

create schema [GreekFireExpense];
go

create table [GreekFireExpense].[ExpensesTable]
(
  [Id] bigint not null identity,
  [ApprovalDate] datetime null,
  [CreatedDate] datetime not null,
  [Description] nvarchar(max) not null,
  [Title] nvarchar(max) not null,
  constraint [PK_ExpensesTable] primary key clustered ([Id])
);
go

create table [GreekFireExpense].[ExpenseLineItemsTable]
(
  [Id] bigint not null identity,
  [Amount] decimal(28,6) not null,
  [Description] nvarchar(max) not null,
  [Expense] bigint not null,
  constraint [PK_ExpenseLineItemsTable] primary key clustered ([Id]),
  constraint [FK_ExpenseLineItemsTable_Expense_GreekFireExpense_ExpensesTable] foreign key ([Expense]) references [GreekFireExpense].[ExpensesTable] ([Id])
);
go

commit transaction;
go
