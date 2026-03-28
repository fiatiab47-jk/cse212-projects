using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        Node newNode = new(value);
        // If the list is empty, point both head and tail to the new node
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If not empty, only tail is affected
        else
        {
            newNode.Prev = _tail;   // Connect new node to the previous tail
            _tail.Next = newNode;   // Connect previous tail to the new node
            _tail = newNode;        // Update th tail to point to the new node
        }
        
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If more than one item, only tail is affected
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null;   // Disconnect second-to-last node from the tail
            _tail = _tail.Prev;        // Update the tail to the second-to-last node

        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // Start searching from the head of the list
        Node? curr = _head;
        // Keep going until we reach the end of the list (null)
        while (curr is not null)
        {
            // Check if the current node holds the value wee want to remove
            if (curr.Data == value)
            {
                if (curr == _head)
                {
                    // Reuse of existing logic to remove head node if equal to value
                    RemoveHead();
                }
                else if (curr == _tail)
                {
                    // Reuse of existing logic to remove tail node if equal to value
                    RemoveTail();
                }
                else
                {
                    /* Tell the node before curr to skip over curr and 
                    point directly to the node after curr*/
                    curr.Prev!.Next = curr.Next;

                    /* Tell the node after curr to skip over curr and 
                    point directly to the node before curr*/
                    curr.Next!.Prev = curr.Prev;
                }
                // Stop after first match and delete the first occurrence
                return;
            }
            // If no match yet move forward to the next node 
            curr = curr.Next;
        }
        /*If we reach here, the value was not found in the list, 
        nothing happens, no crash, just a silent exit*/
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // Start searching from the head of the list
        Node? curr = _head;
        // Keep going until we reach the end of the list (null)
        while(curr is not null)
        {
            // Check if the current node holds the value we want to replace
            if (curr.Data == oldValue)
            {
                // If old value found, overwrite it with the new value
                curr.Data = newValue;
            }
            /* Move forward to the next node regardless of whether 
            we found a match or not, we need to check every node */ 
            curr = curr.Next;
        } 

    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // Start at the TAIL instead of the head 
        // Because we are going backwards through the list
        var curr = _tail;

        // keep going until we reach the beginning of the list (null)
        while (curr is not null)
        {

            yield return curr.Data; // replace this line with the correct yield return statement(s)

            // Move backward to the previous node Instead of the 
            // curr.Next (forward), we use curr.Prev (backward)
            curr = curr.Prev;
        }

    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}