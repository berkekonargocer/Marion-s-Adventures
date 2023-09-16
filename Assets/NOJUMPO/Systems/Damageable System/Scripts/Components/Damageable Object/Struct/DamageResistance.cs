using System;
using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    [Serializable]
    public struct DamageResistance
    {
        [field: SerializeField] public DamageTypeSO DamageType { get; private set; }
        [field: SerializeField] public int PercentageToTake { get; private set; }
    }
}