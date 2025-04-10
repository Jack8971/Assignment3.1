using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Assignment3
{
    [DataContract]
    public class User : IEquatable<User>
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string Email { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        public bool IsCorrectPassword(string input)
        {
            if (string.IsNullOrEmpty(Password) == string.IsNullOrEmpty(input))
                return true;
            else if (string.IsNullOrEmpty(Password) != string.IsNullOrEmpty(input))
                return false;
            else
                return Password.Equals(input);
        }

        public override bool Equals(Object other)
        {
            if (!(other is User otherUser))
                return false;

            return Id == otherUser.Id && Name.Equals(otherUser.Name) && Email.Equals(otherUser.Email);
        }

        public bool Equals(User other)
        {
            return !(other is null) &&
                   Id == other.Id &&
                   Name == other.Name &&
                   Email == other.Email &&
                   Password == other.Password;
        }

        public override int GetHashCode()
        {
            int hashCode = 825453597;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}
