namespace Nojumpo
{
    public class CharacterStateMachine
    {
        // -------------------------------- FIELDS --------------------------------
        public CharacterState CurrentCharacterState { get; private set; }

        
        // ------------------------ CUSTOM PRIVATE METHODS ------------------------
        
        
        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public void Initialize(CharacterState initialState) {
            CurrentCharacterState = initialState;
            CurrentCharacterState.EnterState();
        }

        public void ChangeState(CharacterState newState) {
            CurrentCharacterState.ExitState();
            CurrentCharacterState = newState;
            CurrentCharacterState.EnterState();
        }

        public bool IsCurrentState(CharacterState characterState) {
            return CurrentCharacterState == characterState;
        }
    }
}