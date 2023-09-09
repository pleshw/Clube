namespace Clube.Utils
{
    public static class ListUtils
    {
        private static Random _randomGenerator = new Random();
        
        public static T GetRandom<T>( this List<T> list )
        {
            return list[_randomGenerator.Next( list.Count )];
        }
    }
}
