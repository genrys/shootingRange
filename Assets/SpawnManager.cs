namespace ShootingGallery.Manager
{
    using Core;
    using UnityEngine;

    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private SpawnObjectPrefab _objectPrefab;
        [SerializeField]
        private Transform _spawnObjectsContainer;

        public void Init()
        {
            for (int i = 0; i < GameManager.Instance.XmlManager.Container.Objects.Count; i++)
            {
                var containerObject = GameManager.Instance.XmlManager.Container.Objects[i];

                SpawnObjectPrefab obj = Instantiate(_objectPrefab, _spawnObjectsContainer);
                obj.Init(containerObject.Award.ToString(), delegate { SpawnObj(); }, GetSpriteByType(containerObject.Type));
            }
        }

        public Sprite GetSpriteByType(ObjectType _type)
        {
            print(_type.ToString());
            return Resources.Load<Sprite>("Sprites/" + _type.ToString());
        }

        private void SpawnObj()
        {

        }
    }
}
