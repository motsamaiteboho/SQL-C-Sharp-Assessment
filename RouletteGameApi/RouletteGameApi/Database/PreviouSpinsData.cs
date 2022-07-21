namespace RouletteGameApi.Database
{
    public class PreviouSpinsData
    {
        static List<int> _PreviousSpins = new List<int>();
        public static void add(int spin)
        {
            _PreviousSpins.Add(spin);
        }
        public static List<int> GetPreviousSpins()
        {
            return _PreviousSpins;
        }
    }
}
