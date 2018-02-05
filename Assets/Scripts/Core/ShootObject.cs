namespace ShootingGallery.Core
{
    using UnityEngine;

    public abstract class ShootObject : MonoBehaviour
    {
        public ObjectType Type;

        public abstract void Init();
    }
}
