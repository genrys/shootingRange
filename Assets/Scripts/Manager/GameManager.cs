namespace ShootingGallery.Manager
{
    using Core;
    using ShootingGallery.View;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public XmlManager XmlManager;
        public SpawnManager SpawnManager;
        public UIViewManager UIViewManager;

        public Weapon WeaponOnject;


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
            WeaponOnject.InitEvents();
            //UIViewManager.InitScore();

            EventsSubscribe();
        }

        private void EventsSubscribe()
        {
            WeaponOnject.SuccesfullShootUI += UIViewManager.ShowWowImage;
            WeaponOnject.SuccesfullShootParticle += UIViewManager.ShowWowParticle;
        }

        private void OnDestroy()
        {
            WeaponOnject.SuccesfullShootUI -= UIViewManager.ShowWowImage;
            WeaponOnject.SuccesfullShootParticle -= UIViewManager.ShowWowParticle;
        }
    }
}
