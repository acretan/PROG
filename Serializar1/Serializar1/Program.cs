using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.IO;

namespace Serializar1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Alumne Andy = new Alumne("Cretan", "Andrei", 30);

            //Binario
            FileStream FichaAndyB = new FileStream(@".\andy.bin", FileMode.Create, FileAccess.Write);
            BinaryFormatter SerializadorB = new BinaryFormatter();
            SerializadorB.Serialize(FichaAndyB, Andy);
            FichaAndyB.Close();

            //XML
            XmlSerializer SerializadorX = new XmlSerializer(typeof(Alumne));
            FileStream FichaAndyX = new FileStream(@".\andy.xml", FileMode.Create);
            SerializadorX.Serialize(FichaAndyX, Andy);
            FichaAndyX.Close();

            //JSON
            JavaScriptSerializer SerializadorJ = new JavaScriptSerializer();
            string AndyJ = SerializadorJ.Serialize(Andy);
            StreamWriter FichaAndyJ = new StreamWriter(@".\andy.json", true);
            FichaAndyJ.WriteLine(AndyJ);
            FichaAndyJ.Close();
        }
    }
    [Serializable]public class Alumne
    {
        //Attributes
        private string _Nom, _Cognoms;
        private int _Id;

        //Properties
        public string Nom { get { return _Nom; } set { _Nom = value; } }
        public string Cognoms { get { return _Cognoms; } set { _Cognoms = value; } }
        public int Id { get { return _Id; } }

        //Constructor
        public Alumne(string Cognoms, string Nom, int Id)
        {
            _Nom = Nom;
            _Cognoms = Cognoms;
            _Id = Id;
        }
        public Alumne() {}

        //Methods
        public override string ToString()
        {
            return string.Format("{0}-{1} {2}", Cognoms, Nom, Id);
        }
    }
}
