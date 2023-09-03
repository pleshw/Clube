namespace Clube.Data
{
    public class ProgressUnknownException : Exception
    {
        internal ProgressUnknownException()
        { }
    }

    public class ProgressTracker : IProgress<double>
    {
        List<IObserver<double>> observers = new List<IObserver<double>>();
        public ProgressTracker()
        {
            observers = new List<IObserver<double>>();
        }

        public ProgressTracker(IObserver<double> observer)
        {
            observers = new List<IObserver<double>> { observer };
        }


        public void Report( double value )
        {
            var tmpProgress = (int)double.Round( value * 100 );
            if (tmpProgress >= 100)
            {
                foreach (var observer in observers)
                {
                    observer.OnCompleted();
                }
                return;
            }

            foreach (var observer in observers)
            {
                if (tmpProgress >= 0)
                {
                    observer.OnNext( value );
                }
                else
                {
                    observer.OnError( new ProgressUnknownException() );
                }
            }
        }
    }
}