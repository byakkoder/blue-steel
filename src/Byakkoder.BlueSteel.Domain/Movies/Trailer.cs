using Byakkoder.BlueSteel.Domain.Abstractions;

namespace Byakkoder.BlueSteel.Domain.Movies
{
    public sealed class Trailer : ValueObject
    {
        public string Title { get; }
        public Uri Url { get; }

        private Trailer(string title, Uri url)
        {
            Title = title;
            Url = url;
        }

        public static Trailer Create(string title, string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
                throw new ArgumentException("Invalid trailer URL.", nameof(url));

            return new Trailer(title?.Trim() ?? string.Empty, uri);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Title.ToLowerInvariant();
            yield return Url.ToString().ToLowerInvariant();
        }
    }
}
