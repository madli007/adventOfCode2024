namespace Day_5
{
    internal static class ListExtension
    {
        private static readonly Random rng = new();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        public static IEnumerable<T> Prepend<T>(
        this IEnumerable<T> items,
        T first)
        {
            yield return first;
            foreach (T item in items)
                yield return item;
        }
        public static IEnumerable<IEnumerable<T>> Combinations<T>(
            this IEnumerable<T> items)
        {
            if (!items.Any())
                yield return items;
            else
            {
                var head = items.First();
                var tail = items.Skip(1);
                foreach (var sequence in tail.Combinations())
                {
                    yield return sequence; // Without first
                    yield return sequence.Prepend(head);
                }
            }
        }
    }
}
