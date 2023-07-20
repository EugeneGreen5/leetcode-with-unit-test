// See https://aka.ms/new-console-template for more information
using PrimeService;

internal class Program
{
    private static void Main(string[] args)
    {

        PrimeService.PrimeService.ListNode oldHead = ConvertToLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        PrintLinkedList(oldHead);

        
        oldHead = PrimeService.PrimeService.OddEvenList(oldHead);

        PrintLinkedList(oldHead);

    }

    private static PrimeService.PrimeService.ListNode ConvertToLinkedList(int[] array)
    {
        PrimeService.PrimeService.ListNode head = new PrimeService.PrimeService.ListNode(array[0]);
        PrimeService.PrimeService.ListNode currentNode = head;
        PrimeService.PrimeService.ListNode newNode;
        for(int i = 1; i < array.Length; i++) { 
            newNode = new PrimeService.PrimeService.ListNode(array[i]);
            currentNode.next = newNode;
            currentNode = newNode;
        }

        return head;
    }

    private static void PrintLinkedList(PrimeService.PrimeService.ListNode head)
    {
        PrimeService.PrimeService.ListNode currentNode = head;
        while (currentNode is not null)
        {
            Console.Write(currentNode.val);
            currentNode = currentNode.next;
        }
        Console.WriteLine();
    }
}