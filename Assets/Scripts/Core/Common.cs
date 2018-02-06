namespace ShootingGallery.Core
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    #region ENUMS

    [System.Serializable]
    public enum ObjectType
    {
        CUBE,
        CIRCLE,
        CAPSULE
    }

    public enum ClipType
    {
        WOW_SHOOT,
        GOOD_SHOOT,
        WRONG_SHOOT,
        MAIN_CLIP
    }

    #endregion

    #region CLASSES

    [System.Serializable]
    [XmlType("SpawnObject")]
    public class SpawnObject
    {
        [XmlElement]
        public ObjectType Type;
        [XmlElement]
        public int Award;
    }

    [System.Serializable]
    [XmlRoot("SpawnObjectsCollection")]
    public class SpawnObjectsContainer
    {
        [XmlArray("Objects"), XmlArrayItem("SpawnObject")]
        public List<SpawnObject> Objects = new List<SpawnObject>();
    }
    #endregion
}