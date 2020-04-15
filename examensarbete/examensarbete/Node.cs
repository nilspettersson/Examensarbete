using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examensarbete
{
    class Node
    {
        private string id;

        public Node()
        {
            id = createUniqueId();
        }


        public string createUniqueId()
        {
            return Guid.NewGuid().ToString("N");
        }

        public void setId(string id)
        {
            this.id = id;
        }
        public string getId()
        {
            return id;
        }
    }
}
