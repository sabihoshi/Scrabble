using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scrabble.Models
{
    public static class CollectionExtensions
    {
        public static T Pop<T>(this ICollection<T> collection, int? location = null)
        {
            var result = collection.ElementAtOrDefault(location ?? 0);
            collection.Remove(result);
            return result;
        }
    }
}
