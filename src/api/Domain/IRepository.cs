using System.Runtime.InteropServices.ComTypes;

namespace OutreachOperations.Api.Domain
{
    public interface IRepository  
    {
    long Insert<T>(T item) where T : class;
    void Remove<T>(T item);
    void Update<T>(T item);
    T FindById<T>(int id) where T : class;
    T Find<T>();

    }
}
