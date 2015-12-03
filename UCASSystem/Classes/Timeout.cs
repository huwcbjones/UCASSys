using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UCASSys.Classes
{
    class Timeout
    {
        public delegate void timeoutReached();
        public event timeoutReached timeoutReachedHandler;

        private DateTime _lastKeyPress;
        private int _timeout;

        private bool _shouldTerminate = false;

        public int Time
        {
            get { return _timeout; }
            set
            {
                _timeout = value;
            }
        }

        public Timeout(int timeout)
        {
            _timeout = timeout;
        }

        public void KeyPress()
        {
            _shouldTerminate = true;
            _lastKeyPress = DateTime.Now;
            ThreadPool.QueueUserWorkItem(new WaitCallback(_doTimeout));
        }

        private void _doTimeout(object StateInfo)
        {
            _shouldTerminate = false;
            while (DateTime.Now.Subtract(_lastKeyPress).Ticks < (10000 * _timeout))
            {
                if (_shouldTerminate)
                {
                    break;
                }
            }
            if (!_shouldTerminate)
            {
                if (timeoutReachedHandler != null)
                {
                    Program.log.console(GetType().Namespace, "Timeout reached!");
                    timeoutReachedHandler();
                }
            }
            _shouldTerminate = false;
        }
    }
}
