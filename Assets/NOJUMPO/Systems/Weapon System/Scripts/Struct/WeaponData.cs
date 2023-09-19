using System;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [Serializable]
    public struct WeaponData
    {
        [field: SerializeField] public int Damage { get; set; }
    }
}