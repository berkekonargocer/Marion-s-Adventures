namespace Nojumpo.Interfaces
{
    public interface IState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void OnEnterState();
        public void Tick();
        public void FixedTick();
        public void OnExitState();
    }
}