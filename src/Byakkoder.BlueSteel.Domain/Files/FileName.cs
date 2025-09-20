using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Common;

namespace Byakkoder.BlueSteel.Domain.Files
{
    public sealed class FileName : ValueObject
    {
        public string Value { get; }

        private FileName(string value) => Value = value;

        public static FileName Create(string value)
        {
            Guard.AgainstNullOrWhiteSpace(value, nameof(value));
            // Must be a plain filename: no directory separators and no root.
            bool hasSeparator = value.Contains(Path.DirectorySeparatorChar) || value.Contains(Path.AltDirectorySeparatorChar);
            Guard.Against(hasSeparator, "File name must not contain directory separators.", nameof(value));
            Guard.Against(Path.IsPathRooted(value), "File name must not be rooted.", nameof(value));
            return new FileName(value.Trim());
        }

        protected override IEnumerable<object?> GetEqualityComponents() { yield return Value.ToLowerInvariant(); }
        public override string ToString() => Value;
    }
}
