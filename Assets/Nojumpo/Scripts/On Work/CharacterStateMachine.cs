namespace Nojumpo
{
    public class CharacterStateMachine
    {
        // -------------------------------- FIELDS --------------------------------
        public Agent2DStateBase currentAgent2DState { get; private set; }

        
        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        
        
        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void Initialize(Agent2DStateBase initial2DState) {
            currentAgent2DState = initial2DState;
            currentAgent2DState.Enter();
        }

        public void ChangeState(Agent2DStateBase newState) {
            currentAgent2DState.Exit();
            currentAgent2DState = newState;
            currentAgent2DState.Enter();
        }

        public bool IsCurrentState(Agent2DStateBase agent2DState) {
            return currentAgent2DState == agent2DState;
        }
    }
}