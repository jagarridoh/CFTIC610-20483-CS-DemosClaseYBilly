using System;
using System.Collections;
using System.Collections.Generic;

namespace _11Collection
{
    // IComparable, IEmployee
    //IEnumerable<string>, IEmployee,struct,class
    public class GenericList<T> where T : IEmployee
    {
        private class Node
        {
            public Node(T t) => (Next, Data) = (null, t);

            public Node Next { get; set; }
            public T Data { get; set; }
        }

        private Node head;

        public void AddHead(T t)
        {
            Node n = new Node(t) { Next = head };
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T FindFirstOccurrence(string s)
        {
            Node current = head;
            //T t = null;
            T t = default(T);

            while (current != null)
            {
                //The constraint enables access to the Name property.
                if (current.Data.Name == s)
                {
                    t = current.Data;
                    break;
                }
                else
                {
                    current = current.Next;
                }
            }
            return t;
        }
    }

    public interface IEmployee
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class Employee : IEmployee, IComparable
    {
        public Employee() { }
        public Employee(string name, int id) => (Name, ID) = (name, id); // Constructor
        public string Name { get; set; }
        public int ID { get; set; }
        public int CompareTo(object obj)
        {
            Employee employee = (Employee)obj;
            return string.Compare(this.Name, employee.Name);
        }
    }

    public struct EmployeeOfMonth
    {

        public EmployeeOfMonth(string name, int id) => (Name, ID) = (name, id); // Constructor
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class EmployeeOfYear : IEmployee, IEnumerable<string>
    {
        public EmployeeOfYear(string name) => Name = name;
        public EmployeeOfYear(string name, int id) => (Name, ID) = (name, id); // Constructor

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID { get; set; }
        public int CompareTo(object obj)
        {
            Employee employee = (Employee)obj;
            return string.Compare(this.Name, employee.Name);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new EmployeeEnumerator(name);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }
    }

    public class EmployeeEnumerator : IEnumerator<string>
    {
        private string name;
        public EmployeeEnumerator(string name) => name = this.name;

        private string current;
        public string Current
        {
            get
            {
                if (name == null || current == null)
                    throw new InvalidOperationException();
                return name;
            }
        }

        private object current1;
        object IEnumerator.Current
        {
            get { return current1; }
        }

        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Redeclaracion del método dispose "usando virtual"
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose of managed resources here
                }
                name = null;
            }
            this.disposedValue = true;
        }

        public bool MoveNext()
        {
            if (current == null)
                return false;
            return true;
        }

        public void Reset()
        {
            name = null;
        }
        ~EmployeeEnumerator()
        {
            Dispose(false);
        }
    }

    public class EmployeeOfCountry : IEmployee
    {
        public string Name { get ; set ; }
        public int ID { get; set ; }
    }

    public class EmployeeOfContinent : IEnumerable<string>
    {
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}