using System.Windows.Forms;

namespace APEXExtractor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_log = new System.Windows.Forms.CheckBox();
            this.textBox_sidsthentet = new System.Windows.Forms.TextBox();
            this.textBox_outputfolder = new System.Windows.Forms.TextBox();
            this.textBox_workfolder = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_outputfolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_workfolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Validate = new System.Windows.Forms.CheckBox();
            this.checkBox_Transform = new System.Windows.Forms.CheckBox();
            this.checkBox_Extract = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBox_pakoutput = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_zip = new System.Windows.Forms.Button();
            this.textBox_zip = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;
            this.toolTip1.ShowAlways = true;
            // 
            // checkBox_log
            // 
            this.checkBox_log.AutoSize = true;
            this.checkBox_log.Checked = true;
            this.checkBox_log.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_log.Location = new System.Drawing.Point(570, 124);
            this.checkBox_log.Name = "checkBox_log";
            this.checkBox_log.Size = new System.Drawing.Size(86, 17);
            this.checkBox_log.TabIndex = 4;
            this.checkBox_log.Text = "Log Enabled";
            this.toolTip1.SetToolTip(this.checkBox_log, "Skriver til log.txt i den eksekverende folder");
            this.checkBox_log.UseVisualStyleBackColor = true;
            // 
            // textBox_sidsthentet
            // 
            this.textBox_sidsthentet.Location = new System.Drawing.Point(253, 125);
            this.textBox_sidsthentet.Name = "textBox_sidsthentet";
            this.textBox_sidsthentet.Size = new System.Drawing.Size(129, 20);
            this.textBox_sidsthentet.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox_sidsthentet, "Angiv navn på xmlfil");
            // 
            // textBox_outputfolder
            // 
            this.textBox_outputfolder.Location = new System.Drawing.Point(157, 14);
            this.textBox_outputfolder.Name = "textBox_outputfolder";
            this.textBox_outputfolder.Size = new System.Drawing.Size(400, 20);
            this.textBox_outputfolder.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBox_outputfolder, "Angiv navn på xmlfil");
            // 
            // textBox_workfolder
            // 
            this.textBox_workfolder.Location = new System.Drawing.Point(157, 40);
            this.textBox_workfolder.Name = "textBox_workfolder";
            this.textBox_workfolder.Size = new System.Drawing.Size(400, 20);
            this.textBox_workfolder.TabIndex = 12;
            this.toolTip1.SetToolTip(this.textBox_workfolder, "Angiv navn på xmlfil");
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(15, 258);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_outputfolder
            // 
            this.button_outputfolder.Location = new System.Drawing.Point(581, 14);
            this.button_outputfolder.Name = "button_outputfolder";
            this.button_outputfolder.Size = new System.Drawing.Size(75, 23);
            this.button_outputfolder.TabIndex = 10;
            this.button_outputfolder.Text = "Vælg";
            this.button_outputfolder.UseVisualStyleBackColor = true;
            this.button_outputfolder.Click += new System.EventHandler(this.button_outputfolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Placering af output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Placering af mellemresultater";
            // 
            // button_workfolder
            // 
            this.button_workfolder.Location = new System.Drawing.Point(581, 38);
            this.button_workfolder.Name = "button_workfolder";
            this.button_workfolder.Size = new System.Drawing.Size(75, 23);
            this.button_workfolder.TabIndex = 13;
            this.button_workfolder.Text = "Vælg";
            this.button_workfolder.UseVisualStyleBackColor = true;
            this.button_workfolder.Click += new System.EventHandler(this.button_workfolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sidst hentet NGID";
            // 
            // checkBox_Validate
            // 
            this.checkBox_Validate.AutoSize = true;
            this.checkBox_Validate.Location = new System.Drawing.Point(15, 174);
            this.checkBox_Validate.Name = "checkBox_Validate";
            this.checkBox_Validate.Size = new System.Drawing.Size(82, 17);
            this.checkBox_Validate.TabIndex = 16;
            this.checkBox_Validate.Text = "Validate xml";
            this.checkBox_Validate.UseVisualStyleBackColor = true;
            // 
            // checkBox_Transform
            // 
            this.checkBox_Transform.AutoSize = true;
            this.checkBox_Transform.Checked = true;
            this.checkBox_Transform.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Transform.Location = new System.Drawing.Point(15, 151);
            this.checkBox_Transform.Name = "checkBox_Transform";
            this.checkBox_Transform.Size = new System.Drawing.Size(126, 17);
            this.checkBox_Transform.TabIndex = 17;
            this.checkBox_Transform.Text = "Transform xml-extract";
            this.checkBox_Transform.UseVisualStyleBackColor = true;
            // 
            // checkBox_Extract
            // 
            this.checkBox_Extract.AutoSize = true;
            this.checkBox_Extract.Checked = true;
            this.checkBox_Extract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Extract.Location = new System.Drawing.Point(15, 125);
            this.checkBox_Extract.Name = "checkBox_Extract";
            this.checkBox_Extract.Size = new System.Drawing.Size(84, 17);
            this.checkBox_Extract.TabIndex = 18;
            this.checkBox_Extract.Text = "Data extract";
            this.checkBox_Extract.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1,
            this.StatusLabel2,
            this.StatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 311);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(674, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel2
            // 
            this.StatusLabel2.Name = "StatusLabel2";
            this.StatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // StatusLabel3
            // 
            this.StatusLabel3.Name = "StatusLabel3";
            this.StatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // checkBox_pakoutput
            // 
            this.checkBox_pakoutput.AutoSize = true;
            this.checkBox_pakoutput.Location = new System.Drawing.Point(15, 197);
            this.checkBox_pakoutput.Name = "checkBox_pakoutput";
            this.checkBox_pakoutput.Size = new System.Drawing.Size(78, 17);
            this.checkBox_pakoutput.TabIndex = 20;
            this.checkBox_pakoutput.Text = "Pak output";
            this.checkBox_pakoutput.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Placering af zip filer";
            // 
            // button_zip
            // 
            this.button_zip.Location = new System.Drawing.Point(581, 73);
            this.button_zip.Name = "button_zip";
            this.button_zip.Size = new System.Drawing.Size(75, 23);
            this.button_zip.TabIndex = 22;
            this.button_zip.Text = "Vælg";
            this.button_zip.UseVisualStyleBackColor = true;
            this.button_zip.Click += new System.EventHandler(this.button_zip_Click);
            // 
            // textBox_zip
            // 
            this.textBox_zip.Location = new System.Drawing.Point(157, 75);
            this.textBox_zip.Name = "textBox_zip";
            this.textBox_zip.Size = new System.Drawing.Size(400, 20);
            this.textBox_zip.TabIndex = 21;
            this.toolTip1.SetToolTip(this.textBox_zip, "Angiv navn på xmlfil");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(674, 333);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_zip);
            this.Controls.Add(this.textBox_zip);
            this.Controls.Add(this.checkBox_pakoutput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.checkBox_Extract);
            this.Controls.Add(this.checkBox_Transform);
            this.Controls.Add(this.checkBox_Validate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_workfolder);
            this.Controls.Add(this.textBox_workfolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_outputfolder);
            this.Controls.Add(this.textBox_outputfolder);
            this.Controls.Add(this.textBox_sidsthentet);
            this.Controls.Add(this.checkBox_log);
            this.Controls.Add(this.button_Start);
            this.Name = "Form1";
            this.Text = "SA\'s APEX Extractor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.CheckBox checkBox_log;
        private System.Windows.Forms.TextBox textBox_sidsthentet;
        private ToolTip toolTip1;
        private Button button_outputfolder;
        private TextBox textBox_outputfolder;
        private Label label1;
        private Label label2;
        private Button button_workfolder;
        private TextBox textBox_workfolder;
        private Label label3;
        private CheckBox checkBox_Validate;
        private CheckBox checkBox_Transform;
        private CheckBox checkBox_Extract;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel1;
        private ToolStripStatusLabel StatusLabel2;
        private ToolStripStatusLabel StatusLabel3;
        private CheckBox checkBox_pakoutput;
        private Label label4;
        private Button button_zip;
        private TextBox textBox_zip;
    }
}

