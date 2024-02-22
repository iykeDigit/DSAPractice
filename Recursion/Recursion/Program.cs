// See https://aka.ms/new-console-template for more information

var arr = new int[] { 2, 3 };
var list = new ListNode(1);
for (int i = 0; i < arr.Length; i++)
{
    list.InsertAtTail(arr[i], list);
}

var res = list.ReverseList(list);
Console.WriteLine("Hello, World!");


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
        if (head == null || head.next == null) return head;
        ListNode prev = null;
        ListNode h2 = ReverseList(head.next);
        head.next.next = head;
        head.next = prev;
        return h2;
    }

    public ListNode InsertAtTail(int x, ListNode head)
    {
        var last = head;
        var node = new ListNode(x);

        while (last.next != null)
        {
            last = last.next;
        }

        last.next = node;
        return head;
    }
}
