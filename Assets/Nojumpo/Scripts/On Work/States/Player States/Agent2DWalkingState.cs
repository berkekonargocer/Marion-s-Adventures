using UnityEngine;

namespace Nojumpo
{
    public class Agent2DWalkingState : Agent2DState
    {
        // -------------------------------- FIELDS --------------------------------
        [SerializeField] protected Agent2DMovementData agent2DMovementData;

        [SerializeField] Agent2DState idleState;
        
        
        // const string ANIMATOR_STATE_PARAMETER = "Run";
        
        
        // ----------------------------- CONSTRUCTOR ------------------------------


        // ------------------------ CUSTOM PRIVATE METHODS ------------------------


        // ------------------------ CUSTOM PUBLIC METHODS -------------------------
        public override void EnterState() {
            // _agent2D.characterAnimator.PlayAnimation(ANIMATOR_STATE_PARAMETER);
        }
    }
}