using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace United_Youth_Orchestra_with_MVC.Models
{
    public class MailModel
    {
        public string From
        {
            get;
            set;
        }
        public string To
        {
            get;
            set;
        }
        public string Subject
        {
            get;
            set;
        }
        public string Body
        {
            get;
            set;
        }
    }
}
