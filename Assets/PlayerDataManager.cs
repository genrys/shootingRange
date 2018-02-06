namespace ShootingGallery.View
{
    using System;
    using UnityEngine;

    public class PlayerDataManager : MonoBehaviour
    {
        #region EVENTS
        public event Action<string> LoadDataFromPrefs;

        #endregion

        public string PlayerScore = "PlayerScore";

        public int LoadData()
        {
            int score;
            if (!PlayerPrefs.HasKey(PlayerScore))
            {
                PlayerPrefs.SetInt(PlayerScore, 0);
            }

            score = PlayerPrefs.GetInt(PlayerScore);

            if (LoadDataFromPrefs != null)
                LoadDataFromPrefs.Invoke(score.ToString());

            return score;
        }

        public void SaveData(int data)
        {
            PlayerPrefs.SetInt(PlayerScore, PlayerPrefs.GetInt(PlayerScore) + data);
        }

        public void InitEvents()
        {
            LoadDataFromPrefs = delegate { };
        }
    }
}
