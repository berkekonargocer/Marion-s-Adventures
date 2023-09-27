using System.Collections.Generic;
using Nojumpo.AgentSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    public class Agent2DWeaponTest : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public List<WeaponSO> Weapons = new List<WeaponSO>();


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            Agent2DBase agent2DBase = GetComponent<Agent2DBase>();

            if (agent2DBase == null)
                return;

            for (int i = 0; i < Weapons.Count; i++)
            {
                agent2DBase.AgentWeapon.AddWeapon(Weapons[i]);
            }
        }
    }
}