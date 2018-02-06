namespace ShootingGallery.Manager
{
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public XmlManager XmlManager;
        public SpawnManager SpawnManager;


        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            Instance = this;

            XmlManager.Init();
            SpawnManager.Init();
            SpawnManager.InitExtendableObjectPool();
        }
    }
}
