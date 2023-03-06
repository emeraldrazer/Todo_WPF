using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TodoApp
{
    internal class Todo
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string DueDate { get; set; }
        public bool Finished { get; set; } 
    }
}
