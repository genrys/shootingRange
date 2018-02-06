namespace ShootingGallery.View
{
    using ShootingGallery.Core;
    using UnityEngine;

    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource MainSource;
        [SerializeField]
        private AudioSource SfxSource;

        [Space(10f)]

        [SerializeField]
        private AudioClip MainClip;
        [SerializeField]
        private AudioClip WowClip;
        [SerializeField]
        private AudioClip GoodClip;
        [SerializeField]
        private AudioClip WrongClip;

        /// <summary>
        /// Play audio clip by type.
        /// </summary>
        /// <param name="type">audio clip type</param>
        public void PlayAudio(ClipType type)
        {
            switch (type)
            {
                case ClipType.WOW_SHOOT:
                    SfxSource.PlayOneShot(WowClip);
                    break;
                case ClipType.GOOD_SHOOT:
                    SfxSource.PlayOneShot(GoodClip);
                    break;
                case ClipType.WRONG_SHOOT:
                    SfxSource.PlayOneShot(WrongClip);
                    break;
            }
        }

        /// <summary>
        /// Init main audio source.
        /// </summary>
        public void Init()
        {
            MainSource.PlayOneShot(MainClip);
        }
    }
}
