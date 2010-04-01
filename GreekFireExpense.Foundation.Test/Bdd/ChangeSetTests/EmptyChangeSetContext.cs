using GreekFire.Foundation.ChangeSets;
using GreekFireExpense.Foundation_Test.Bdd;

namespace GreekFireExpense.Foundation_Test.ChangeSetTests
{
    public abstract class EmptyChangeSetContext : ContextSpecification
    {
        protected ChangeSet ChangeSet { get; set; }

        protected override void Context()
        {
            ChangeSet = new ChangeSet();            
        }
    }
}
