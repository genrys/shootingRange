namespace ShootingGallery.Core
{
    using UnityEngine;
    using Text = UnityEngine.UI.Text;
    using Image = UnityEngine.UI.Image;
    using Button = UnityEngine.UI.Button;

    public class SpawnObjectPrefab : MonoBehaviour
    {
        public Text AwardTextComponent;
        public Button SpawnButtonComponent;
        public Image ViewImageComponent;

        /// <summary>
        /// Initialize components of spawn object.
        /// </summary>
        /// <param name="_text">text</param>
        /// <param name="action">Action</param>
        /// <param name="sprite">sprite</param>
        public void Init(string _text, System.Action action, Sprite sprite)
        {
            AwardTextComponent.text = _text;

            ViewImageComponent.sprite = sprite;

            SpawnButtonComponent.onClick.RemoveAllListeners();
            SpawnButtonComponent.onClick.AddListener(() => { action(); });
        }
    }
}
