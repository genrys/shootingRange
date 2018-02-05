namespace ShootingGallery.Manager 
{
    using Core;
    using System.IO;
    using System.Xml.Serialization;
    using UnityEngine;

    [XmlRoot("SpawnObjectsCollection", Namespace= "ShootingGallery.Manager")]
    public class XmlManager : MonoBehaviour
    {
        [XmlArray("Objects"), XmlArrayItem("SpawnObject")]
        [SerializeField]
        public SpawnObject[] Objects;

        public TextAsset XmlData;

        private void Start()
        {
            Init();
            print(Application.dataPath);
            Save(Application.dataPath + "/Resources/XMLData.xml");
        }

        private void Init()
        {
            if (XmlData == null)
            {
                XmlData = (TextAsset)Resources.Load("XMLData");
            }
        }

        public void Save(string path)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("ShootingGallery", "ShootingGallery.Manager");
            var serializer = new XmlSerializer(typeof(SpawnObject));
            using (StreamWriter stream = new StreamWriter(path, false))
            {
                serializer.Serialize(stream, this,ns);
            }
        }

        private void FillXmlData()
        {

        }
    }
}
