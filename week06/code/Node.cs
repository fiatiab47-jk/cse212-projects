public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        // Rejects Duplicates, if the value already exists, do nothing
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Search for a value recursively
        // Base case: we found the value at the current node, return true.
        if (value == Data)
            return true;

            // The value is small search the left subtree
        if (value < Data)
        {
            // Base case: no left child means the value is not in the tree
            if (Left is null)
                return false;
            // Recursive case: keep searching down the left subtree
            return Left.Contains(value);
        }
        else
        {
            // The value os larger, so  search the right subtree
            // Base case: no right child means the value is not in the tree
            if (Right is null)
                return false;

            // Recursive case: keep searching down the right subtree
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // Assume both subtree heights start at 0
        int leftHeight = 0;
        int rightHeight = 0;

        // Check if there is a Left child 
        if (Left != null)
        {
            // Ask the Left child; hey!, how tall is your subtree?
            leftHeight = Left.GetHeight();
        }
        // Check if there is a Right child 
        if (Right != null)
        {
            // Ask the Right child; hey!, how tall is your subtree?
            leftHeight = Right.GetHeight();
        }

        // Figure out which subtree is taller
        int tallerSubtreeHeight;

        if (leftHeight > rightHeight)
            tallerSubtreeHeight = leftHeight;
        else
            tallerSubtreeHeight = rightHeight;

        // Add 1 for the current node, because heights counts this node too. 
        int totalHeight = 1 + tallerSubtreeHeight;
        
        // Return the final height
        return totalHeight; // Replace this line with the correct return statement(s)
    }
}