using System.Text.Json;

namespace eshop.MVC.ExtensionMerhods
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            var serialized = JsonSerializer.Serialize(value);
            session.SetString(key, serialized);
        }

        public static T GetJson<T>(this ISession session, string key) where T : class, new()
        {

            var serializedString = session.GetString(key);

            return serializedString == null ? default(T) : JsonSerializer.Deserialize<T>(serializedString);


        }
    }
}
