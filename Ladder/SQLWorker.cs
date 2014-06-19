
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Ladder
{
    using System.IO;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Collections.Generic;
    using System.Xml;
  
    
    

    public class SQLWorker : ISQLWorker
    {
        #region Constructors
        public long size;
        public string name;
        public SQLWorker()
        {
            NameValueCollection nc = ConfigurationManager.AppSettings;
            
            try
            {
                ConnectionString = nc["conn"];
                conn = new SqlConnection(ConnectionString);
                try
                {

                    conn.Open();

                }
                catch (Exception e)
                {
                    Steps.Log.Error(e.Message);
                    return;
                }
            }
            catch
            {
                ConnectionString = "";
            }
            SQLFile = new FileInfo("./lib/APExSQL.sql");
            HoldingFile = new FileInfo("./lib/Holdings_Guide_DK-850940.xml");
        }

        #endregion Constructors

        #region Properties

        public string ConnectionString
        {
            get; set;
        }
        public FileInfo SQLFile
        {
            get;
            set;
        }
        public FileInfo HoldingFile
        {
            get;
            set;
        }
        #endregion Properties

        #region Methods

        public int QueryDaisy(FileInfo newXmlFile, int sidsthentet)
        {

            int Sidst = sidsthentet;
            Steps.Log.DebugFormat("Logon til Daisy med værdi for '{0}'", ConnectionString);
            try
            {

            if(conn.State!=System.Data.ConnectionState.Open ) conn.Open();
        
            }
            catch (Exception e)
            {
                Steps.Log.Error( e);
                return Sidst;
            }
           

            Steps.Log.Debug("Execute SQL");

         

            var nids = FetchIDs(GetQueryWithProc());
            var navne = FindNavne(nids);
            navne.Sort();
            
            string alfa = "§ 0 1 2 3 4 5 6 7 8 9 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z Æ Ø Å";
            string[] bogstav = alfa.Split(' ');
            List<string> bog = new List<string>();
            foreach (string b in bogstav)
                bog.Add(b);
           

            //int[] antal = new int [bogstav.Length + 1];

            //foreach (string navn in navne)
            //{
            //    bool fundet = false; 
            //    for (int i = 0; i < bogstav.Length; i++)
            //    {
                   
            //        if (navn.Length > 0)
            //            if (navn.Substring(0, 1).ToUpper() == bogstav[i])
            //            {
            //                int ii = antal[i] + 1;
            //                antal[i] = ii;
            //                fundet = true;
                           
            //            }
                   
            //    }
            //    if (!fundet)
            //    {
            //        int ii = antal[bogstav.Length] + 1;
            //        antal[bogstav.Length] = ii;
            //    }
            //}

         //   nids.Sort();

        
            
            int t = 0;
            foreach (string navn in navne)
            {
                int id = Findid(navn);
                if (id != 0)
                {
                    //foreach (int id in nids)

                    string s = HentNGNavn(id);
                    string name = HentNavn(s);
                    string name1 = name.Trim().TrimStart(',').TrimStart('"').Trim();
                    string folderb;
                    if (bog.Contains(name1.ToUpper().Substring(0, 1)))
                        folderb = name1.ToUpper().Substring(0, 1);
                    else
                        folderb = "rest";

                    // if (id > sidsthentet)
                    //if (
                    //    name.ToLower().Contains("indenrigsminister") 
                    //    ||
                    //    name.ToLower().Contains("justitsminister") 
                    //    ||
                    //  name.ToLower().Contains("statsminister") 
                    //  ||
                    //    name.ToLower().Contains("danske kancelli") ||
                    //    name.ToLower().Contains("rentekammer")
                    //    )

                    var hids = FetchIDs(GetQueryWithHProc(id.ToString()));
                    //  string s = HentNGNavn(id);

                    //if (hids.Count > 0)
                    //{

                    t++;
                    //if (t > 100)
                    //    break;

                    string OutputFil = SetOutputName(newXmlFile, id, folderb, t);
                    string HoldingFil = SetHoldingFile(newXmlFile, id, folderb, t);
                    var extract = new StreamWriter(OutputFil, true, Encoding.UTF8); ;
                    extract.Write("<Apex>");
                    extract.Write("<ApexNg id=" + om(id.ToString()) + ">");

                    //  extract.Write(HentNGNavn(id));
                    extract.Write(s);
                    extract.Write(HentNGInfo(id));
                    extract.Write(HentNGDetaljer(id));

                    if (hids.Count > 0)
                    {
                        foreach (int hid in hids)
                        {

                            extract.Write("<ApexHe>");
                            extract.Write("<ApexHeId>" + hid.ToString() + "</ApexHeId>");
                            extract.Write("<ApexNgId>" + id.ToString() + "</ApexNgId>");
                            extract.Write(HentHeInfoTop(hid));
                            extract.Write(HentHeInfoBund(hid));
                            extract.Write(HentHeAvInfo(hid));
                            string ep = HentEpMeInfo(hid);
                            var epinfo = HentEpInfo(ep);

                            if (ep.Contains("AOEpId"))
                                extract.Write(ep);
                            foreach (var epif in epinfo)
                            {

                                string epid = epif.Key;
                                string epin = epif.Value;

                                if (epid != "")
                                {
                                    extract.Write("<ApexEP nid=" + om(id.ToString()) + " hid=" + om(hid.ToString()) + " epid=" + om(epid.ToString()) + ">");
                                    extract.Write("<ApexEPInfo>" + epin + "</ApexEPInfo>");
                                    var rids = FetchIDs(GetQueryWithRProc(epid));
                                    foreach (int rid in rids)
                                    {
                                        var mids = FetchIDs(GetQueryWithMProc(rid.ToString()));
                                        foreach (int mid in mids)
                                            if (mid > 0)
                                            {
                                                extract.Write("<ApexME ngid=" + om(id.ToString()) + " m2rid=" + om(mid.ToString()) + " heid=" + om(hid.ToString()) + " epid=" + om(epid.ToString()) + ">");
                                                extract.Write(HentMEDetaljer(mid));
                                                extract.Write("</ApexME>");
                                            }
                                    }
                                    extract.Write("</ApexEP>");
                                }


                            }

                            extract.Write("</ApexHe>");
                        }
                    }
                    extract.Write("</ApexNg>");




                    extract.Write("</Apex>");

                    extract.Close();




                    string[] newxml = File.ReadAllLines(OutputFil, Encoding.UTF8);
                    var write = new StreamWriter(OutputFil, false, Encoding.UTF8);
                    using (write)
                    {
                        foreach (var n in newxml)
                            write.WriteLine(CleanString(n));

                    }
                    string o = @"""";
                    string cleanname = name1.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;");
                       
                 
 





                    string holding = File.ReadAllText(HoldingFil, Encoding.UTF8);
                    string newholding = holding.Replace("</archdesc>",
                        "<dsc> <c level=" + om("item") + "><did> <unittitle encodinganalog=" + om("3.1.2") + ">" + cleanname + "</unittitle> </did><otherfindaid><p><extref xmlns:xlink=" +
                        om("http://www.w3.org/1999/xlink") + " xlink:href=" + om(t.ToString().PadLeft(10, '0') + id.ToString()) + "/></p> </otherfindaid> </c> </dsc></archdesc>");


                   


                    var writeholding = new  StreamWriter(HoldingFil, false, Encoding.UTF8);
                    using (writeholding)
                    {
                        writeholding.Write(newholding);

                    }
                    Sidst = id;
                }
            }

                
            
                conn.Close();

                Steps.Log.DebugFormat("Write result til filen '{0}'", newXmlFile);
                return Sidst;
             
        }
        private int Findid(string navn)
        {
            int pos = navn.IndexOf("NUMBER");
            string s = navn.Remove(0, pos + 6);
            int id = 0;
            try
            {
                id = Convert.ToInt32(s);
            }
            catch { }
            return id;
        }

        private string HentNavn(string s)
        {
            XmlDocument xdoc = new XmlDocument();
            string myXml = s;
            xdoc.LoadXml(myXml);
            XmlNodeList nodeList = xdoc.GetElementsByTagName("NgNavn");
            string ngnavn = "";
            foreach (XmlNode node in nodeList)
            {
                ngnavn = node.InnerText;
            }
            return ngnavn;
        }
        private string om(string s)
        {
            string o = @"""";
            return o + s + o;
        }
        private string SetOutputName(FileInfo newXmlFile, int id, string folderb, int t)
        {
            string folder = newXmlFile.DirectoryName + @"\" + folderb;
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return folder + @"\" +  t.ToString().PadLeft(10, '0') +  newXmlFile.Name.Replace(newXmlFile.Name, newXmlFile.Name + id.ToString() + ".xml");
       
        }
        private string SetHoldingFile(FileInfo newXmlFile, int id, string folderb, int t)
        {
            string folder = newXmlFile.DirectoryName + @"\" + folderb;
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            string holdingfile  = folder + @"\" + "Holdings_Guide_DK-850940_" + folderb + ".xml";
            if (!File.Exists(holdingfile))
                CreateHolding(holdingfile, folderb);
            return holdingfile;
        }
        private void CreateHolding(string holdingfile, string folderb)
        {
            string holding = File.ReadAllText(HoldingFile.FullName, Encoding.UTF8);
            string newholding = holding.Replace("rest", folderb);
            File.WriteAllText(holdingfile, newholding);

      
            
        }
        private List<string> FindNavne(List<int> nids)
        {
            var navne = new List<string>();
            foreach (int nid in nids)
            {
                string s = HentNGNavn(nid);
                string name = HentNavn(s);
                string name1 = name.Trim().TrimStart(',').TrimStart('"').Trim();
                navne.Add(name1+ "NUMBER" + nid.ToString());
               
            }
            navne.Sort();
            return navne; 

            
        }
        private List<int> FetchIDs(string queryString)
        {
           
            var command = new SqlCommand(queryString, conn);
            SqlDataReader reader = command.ExecuteReader();

            var ids = new List<int>();


            try
            {

                while (reader.Read())
                {
                    if (!ids.Contains((int)reader[0]))
                    ids.Add((int)reader[0]);
                }

            }
            finally
            {
                reader.Close();
            }
            return ids;
        }
       
      
        private string HentXMLWithProcedure(string procedureName, Dictionary<string,string> parameters)
        {
            string result = string.Empty;
            string parameter = "";
            try
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (string key in parameters.Keys)
                    {
                        cmd.Parameters.AddWithValue(string.Format("@{0}", key), parameters[key]);
                        parameter = parameters[key] + " ";
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result = result + reader[i].ToString();
                            }
                        }
                    }
                }
                size = size + result.Length;
            }
            catch
            {
                result = string.Empty;
                Steps.Log.DebugFormat("Fejl i udtræk: " + procedureName + ": " + parameter);
            }
            return result;
        }

        private string HentNGNavn(int ngid)
        {
            Dictionary<string, string> pars = new Dictionary<string,string>();
            pars.Add("ngid", ngid.ToString());
            pars.Add("ngnid", 0.ToString());
            return  HentXMLWithProcedure("Xml_HentNgNavn",pars);
}

        private string HentNGInfo(int ngid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("ngid", ngid.ToString());
            return HentXMLWithProcedure("[Xml_HentNgInfo]", pars);
        }
        private string HentNGDetaljer(int ngid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("ngid", ngid.ToString());
            pars.Add("fra", "0");
            pars.Add("til", "99999999");
            pars.Add("sort", "1");
            pars.Add("direction", "a");
            pars.Add("interval", "0");
           
            string s = HentXMLWithProcedure("[Xml_HentNgDetaljer]", pars);
            return s;
        }
        private string HentHeInfoTop(int heid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("heid", heid.ToString());
            pars.Add("henid", 0.ToString());
            return HentXMLWithProcedure("Xml_HentHeInfoTop", pars);
        }
        private string HentHeInfoBund(int heid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("heid", heid.ToString());
            return HentXMLWithProcedure("Xml_HentHeInfoBund", pars);
        }
        private string HentHeAvInfo(int heid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("heid", heid.ToString());
            return HentXMLWithProcedure("Xml_HentHeAvInfo", pars);
        }
        private string HentEpMeInfo(int heid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("heid", heid.ToString());
            return HentXMLWithProcedure("Xml_HentEpMeInfo", pars);
        }
         private string HentMEDetaljer(int rid)
        {
            Dictionary<string, string> pars = new Dictionary<string, string>();
            pars.Add("MeID", 0.ToString());
            pars.Add("HeId", 0.ToString());
            pars.Add("HeNavnId", 0.ToString());
            pars.Add("EpId", 0.ToString());
            pars.Add("FormaalartId", 0.ToString());
            pars.Add("Me2RifId", rid.ToString());
        
            return HentXMLWithProcedure("Xml_HentMEDetaljer", pars);
        }
       
        private string GetQueryWithProc()
        {
       //   return "Select Ng.Id from Ng;";
          return "Select Ng.Id from Ng Where Ng.Kladde = 0;";
        }
      
        private string GetQueryWithHProc(string ngid)
        {
       //     return "Select Ng2HE.HeId from Ng2He where Ng2HE.Ngid = " + ngid + ";";
            return "Select Ng2HE.HeId from Ng2He join He on Ng2He.HeId = He.Id where He.Kladde = 0 and Ng2HE.Ngid = " + ngid + ";";
        }
        private string GetQueryWithNProc(string ngid)
        {
            return "Select NgNavn.Id from NgNavn where NgNavn.NgId = " + ngid + ";";
        }
        private string GetQueryWithRProc(string epid)
        {
            return "Select Rif.Id from Rif where Rif.EpId = " + epid + ";";
        }
        private string GetQueryWithMProc(string rid)
        {
            return "Select Me2Rif.Id from Me2Rif where Me2Rif.RifId = " + rid + ";";
        }
    
        private List<string> HentEpId(string ep)
        {
            XmlDocument xdoc = new XmlDocument();
            string myXml = ep;
            xdoc.LoadXml(myXml);
            XmlNodeList nodeList = xdoc.GetElementsByTagName("EpId");
            List<string> epid = new List<string>();
            foreach (XmlNode node in nodeList)
            {
                epid.Add(node.InnerText);
            }
            return epid;
        }
        private string CleanDates(string s)
        {
            XmlDocument xdoc = new XmlDocument();
            string myXml = s;
            xdoc.LoadXml(myXml);
            XmlNode root = xdoc.DocumentElement;

            XmlNodeList nodefra = xdoc.GetElementsByTagName("Fra");
            XmlNodeList nodetil = xdoc.GetElementsByTagName("Til");
            if (nodefra.Count == 0)
            {
                XmlElement elem = xdoc.CreateElement("Fra");
                elem.InnerText = "0000";
                root.AppendChild(elem);
            }
            if (nodetil.Count == 0)
            {
                XmlElement elem = xdoc.CreateElement("Til");
                elem.InnerText = "9999";
                root.AppendChild(elem);
            }
                return xdoc.InnerXml;

       
        }

        private SortedList<string, string> HentEpInfo(string ep)
        {
            XmlDocument xdoc = new XmlDocument();
            string myXml = ep;
            xdoc.LoadXml(myXml);
            XmlNodeList nodeList = xdoc.GetElementsByTagName("Eksemplar");
            SortedList<string, string> epid = new SortedList<string, string>();
            foreach (XmlNode node in nodeList)
            {
              
                XmlNodeList nodechildren = node.ChildNodes;
                string e = "";
                string i = "";
                foreach (XmlNode nodechild in nodechildren)
                {


                    if (nodechild.Name == "EpId")
                        e = nodechild.InnerText;
                    if (nodechild.Name == "FormaalArt")
                        i = i + "<FormaalArt>" + nodechild.InnerText + "</FormaalArt>";
                    if (nodechild.Name == "MedieArt")
                        i = i + "<MedieArt>" + nodechild.InnerText + "</MedieArt>";
                    if (nodechild.Name == "EnhedNavne")
                        i = i + "<EnhedNavne>" + nodechild.InnerText + "</EnhedNavne>";
                   
                }
                if (!epid.Keys.Contains(e))
                     epid.Add(e, i);
            }

            return epid;
        }
        private string CleanString(string p)
        {
   
            if (p.Contains("&#x01;"))
                 return p.Replace("&#x01;", "");
            
            return p;
     
                
		 
        }

        #endregion Methods

        #region Other

        private string GetQuery()
        {
            return File.ReadAllText(SQLFile.FullName);
        }
        

        #endregion Other
    
public  SqlConnection conn { get; set; }}
}