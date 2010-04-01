
module GreekFireExpense
{
    type Expense
    {
        Id : Integer64 = AutoNumber();
        Description : Text;
        Title : Text;   
        CreatedDate : DateTime;
        ApprovalDate : DateTime?;        
    } where identity Id;
    
    ExpensesTable : Expense*;
    
    type ExpenseLineItem
    {
        Id : Integer64 = AutoNumber();
        Description : Text;
        Amount : Decimal28;
        Expense : Expense;
    } where identity Id;
        
    ExpenseLineItemsTable : ExpenseLineItem* where item.Expense in ExpensesTable;
}