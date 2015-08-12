using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Helpers
{
    public static class Serializer
    {
		
        public static void Serialize(string path, object obj)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
            }
        }

        public static T Deserialize<T>(string path)
        {
			T value;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                stream.Position = 0;
                value = (T)formatter.Deserialize(stream);
			}
			return value;
        }

    }
}
