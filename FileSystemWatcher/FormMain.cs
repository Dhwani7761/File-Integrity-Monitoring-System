using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace FileChangeNotifier
{
    public partial class frmNotifier : Form
    {
        private StringBuilder Sb;
        private bool bempty;
        private System.IO.FileSystemWatcher Watcher;
        private bool bIsWatching;

        public frmNotifier()
        {
            InitializeComponent();
            Sb = new StringBuilder();
            bempty = false;
            bIsWatching = false;
            /*string p = txtFile.Text;
            string h= System.Net.Dns.GetHostName();
            String str = @"Data Source=DHWANI\SQLEXPRESS;Initial Catalog=ABCD;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            string q = "Insert into Driver(driver_host,driver_path) VALUES (@driver_host,@driver_path)";
            SqlCommand cmd1 = new SqlCommand(q, con1);
            cmd1.Parameters.AddWithValue("@driver_host", h);
            cmd1.Parameters.AddWithValue("@driver_path", p);
            cmd1.ExecuteNonQuery();*/
        }

        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            if (bIsWatching)
            {
                bIsWatching = false;
                Watcher.EnableRaisingEvents = false;
                Watcher.Dispose();
                btnWatchFile.BackColor = Color.LightSkyBlue;
                btnWatchFile.Text = "Start Watching";
                
            }
            else
            {
                bIsWatching = true;
                btnWatchFile.BackColor = Color.Red;
                btnWatchFile.Text = "Stop Watching";

                Watcher = new System.IO.FileSystemWatcher();
                if (rdbDir.Checked)
                {
                    Watcher.Filter = "*.*";
                    Watcher.Path = txtFile.Text + "\\";
                }
                else
                {
                    Watcher.Filter = txtFile.Text.Substring(txtFile.Text.LastIndexOf('\\') + 1);
                    Watcher.Path = txtFile.Text.Substring(0, txtFile.Text.Length - Watcher.Filter.Length);
                }

                if (chkSubFolder.Checked)
                {
                    Watcher.IncludeSubdirectories = true;
                }

                Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                Watcher.Changed += new FileSystemEventHandler(OnChanged);
                Watcher.Created += new FileSystemEventHandler(OnChanged);
                Watcher.Deleted += new FileSystemEventHandler(OnChanged);
                Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                Watcher.EnableRaisingEvents = true;

                string p = txtFile.Text;
           string h= System.Net.Dns.GetHostName();
           String str = @"Data Source=DHWANI\SQLEXPRESS;Initial Catalog=ABCD;Integrated Security=True";
           SqlConnection con1 = new SqlConnection(str);
           con1.Open();
           string q = "Insert into Driver(driver_host,driver_path) VALUES (@driver_host,@driver_path)";
           SqlCommand cmd1 = new SqlCommand(q, con1);
           cmd1.Parameters.AddWithValue("@driver_host", h);
           cmd1.Parameters.AddWithValue("@driver_path", p);
           cmd1.ExecuteNonQuery();
            }
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!bempty)
            {
                string hname = System.Net.Dns.GetHostName();
                string dt = DateTime.Now.ToString();
                String s = @"Data Source=DHWANI\SQLEXPRESS;Initial Catalog=ABCD;Integrated Security=True";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                string q = "Insert into FileLogs(f_name , f_path ,f_action,f_dtime,f_hname) VALUES (@f_name, @f_path,@f_action,@f_dtime,@f_hname)";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@f_name", e.Name);
                cmd.Parameters.AddWithValue("@f_path", e.FullPath);
                cmd.Parameters.AddWithValue("@f_action", e.ChangeType.ToString());
                cmd.Parameters.AddWithValue("@f_dtime",dt);
                cmd.Parameters.AddWithValue("@f_hname", hname);
                cmd.ExecuteNonQuery();

                Sb.Remove(0, Sb.Length);
                Sb.Append(e.FullPath);
                Sb.Append(" ");
                Sb.Append(e.Name);
                Sb.Append(" ");
                Sb.Append(e.ChangeType.ToString());
                Sb.Append("    ");
                Sb.Append(DateTime.Now.ToString());
                bempty = true;
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
        if (!bempty)
            {
                string hname = System.Net.Dns.GetHostName();
                string dt = DateTime.Now.ToString();
                String s = @"Data Source=DHWANI\SQLEXPRESS;Initial Catalog=ABCD;Integrated Security=True";
                SqlConnection con = new SqlConnection(s);
                con.Open();
                string q = "Insert into FileLogs(f_name , f_path ,f_action,f_dtime,f_hname) VALUES (@f_name, @f_path,@f_action,@f_dtime,@f_hname)";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@f_name", e.Name);
                cmd.Parameters.AddWithValue("@f_path", e.FullPath);
                cmd.Parameters.AddWithValue("@f_action", e.ChangeType.ToString());
                cmd.Parameters.AddWithValue("@f_dtime", dt);
                cmd.Parameters.AddWithValue("@f_hname", hname);
                cmd.ExecuteNonQuery();

                Sb.Remove(0, Sb.Length);
                Sb.Append(e.OldFullPath);
                Sb.Append(" ");
                Sb.Append(e.ChangeType.ToString());
                Sb.Append(" ");
                Sb.Append(e.Name);
                Sb.Append("    ");
                Sb.Append(DateTime.Now.ToString());
                bempty = true;
                if (rdbFile.Checked)
                {
                    Watcher.Filter = e.Name;
                    Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - Watcher.Filter.Length);
                }
            }            
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (bempty)
            {
                lstNotification.BeginUpdate();
                lstNotification.Items.Add(Sb.ToString());
                lstNotification.EndUpdate();
                bempty = false;
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            if (rdbDir.Checked)
            {
                DialogResult resDialog = dlgOpenDir.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenDir.SelectedPath;
                }
            }
            else
            {
                DialogResult resDialog = dlgOpenFile.ShowDialog();
                if (resDialog.ToString() == "OK")
                {
                    txtFile.Text = dlgOpenFile.FileName;
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = dlgSaveFile.ShowDialog();
            if (resDialog.ToString() == "OK")
            {
                FileInfo fi = new FileInfo(dlgSaveFile.FileName);
                StreamWriter sw = fi.CreateText();
                foreach (string sItem in lstNotification.Items)
                {
                    sw.WriteLine(sItem);
                }
                sw.Close();
            }
        }

        private void rdbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFile.Checked == true)
            {
                chkSubFolder.Enabled = false;
                chkSubFolder.Checked = false;
            }
        }

        private void rdbDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDir.Checked == true)
            {
                chkSubFolder.Enabled = true;
            }
        }
    }
}