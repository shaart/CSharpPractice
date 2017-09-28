// https://metanit.com/sharp/interview/1.1.php
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpPractice.Code.TheoryTesting
{
    //q1
    public class A
    {
        public virtual void Foo()
        {
            Trace.WriteLine("Class A");
        }
    }

    //q1
    public class B : A
    {
        public override void Foo()
        {
            Trace.WriteLine("Class B");
        }
    }

    //q2
    public struct S : IDisposable
    {
        private bool dispose;
        public void Dispose()
        {
            dispose = true;
        }
        public bool GetDispose()
        {
            return dispose;
        }
    }

    //q6
    internal class LockProgramSample
    {
        private static Object syncObject = new Object();

        private static void Write()
        {
            Console.WriteLine(">>>Locking syncObject in Write");
            lock (syncObject)
            {
                Console.WriteLine(">>>Locked syncObject in Write");
                Console.WriteLine(">>>   test");
            }
            Console.WriteLine(">>>Unlocked syncObject in Write");
            Console.WriteLine(">>>Write() is completed");
        }

        public static void Main(object args)
        {
            Console.WriteLine("Locking syncObject in Main");
            lock (syncObject)
            {
                Console.WriteLine("Locked syncObject in Main");
                Console.WriteLine("Call Write() in Main");
                Write();
                Console.WriteLine("Write() is done at Main");
            }
            Console.WriteLine("Unlocked syncObject in Main");
        }
    }

    [TestClass()]
    public class Example
    {
        const string CATEGORY = "Theory Testing";

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void A_B_Classes()
        {
            //q1
            A obj = new A();        // Class A
            obj.Foo();              //

            //B obj1 = new A();     // Error
            //obj1.Foo();           //

            B obj2 = new B();
            obj2.Foo();             // Class B

            A obj3 = new B();
            obj3.Foo();             // Class B

            Assert.IsTrue(1 > 0);
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Using_and_Dispose()
        {
            //q2
            Trace.WriteLine("var s = new S()");
            var s = new S();
            using (s)
            {
                Trace.WriteLine(s.GetDispose());    // False
            }
            Trace.WriteLine(s.GetDispose());        // False
            s.Dispose();
            Trace.WriteLine(s.GetDispose());        // True

            Trace.WriteLine("Using d = new S()");
            using (var d = new S())
            {
                Trace.WriteLine(d.GetDispose());    // False
            }
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void ListAction()
        {
            //q3
            Console.WriteLine("=== 1 ===");
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 10; count++)
            {
                actions.Add(() => Console.WriteLine(count));
            }
            foreach (var action in actions)
            {
                action(); // 10 10 10 10 ... = "10" x10
            }
            Console.WriteLine("=== 2 ===");
            actions.Clear();
            for (var count = 0; count < 10; count++)
            {
                int d = count;
                actions.Add(() => Console.WriteLine(d));
            }
            foreach (var action in actions)
            {
                action(); // 0 1 2 3 ... 9
            }
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Int_Object()
        {
            //q4
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i);               // 2
            Console.WriteLine(obj);             // 1
            //Console.WriteLine((short)obj);    // exception
            Console.WriteLine((int)obj);        // 1
            Console.WriteLine(obj.GetType());   // System.Int32            
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void String_Compare()
        {
            // q5
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            Console.WriteLine("{0} == {1}: {2}", s1, s2,
                s1 == s2);                                                  // True
            Console.WriteLine("{0} {1} == {2} {3}: {4}",
                ((object)s1).GetType(), (object)s1,                         // System.String abccba 
                ((object)s2).GetType(), (object)s2,                         // System.String abccba
                (object)s1 == (object)s2);                                  // False
            Console.WriteLine("{0} == {1}: {2}", s2, s3,
                s2 == s3);                                                  // True
            Console.WriteLine("{0} {1} == {2} {3}: {4}",
                ((object)s2).GetType(), (object)s2,                         // System.String abccba
                ((object)s3).GetType(), (object)s3,                         // System.String abccba                         
                (object)s2 == (object)s3);                                  // True
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Lock()
        {
            System.Threading.Thread _thread = new System.Threading.Thread(
                new System.Threading.ParameterizedThreadStart(LockProgramSample.Main));
            _thread.Start();
            bool _completed = _thread.Join(5000);
            if (_completed) { return; }
            else
            {
                _thread.Abort();
                Assert.Fail("Deadlock");
            }
            // Result: test
        }

        [TestMethod()]
        [TestCategory(CATEGORY)]
        public void Blank()
        {
            Assert.IsTrue(1 > 0);
        }
    }
}
