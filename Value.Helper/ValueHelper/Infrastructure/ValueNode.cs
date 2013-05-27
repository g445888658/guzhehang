using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.Infrastructure
{
    public abstract class ValueNode<T>
    {
        public String Text { get; set; }

        public String Value { get; set; }

        private IList<T> nodes;
        public IList<T> Nodes
        {
            get
            {
                return nodes;
            }
            set
            {
                if (nodes == null)
                    nodes = new List<T>();
                nodes = value;
            }
        }
    }
}
