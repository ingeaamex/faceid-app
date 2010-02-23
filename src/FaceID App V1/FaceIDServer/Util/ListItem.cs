using System;
using System.Collections.Generic;
using System.Text;

namespace FaceIDAppVBEta
{
    public class ListItem
    {
        public object Value { get; set; }
        public object Name { get; set; }

        public ListItem(object value)
        {
            this.Value = value;
            this.Name = value;
        }

        public ListItem(object value, object name)
        {
            this.Value = value;
            this.Name = name;
        }
    }
}
