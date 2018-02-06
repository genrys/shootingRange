namespace ShootingGallery.Core
{
    using UnityEngine;

    public class Spawn : MonoBehaviour
    {
        public Transform TransformObject;
        public bool IsAvailable;

        public void SetState(bool state)
        {
            IsAvailable = state;
        }
    }
}
