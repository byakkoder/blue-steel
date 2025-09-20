using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Files;

namespace Byakkoder.BlueSteel.Domain.Library
{
    public sealed class MediaDirectory : Entity<int> // child entity inside the aggregate
    {
        public RelativePathWithoutDrive RelativePath { get; private set; }
        public string? FriendlyName { get; private set; }

        // EF-friendly protected ctor if needed
        private MediaDirectory() { }

        internal MediaDirectory(int id, RelativePathWithoutDrive relativePath, string? friendlyName = null) : base(id)
        {
            RelativePath = relativePath;
            FriendlyName = string.IsNullOrWhiteSpace(friendlyName) ? null : friendlyName.Trim();
        }

        internal void Rename(string? friendlyName)
            => FriendlyName = string.IsNullOrWhiteSpace(friendlyName) ? null : friendlyName.Trim();
    }
}
