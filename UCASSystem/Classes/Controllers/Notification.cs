using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace UCASSys.Classes.Controllers
{
    public class Notification : IDisposable
    {
        private Timer pollTimer = new Timer();

        private Thread notifierThread;
        private List<Items.NotificationItem> notificationQueue = new List<Items.NotificationItem>();

        private bool enabled = false;
        private AutoResetEvent enableQueue = new AutoResetEvent(false);
        private AutoResetEvent resetQueue = new AutoResetEvent(false);


        public delegate void notificationHandler(Items.NotificationItem notification, bool data = false);
        public event notificationHandler raiseNotification;

        public delegate void notificationPollHandler();
        public event notificationPollHandler pollNotifications;

        public Notification()
        {
            pollTimer.Interval = 1000 * 60 * 10;

            if (Program.regCtrl.getKey("interval_notification_poll"))
            {
                if (Program.regCtrl.getKey("interval_notification_poll") != null)
                {
                    pollTimer.Interval = 1000 * 60 * (int)Program.regCtrl.getKey("interval_notification_poll").Data;
                }
            }

            pollTimer.Tick += pollTimer_Tick;

            notifierThread = new Thread(processQueue);
            notifierThread.Priority = ThreadPriority.BelowNormal;
            notifierThread.IsBackground = true;
            notifierThread.Start();
        }

        private void pollTimer_Tick(object sender, EventArgs e)
        {
            if (pollNotifications != null)
            {
                pollNotifications();
            }
        }

        public void Dispose()
        {
            pollTimer.Dispose();
            notifierThread.Abort();
            enableQueue.Dispose();
            resetQueue.Dispose();
        }

        public void Add(Items.NotificationItem notification)
        {
            notificationQueue.Add(notification);
            resetQueue.Set();
        }

        public void Enable()
        {
            this.enabled = true;
            this.pollTimer.Enabled = true;
            this.enableQueue.Set();
        }
        public void Disable()
        {
            this.enabled = false;
            this.pollTimer.Enabled = false;
        }

        private void processQueue()
        {
            Classes.Items.NotificationItem currentNotification;
            do
            {
                if (!this.enabled)
                {
                    enableQueue.WaitOne();
                }

                for (int x = this.notificationQueue.Count - 1; x >= 0; x += -1)
                {
                    Program.log.console(GetType().ToString(), "Processing notification #" + x.ToString());
                    if (this.notificationQueue.ElementAtOrDefault(x) != null)
                    {
                        currentNotification = this.notificationQueue[x];
                        raiseNotification(currentNotification, (currentNotification.Data != null));
                        this.notificationQueue.RemoveAt(x);
                        Thread.Sleep(5000);
                    }

                }
                resetQueue.WaitOne();
            } while (true);
        }
    }
}
