using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using GreekFireExpense.Data.EntityFramework;

namespace GreekFireExpense.Console
{
    public class MyExp
    {
        private EntityCollection<ExpenseLineItems> _items;
        public EntityCollection<ExpenseLineItems> Items 
        {
            get { return _items; } 
            set
            {
                _items = value;
            }
        }
    }
}
