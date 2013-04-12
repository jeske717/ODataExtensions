namespace Jesko.ODataExtensions.Mixins
{
    public interface IODataCapable : IODataCapable<object>
    {
    }
    
    public interface IODataCapable<TResult> where TResult : class
    {
    }
}