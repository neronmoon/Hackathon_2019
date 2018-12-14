using NaughtyAttributes;
using UnityEngine;

namespace Project_Hackathon_2019.DesignDataTypes {
    [CreateAssetMenu (fileName = "Weapon", menuName = "Gameplay/Weapon")]
    public class Weapon : ScriptableObject {
        public string Name;

        [InfoBox ("Count of projectiles per sec")]
        public float AttackRate = 1f;

        [ShowAssetPreview]
        public GameObject Projectile;
        public float ProjectileSpeed = 100f;
        public float ProjectileLifetime = 1f;
    }
}
