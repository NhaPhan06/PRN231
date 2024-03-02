namespace BussinessLogic.IService;

public interface ICacheManager
{
    Task Set(String key, object value, int time);

    Task<T> Get<T>(string key);

    Task Remove(String key);

}