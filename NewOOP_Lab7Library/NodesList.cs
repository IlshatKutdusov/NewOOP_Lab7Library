using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewOOP_Lab7Library
{
    public class NodesList<Types> : IEnumerable<Types>
    {
        private Node<Types> head;
        private Node<Types> tail;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public Types Last
        {
            get
            {
                return tail.Data;
            }
        }

        public Types this[int index]
        {
            get
            {
                if (index < 0 || index > count - 1) throw new ArgumentOutOfRangeException();
                Node<Types> current = head;
                for (int i = 0; i < index; i++)
                {
                    if (current.Next == null) throw new ArgumentOutOfRangeException();
                    current = current.Next;
                }
                return current.Data;
            }
            set
            {
                if (index < 0 || index > count - 1) throw new ArgumentOutOfRangeException();
                Node<Types> current = head;
                for (int i = 0; i < index; i++)
                {
                    if (current.Next == null) throw new ArgumentOutOfRangeException();
                    current = current.Next;
                }
                current.Data = value;
            }
        }

        public void Add(Types data)
        {
            Node<Types> node = new Node<Types>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }
        public bool Remove(Types data)
        {
            Node<Types> current = head;
            Node<Types> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null) tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null) tail = null;
                    }
                    previous = current;
                    current = current.Next;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<Types> IEnumerable<Types>.GetEnumerator()
        {
            Node<Types> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
