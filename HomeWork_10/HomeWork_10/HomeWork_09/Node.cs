using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HomeWork_09
{
    public class Node<T>
    {
        public T Value;
        public Node<T>? NextNode { get; set; }

    }
}
