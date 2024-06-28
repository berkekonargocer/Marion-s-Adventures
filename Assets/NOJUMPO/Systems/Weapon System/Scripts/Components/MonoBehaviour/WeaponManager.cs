using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NOJUMPO.WeaponSystem
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
            SetComponents();
            ToggleWeaponVisibility(false);
        }

        
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public WeaponSO GetCurrentWeapon() {
            return _weaponStorage.GetCurrentWeapon();
        }

        public List<string> GetPlayerWeaponNames() {
            return _weaponStorage.GetPlayerWeaponNames();
        }

        public bool CanAttack(bool isGrounded) {
            return _weaponStorage.WeaponCount > 0 && GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public void AddWeapon(WeaponSO weaponSO) {
            if (!_weaponStorage.AddWeapon(weaponSO))
                return;

            if (_weaponStorage.WeaponCount == 2)
            {
                OnMultipleWeapons?.Invoke();
            }

            SwapWeaponSprite(weaponSO.WeaponData.Sprite);
        }

        public void PickUpWeapon(WeaponSO weaponSO) {
            AddWeapon(weaponSO);
            OnWeaponPickUp?.Invoke();
        }

        public void SwapWeapon() {
            if (_weaponStorage.WeaponCount <= 0)
                return;

            SwapWeaponSprite(_weaponStorage.SwapWeapon().WeaponData.Sprite);
        }

        public void ToggleWeaponVisibility(bool isVisible) {
            if (isVisible)
            {
                SwapWeaponSprite(GetCurrentWeapon().WeaponData.Sprite);
            }

            _spriteRenderer.enabled = isVisible;
        }

        
        // ------------------------- CUSTOM PRIVATE METHODS ------------------------
        void SetComponents() {
            _weaponStorage = new WeaponStorage();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        void SwapWeaponSprite(Sprite weaponSprite) {
            _spriteRenderer.sprite = weaponSprite;
            OnWeaponSwap?.Invoke(weaponSprite);
        }
    }
}