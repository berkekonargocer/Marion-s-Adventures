using System;
using Nojumpo.DamageableSystem;
using UnityEngine;

namespace Nojumpo.WeaponSystem
{
    [Serializable]
    public struct WeaponData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public DamageTypeSO DamageType { get; private set; }
        [field: SerializeField] public AudioClip AttackSFX { get; private set; }
    }
}