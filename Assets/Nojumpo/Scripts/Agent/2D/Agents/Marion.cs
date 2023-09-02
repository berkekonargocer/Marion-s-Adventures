using System;

namespace Nojumpo
{
    public class Marion : Agent2DBase
    {
        // -------------------------------- FIELDS ---------------------------------
        
        
		
        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void OnEnable() {
	        GameInputReader.onAttackInputPressed += AgentHealth.TakeDamage;
	        GameInputReader.onHealInputPressed += AgentHealth.Heal;
        }
        
        void OnDisable() {
	        GameInputReader.onAttackInputPressed -= AgentHealth.TakeDamage;
	        GameInputReader.onHealInputPressed -= AgentHealth.Heal;
        }

        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
		
		
		
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
		
    }
}