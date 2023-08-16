namespace Nojumpo
{
    public class CharacterStateMachine
    {
        // -------------------------------- FIELDS --------------------------------
        public Agent2DState currentAgent2DState { get; private set; }

        
        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        
        
        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void Initialize(Agent2DState initial2DState) {
            currentAgent2DState = initial2DState;
            currentAgent2DState.EnterState();
        }

        public void ChangeState(Agent2DState newState) {
            currentAgent2DState.ExitState();
            currentAgent2DState = newState;
            currentAgent2DState.EnterState();
        }

        public bool IsCurrentState(Agent2DState agent2DState) {
            return currentAgent2DState == agent2DState;
        }
    }
}