namespace ShootingGallery.Core
{
    using UnityEngine;

    public class Weapon : MonoBehaviour
    {
        #region EVENTS
        public delegate void OnShoot();

        public static event OnShoot Shoot;
        #endregion

    }
}
