namespace ShootingGallery.Core
{
    using UnityEngine;

    public abstract class ShootObject : MonoBehaviour
    {
        public ObjectType ObjectType;
        public Vector3 DirectionVector;
        public Spawn CurrentSpawn;

        public Color ObjectColor;
        public float ObjectSpeed;
        public int ObjectHP;

        public int AwardForObject;

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

        public void ActivateObject()
        {
            gameObject.SetActive(true);
        }

        public void DeactivateObject()
        {
            gameObject.SetActive(false);
        }

        public void SetPosition(Vector3 position)
        {
            gameObject.transform.position = position;
        }

        public void SetSpawnObject(Spawn spawn)
        {
            CurrentSpawn = spawn;
        }

        public void SetObjectAward(int award)
        {
            AwardForObject = award;
        }
    }
}
