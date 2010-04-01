IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseDB')

begin

ALTER DATABASE [GreekFireExpenseDB] 
    SET SINGLE_USER 
    WITH ROLLBACK IMMEDIATE
    
DROP DATABASE [GreekFireExpenseDB]

end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseDB')
CREATE DATABASE [GreekFireExpenseDB]



IF  EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseDB')

begin

ALTER DATABASE [GreekFireExpenseDB] 
    SET SINGLE_USER 
    WITH ROLLBACK IMMEDIATE
    
DROP DATABASE [GreekFireExpenseDB]

end

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'GreekFireExpenseDB')
CREATE DATABASE [GreekFireExpenseDB]

