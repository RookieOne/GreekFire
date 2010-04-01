using NUnit.Framework;

namespace GreekFireExpense.Foundation_Test.Bdd
{
    /// <summary>
    /// Provides common services for BDD-style (context/specification) unit tests.  
    /// Serves as an adapter between the MSTest framework and our BDD-style tests.
    /// written by Eric Lee
    /// found @ (http://blogs.msdn.com/elee/archive/2009/01/20/bdd-with-mstest.aspx)
    /// </summary>
    public abstract class ContextSpecification
    {
        /// <summary>
        /// Steps that are run before each test.
        /// </summary>
        [SetUp]
        public void TestSetup()
        {
            Context();
            BecauseOf();
        }

        /// <summary>
        /// Steps that are run after each test.
        /// </summary>
        [TearDown]
        public void TestTearDown()
        {
            Cleanup();
        }

        /// <summary>
        /// Sets up the environment for a specification context.
        /// </summary>
        protected virtual void Context()
        {

        }

        /// <summary>
        /// Acts on the context to create the observable condition.
        /// </summary>
        protected virtual void BecauseOf()
        {

        }

        /// <summary>
        /// Cleans up the context after the specification is verified.
        /// </summary>
        protected virtual void Cleanup()
        {

        }
    }
}
