namespace ShootingGallery.Manager
{
    using Core;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using UnityEngine;

    public class XmlManager : MonoBehaviour
    {
        public SpawnObjectsContainer Container;

        public TextAsset XmlData;

        private string _path;
        [SerializeField]
        private int _objectsCount;

        /// <summary>
        /// Init XML File
        /// </summary>
        public void Init()
        {
            if (XmlData == null)
            {
                XmlData = (TextAsset)Resources.Load("XMLData");
            }

            _path = Application.dataPath + "/Resources/XMLData.xml";

            ObjectsRandomzie(_objectsCount);

            Save(_path);
            Load(_path);
        }

        /// <summary>
        /// Save data to XML
        /// </summary>
        /// <param name="path">file path</param>
        public void Save(string path)
        {
            var serializer = new XmlSerializer(typeof(SpawnObjectsContainer));

            using (StreamWriter stream = new StreamWriter(path, false))
            {
                serializer.Serialize(stream, Container);
                stream.Close();
            }
        }

        /// <summary>
        /// Load data from XML
        /// </summary>
        /// <param name="path">file path</param>
        public void Load(string path)
        {
            var serializer = new XmlSerializer(typeof(SpawnObjectsContainer));

            using (StreamReader stream = new StreamReader(path, false))
            {
               Container = serializer.Deserialize(stream) as SpawnObjectsContainer;
                stream.Close();
            }
        }

        /// <summary>
        /// Randomize object to xml File
        /// </summary>
        /// <param name="count">Count of objects</param>
        private void ObjectsRandomzie(int count)
        {
            Container.Objects = new List<SpawnObject>();
            for (int i = 0; i < count; i++)
            {
                Container.Objects.Add(new SpawnObject() { Type = (ObjectType)Random.Range(0, 3), Award = Random.Range(0, 1000) });
            }
        }
    }
}
