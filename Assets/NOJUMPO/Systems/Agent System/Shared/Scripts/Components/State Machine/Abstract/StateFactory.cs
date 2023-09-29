using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class StateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Agent2DMovementData m_AgentMovementData { get; private set; }

        [field: SerializeField] public Agent2DState m_Idle { get; private set; }
        [field: SerializeField] public Agent2DState m_Move { get; private set; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void InitializeStates(Agent2D agent2D, Agent2DData agent2DData) {
            Agent2DState[] agent2DStates = GetComponents<Agent2DState>();

            for (int i = agent2DStates.Length - 1; i >= 0; i--)
            {
                agent2DStates[i].Initialize(agent2D, agent2DData);
            }
        }
    }
}