using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class AI2DStateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public AI2DState m_Idle { get; private set; }
        [field: SerializeField] public AI2DState m_Patrol { get; private set; }
        [field: SerializeField] public AI2DState m_Chase { get; private set; }
        [field: SerializeField] public AI2DState m_Attack { get; private set; }
        [field: SerializeField] public AI2DState m_TakeDamage { get; private set; }
        [field: SerializeField] public AI2DState m_Die { get; private set; }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void InitializeStates(AI2DStateMachine ai2DStateMachine, Agent2DData agent2DData) {
            AI2DState[] agent2DStates = GetComponents<AI2DState>();

            for (int i = agent2DStates.Length - 1; i >= 0; i--)
            {
                agent2DStates[i].Initialize(ai2DStateMachine, agent2DData);
            }
        }
    }
}