namespace APEXExtractor
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using Ladder;

    public partial class Form1 : Form
    {
        #region Constructors

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            ISteps ladder = new Steps();
            ladder.LogEnabled = checkBox1.Checked;
            ladder.TotalFlow(new FileInfo(textBox1.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Methods

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}