using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace PostalCode.Models
{
    public class LoadPage
    {
        string basedir = AppDomain.CurrentDomain.BaseDirectory;
        public IEnumerable<State> LoadFirstList()
        {
            List<State> arl = new List<State>();

            string path = basedir + "App_Data\\dataset.xml";
            XDocument users = XDocument.Load(path);
            XmlNodeList stateList = getNodes("states.xml", "state", basedir);
            foreach (XmlNode xms in stateList)
            {
                State state = new State();
                string Name = xms["Name"].InnerText;
                state.Name = Name;
                int id = Convert.ToInt32(xms["StateId"].InnerText);
                state.Id = id;
                int ct = getNumByState(users, id).Count();
                if (ct > 0)
                {
                    state.NumOfPeople = ct;
                    arl.Add(state);
                }
            }
            return arl;
        }

        public IEnumerable<PeopleByState> LoadByState(int stateId)
        {
            List<PeopleByState> lsp = new List<PeopleByState>();
            string path = basedir + "App_Data\\dataset.xml";
            XDocument users = XDocument.Load(path);
            IEnumerable<XElement> state = getNumByState(users, stateId);
            foreach (var st in state)
            {
                PeopleByState ps = new PeopleByState();
                ps.FirstName = st.Element("first_name").Value;
                ps.Lastname = st.Element("last_name").Value;
                ps.ZipCode = st.Element("postal_code").Value;
                lsp.Add(ps);
            }
            return lsp;
        }

        public XmlNodeList getNodes(string xmlFileName, string nodeName, string basedir)
        {
            string pathToStates = basedir + "App_Data\\" + xmlFileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(pathToStates);
            return doc.GetElementsByTagName(nodeName);
        }
        public IEnumerable<XElement> getNumByState(XDocument xdoc, int stid)
        {
            return (from c in xdoc.Descendants("record")
                    from f in c.Descendants("StateId")
                    where (string)f.Value == "" + stid
                    select c);
        }

        public IEnumerable<PeopleByState> LoadByStateName(string name)
        {
            string path = basedir + "App_Data\\states.xml";
            XDocument users = XDocument.Load(path);
            string ich = (from c in users.Descendants("state")
                          from f in c.Descendants("Name")
                          from d in c.Descendants("StateId")
                          where (string)f.Value == name
                          select (string)d.Value).FirstOrDefault().ToString();
            return LoadByState(Convert.ToInt32(ich));
        }
    }
}