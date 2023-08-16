using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo
{
    public class PlayerIdleState : Agent2DState
    {
	    // -------------------------------- FIELDS ---------------------------------
	    [SerializeField] Agent2DState walkingState;
	    
		
	    // ------------------------- CUSTOM PRIVATE METHODS ------------------------
		
		
        
	    // ------------------------- CUSTOM PUBLIC METHODS -------------------------
	    public override void EnterState() {
		    _agent2D.agentAnimator.PlayAnimation("Idle");
	    }

	    protected override void HandleMovement() {
		    Vector2 moveInput = InputReader.Instance.MoveInput;

		    
		    if (Mathf.Abs(moveInput.x) > 0)
		    {
			    
			    _agent2D.ChangeState(walkingState,this);
			    
			    
			    // if (moveInput.x > 0)
			    // {
				   //  transform.localScale = Vector3.one;
			    // }
			    // else if (moveInput.x < 0)
			    // {
				   //  transform.localScale = new Vector3(-1, 1, 1);
			    // }
			    // if (Mathf.Abs(_rigidbody2D.velocity.x) < 0.01f)
			    // {
				   //  characterAnimator.PlayAnimation(CharacterAnimationType.RUN);
			    // }
		    }
	    }
    }
}