using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examensarbete
{
    class NodeB:Node
    {

        private NodeB[] children;

        public NodeB()
        {
            children = new NodeB[] { };
        }

        public NodeB[] getChildren()
        {
            return children;
        }

        public void setChildren(NodeB[] children)
        {
            this.children = children;
        }

    }
}
