using Newtonsoft.Json;

namespace TxtDatabase
{
    public static class Database
    {
        public static void Save(DatabaseObject obj)
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory; //TODO Add proper folder for database
            var filePath = currentPath + "/" + obj.GetType().Name + ".txt";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            string[] lines = File.ReadAllLines(filePath);

            var objectSerialized = JsonConvert.SerializeObject(obj);

            var lineToSave = $"{obj.Id};{objectSerialized}";
            //Update Line

            int lineIndex = 0;
            bool hasUpdatedLine = false;
            foreach (string line in lines)
            {
                if (line.Split(';')[0] == obj.Id)
                {
                    lines[lineIndex] = lineToSave;
                    hasUpdatedLine = true;
                    break;
                }
                lineIndex++;
            }

            if (!hasUpdatedLine)
            {
                var linesList = lines.ToList();
                linesList.Add(lineToSave);
                lines = linesList.ToArray();
            }

            File.WriteAllLines(filePath, lines);
        }

        public static List<T> Query<T>()
        {
            if(!typeof(T).IsSubclassOf(typeof(DatabaseObject)))
            {
                throw new ArgumentException("Only database objects can be queried.");
            }

            string currentPath = AppDomain.CurrentDomain.BaseDirectory; //TODO Add proper folder for database
            var filePath = currentPath + typeof(T).Name + ".txt";

            if (!File.Exists(filePath))
            {
                return new List<T> { };
            }

            string[] lines = File.ReadAllLines(filePath);

            List<T> table = new List<T>();

            foreach(var line in lines)
            {
                var deserializedObject = JsonConvert.DeserializeObject<T>(line.Split(';')[1]);
                if(deserializedObject is not null)
                {
                    (deserializedObject as DatabaseObject).Id = line.Split(';')[0];
                    table.Add(deserializedObject);
                }
            }

            return table.ToList();
        }

        public static void Delete(DatabaseObject obj)
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory; //TODO Add proper folder for database
            var filePath = currentPath + obj.GetType().Name + ".txt";

            if (!File.Exists(filePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            List<string> linesList = lines.ToList();

            foreach (string line in lines)
            {
                if (line.Split(';')[0] == obj.Id)
                {
                    linesList.Remove(line);
                    break;
                }
            }

            File.WriteAllLines(filePath, linesList.ToArray());
        }
    }

}