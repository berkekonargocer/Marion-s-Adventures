namespace Nojumpo
{
    public class IdleState : CharacterState
    {
        // -------------------------------- FIELDS --------------------------------
        const string ANIMATOR_STATE_PARAMETER = "Idle";
        
        
        // ----------------------------- CONSTRUCTOR ------------------------------
        public IdleState(Character character, CharacterStateMachine characterStateMachine) : base(character, characterStateMachine) {
            
        }

        
        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void EnterState() {
            _character.characterAnimator.PlayAnimation(ANIMATOR_STATE_PARAMETER);
        }
    }
}