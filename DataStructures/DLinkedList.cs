using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class DLinkedList<T>
    { 
        private DLinkedListNode<T> _firstNode;
        private DLinkedListNode<T> _lastNode;
        private int _count;

        public DLinkedListNode<T> Head { get; set; }
         
        public int Count
        {
            get
            {
                DLinkedListNode<T> currentNode;
                if (Head == null)
                {
                    _count = 0;
                }
                else if (_count == 0)
                {
                    currentNode = Head;
                    while (currentNode.Next != Head)
                    {
                        _count++;
                        currentNode = currentNode.Next;
                    }
                }
                return _count;
            }
        }

        public DLinkedListNode<T> LastNode
        {
            get
            {
                DLinkedListNode<T> currentNode;
                if (_lastNode == null)
                {
                    if (Head != null)
                    {
                        currentNode = Head;
                        while (currentNode.Next != Head)
                        {
                            currentNode = currentNode.Next;
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

        public void PrependNode(DLinkedListNode<T> newNode)
        {
            if (Head == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                newNode.Next = _firstNode;
                newNode.Previous = _firstNode.Previous;
                _firstNode = newNode;
            }
        }

        public void AppendNode(DLinkedListNode<T> newNode)
        {
            if (Head == null)
            {
                _firstNode = _lastNode = newNode;
            }
            else
            {
                newNode.Next = _firstNode;
                newNode.Previous = _firstNode.Previous;
                _firstNode.Previous = newNode;
            }
        }

        public void InsertNewNode(DLinkedListNode<T> newNode, int index)
        {
            int currentIndex = 0;
            DLinkedListNode<T> currentNode;
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
                while (currentNode.Next != Head)
                {
                    if (currentIndex == index)
                    {
                        var p = currentNode.Next;
                        currentNode.Next = newNode;
                        newNode.Previous = currentNode; 
                        newNode.Next = p;
                        p.Previous = newNode;
                    }
                    currentIndex++;
                    currentNode = currentNode.Next;
                }
            }
        }

        public DLinkedListNode<T> GetItem(int index)
        {
            DLinkedListNode<T> node;
            DLinkedListNode<T> currentNode;
            if (Head == null)
            {
                return null;
            }
            else if (index < 0 || index > Count)
            {
                throw new Exception("Index out of bounds");
            }
            else if (index == 0)
            {
                return _firstNode;
            }
            else if (index == _count - 1)
            {
                return _lastNode;
            }
            else
            {
                int i = 1;
                currentNode = Head.Next;
                while (i <= index)
                {
                    currentNode = currentNode.Next;
                    i++;
                }
                return currentNode;
            }
        }

        public void DeleteNode(int index)
        {
            DLinkedListNode<T> node;
            DLinkedListNode<T> currentNode;
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
                currentNode = Head.Next;
                _firstNode = currentNode;
                p = null;
                return;
            }
            else
            {
                int i = 1;
                currentNode = Head.Next;
                while (i <= index)
                {
                    var p = currentNode.Next;
                    currentNode = currentNode.Next.Next;
                    p.Data = default(T);
                    p.Next = null;
                }
                return;
            }
        }
    }
     
    public class DLinkedListNode<T>
    {
        public T Data { get; set; }
        
        public DLinkedListNode<T> Next { get; set; }
        public DLinkedListNode<T> Previous { get; set; }

        public DLinkedListNode(T value)
        {
            Data = value;
            Next = null;
            Previous = null;
        }

        public DLinkedListNode(T value, DLinkedListNode<T> nextNode, DLinkedListNode<T> prevNode)
        {
            Data = value;
            Next = nextNode;
            Previous = prevNode;
        }
    }
}
