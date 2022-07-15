using BallisticCalculatorNet.InputPanels;
using System;
using System.Collections.Generic;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    internal class MockFileNamePromptFactory : IFileNamePromptFactory
    {
        private readonly Queue<MockFileNamePrompt> mQueue = new Queue<MockFileNamePrompt>();

        public void AddPrompt(MockFileNamePrompt prompt) => mQueue.Enqueue(prompt);

        public IFileNamePrompt CreateFileNamePrompt(bool savePrompt)
        {
            if (mQueue.Count == 0)
                throw new InvalidOperationException();
            else if (mQueue.Count == 1)
                return mQueue.Peek();
            else
                return mQueue.Dequeue();
        }
    }
}
