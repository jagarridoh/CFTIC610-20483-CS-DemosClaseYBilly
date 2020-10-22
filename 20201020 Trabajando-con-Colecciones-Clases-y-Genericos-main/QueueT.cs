using System;
using System.Collections.Generic;
using static System.Console;

namespace _11Collection
{
    class UsingQueueT
    {
        public void UsingQueueTList()
        {
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            // A queue can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                WriteLine(number);
            }

            WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
            WriteLine("Peek at next item to dequeue: {0}",
                numbers.Peek());
            WriteLine("Dequeuing '{0}'", numbers.Dequeue());

            // Create a copy of the queue, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

            WriteLine("\nContents of the first copy:");
            foreach (string number in queueCopy)
            {
                WriteLine(number);
            }

            // Create an array twice the size of the queue and copy the
            // elements of the queue, starting at the middle of the
            // array.
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second queue, using the constructor that accepts an
            // IEnumerable(Of T).
            Queue<string> queueCopy2 = new Queue<string>(array2);

            WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in queueCopy2)
            {
                WriteLine(number);
            }

            WriteLine("\nqueueCopy.Contains(\"four\") = {0}",
                queueCopy.Contains("four"));

            WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);
        }
    }

    /* This code example produces the following output:

    one
    two
    three
    four
    five

    Dequeuing 'one'
    Peek at next item to dequeue: two
    Dequeuing 'two'

    Contents of the copy:
    three
    four
    five

    Contents of the second copy, with duplicates and nulls:



    three
    four
    five

    queueCopy.Contains("four") = True

    queueCopy.Clear()

    queueCopy.Count = 0
     */
}