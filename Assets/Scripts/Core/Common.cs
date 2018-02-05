namespace ShootingGallery.Core
{
    #region ENUMS

    [System.Serializable]
    public enum ObjectType
    {
        CUBE,
        CIRCLE,
        CAPSULE
    }

    #endregion

    #region CLASSES

    [System.Serializable]
    public class SpawnObject
    {
        public ObjectType Type;
        public int Award;
    }

    #endregion
}