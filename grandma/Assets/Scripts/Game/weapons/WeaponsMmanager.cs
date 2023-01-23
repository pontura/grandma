using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tumba.Game.Weapons
{
    public class WeaponsMmanager : MonoBehaviour
    {
        [SerializeField] Transform container;
        public void Shoot(string weaponName, Vector2 pos, Vector2 dir)
        {
            GameObject go = GameManager.Instance.pool.Get(weaponName);
            Weapon weapon = go.GetComponent<Weapon>();
            if (weapon == null)
                return;
            go.transform.position = pos;
            go.transform.SetParent(container);
            go.SetActive(true);
            weapon.Init(dir);
        }
    }
}
