using System.Collections.Generic;
using Nojumpo.AgentSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    public class Agent2DAddWeapon : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        public List<WeaponSO> Weapons = new List<WeaponSO>();


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Start() {
            Agent2D agent2D = GetComponent<Agent2D>();

            if (agent2D == null)
                return;

            for (int i = 0; i < Weapons.Count; i++)
            {
                agent2D.m_AgentWeapon.AddWeapon(Weapons[i]);
            }
        }
    }
}