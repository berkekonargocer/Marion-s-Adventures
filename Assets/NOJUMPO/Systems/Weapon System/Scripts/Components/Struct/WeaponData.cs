using System;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [Serializable]
    public struct WeaponData
    {
        [field: SerializeField] public string WeaponName { get; private set; }
        [field: SerializeField] public Sprite WeaponSprite { get; private set; }
        [field: SerializeField] public int Damage { get; set; }
        [field: SerializeField] public AudioClip AttackSFX { get; set; }
    }
}