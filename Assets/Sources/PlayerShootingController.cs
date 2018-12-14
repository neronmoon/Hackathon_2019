using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Project_Hackathon_2019.DesignDataTypes;
using Project_Hackathon_2019.Support;
using UnityEngine;

namespace Project_Hackathon_2019 {
    public class PlayerShootingController : MonoBehaviour {

        [Required]
        public Transform SpawnPoint;

        [Required]
        public Weapon Weapon;

        private bool isShooting = false;
        private Coroutine shootingProcess;

        void Update () {
            bool shouldShoot = Input.GetMouseButton (0);

            if (shouldShoot && !isShooting) {
                shootingProcess = StartCoroutine (shoot (Weapon));
                isShooting = true;
            }
            if (!shouldShoot && isShooting) {
                isShooting = false;
                StopCoroutine (shootingProcess);
                shootingProcess = null;
            }
        }

        private IEnumerator shoot (Weapon weapon) {
            while (true) {
                spawnProjectile (weapon);
                yield return new WaitForSeconds (1 / weapon.AttackRate);
            }
        }

        private void spawnProjectile (Weapon weapon) {
            GameObject projectile = ObjectPool.Instance.Spawn (weapon.Projectile, SpawnPoint.transform.position, SpawnPoint.rotation);
            projectile.GetComponent<Rigidbody> ().AddForce (SpawnPoint.forward * weapon.ProjectileSpeed);
            StartCoroutine (despawnProjectile (projectile, weapon.ProjectileLifetime));
        }

        private IEnumerator despawnProjectile (GameObject projectile, float delay) {
            yield return new WaitForSeconds (delay);
            ObjectPool.Instance.Despawn (projectile);
        }
    }
}
