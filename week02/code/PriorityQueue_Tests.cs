using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three different priorities to the queue.
    // Expected Result: Dequeue method should return the item with the highest priority.
    // Defect(s) Found: The Loop that searched for the highest priority item did not check the last element.
    // The Dequeue method returned the value but did not remove the item form the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }


    [TestMethod]
    // Scenario: Add several items with the same priority
    // Expected Result: Items should be dequeued in First in First out order.
    // Defect(s) Found: The comparison used >= instead of > which caused the last item with the priority
    // to be dequeued instead of maintaining FIFO order 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Add several items with mixed priorities
    // Expected Result: Items should be dequeued in First in First out order.
    // Defect(s) Found: The comparison used >= instead of > which caused the last item with the priority
    // to be dequeued instead of maintaining FIFO order 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 6);
        priorityQueue.Enqueue("D", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue form an empty queue
    // Expected Result: InvalidOperationException should be thrown with message "The queue is empty."
    // Defects found:
    // None; The exception handling worked as expected.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
        }
    }
}