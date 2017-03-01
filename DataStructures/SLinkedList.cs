using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class SLinkedList<T>
    {

        private SLinkedListNode<T> _firstNode;
        private SLinkedListNode<T> _lastNode;
        private int _count;

        public SLinkedListNode<T> Head { get; set; } 

        public int Count
        {
            get
            {
                SLinkedListNode<T> currentNode;
                if (Head == null)
                {
                    _count = 0;
                }
                else if (_count == 0)
                { 
                    currentNode = Head; 
                    while (currentNode.next != null)
                    {
                        _count++;
                        currentNode = currentNode.next;
                    } 
                }
                return _count;
            }
        }

        public SLinkedListNode<T> LastNode
        {
            get
            {
                SLinkedListNode<T> currentNode;
                if(_lastNode == null)
                {
                    if (Head != null)
                    {
                        currentNode = Head;
                        while (currentNode.next != null)
                        {
                            currentNode = currentNode.next;
                        }
                        _lastNode = currentNode;
                    }
                    else
                    {
                        throw new Exception("Empty List");
                    }
                }
                return _lastNode;
            }
        }

        public void PrependNode(SLinkedListNode<T> newNode)
        {
            if (Head == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                newNode.next = _firstNode;
                _firstNode = newNode;
            }
        }

        public void AppendNode(SLinkedListNode<T> newNode)
        {
            if (_lastNode == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                _lastNode.next = newNode;
                newNode.next = null;
            }
        }

        public void InsertNewNode(SLinkedListNode<T> newNode, int index)
        {
            int currentIndex = 0;
            SLinkedListNode<T> currentNode;
            if (newNode == null)
            {
                return;
            }

            if (index == 0)
            {
                PrependNode(newNode);
            }
            else if (index == Count)
            {
                AppendNode(newNode);
            }                
            else if (Head == null)
            {
                Head = newNode = LastNode;
            }    
            else
            {
                currentNode = Head;
                while(currentNode.next != null)
                {
                    if (currentIndex == index)
                    {
                        var p = currentNode.next;
                        currentNode.next = newNode;
                        newNode.next = p;
                    }
                    currentIndex++;
                    currentNode = currentNode.next;
                }
            }                
        }

        public SLinkedListNode<T> GetItem(int index)
        {
            SLinkedListNode<T> node;
            SLinkedListNode<T> currentNode;
            if (Head == null)
            {
                return null;
            }
            else if(index < 0 || index > Count)
            {
                throw new Exception("Index out of bounds");
            }
            else if(index ==0)
            {
                return _firstNode;
            }
            else if (index == _count-1)
            {
                return _lastNode;
            }
            else
            {
                int i = 1;
                currentNode = Head.next;
                while(i <= index)
                { 
                    currentNode = currentNode.next;
                    i++;
                }
                return currentNode;
            }
        }

        public void DeleteNode(int index)
        {
            SLinkedListNode<T> node;
            SLinkedListNode<T> currentNode;
            if (Head == null)
            {
                return;
            }
            else if (index < 0 || index > Count)
            {
                throw new Exception("Index out of bounds");
            }
            else if (index == 0)
            {
                var p = Head;
                currentNode = Head.next;
                _firstNode = currentNode;
                p = null;
                return;
            } 
            else
            {
                int i = 1;
                currentNode = Head.next;
                while (i <= index)
                {
                    var p = currentNode.next; 
                    currentNode = currentNode.next.next;
                    p.data = default(T);
                    p.next = null;
                }
                return;
            }
        }
    }

    public class SLinkedListNode<T>
    {
        public T data { get; set; }
        public SLinkedListNode<T> next { get; set; }

        public SLinkedListNode(T value)
        {
            data = value;
        }

        public SLinkedListNode(T value, SLinkedListNode<T> nextNode)
        {
            data = value;
            next = nextNode;
        }
    }
}
