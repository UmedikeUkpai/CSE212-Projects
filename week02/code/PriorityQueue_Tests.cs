using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue A (1), B (5), C (3), then dequeue three times.
    // Expected Result: B, C, A (highest priority first, and each item is removed once returned)
    // Defect(s) Found: Test failed. The first Dequeue returned B, but the second Dequeue returned B again instead of C. Dequeue never removed the item from the list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }


    [TestMethod]
    // Scenario: Enqueue A (1), B (2), C (9) so the highest priority is the last item.
    // Expected Result: C, B, A
    // Defect(s) Found: Test failed. Dequeue returned B instead of C. The loop condition (index < _queue.Count - 1) skipped the last item, so a high priority at the back of the queue was never considered.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

     [TestMethod]
    // Scenario: Enqueue A (5), B (5), C (1). A and B tie for the highest priority.
    // Expected Result: A, B, C (the tied item closest to the front is removed first)
    // Defect(s) Found: Test failed. Dequeue returned B instead of A. The comparison used >=,
    // so a later item with equal priority replaced the earlier one. It should use >.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue A (9), B (2), C (1) so the highest priority is the first item.
    // Expected Result: A, B, C
    // Defect(s) Found: Test failed. After returning A, the next Dequeue returned A again
    // instead of B, because the item was never removed from the queue.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 9);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue a single item A (1), dequeue it, then dequeue again.
    // Expected Result: The first Dequeue returns A. The second throws an
    // InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: Test failed. The second Dequeue returned A again instead of
    // throwing, because the item was never removed from the list.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());

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
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Dequeue from a brand new, empty queue.
    // Expected Result: InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: No defect found. The test passed. The empty check was already correct.
    public void TestPriorityQueue_6()
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
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }
}