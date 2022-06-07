using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace praktuchna_1
{
    enum KeyResult
    {
        OK, ERROR
    }

    enum ManagerState
    {
        WAITING, PROCESS, FINISHED 
    }
    class InputManager
    {
        private Stopwatch watch;
        private string testWord;
        private int wordSize;
        private int count;
        private double[] results;
        private ManagerState state;
        public InputManager(string testWord)
        {
            watch = new Stopwatch();
            cancel(testWord);
        }
        public String getTypedText() => testWord.Substring(0, count);

        public double[] getResult()
        {
            int size = results.Length;
            double[] copy = new double[size];
            for (int i = 0; i < size; i++) copy[i] = results[i];
            return copy;
        }

        public ManagerState getState() => state;

        public void cancel(string testWord)
        {
            watch.Stop();
            if (testWord.Length == 0)
            {
                throw new Exception("Invalid test word");
            }
            this.testWord = testWord;
            wordSize = testWord.Length;
            count = 0;
            results = new double[wordSize - 1];
            state = ManagerState.WAITING;
        }

        public KeyResult keyUp(string text)
        {
            if (isTextCorrect(text))
            {
                count++;
                if (count == 1)
                {
                    startTest();
                }
                else if (count == wordSize)
                {
                    endTest();
                }
                else
                {
                    continueTest();
                }
                return KeyResult.OK;
            }
            else
            {
                return KeyResult.ERROR;
            }
        }

        private bool isTextCorrect(string text)
        {
            if (state == ManagerState.FINISHED)
            {
                return false;
            }
            else
            {
                int newCount = count + 1;
                return text.Length == newCount && text.Substring(0, newCount) == testWord.Substring(0, newCount);
            }
        }

        private void startTest()
        {
            state = ManagerState.PROCESS;
            watch.Start();
        }

        private void endTest()
        {
            getTime();
            state = ManagerState.FINISHED;
        }

        private void continueTest()
        {
            getTime();
            watch.Start();
        }
        private void getTime()
        {
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            results[count - 2] = ts.TotalSeconds;
        }
    }
}
