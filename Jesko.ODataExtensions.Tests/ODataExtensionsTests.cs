using NUnit.Framework;

namespace Jesko.ODataExtensions.Tests
{
    [TestFixture]
    public class ODataExtensionsTests
    {
        [Test]
        public void Filter_Generates_OData_Filter_For_Equality()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.StringProperty == "value");

            Assert.AreEqual("$filter(StringProperty eq 'value')", actual.ToString());
        }
        
        [Test]
        public void Filter_Generates_OData_Filter_For_Equality_With_NumericVariable_OnRightSide()
        {
            var instance = new ClassWithProperties();
            const int rightSide = 23;

            var actual = instance.Filter(x => x.IntegerProperty == rightSide);

            Assert.AreEqual("$filter(IntegerProperty eq '23')", actual.ToString());
        }

        [Test]
        public void Filter_Works_On_Types_Other_Than_The_InstanceType()
        {
            var instance = new OtherClass();
            const int rightSide = 23;

            var actual = instance.Filter<ClassWithProperties>(x => x.IntegerProperty == rightSide);

            Assert.AreEqual("$filter(IntegerProperty eq '23')", actual.ToString());
        }
    }

    class ClassWithProperties
    {
        public string StringProperty { get; set; }
        public int IntegerProperty { get; set; }
    }

    class OtherClass
    {
    }
}