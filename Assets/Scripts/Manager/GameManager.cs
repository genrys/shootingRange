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
        public PlayerDataManager PlayerDataManager;
        public AudioManager AudioManager;

        public UIView UIView;
        public Weapon WeaponOnject;

        private void Start()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize all necessary scripts.
        /// </summary>
        private void Initialize()
        {
            Instance = this;

            XmlManager.Init();
            SpawnManager.Init();
            SpawnManager.InitExtendableObjectPool();
            WeaponOnject.InitEvents();
            AudioManager.Init();
            EventsSubscribe();

            PlayerDataManager.LoadData();
        }

        /// <summary>
        /// Subscribe on events.
        /// </summary>
        private void EventsSubscribe()
        {
            WeaponOnject.SuccesfullShootUI += UIView.ShowWowImage;
            WeaponOnject.SuccesfullShootParticle += UIView.ShowWowParticle;
            PlayerDataManager.LoadDataFromPrefs += UIView.UpdateScore;
        }

        private void OnDestroy()
        {
            WeaponOnject.SuccesfullShootUI -= UIView.ShowWowImage;
            WeaponOnject.SuccesfullShootParticle -= UIView.ShowWowParticle;
            PlayerDataManager.LoadDataFromPrefs -= UIView.UpdateScore;
        }
    }
}
