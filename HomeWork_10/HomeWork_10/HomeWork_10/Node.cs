using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10
{
    public class Node<T>
    {
        public T Value;
        public Node<T>? NextNode { get; set; }

    }
}
