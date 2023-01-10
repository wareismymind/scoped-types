namespace WareIsMyMind.ScopedTypes.UnitTests;

public class ScopedTests
{
    public class ValueConstructor
    {
        [Fact]
        public void NullValue_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Scoped<object, string>(null!));
        }
    }

    public class CastToT
    {
        [Fact]
        public void ImplicitCastToT_Compiles()
        {
            Assert.Equal(7, new Scoped<int, string>(7));
        }
    }

    public class CastFromT
    {
        [Fact]
        public void ExplicitCastFromT_Compiles()
        {
            _ = (Scoped<int, string>)5;
        }
    }
}