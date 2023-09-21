using UnityEngine;
using UnityEngine.Events;

namespace Nojumpo.WeaponSystem
{
    public class WeaponManager : MonoBehaviour
    {
        // -------------------------------- FIELDS ---------------------------------
        SpriteRenderer _spriteRenderer;

        WeaponStorage _weaponStorage;

        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnWeaponPickUp;


        // ------------------------- UNITY BUILT-IN METHODS ------------------------
        void Awake() {
            _weaponStorage = new WeaponStorage();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            ToggleWeaponVisibility(false);
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
        void ToggleWeaponVisibility(bool isVisible) {
            if (isVisible)
            {
                SwapWeaponSprite(GetCurrentWeapon().WeaponSprite);
            }

            _spriteRenderer.enabled = isVisible;
        }

        void SwapWeaponSprite(Sprite weaponSprite) {
            _spriteRenderer.sprite = weaponSprite;
            OnWeaponSwap?.Invoke(weaponSprite);
        }


        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public WeaponSO GetCurrentWeapon() {
            return _weaponStorage.GetCurrentWeapon();
        }

        public void SwapWeapon() {
            if (_weaponStorage.WeaponCount <= 0)
                return;
            
            SwapWeaponSprite(_weaponStorage.SwapWeapon().WeaponSprite);
        }

        public void AddWeapon(WeaponSO weaponSO) {
            _weaponStorage.AddWeapon(weaponSO);

            if (_weaponStorage.WeaponCount == 2)
            {
                OnMultipleWeapons?.Invoke();
            }
            
            SwapWeaponSprite(weaponSO.WeaponSprite);
        }

        public void PickUpWeapon(WeaponSO weaponSO) {
            AddWeapon(weaponSO);
            OnWeaponPickUp?.Invoke();
        }
    }
}