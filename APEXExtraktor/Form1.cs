using System.Threading;

namespace APEXExtractor
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Windows.Forms;
   

    using Ladder;

    public partial class Form1 : Form
    {
        #region Constructors
        public bool Stop;
        public bool Error;

        public Form1()
        {
            
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void button_Start_Click(object sender, EventArgs e)
        {
            Stop = false;

            DateTime start = DateTime.Now;
            if (!Stop)
            {
                if (checkBox_Extract.Checked)
                {
                    StatusLabel1.Text = "...";
                    StatusLabel3.Text = "Extract";
                    backgroundWorker1.RunWorkerAsync(1);
                    while (StatusLabel1.Text == "...")
                    {

                        ProcessInProgress(start);
                        Thread.Sleep(1000);


                    }
                }
            }
            if (!Stop)
            {
                if (checkBox_Transform.Checked)
                {
                    StatusLabel1.Text = "...";
                    StatusLabel3.Text = "Transform";
                    backgroundWorker1.RunWorkerAsync(2);
                    while (StatusLabel1.Text == "...")
                    {

                        ProcessInProgress(start);
                        Thread.Sleep(1000);


                    }
                }
            }
            if (!Stop)
            {
                if (checkBox_Validate.Checked)
                {
                    StatusLabel1.Text = "...";
                    StatusLabel3.Text = "Validate";
                    backgroundWorker1.RunWorkerAsync(3);
                    while (StatusLabel1.Text == "...")
                    {

                        ProcessInProgress(start);
                        Thread.Sleep(1000);


                    }
                }
            }
                if (!Stop)
                {
                    if (checkBox_pakoutput.Checked)
                    {
                        StatusLabel1.Text = "...";
                        StatusLabel3.Text = "Pakning";
                        backgroundWorker1.RunWorkerAsync(4);
                        while (StatusLabel1.Text == "...")
                        {

                            ProcessInProgress(start);
                            Thread.Sleep(1000);


                        }
                    }
                }
                StatusLabel3.Text = "Finish";
                Application.DoEvents();

                //        ladder.TotalFlow(new DirectoryInfo (textBox_outputfolder.Text, new DirectoryInfo(textBox_workfolder.Text), new FileInfo(textBox_outputfil.Text)));
            
        }
        private void ProcessInProgress(DateTime start)
        {
            StatusLabel2.Text = (DateTime.Now - start).ToString();
         
            Application.DoEvents();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Methods

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_outputfolder.Text = ApexSettings.ReadApexSetting("outputfolder");
            textBox_workfolder.Text = ApexSettings.ReadApexSetting("workfolder");
            textBox_sidsthentet.Text = ApexSettings.ReadApexSetting("sidsthentet");
        }

        private void button_outputfolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)

                textBox_outputfolder.Text = fbd.SelectedPath;


        }

        private void button_workfolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)

                textBox_workfolder.Text = fbd.SelectedPath;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            ISteps ladder = new Steps();
            ladder.LogFolder = new DirectoryInfo(textBox_workfolder.Text);
            ladder.LogEnabled = checkBox_log.Checked;
            var step = (int)e.Argument;
            if (step == 1)
            {
              int sidst = ladder.GetDaisyXML(new FileInfo(textBox_workfolder.Text + @"\dataextract"), Convert.ToInt16(textBox_sidsthentet.Text));
              ApexSettings.UpdateApexSetting("sidsthentet", sidst.ToString());
            }
            if (step == 2)
            {
                ladder.TransformDaisy2APEX(new DirectoryInfo(textBox_workfolder.Text), new DirectoryInfo(textBox_outputfolder.Text));
               
            }
            if (step == 3)
                ladder.ValidateAPEXFile(new FileInfo(textBox_outputfolder.Text + @"\" + textBox_sidsthentet.Text));

            if (step == 4)
         PackFiles();
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                StatusLabel1.Text = "Afbrudt";
            }
            else if (e.Error != null)
            {
                StatusLabel1.Text = "Fejlede";
            }
            else
            {
                StatusLabel1.Text = "";
            }
        }


        private void button_Stop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }
        private void PackFiles()
        {
            string[] outputdirs = Directory.GetDirectories(textBox_outputfolder.Text, "*", SearchOption.TopDirectoryOnly);
            
            foreach (string outputdir in outputdirs)
            {
                DirectoryInfo output = new DirectoryInfo(outputdir);

                string startPath = outputdir;
                string zipPath = textBox_zip.Text + @"\" + output.Name + ".zip";
                  ZipFile.CreateFromDirectory(startPath, zipPath);
            }

            //if (!Directory.Exists(textBox_outputfolder.Text+"zip"))
            //    Directory.CreateDirectory(textBox_outputfolder.Text+"zip");

            //string startPath = textBox_outputfolder.Text;
            //string zipPath = textBox_outputfolder.Text+"zip" + @"\result.zip";
      

            

          

        }

        private void button_zip_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)

                textBox_zip.Text = fbd.SelectedPath;
        }
    }
}