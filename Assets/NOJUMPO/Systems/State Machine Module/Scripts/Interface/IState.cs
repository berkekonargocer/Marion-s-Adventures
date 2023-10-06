namespace Nojumpo.StateMachine
{
    public interface IState
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void OnEnterState();
        public void Tick(float deltaTime);
        public void FixedTick();
        public void OnExitState();
    }
}