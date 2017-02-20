using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace Core.Common.Tests
{
    [TestClass]
    public class ObjectBaseTest
    {
        [TestMethod]
        public void test_clean_property_change()
        {
            TestClass obj = new TestClass();
            bool propChanged = false;

            obj.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName.Equals("CleanProp"))
                {
                    propChanged = true;
                }
            };

            obj.CleanProp = "Test Value";

            Assert.IsTrue(propChanged, "Property should have triggered change notification");
        }

        [TestMethod]
        public void test_clean_state()
        {
            TestClass obj = new TestClass();
            Assert.IsFalse(obj.IsDirty, "Object should be clean");
        }

        [TestMethod]
        public void test_dirty_state()
        {
            TestClass obj = new TestClass();
            obj.CleanProp = "Test Value";
            Assert.IsTrue(obj.IsDirty, "Object should be dirty");
        }

        [TestMethod]
        public void test_property_change_single_subscription()
        {
            TestClass obj = new TestClass();
            int changeCounter = 0;
            PropertyChangedEventHandler handler1 = new PropertyChangedEventHandler((s, e) => { changeCounter++; });
            PropertyChangedEventHandler handler2 = new PropertyChangedEventHandler((s, e) => { changeCounter++; });

            obj.PropertyChanged += handler1;
            obj.PropertyChanged += handler1;
            obj.PropertyChanged += handler1;

            obj.PropertyChanged += handler2;
            obj.PropertyChanged += handler2;
            obj.PropertyChanged += handler2;

            obj.CleanProp = "Test Value";

            Assert.IsTrue(changeCounter == 2, "Handler should only have subscribed twice");
        }
    }
}
