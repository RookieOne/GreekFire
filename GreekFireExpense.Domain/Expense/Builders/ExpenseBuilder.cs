using System.Collections.Generic;
using System.Linq;
using GreekFire.Foundation.Extensions;

namespace GreekFire.Domain
{
    /// <summary>
    /// Partial Expense Class that holds the Builder for the Expense
    /// And contains the private constructor
    /// And the ToDto method
    /// </summary>
    public partial class Expense
    {
        /// <summary>
        /// Turns the Expense into the appropriate Data Transfer Object
        /// </summary>
        /// <returns></returns>
        public virtual ExpenseDto ToDto()
        {
            var dto = new ExpenseDto
            {
                Id = Id,
                Description = Description,
                Title = Title,                
                CreatedDate = CreatedDate,
                Total = CalculateTotal()
            };
            dto.LineItems = LineItems.ToList().ConvertAll(i => i.ToDto(dto));
            return dto;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// Protected constructor to prevent construction of an Expense without using
        /// the Builder yet allow other objects to inherit from abstract Expense obj
        /// </summary>
        protected Expense()
        {
            LineItems = new List<ExpenseLineItem>();
        }        

        /// <summary>
        /// Builder Class controls the construction of an Expense
        /// using a fluent interface to either build using methods
        /// or by using a Data Transfer Object
        /// </summary>
        public abstract class Builder<T, B> where T : Expense where B : class
        {
            protected T _expense;

            /// <summary>
            /// Sets the title.
            /// </summary>
            /// <param name="title">The title.</param>
            /// <returns></returns>
            public B withTitle(string title)
            {
                _expense.Title = title;
                return this as B;
            }

            /// <summary>
            /// Sets the description.
            /// </summary>
            /// <param name="description">The description.</param>
            /// <returns></returns>
            public B withDescription(string description)
            {
                _expense.Description = description;
                return this as B;
            }

            /// <summary>
            /// Populates Expense from the dto.
            /// </summary>
            /// <param name="dto">The dto.</param>
            /// <returns></returns>
            public virtual B fromDto(ExpenseDto dto)
            {                
                _expense.Id = dto.Id;
                
                withDescription(dto.Description);
                withTitle(dto.Title);

                dto.LineItems.ForEach(i =>
                {
                    var item = ExpenseLineItem.create()
                        .fromDto(i)
                        .complete();
                    _expense.AddLineItem(item);
                });

                return this as B;
            }

            /// <summary>
            /// Builds and returns the Expense.
            /// </summary>
            /// <returns></returns>
            public T complete()
            {
                return _expense;
            }

            public B copy(Expense expense)
            {                
                return fromDto(expense.ToDto());
            }
        }
    }
}
