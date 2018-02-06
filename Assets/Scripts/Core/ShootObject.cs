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

        /// <summary>
        /// Initializing parametres.
        /// </summary>
        public abstract void Init();

        /// <summary>
        /// Object moving or rotation
        /// </summary>
        public abstract void MoveRotation();

        /// <summary>
        /// Update movement parametres
        /// </summary>
        /// <param name="dir">Direction</param>
        /// <param name="speed">Speed of mmoving</param>
        public abstract void UpdateParameters(Vector3 dir, float speed);

        private void Update()
        {
            MoveRotation();
        }

        private void Start()
        {
            Init();
        }

        /// <summary>
        /// Set color to object.
        /// </summary>
        public void SetColor()
        {
            _objectMaterial = GetComponent<Renderer>();
            _objectMaterial.material.color = ObjectColor;
        }

        /// <summary>
        /// Activate object on scene.
        /// </summary>
        public void ActivateObject()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Deactivate object on scene.
        /// </summary>
        public void DeactivateObject()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Set position for object.
        /// </summary>
        public void SetPosition(Vector3 position)
        {
            gameObject.transform.position = position;
        }

        /// <summary>
        /// Set spawn instance for object.
        /// </summary>
        /// <param name="spawn"></param>
        public void SetSpawnObject(Spawn spawn)
        {
            CurrentSpawn = spawn;
        }

        /// <summary>
        /// Set current object reward.
        /// </summary>
        /// <param name="award">Сurent award</param>
        public void SetObjectAward(int award)
        {
            AwardForObject = award;
        }
    }
}
