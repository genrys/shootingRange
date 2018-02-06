namespace ShootingGallery.Core
{
    using UnityEngine;

    public abstract class ShootObject : MonoBehaviour
    {
        public ObjectType ObjectType;
        public Vector3 DirectionVector;

        public Color ObjectColor;
        public float ObjectSpeed;
        public int ObjectHP;

        public int PointForObject;

        private Renderer _objectMaterial;

        public abstract void Init();

        public abstract void MoveRotation();

        public abstract void UpdateParameters(Vector3 dir, float speed);

        private void Update()
        {
            MoveRotation();
        }

         private void Start()
        {
            Init();
        }

        public void SetColor()
        {
            _objectMaterial = GetComponent<Renderer>();
            _objectMaterial.material.color = ObjectColor;
        }
    }
}
