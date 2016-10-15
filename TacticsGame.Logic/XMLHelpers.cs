using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacticsGame.Logic.Models.Actors;
using System.Xml.Serialization;
using System.IO;
using TacticsGame.Logic.Enums;
using System.Xml;

namespace TacticsGame.Logic
{
    //TODO: Add some try catches to this to make sure we don't crash all the time
    /// <summary>
    /// A collection of methods to aid with the XML file workflow
    /// </summary>
    public class XMLHelper
    {
        /// <summary>
        /// A private method to make sure everything goes into the correct root folder
        /// </summary>
        /// <returns></returns>
        private static string GetCustomRoot()
        {
            string root = string.Empty;
            root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TacticsGame";
            return root;
        }

        private static string GetCoreRoot()
        {
            string root = string.Empty;
            root = "../TacticsGame.Data/Assets/";
            return root;

        }
        //C:\Users\Student-PC\Source\Repos\TacticsGameDemo\TacticsGame\TacticsGame.Data\Assets\
        //C:\Users\Student-PC\Source\Repos\TacticsGameDemo\TacticsGame\TacticsGame.Logic\Models\

        /// <summary>
        /// Adds all the necessary paths needed to reach items inside a folder
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        private static string GetFolderPath(FolderName folder, bool customFile)
        {

            string folderPath;
            if (customFile == true)
            {
                folderPath = GetCustomRoot() + @"\" + folder + @"\";
            }
            else
            {
                folderPath = GetCoreRoot() + @"\" + folder + @"\";
            }
            return folderPath;
        }
        //TODO: This needs to be moved to its proper location
        //public static UnitTestDTO ActorParser(Humanoid u)
        //{
        //    UnitTestDTO newDTO = new UnitTestDTO()
        //    {
        //        ActorLevel = u.ActorLevel,
        //        Name = u.Name,
        //        Nickname = u.Nickname,
        //        MaxHealthPoints = u.MaxHealthPoints,
        //        HealthPoints = u.HealthPoints,
        //        MaxManaPoints = u.MaxManaPoints,
        //        ManaPoints = u.ManaPoints,
        //        Strength = u.Strength,
        //        Dexterity = u.Dexterity,
        //        Defense = u.Defense,
        //        MagicPower = u.MagicPower,
        //        MagicDefense = u.MagicDefense,
        //        ExperiencePoints = u.ExperiencePoints,
        //        isPlayerControlled = u.isPlayerControlled,
        //        LearnedAbilities = u.LearnedAbilities
        //    };
        //    return newDTO;
        //}

        /// <summary>
        /// This is a generic Save to XML method it is used to create or save data to a XML file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Object To Parse"></param>
        /// <param name="fileName"></param>
        /// <param name="directoryName"></param>
        public static void SaveToFile<T>(T objectClass, string fileName, FolderName folder, bool customFile)
        {
            //Here we are creating a new instance of the XmlSerializer class and dynamically passing in the 
            //Object (T) to serialize
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            //Since right now this is a console application it might be easier for us to save our data to MyDocs
            string rootDirectory;
            if (customFile == true)
            {
                rootDirectory = GetCustomRoot();
            }
            else
            {
                rootDirectory = GetCoreRoot();
            }
            Directory.CreateDirectory(rootDirectory + @"\" + folder);

            //TODO: See if there is a way to reduce simplify this code
            var filePath = rootDirectory + @"\" + folder + @"\" + fileName;
            FileStream file = File.Create(filePath);

            serializer.Serialize(file, objectClass);
            file.Close();
        }

        /// <summary>
        /// Generic XML Reader that returns an object 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static T ReadFromFile<T>(string fileName, FolderName folder, bool customFile)
        {
            //We need an instance of the class we want to return
            T result;
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            string filePath;
            if (customFile == true)
            {
                filePath = GetFolderPath(folder, true) + fileName;
            }
            else
            {
                filePath = GetFolderPath(folder, false) + fileName;
            }
            FileStream file = new FileStream(filePath, FileMode.Open);
            XmlReader reader = XmlReader.Create(file);

            result = (T)deserializer.Deserialize(reader);
            reader.Close();
            return result;
        }
    }
}
