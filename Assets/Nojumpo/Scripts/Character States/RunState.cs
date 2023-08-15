using System;

namespace Nojumpo
{
    public class RunState : CharacterState
    {
        // -------------------------------- FIELDS --------------------------------
        const string ANIMATOR_RUN_STATE_PARAMETER = "Run";
        
        
        // ----------------------------- CONSTRUCTOR ------------------------------
        public RunState(Character character, CharacterStateMachine characterStateMachine) : base(character, characterStateMachine) {
            
        }
        

        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------

    }
}