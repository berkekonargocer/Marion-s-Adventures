using UnityEngine;

namespace Nojumpo
{
    public class SpawnPointManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public Transform PlayerSpawnPoint { get; private set; }


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
        public void SetPlayerSpawnPoint(Transform spawnPoint) {
            PlayerSpawnPoint = spawnPoint;
        }

        public void SpawnPlayer(Transform player) {
            player.position = PlayerSpawnPoint.position;
        }
    }
}