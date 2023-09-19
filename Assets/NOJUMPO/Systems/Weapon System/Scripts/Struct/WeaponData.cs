using System;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [Serializable]
    public class WeaponData
    {
        [field: SerializeField] public int Damage { get; set; }
    }
}