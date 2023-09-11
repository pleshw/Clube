namespace Clube.Utils
{
    public class RandomList<T> : List<T>
    {
        private static Random _randomGenerator = new Random();
        private T? lastResult;


        public T Get()
        {
            return lastResult = this[_randomGenerator.Next( Count )];
        }

        public T GetExcept( T exception )
        {
            return GetExcept( new List<T> { exception } );
        }

        public T GetExcept(List<T> listExceptions)
        {
            List<T> range = this.Except( listExceptions ).ToList();

            int index = _randomGenerator.Next( 0 , range.Count );
            return lastResult = range.ElementAt( index );
        }

        public T GetExceptLastResult()
        {
            if( lastResult == null)
            {
                return lastResult = Get();
            }

            return lastResult = GetExcept( lastResult );
        }

        public void FYatesShuffle()
        {
            int n = Count;
            while (n > 1)
            {
                n--;
                int k = _randomGenerator.Next( n + 1 );
                T value = this[k];
                this[k] = this[n];
                this[n] = value;
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static RandomList<T> ToRandomList<T>( this List<T> list )
        {
            RandomList<T> randomList = new RandomList<T>();
            randomList.AddRange( list );
            return randomList;
        }

        public static RandomList<T> ToRandomList<T>( this IEnumerable<T> list )
        {
            RandomList<T> randomList = new RandomList<T>();
            randomList.AddRange( list );
            return randomList;
        }
    }
}
