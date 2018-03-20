using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetAllSiteURL
{
    public partial class ExportUrl : Form
    {
        public ExportUrl()
        {
            InitializeComponent();
            linkLog.Text = string.Empty;
        }
        private string logPath;
        private string errorLogPath;
        private string webAppUrl;
        private string resultPath = "SiteUrls.csv";

        private void btnExport_Click(object sender, EventArgs e)
        {
            logPath = "CR1052or6Log_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt";
            errorLogPath = "CRErrorLog_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt";
            if (File.Exists(resultPath))
            {
                File.Delete(resultPath);
            }
            //ConnStr.Text = @"Data Source=US70TWDBS019\SP13DMIG01;Initial Catalog=SFDC_Integrations;Integrated Security=SSPI;";
            if (string.IsNullOrEmpty(UrlStr.Text))
            {
                MessageBox.Show("Please input Web Application Url.");
                return;
            }
            else
            {
                webAppUrl = UrlStr.Text;
            }

            SetLabelText("Running...Please wait...");
            btnExport.Enabled = false;
            linkLog.Enabled = false;
            Thread thread = new Thread(new ThreadStart(GetUrl));
            thread.IsBackground = true;
            thread.Start();
        }

        private void GetUrl()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWebApplication webApp = SPWebApplication.Lookup(new Uri(webAppUrl));
                    DateTime date1 = System.DateTime.Now;
                    WriteLog(date1.ToString());
                    string head = @"url";
                    WriteResult(head);

                    foreach (SPSite site in webApp.Sites)
                    {

                        try
                        {
                            //string resultText = "\"" + site.Url + "\"";
                            //WriteResult(resultText);
                            try
                            {
                                DoSubsite(site.RootWeb);
                            }
                            catch (Exception ex)
                            {

                                WriteErrorLog("Into DoSubsite method error for site " + site.Url + ex.ToString());
                            }
                            
                        }
                        catch (Exception ex)
                        {

                            WriteErrorLog("write site error for site " + site.Url + ex.ToString());
                        }
                        site.Dispose();
                        site.Close();
                    }
                    DateTime date2 = System.DateTime.Now;
                    WriteLog("End time:" + (date2 - date1).ToString());
                }
                );


                this.BeginInvoke(new MethodInvoker(delegate
                {
                    btnExport.Enabled = true;
                    linkLog.Enabled = true;
                }));

                SetLabelText("Click here to view log file.");

            }
            catch (Exception ex)
            {
                WriteErrorLog("There are something wrong!!" + ex.ToString());
            }
        }

        private void DoSubsite(SPWeb web)
        {
            try
            {
                string webServerRelativeUrl = web.ServerRelativeUrl.TrimEnd(new char[] { '/' });
                if (webServerRelativeUrl != "" && !webServerRelativeUrl.Contains("QuoteMigration") && !webServerRelativeUrl.Contains("OfferMigration") && !webServerRelativeUrl.Contains("ContractMigration"))
                {
                    string resultText = "\"" + web.Url + "\"";
                    WriteResult(resultText);
                }
               

                foreach (SPWeb subWeb in web.Webs)
                {
                    DoSubsite(subWeb);
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("write Url error for web:" + web.Url + ". Exception:" + ex.ToString());
            }
            finally
            {
                web.Dispose();
                web.Close();
                web = null;
            }
        }
        public void WriteResult(string text)
        {
            FileStream fs = new FileStream(resultPath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(text);
            sw.Close();
            fs.Close();
        }
        delegate void labDelegate(string str);
        private void SetLabelText(string str)
        {
            if (linkLog.InvokeRequired)
            {
                Invoke(new labDelegate(SetLabelText), new string[] { str });
            }
            else
            {
                linkLog.Text = str;
            }
        }
        public void WriteLog(string text)
        {
            FileStream fs = new FileStream(logPath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(text);
            sw.Close();
            fs.Close();
        }
        public void WriteErrorLog(string text)
        {
            FileStream fs = new FileStream(errorLogPath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.WriteLine(text);
            sw.Close();
            fs.Close();
        }

        private void linkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(logPath);
        }
    }
}
