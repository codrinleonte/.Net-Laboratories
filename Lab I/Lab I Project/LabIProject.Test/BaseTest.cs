namespace LabIProject.Test
{
    public abstract class BaseTest<T> where T : class
    {
        protected BaseTest()
        {
            SystemUnderTest = SetupSystemUnderTest();
        }

        protected T SystemUnderTest;
        protected abstract T SetupSystemUnderTest();
    }
}