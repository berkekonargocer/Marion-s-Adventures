using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class Player2DStateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Agent2DMovementData m_AgentMovementData { get; private set; }

        [field: SerializeField] public Player2DState m_Idle { get; private set; }
        [field: SerializeField] public Player2DState m_Move { get; private set; }
        [field: SerializeField] public Player2DState m_Jump { get; private set; }
        [field: SerializeField] public Player2DState m_Fall { get; private set; }
        [field: SerializeField] public Player2DState m_Climb { get; private set; }
        [field: SerializeField] public Player2DState m_Attack { get; private set; }
        [field: SerializeField] public Player2DState m_TakeDamage { get; private set; }
        [field: SerializeField] public Player2DState m_Die { get; private set; }

        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void InitializeStates(Player2DStateMachine player2DStateMachine, Agent2DData agent2DData) {
            Player2DState[] agent2DStates = GetComponents<Player2DState>();

            for (int i = agent2DStates.Length - 1; i >= 0; i--)
            {
                agent2DStates[i].Initialize(player2DStateMachine, agent2DData);
            }
        }
    }
}