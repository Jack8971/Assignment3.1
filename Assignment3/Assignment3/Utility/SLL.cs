using System;

namespace Assignment3
{
    public class SLL : ILinkedListADT
    {
        private class Node
        {
            public User Data { get; set; }
            public Node Next { get; set; }

            public Node(User data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;
        private int size;

        public SLL()
        {
            head = null;
            size = 0;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > size)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = head;

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;
                current.Next = newNode;
                size++;
            }
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value)
            {
                Next = head
            };
            head = newNode;
            size++;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            size++;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        public int Count() => size;

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(value))
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }

        public bool Contains(User value) => IndexOf(value) != -1;

        public bool IsEmpty() => size == 0;

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                current.Next = current.Next?.Next;
                size--;
            }
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List is empty.");

            head = head.Next;
            size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("List is empty.");

            if (size == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }

                current.Next = null;
            }
            size--;
        }

        // reverse
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
        }
    }
}
