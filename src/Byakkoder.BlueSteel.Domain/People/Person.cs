using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Common;
using Byakkoder.BlueSteel.Domain.Files;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.People
{
    public sealed class Person : Entity<PersonId>
    {
        public string FullName { get; private set; }
        public FileName? PhotoFileName { get; private set; }
        public DateOnly? BirthDate { get; private set; }
        public string? PlaceOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public string? Biography { get; private set; }

        private Person(PersonId id, string fullName) : base(id)
        {
            FullName = fullName;
            Gender = Gender.Unknown;
        }

        public static Person Create(PersonId id, string fullName)
        {
            Guard.AgainstNullOrWhiteSpace(fullName, nameof(fullName));
            return new Person(id, fullName.Trim());
        }

        public void Rename(string fullName)
        {
            Guard.AgainstNullOrWhiteSpace(fullName, nameof(fullName));
            FullName = fullName.Trim();
        }

        public void SetPhoto(FileName? photo) => PhotoFileName = photo;
        public void SetBirth(DateOnly? birthDate, string? placeOfBirth)
        {
            BirthDate = birthDate;
            PlaceOfBirth = string.IsNullOrWhiteSpace(placeOfBirth) ? null : placeOfBirth.Trim();
        }

        public void SetGender(Gender gender) => Gender = gender;

        public void SetBiography(string? biography)
            => Biography = string.IsNullOrWhiteSpace(biography) ? null : biography.Trim();
    }
}
