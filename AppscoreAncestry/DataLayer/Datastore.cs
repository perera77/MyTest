using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using AppscoreAncestry.Models;

namespace AppscoreAncestry.DataLayer
{
    class DataSet
    {
        public List<Place> places { get; set; }
        public List<Person> people { get; set; }
    }

    public class Datastore
    {
        private static readonly Datastore _instance = new Datastore();

        private DataSet dataset;


        private Datastore() { }

        public static Datastore Instance {  get { return _instance; } }

        public void loadData()
        {
            string file = HttpContext.Current.Server.MapPath(@"~\App_Data\data_small.json");


            // deserialize JSON from file
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            dataset = ser.Deserialize<DataSet>(Json);
        }

        public IEnumerable<Person> People { get
            {
                if (dataset == null)
                    loadData();

                return dataset.people;
            }
        }

        public IEnumerable<Place> Places { get
            {
                if (dataset == null) loadData();
                return dataset.places;
            }
        }
    }
}