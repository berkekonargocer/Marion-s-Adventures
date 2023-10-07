using UnityEngine;
using UnityEngine.Serialization;

namespace Nojumpo.AgentSystem
{
    [CreateAssetMenu(fileName = "NewAgent2DData", menuName = "Nojumpo/Scriptable Objects/Agent2D/Data/New Agent Data")]
    public class Agent2DData : ScriptableObject
    {
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string _developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [FormerlySerializedAs("maxSpeed")]
        [Header("MOVEMENT DATA")]
        [Space]
        [SerializeField] float walkingSpeed = 3.0f;
        [SerializeField] float runningSpeed = 6.0f;
        [SerializeField] float accelerationSpeed = 50.0f;
        [SerializeField] float decelerationSpeed = 50.0f;
        [SerializeField] float climbingSpeed = 2.5f;

        public float m_RunningSpeed { get { return runningSpeed; } private set { runningSpeed = value; } }
        public float m_WalkingSpeed { get { return walkingSpeed; } private set { walkingSpeed = value; } }
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