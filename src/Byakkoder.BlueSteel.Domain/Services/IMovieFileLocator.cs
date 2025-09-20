using Byakkoder.BlueSteel.Domain.Files;
using Byakkoder.BlueSteel.Domain.Library;

namespace Byakkoder.BlueSteel.Domain.Services
{
    /// <summary>
    /// Domain service contract to locate an absolute path for a movie file by iterating
    /// over a set of candidate drive roots and the configured media directories.
    /// Implementation belongs to Infrastructure (IO, file system).
    /// </summary>
    public interface IMovieFileLocator
    {
        /// <param name="driveRoots">
        /// Examples: "D:\", "E:\", "/mnt/media/", "/Volumes/Media/".
        /// The application can provide available roots per OS.
        /// </param>
        /// <param name="mediaDirectories">Configured relative directories without drive/root.</param>
        /// <param name="movieFileName">Plain file name to search for (no directories).</param>
        /// <returns>Absolute OS path if found; otherwise null.</returns>
        string? TryResolve(IEnumerable<string> driveRoots,
                           IReadOnlyCollection<MediaDirectory> mediaDirectories,
                           FileName movieFileName);
    }
}
