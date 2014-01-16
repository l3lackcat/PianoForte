using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.ComponentModel;

using PianoForte.Models;
using PianoForte.Services;

namespace PianoForte
{
    public class Global : System.Web.HttpApplication
    {
        BackgroundWorker worker;
        List<Branch> branchList;

        protected void Application_Start(object sender, EventArgs e)
        {
            //branchList = BranchService.getBranchList();

            //startUpdateClassroomDetailStatusBackgroundWorker(); 
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            stopUpdateClassroomDetailStatusBackgroundWorker();
        }

        private void startUpdateClassroomDetailStatusBackgroundWorker()
        {
            this.worker = new BackgroundWorker();
            this.worker.DoWork += new DoWorkEventHandler(updateClassroomDetailStatusWork);
            this.worker.WorkerReportsProgress = false;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(updateClassroomDetailStatusWorkCompleted);
            this.worker.RunWorkerAsync(HttpContext.Current); //Pass HttpContext to background worker

            //Add this BackgroundWorker object instance to the application variables 
            //so it can be cleared when the Application_End event fires.
            //HttpContext.Current.Application.GetVariables().SqlPollingBackgroundWorker = worker;
            HttpContext.Current.Application["UpdateClassroomDetailStatusBackgroundWorker"] = this.worker;
        }

        private void stopUpdateClassroomDetailStatusBackgroundWorker()
        {
            //If background worker process is running then clean up that object.
            this.worker.CancelAsync();
        }

        private void updateClassroomDetailStatusWork(object sender, DoWorkEventArgs e)
        {
            //Get current HttpContext from the DoWorkEventArgs object
            HttpContext.Current = (HttpContext)e.Argument;

            //Run a constant loop that polls SQL server at an interval dictated 
            //by the CacheRefreshIntervalMinutes application setting. This loop 
            //will run as long as the web application is running. When the web
            //application stops, this process will be stopped.
            while (true)
            {
                //Sleep for some period of time
                System.Threading.Thread.Sleep(15 * 60 * 1000);

                try
                {
                    foreach (Branch branch in this.branchList)
                    {
                        ClassroomDetailService.updateClassroomDetailStatus(branch.DatabaseName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void updateClassroomDetailStatusWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Do Nothing
        }
    }
}