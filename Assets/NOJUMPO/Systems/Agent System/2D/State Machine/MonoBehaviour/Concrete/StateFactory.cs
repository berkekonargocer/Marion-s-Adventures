using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class StateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Agent2DState m_Idle { get; protected set; }
        [field: SerializeField] public Agent2DState m_Move { get; protected set; }
        [field: SerializeField] public Agent2DState m_Jump { get; protected set; }
        [field: SerializeField] public Agent2DState m_Fall { get; protected set; }
        [field: SerializeField] public Agent2DState m_Climb { get; protected set; }
        [field: SerializeField] public Agent2DState m_Attack { get; protected set; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void InitializeStates(Agent2D agent2D, Agent2DData agent2DData) {
            Agent2DState[] agent2DStates = GetComponents<Agent2DState>();

            for (int i = 0; i < agent2DStates.Length; i++)
            {
                agent2DStates[i].Initialize(agent2D, agent2DData);
            }
        }
    }
}