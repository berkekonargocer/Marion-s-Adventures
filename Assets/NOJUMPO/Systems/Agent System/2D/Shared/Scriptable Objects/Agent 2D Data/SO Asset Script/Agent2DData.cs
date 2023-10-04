using UnityEngine;

namespace Nojumpo.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewAgent2DData", menuName = "Nojumpo/Scriptable Objects/Agent2D/Data/New Agent Data")]
    public class Agent2DData : ScriptableObject
    {
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string _developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [Header("MOVEMENT DATA")]
        [Space]
        [SerializeField] float maxSpeed = 6.0f;
        [SerializeField] float accelerationSpeed = 50.0f;
        [SerializeField] float decelerationSpeed = 50.0f;
        [SerializeField] float climbingSpeed = 2.5f;

        public float m_MaxSpeed { get { return maxSpeed; } private set { maxSpeed = value; } }
        public float m_AccelerationSpeed { get { return accelerationSpeed; } private set { accelerationSpeed = value; } }
        public float m_DecelerationSpeed { get { return decelerationSpeed; } private set { decelerationSpeed = value; } }
        public float m_ClimbingSpeed { get { return climbingSpeed; } set { climbingSpeed = value; } }

        [Header("JUMP DATA")]
        [Space]
        [SerializeField] float jumpForce = 12.0f;
        [SerializeField] float lowJumpMultiplier = 2.0f;
        [SerializeField] float maxFallSpeed = 25.0f;

        public float m_JumpForce { get { return jumpForce; } private set { jumpForce = value; } }
        public float m_LowJumpMultiplier { get { return lowJumpMultiplier; } private set { lowJumpMultiplier = value; } }
        public float m_MaxFallSpeed { get { return maxFallSpeed; } }
    }
}