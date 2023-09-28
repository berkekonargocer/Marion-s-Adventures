using System;
using Nojumpo.ScriptableObjects;
using UnityEngine;

namespace Nojumpo.AgentSystem
{
    public class StateFactory : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        [field: SerializeField] public Agent2DState Idle { get; protected set; }
        [field: SerializeField] public Agent2DState Move { get; protected set; }
        [field: SerializeField] public Agent2DState Jump { get; protected set; }
        [field: SerializeField] public Agent2DState Fall { get; protected set; }
        [field: SerializeField] public Agent2DState Climb { get; protected set; }
        [field: SerializeField] public Agent2DState Attack { get; protected set; }


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
        }

        void OnEnable() {
        }

        void OnDisable() {
        }

        void Start() {
        }

        void Update() {
        }


        // ------------------------- CUSTOM PRIVATE METHODS ------------------------


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