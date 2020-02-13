using System.Collections.Generic;
using System.Linq;

namespace Scrabble.Extensions
{
    public static class CollectionExtensions
    {
        public static T Pop<T>(this ICollection<T> collection, int? location = null)
        {
            T result = collection.ElementAtOrDefault(location ?? 0);
            collection.Remove(result);
            return result;
        }
    }
}