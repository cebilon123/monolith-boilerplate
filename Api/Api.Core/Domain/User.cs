using System;
using Api.Domain.Helpers;

namespace Api.Domain.Domain
{
    public class User : IAggregateRoot
    {
        public Guid Id { get; }
        public string Email { get; }
        public string Password { get; }

        public User(Guid id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public static User Create(string email, string password)
            => Create(Guid.NewGuid(), email, password);

        public static User Create(Guid id, string email, string password)
            => new User(id, email, password);
    }
}