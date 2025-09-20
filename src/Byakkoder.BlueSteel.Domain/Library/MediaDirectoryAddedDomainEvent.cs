using Byakkoder.BlueSteel.Domain.Abstractions;
using Byakkoder.BlueSteel.Domain.Files;
using Byakkoder.BlueSteel.Domain.Shared;

namespace Byakkoder.BlueSteel.Domain.Library
{
    public sealed class MediaDirectoryAddedDomainEvent : DomainEvent
    {
        public MediaLibraryId LibraryId { get; }
        public int DirectoryId { get; }
        public RelativePathWithoutDrive RelativePath { get; }

        public MediaDirectoryAddedDomainEvent(MediaLibraryId libraryId, int directoryId, RelativePathWithoutDrive relativePath)
        {
            LibraryId = libraryId;
            DirectoryId = directoryId;
            RelativePath = relativePath;
        }
    }
}
