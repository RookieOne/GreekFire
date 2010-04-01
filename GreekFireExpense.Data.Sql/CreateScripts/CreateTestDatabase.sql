IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseTestDB')

begin

ALTER DATABASE [GreekFireExpenseTestDB] 
    SET SINGLE_USER 
    WITH ROLLBACK IMMEDIATE
    
DROP DATABASE [GreekFireExpenseTestDB]

end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseTestDB')
CREATE DATABASE [GreekFireExpenseTestDB]



IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseTestDB')

begin

ALTER DATABASE [GreekFireExpenseTestDB] 
    SET SINGLE_USER 
    WITH ROLLBACK IMMEDIATE
    
DROP DATABASE [GreekFireExpenseTestDB]

end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseTestDB')
CREATE DATABASE [GreekFireExpenseTestDB]

