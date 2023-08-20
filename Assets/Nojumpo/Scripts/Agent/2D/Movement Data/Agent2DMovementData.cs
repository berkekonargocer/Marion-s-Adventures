using UnityEngine;

namespace Nojumpo
{
    [CreateAssetMenu(fileName = "NewAgent2DMovementData", menuName = "Nojumpo/Scriptable Objects/Agent2D/Data/New Movement Data")]
    public class Agent2DMovementData : ScriptableObject
    {
        // -------------------------------- FIELDS --------------------------------
        public float HorizontalMovementDirection;
        public float CurrentSpeed;
        public Vector2 CurrentVelocity;
    }
}