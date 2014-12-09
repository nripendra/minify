using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Src
{
    public partial class MainForm : Form
    {
        ProjectConfig config;
        DateTime lastTime = DateTime.MinValue;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);
            string fileName = openFileDialog1.FileName;
            if (File.Exists(fileName))
            {

                config = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectConfig>(File.ReadAllText(fileName));

                if (string.IsNullOrWhiteSpace(config.DirectoryName))
                {
                    config.DirectoryName = Path.GetDirectoryName(fileName);
                }

                lnkFileName.Text = config.ProjectName;
                lnkFileName.Tag = fileName;
                lnkFileName.Visible = true;

                btnStart.Enabled = true;
                btnBundle.Enabled = true;
            }
        }

        private void lnkFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = lnkFileName.Tag as string;
            if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName))
            {
                Process.Start(new ProcessStartInfo { FileName = "Explorer.exe", Arguments = Path.GetDirectoryName(fileName) });
            }
        }

        private void fileChangeWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            var now = DateTime.Now;
            var diff = now - lastTime;
            if (diff.TotalMilliseconds > 1000)
            {
                lastTime = DateTime.Now;

                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    if (config != null && config.Bundles != null)
                    {
                        System.Threading.Thread.Sleep(500);

                        BundleAndMinify(e.FullPath);
                    }
                }
            }
        }

        private void BundleAndMinify(string changedFile)
        {
            foreach (var bundle in config.Bundles)
            {
                // #nrip - don't entertain event fired due to our own write..
                if (!string.IsNullOrWhiteSpace(changedFile) && changedFile.Equals(Path.Combine(config.DirectoryName, bundle.BundleName), StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }

                string[] patterns = bundle.Files.SelectMany(pattern => pattern.Split('|')).ToArray();

                string[] bundlableFiles = patterns.SelectMany(x => Directory.GetFiles(config.DirectoryName, x)).ToArray();
                if (bundlableFiles != null && bundlableFiles.Length > 0)
                {
                    if (string.IsNullOrWhiteSpace(changedFile) || bundlableFiles.Contains(changedFile, StringComparer.InvariantCultureIgnoreCase))
                    {
                        if (!string.IsNullOrWhiteSpace(changedFile))
                        {
                            Log("File change detected : {0}", changedFile);
                        }

                        StringBuilder bundler = new StringBuilder();
                        foreach (var file in bundlableFiles)
                        {
                            string fileContent = "";
                            if (bundle.Minify)
                            {
                                Minifier minifier = new Minifier();
                                fileContent = minifier.MinifyJavaScript(File.ReadAllText(file), new CodeSettings { OutputMode = OutputMode.SingleLine });
                            }
                            else
                            {
                                fileContent = File.ReadAllText(file);
                            }

                            bundler.AppendLine(fileContent);
                        }

                        string outfile = Path.Combine(config.DirectoryName, bundle.BundleName);
                        File.WriteAllText(outfile, bundler.ToString());
                        Log("Completed: {0}!!", outfile);
                    }
                }
            }
            return;
        }

        private void Log(string message, params object[] args)
        {
            txtLog.Text += string.Format(message, args) + Environment.NewLine;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if ((btnStart.Tag ?? "").ToString() != "Started")
            {
                btnStart.Tag = "Started";
                btnStart.Text = "Stop";
                toolTip1.SetToolTip(btnStart, "Stop listening to file changes.");
                btnBundle.Enabled = false;

                fileChangeWatcher.Path = config.DirectoryName;
                fileChangeWatcher.EnableRaisingEvents = true;
                Log("Started...");
            }
            else
            {
                btnStart.Tag = "Stopped";
                btnStart.Text = "Start";
                toolTip1.SetToolTip(btnStart, "Start listening to changes made to file, and automatically bundle and minify any changes.");
                btnBundle.Enabled = true;

                fileChangeWatcher.EnableRaisingEvents = false;

                Log("Stopped...");
            }
        }

        private void btnBundle_Click(object sender, EventArgs e)
        {
            BundleAndMinify("");
        }

    }
}
