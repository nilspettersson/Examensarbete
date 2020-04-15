using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examensarbete
{
    class NodeA: Node
    {

        private string[] children;

        public NodeA()
        {
            children = new string[] { };
        }

        public void setChildren(string[] children)
        {
            this.children = children;
        }
        public string[] getChildren()
        {
            return children;
        }

    }
}
