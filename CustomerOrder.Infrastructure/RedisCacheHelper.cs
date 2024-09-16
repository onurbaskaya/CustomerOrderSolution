using StackExchange.Redis;
using System;

namespace CustomerOrder.Infrastructure
{
    public class RedisCacheHelper
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisCacheHelper(string connectionString)
        {
            // OB(15.09.2024): Redis bağlantısı oluşturuluyor.
            _redis = ConnectionMultiplexer.Connect(connectionString);
            _db = _redis.GetDatabase();
        }

        public void SetCacheValue(string key, string value)
        {
            // OB(15.09.2024): Cache'e değer ekleme işlemi.
            _db.StringSet(key, value);
        }

        public string GetCacheValue(string key)
        {
            // OB(15.09.2024): Cache'den değer alma işlemi.
            return _db.StringGet(key);
        }

        public void RemoveCacheValue(string key)
        {
            // OB(15.09.2024): Cache'den değer silme işlemi.
            _db.KeyDelete(key);
        }
    }
}
