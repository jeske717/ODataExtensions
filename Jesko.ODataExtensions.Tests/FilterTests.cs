using NUnit.Framework;

namespace Jesko.ODataExtensions.Tests
{
    [TestFixture]
    public class FilterTests
    {
        [Test]
        public void Filter_Generates_OData_Filter_For_Equality()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.StringProperty == "value");

            Assert.AreEqual("$filter(StringProperty eq 'value')", actual.ToString());
        }
        
        [Test]
        public void Filter_Works_On_Types_Other_Than_The_InstanceType()
        {
            var instance = new OtherClass();
            const int rightSide = 23;

            var actual = instance.Filter<ClassWithProperties>(x => x.IntegerProperty == rightSide);

            Assert.AreEqual("$filter(IntegerProperty eq '23')", actual.ToString());
        }

        [Test]
        public void Filter_Generates_Inequality_Filter_When_Expression_Represents_Inequality()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.StringProperty != "value");

            Assert.AreEqual("$filter(StringProperty ne 'value')", actual.ToString());
        }

        [Test]
        public void Filter_Generates_GreaterThan_Filter_When_Expression_Represents_GreaterThan()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.IntegerProperty > 7);

            Assert.AreEqual("$filter(IntegerProperty gt '7')", actual.ToString());
        }

        [Test]
        public void Filter_Generates_GreaterThanOrEqualTo_Filter_When_Expression_Represents_GreaterThanOrEqualTo()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.IntegerProperty >= 7);

            Assert.AreEqual("$filter(IntegerProperty ge '7')", actual.ToString());
        }

        [Test]
        public void Filter_Generates_LessThan_Filter_When_Expression_Represents_LessThan()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.IntegerProperty < 7);

            Assert.AreEqual("$filter(IntegerProperty lt '7')", actual.ToString());
        }

        [Test]
        public void Filter_Generates_LessThanOrEqualTo_Filter_When_Expression_Represents_LessThanOrEqualTo()
        {
            var instance = new ClassWithProperties();

            var actual = instance.Filter(x => x.IntegerProperty <= 7);

            Assert.AreEqual("$filter(IntegerProperty le '7')", actual.ToString());
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