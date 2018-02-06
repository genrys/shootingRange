namespace ShootingGallery.View
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIView : MonoBehaviour
    {
        public Text ScoreText;
        public Animator WowImage;
        public Animator SpawnOccupiedImage;
        public ParticleSystem SuccesfulParticleEffect;

        private string ImageAppearTrigger = "Appear";

        /// <summary>
        /// Show wow image on canvas.
        /// </summary>
        public void ShowWowImage()
        {
            WowImage.SetTrigger(ImageAppearTrigger);
        }


        /// <summary>
        /// Show info image on canvas.
        /// </summary>
        public void ShowSpawnOcupied()
        {
            SpawnOccupiedImage.SetTrigger(ImageAppearTrigger);
        }

        /// <summary>
        /// Show particle at position.
        /// </summary>
        /// <param name="particlePosition"></param>
        public void ShowWowParticle(Transform particlePosition)
        {
            SuccesfulParticleEffect.transform.position = particlePosition.position;
            SuccesfulParticleEffect.Play();
        }

        /// <summary>
        /// Update score value.
        /// </summary>
        /// <param name="score">Current score</param>
        public void UpdateScore(string score)
        {
            ScoreText.text = score;
        }
    }
}
