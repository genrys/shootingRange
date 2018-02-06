namespace ShootingGallery.Manager
{
    using Core;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private List<Spawn> TransformObjects;

        [SerializeField]
        private SpawnObjectPrefab _objectPrefab;
        [SerializeField]
        private Transform _spawnObjectsContainer;

        [SerializeField]
        private Transform _objectPoolContainer;

        [SerializeField]
        private List<ShootObject> _shootObjects;

        /// <summary>
        /// Initializing.
        /// </summary>
        public void Init()
        {
            for (int i = 0; i < GameManager.Instance.XmlManager.Container.Objects.Count; i++)
            {
                var containerObject = GameManager.Instance.XmlManager.Container.Objects[i];

                SpawnObjectPrefab obj = Instantiate(_objectPrefab, _spawnObjectsContainer);
                obj.Init(containerObject.Award.ToString(), delegate { SpawnObj(containerObject.Type.ToString(), containerObject.Award); }, GetSpriteByType(containerObject.Type));
            }
        }

        /// <summary>
        /// Get sprite from resources.
        /// </summary>
        /// <param name="_type">Object type</param>
        /// <returns>sprite</returns>
        public Sprite GetSpriteByType(ObjectType _type)
        {
            return Resources.Load<Sprite>("Sprites/" + _type.ToString());
        }

        /// <summary>
        /// Instantiate object in available spawn position.
        /// </summary>
        private void SpawnObj(string _type, int award)
        {
            Spawn spawn = TransformObjects.Find((x) => x.IsAvailable);

            var obj = _shootObjects.Find((y) => y.name.Contains(_type) && !y.gameObject.activeInHierarchy);

            obj.SetSpawnObject(spawn);
            obj.SetObjectAward(award);

            ActivatePoolObject(obj, spawn);
        }

        /// <summary>
        /// Instantiate object pool objects when game start.
        /// </summary>
        public void InitExtendableObjectPool()
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject prefab = Resources.Load<GameObject>("Prefabs/" + ((ObjectType)i).ToString());

                for (int j = 0; j < 10; j++)
                {
                   GameObject obj = Instantiate(prefab, _objectPoolContainer);
                }
            }
            _shootObjects = new List<ShootObject>(_objectPoolContainer.GetComponentsInChildren<ShootObject>(true));
        }

        /// <summary>
        /// Get from pool.
        /// </summary>
        /// <param name="obj">Shoot object</param>
        public void ActivatePoolObject(ShootObject obj, Spawn spawn)
        {
            obj.ActivateObject();
            obj.SetPosition(spawn.TransformObject.position);
            spawn.SetState(false);
        }

        /// <summary>
        /// Return object to pool.
        /// </summary>
        /// <param name="obj">Shoot object</param>
        public void DeactivatePoolObject(ShootObject obj, Spawn spawn)
        {
            obj.transform.SetParent(_objectPoolContainer);
            obj.DeactivateObject();
            spawn.SetState(true);
        }
    }
}
