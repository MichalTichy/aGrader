﻿#region

using System;
using System.Linq;
using System.Threading.Tasks;
using aGrader.sourceCodes;

#endregion

namespace aGrader
{
    public class ResultReadyArgs : EventArgs
    {
        public TestResult Result { get; set; }
    }
    public static class TestManager
    {
        public static event EventHandler<ResultReadyArgs> ResultReady;
        private static TestProtocol _protocol;
        public async static void TestAllSourceCodes()
        {
            _protocol = new TestProtocol();

            var testTasks= SourceCodes.GetSourceCodeFiles().Select(sourceCode => new Task<TestResult>(new TestC(sourceCode, _protocol).RunTest)).ToList();
            testTasks.ForEach(t=>t.Start());
            while (testTasks.Count>0)
            {
                Task<TestResult> firstFinishedTask = await Task.WhenAny(testTasks);
                testTasks.Remove(firstFinishedTask);
                TestResult result = await firstFinishedTask;
                OnResultReady(result);
            }
        }

        private static void OnResultReady(TestResult result)
        {
            if (ResultReady !=null)
            {
                ResultReady(typeof(TestManager),new ResultReadyArgs() {Result = result});
            }
        }
    }
}