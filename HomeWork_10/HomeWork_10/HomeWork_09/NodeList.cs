using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_09
{
    internal class NodeList<T>
    {
        private Node<T> _firstNode;
        private Node<T> _nowNode;
        public void AddNode(T value)
        {
            if (_firstNode == null)
            {
                _firstNode = new Node<T>();
                _firstNode.Value = value;
            }
            else
            {
                _nowNode = _firstNode;
                while (_nowNode.NextNode != null)
                {
                    _nowNode = _nowNode.NextNode;
                }
                _nowNode.NextNode = new Node<T>();
                _nowNode.NextNode.Value = value;
            }
        }
        public void ShowAllNodes()
        {
            if (_firstNode != null)
            {
                _nowNode = _firstNode;
                while (_nowNode != null)
                {
                    Console.WriteLine(_nowNode.Value);
                    _nowNode = _nowNode.NextNode;
                }
            }
            else
            {
                Console.WriteLine("Nodes is empty");
            }
        }
        public void DeletNode(T value)
        {
            Node<T> nodePrev = null;
            if (_firstNode != null)
            {
                _nowNode = _firstNode;
                while (_nowNode != null && _nowNode.NextNode != null)
                {
                    if (_nowNode.Value.Equals(value))
                    {
                        nodePrev.NextNode = _nowNode.NextNode;
                        _nowNode = _nowNode.NextNode;
                    }
                    else
                    {
                        nodePrev = _nowNode;
                        _nowNode = _nowNode.NextNode;
                    }
                }
            }
        }
        public void Clean ()
        {
            _firstNode = null;
        }
    }
}
