using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.Image.Infrastructure
{
    public class Chain
    {
        private List<ChainNode> nodes;

        public Chain()
        {
            nodes = new List<ChainNode>();
        }

        public Int32 Length
        {
            get
            {
                return this.nodes.Count;
            }
        }

        public ChainNode this[Int32 index]
        {
            get
            {
                if (this.nodes.Count > index)
                    return this.nodes[index];
                return null;
            }
        }

        public Boolean AddNode(ChainNode node)
        {
            if (!exists(node))
            {
                nodes.Add(node);
                return true;
            }

            return false;
        }

        private Boolean exists(ChainNode node)
        {
            var nd = nodes.FirstOrDefault(x => x.X == node.X && x.Y == node.Y);
            return !(nd == null);
        }
    }


    public class ChainNode
    {
        public Int32 X { get; set; }

        public Int32 Y { get; set; }

        public Int32 Dir { get; set; }
    }
}
