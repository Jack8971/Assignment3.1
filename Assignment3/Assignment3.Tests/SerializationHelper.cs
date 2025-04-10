using System.Runtime.Serialization;

namespace Assignment3
{
    public static class SerializationHelper
    {
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));

            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, userList);
                File.WriteAllBytes(fileName, stream.ToArray());
            }
        }

        public static ILinkedListADT DeserializeUsers(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<User>));
            byte[] data = File.ReadAllBytes(fileName);

            using (MemoryStream stream = new MemoryStream(data))
            {
                var userList = (List<User>)serializer.ReadObject(stream);
                ILinkedListADT list = new SLL();

                foreach (User user in userList)
                {
                    list.AddLast(user);
                }

                return list;
            }
        }
    }
}
