namespace Nojumpo.Interfaces
{
    public interface IPointCollector
    {
        // -------------------------------- FIELDS ---------------------------------
        public int CurrentPoint { get; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void AddPoint(int addAmount);
        public void SubtractPoint(int subtractAmount);
        public void MultiplyPoint(int multiplyAmount);
    }
}