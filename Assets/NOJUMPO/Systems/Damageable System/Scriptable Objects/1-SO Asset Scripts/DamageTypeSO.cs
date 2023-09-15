using UnityEngine;

namespace Nojumpo.DamageableSystem
{
    [CreateAssetMenu(fileName = "NewDamageTypeSO", menuName = "Nojumpo/Scriptable Objects/Health System/New Damage Type")]
    public class DamageTypeSO : ScriptableObject
    {
        
#if UNITY_EDITOR

        [TextArea]
        [SerializeField] string developerDescription;

#endif

        // -------------------------------- FIELDS ---------------------------------
        [SerializeField] GameObject onHitEffectPrefab;
        [SerializeField] float destroyDelay;


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public void SpawnOnHitEffect(Vector3 spawnPosition) {
            GameObject onHitEffect = Instantiate(onHitEffectPrefab, spawnPosition, Quaternion.identity);
            Destroy(onHitEffect, destroyDelay);
        }
    }
}