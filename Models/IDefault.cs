namespace Clube.Models
{
    public interface IDefault<T>
    {
        abstract static T GetDefault();
    }
}
