namespace ShootingGallery.Core
{
    using UnityEngine;

    public class Spawn : MonoBehaviour
    {
        public Transform TransformObject;
        public bool IsAvailable;

        /// <summary>
        /// Set spawn state
        /// </summary>
        /// <param name="state">Spawn state</param>
        public void SetState(bool state)
        {
            IsAvailable = state;
        }
    }
}
