namespace ShootingGallery.View
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIViewManager : MonoBehaviour
    {
        public Text ScoreText;
        public Animator WowImage;
        public ParticleSystem SuccesfulParticleEffect;

        private string _wowImageTrigger = "Appear";

        public void ShowWowImage()
        {
            WowImage.SetTrigger(_wowImageTrigger);
        }

        public void ShowWowParticle(Transform particlePosition)
        {
            SuccesfulParticleEffect.transform.position = particlePosition.position;
            SuccesfulParticleEffect.Play();
        }

        public void UpdateScore(string score)
        {
            ScoreText.text = score;
        }
    }
}
