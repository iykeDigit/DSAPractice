using System;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode list = new ListNode();
            // list.InsertAtTail(1,list);
            list.InsertAtTail(1, list);
            list.InsertAtTail(2, list);
            list.InsertAtTail(3, list);
            list.InsertAtTail(4, list);
            list.ReverseList(list);
            
            Console.WriteLine("Hello World!");
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public ListNode ReverseList(ListNode head)
            {
                ListNode curr = head;
                ListNode prev = null;
                while (curr != null)
                {
                    ListNode temp = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = temp;
                }
                return prev;
            }

            public ListNode InsertAtTail(int val, ListNode head)
            {
                var last = head;
                var node = new ListNode(val);
                while(last.next != null)
                {
                    last = last.next;
                }
                node.next = null;
                last.next = node;

                return head.next;
            }
        }
    }
}
