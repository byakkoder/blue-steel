using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Common;

namespace Byakkoder.BlueSteel.Domain.Files
{
    public sealed class RelativePathWithoutDrive : ValueObject
    {
        public string Value { get; }

        private RelativePathWithoutDrive(string value) => Value = value;

        public static RelativePathWithoutDrive Create(string value)
        {
            Guard.AgainstNullOrWhiteSpace(value, nameof(value));
            var trimmed = value.Trim();

            // Must not be rooted, and must not start with a separator.
            Guard.Against(Path.IsPathRooted(trimmed), "Path must be relative and must not include a drive or root.", nameof(value));
            Guard.Against(trimmed.StartsWith(Path.DirectorySeparatorChar) || trimmed.StartsWith(Path.AltDirectorySeparatorChar),
                "Path must not start with a directory separator.", nameof(value));

            return new RelativePathWithoutDrive(trimmed);
        }

        protected override IEnumerable<object?> GetEqualityComponents() { yield return Value.ToLowerInvariant(); }
        public override string ToString() => Value;
    }
}
