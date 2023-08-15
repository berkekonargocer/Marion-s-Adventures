using UnityEngine;

namespace Nojumpo
{
    public abstract class CharacterState
    {
        // -------------------------------- FIELDS --------------------------------
        protected readonly Character _character;
        protected readonly CharacterStateMachine _characterStateMachine;


        // ----------------------------- CONSTRUCTOR ------------------------------
        public CharacterState(Character character, CharacterStateMachine characterStateMachine) {
            _character = character;
            _characterStateMachine = characterStateMachine;
        }


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------

        public virtual void EnterState() {
            
        }
        
        public virtual void Update() {
            
        }

        public virtual void FixedUpdate(){
        
        }
        
        public virtual void ExitState() {
            
        }
    }
}