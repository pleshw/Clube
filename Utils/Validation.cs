namespace Clube.Utils
{
    public class Validation<T>
    {
        public delegate bool Validator( T elementToValidade , in List<string> errorMessages );

        public required List<Validator> Methods;

        public bool IsValid( T elementToValidate , out List<string> errorMessages )
        {
            List<string> _errorMessages = new();
            bool result = Methods.Aggregate( true , ( currentResult , next ) => currentResult && next( elementToValidate , in _errorMessages ) );
            errorMessages = _errorMessages;
            return result;
        }
    }
}
