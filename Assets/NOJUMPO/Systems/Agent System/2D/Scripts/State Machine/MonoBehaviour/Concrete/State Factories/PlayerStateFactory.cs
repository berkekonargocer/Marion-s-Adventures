using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class PlayerStateFactory : StateFactory
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Agent2DState m_Jump { get; private set; }
        [field: SerializeField] public Agent2DState m_Fall { get; private set; }
        [field: SerializeField] public Agent2DState m_Climb { get; private set; }
        [field: SerializeField] public Agent2DState m_Attack { get; private set; }
        [field: SerializeField] public Agent2DState m_TakeDamage { get; private set; }
        [field: SerializeField] public Agent2DState m_Die { get; private set; }
    }
}