namespace ShootingGallery.View
{
    using System;
    using UnityEngine;

    public class UIViewManager : MonoBehaviour
    {
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

        public void UpdateScore()
        {

        }

        public void InitScore()
        {

        }
    }
}
