using CleanArchCQRS.Domain.Validation;
using System.Text.Json.Serialization;

namespace CleanArchCQRS.Domain.Entities
{
    public sealed class Member : Entity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Gender { get; private set; }
        public string? Email { get; private set; }
        public bool? IsActive { get; private set; }

        public Member()
        {
            
        }

        public Member(string? firstName, string? lastName, string? gender, string? email, bool? isActive)
        {
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        [JsonConstructor]
        public Member(int id, string? firstName, string? lastName, string? gender, string? email, bool? isActive)
        {
            DomainValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        public void Update(string? firstName, string? lastName, string? gender, string? email, bool? isActive)
        {
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            DomainValidation.When(string.IsNullOrEmpty(firstName), "First Name is required");
            DomainValidation.When(firstName.Length < 3, "First Name too short");
            DomainValidation.When(string.IsNullOrEmpty(lastName), "Last Name is required");
            DomainValidation.When(lastName.Length < 3, "Last Name too short");
            DomainValidation.When(email?.Length > 250, "Email too long");
            DomainValidation.When(email?.Length < 6, "Email too short");
            DomainValidation.When(string.IsNullOrEmpty(gender), "Gender is required");
            DomainValidation.When(!isActive.HasValue, "Must define activity");

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }
    }
}
