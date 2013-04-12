namespace Jesko.ODataExtensions
{
    public abstract class OData
    {
        public abstract string Type { get; }
        public string PropertyName { get; set; }
    }

    public class FilterOData : OData
    {
        public override string Type
        {
            get { return "filter"; }
        }

        public string Method { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("${0}=({1} {2} '{3}')", Type, PropertyName, Method, Value);
        }
    }

    public class OrderByOData : OData
    {
        public override string Type
        {
            get { return "orderby"; }
        }

        public string Order { get; set; }

        public override string ToString()
        {
            return string.Format("${0}=({1} {2})", Type, PropertyName, Order);
        }
    }
}