using UnityEngine;

namespace Project_Hackathon_2019.DesignDataTypes
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Gameplay/Weapon")]
    public class Weapon: ScriptableObject
    {
        public string Name;
        public float AttackRate = 1f;

        public GameObject Projectile;
        public float ProjectileSpeed = 100f;
        public float ProjectileLifetime = 1f;
    }
}
