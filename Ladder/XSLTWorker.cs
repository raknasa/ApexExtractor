using System;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace Ladder
{
    using System.IO;

    public class XSLTWorker : IXSLTWorker
    {
        #region Constructors

        public XSLTWorker()
        {
            XSLTFile = new FileInfo("./lib/ApexTransMix.xslt");
        }

        #endregion Constructors

        #region Properties

        public FileInfo XSLTFile
        {
            get; set;
        }

        #endregion Properties

        #region Methods


        public void TransformXML(DirectoryInfo dir, DirectoryInfo targetdir)
        {

            string[] bogdirs = Directory.GetDirectories(dir.FullName, "*", SearchOption.TopDirectoryOnly);
            foreach (string bogd in bogdirs)
            {

                DirectoryInfo bogdir = new DirectoryInfo (bogd);
                string outputdir = targetdir + @"\" + bogdir.Name;
                if (!Directory.Exists(outputdir))
                    Directory.CreateDirectory(outputdir);
                string[] files = Directory.GetFiles(bogdir.FullName, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    FileInfo input = new FileInfo(file);
                 //   FileInfo output = new FileInfo(targetdir + @"\" + input.Name);
                    FileInfo output = new FileInfo(outputdir + @"\" + input.Name);
                    if (input.Name.Contains("dataextract"))
                        TransformOneXML(input, output);
                    else
                        File.Copy(input.FullName, outputdir + @"\" + input.Name);
                }
            }
        }
        public void TransformOneXML(FileInfo xmlFile, FileInfo targetFile)
        {
            Steps.Log.Debug("Brug ProcessStartInfo class");
            Steps.Log.Debug("Skriv 'Transform -s:source -xsl:stylesheet -o:output'");

            Steps.Log.DebugFormat("Dvs: 'Transform -s:{0} -xsl:{1} -o:{2}'", xmlFile.FullName, XSLTFile.FullName,
                                          targetFile);

            try
            {
                XPathDocument myXPathDocument = new XPathDocument(xmlFile.FullName);
                var myXslTransform = new System.Xml.Xsl.XslCompiledTransform();
                XmlTextWriter writer = new XmlTextWriter(targetFile.FullName, Encoding.UTF8);
                myXslTransform.Load(XSLTFile.FullName);
                myXslTransform.Transform(myXPathDocument, null, writer);
                writer.Close();

                string id = xmlFile.Name.Replace("dataextract", "").Replace(".xml", "");
                string o = @"""";
                string[] lines = File.ReadAllLines(targetFile.FullName, Encoding.UTF8);
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = lines[i].Replace(" xmlns=" + o + o, "").Replace("Creator", "Creator " + id).Replace("1</eadid>", id+"</eadid>");
                }
                File.WriteAllLines(targetFile.FullName, lines, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Steps.Log.Debug(e);
            }
        }
        #endregion Methods

        #region Other


        #endregion Other
    }
}