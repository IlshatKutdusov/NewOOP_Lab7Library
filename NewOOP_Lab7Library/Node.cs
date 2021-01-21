using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOOP_Lab7Library
{
    class Node<Types>
    {
        public Types Data { get; set; }

        public Node<Types> Next { get; set; }

        public Node(Types data)
        {
            Data = data;
        }
    }
}
