using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: two items with the same priority are enqueued
    // Expected Result: the first item enqueued should be dequeued first
    // Defect(s) Found: old code removed the last item when priorities were equal due to >= comparison
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: the highest priority item is at the end of the queue
    // Expected Result: the item with the highest priority should be dequeued
    // Defect(s) Found: old code skipped the last item due to incorrect loop condition
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario:Dequeue is called twice after adding multiple items
    // Expected Result: Each dequeue should remove an item from the queue
    // Defect(s) Found: Old code did not remove the item from the queue
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 2);

        var firstResult = priorityQueue.Dequeue();
        var secondResult = priorityQueue.Dequeue();

        Assert.AreNotEqual(firstResult, secondResult);
    }

    [TestMethod]
    // Scenario: dequeue is called on an empty queue
    // Expected Result: an InvalidOperationException with the correct message is thrown
    // Defect(s) Found: none
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
