using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Motorcycle.Common.Managers
{
    // define event
    public delegate void DeleteChangeEvent(object sender, DeleteChangeEventArgs args);
    public class DeleteChangeEventArgs : EventArgs 
    {
        public bool Delete { get; }
        public DeleteChangeEventArgs(bool delete)
        {
            this.Delete = delete;
        }
    }

    //publisher


    public class EventManager
    {
        // events
        public event DeleteChangeEvent OnDeleteChangeEvent;

        public EventManager()
        {

        }

        // events publishers
        private void PublishDeleteChangeEvent(bool delete)
        {
            if (this.OnDeleteChangeEvent is not null)
            {
                DeleteChangeEventArgs args = new DeleteChangeEventArgs(delete);
                this.OnDeleteChangeEvent.Invoke(this, args);
            }
        }


        // public triggers
        public void RequestDeletionOfMotorcycle(bool delete)
        {
            this.PublishDeleteChangeEvent(delete);
        }

    }
}
