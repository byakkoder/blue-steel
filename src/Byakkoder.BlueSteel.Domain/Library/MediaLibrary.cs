using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Files;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Library
{
    public sealed class MediaLibrary : AggregateRoot<MediaLibraryId>
    {
        private readonly List<MediaDirectory> _directories = new();

        public IReadOnlyList<MediaDirectory> Directories => _directories;

        private MediaLibrary(MediaLibraryId id) : base(id) { }

        public static MediaLibrary Create(MediaLibraryId id) => new(id);

        public MediaDirectory AddDirectory(RelativePathWithoutDrive relativePath, string? friendlyName = null)
        {
            // prevent duplicates (case-insensitive)
            if (_directories.Any(d => d.RelativePath.Equals(relativePath)))
                throw new InvalidOperationException("The media directory already exists.");

            var nextId = _directories.Count == 0 ? 1 : _directories.Max(d => d.Id) + 1;
            var dir = new MediaDirectory(nextId, relativePath, friendlyName);
            _directories.Add(dir);

            Raise(new MediaDirectoryAddedDomainEvent(Id, dir.Id, dir.RelativePath));
            return dir;
        }

        public void RemoveDirectory(int directoryId)
        {
            var dir = _directories.FirstOrDefault(d => d.Id == directoryId)
                      ?? throw new KeyNotFoundException("Media directory not found.");

            _directories.Remove(dir);
        }
    }
}
