using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethOperation
{
    static class NotificationQueue
    {
        private class NotificationQueueItem
        {
            public string Sender { get; private set; }

            public string Message { get; private set; }

            public string PicName { get; private set; }

            public int Icon { get; private set; }

            public bool PlaySound { get; private set; }

            public NotificationQueueItem(string sender, string message, string picName, int icon, bool playSound)
            {
                Sender = sender;
                Message = message;
                PicName = picName;
                Icon = icon;
                PlaySound = playSound;
            }
        }

        private readonly static Queue<NotificationQueueItem> _queue = new Queue<NotificationQueueItem>();

        public static void Add(string sender, string message, string picName, int icon, bool playSound = true)
        {
            _queue.Enqueue(new NotificationQueueItem(sender, message, picName, icon, playSound));
        }


        public static bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        public static void ProcessAll()
        {
            if (_queue.Count > 0)
            {
                foreach (NotificationQueueItem item in _queue)
                {
                    Util.NotifyWithPicture(item.Sender, item.Message, item.PicName, item.Icon, item.PlaySound);
                }

                _queue.Clear();
            }
        }

    }
}
