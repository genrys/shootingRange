namespace ShootingGallery.Core
{
    using ShootingGallery.Manager;
    using System;
    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        #region EVENTS
        public delegate void OnShoot();
        public static event OnShoot Shoot;

        public event Action SuccesfullShootUI;
        public event Action<Transform> SuccesfullShootParticle;
        #endregion

        [SerializeField]
        private LayerMask _mask = Physics.IgnoreRaycastLayer;

        /// <summary>
        /// Initializing an events.
        /// </summary>
        public void InitEvents()
        {
            Shoot += CreateShoot;

            SuccesfullShootUI = delegate { };
            SuccesfullShootParticle = delegate { };
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot.Invoke();
            }
        }

        /// <summary>
        /// Shoot only on the "Shoot objects".
        /// </summary>
        public void CreateShoot()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] currentShoot = Physics.RaycastAll(ray, 100f, _mask);

            for (int i = 0; i < currentShoot.Length; i++)
            {
                ShootObject obj = currentShoot[i].collider.GetComponent<ShootObject>();
                ShowCongratulation(obj.CurrentSpawn.TransformObject);
                GameManager.Instance.SpawnManager.DeactivatePoolObject(obj, obj.CurrentSpawn);
            }
        }

        public void ShowCongratulation(Transform position = null)
        {
            int random = UnityEngine.Random.Range(0,2);

            if (random == 0)
            {
                SuccesfullShootUI.Invoke();
            }
            else
            {
                SuccesfullShootParticle.Invoke(position);
            }
        }
    }
}
