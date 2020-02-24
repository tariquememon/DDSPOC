using App.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WPF.UI.Wrapper;

namespace App.UITests.Wrapper
{
    [TestClass]
    public class ChangeNotificationSimpleProperty
    {
        Person _person;

        [TestInitialize]
        public void Initialize()
        {
            _person = new Person
            {
                Name = "Tarique Memon",
                Address = new Address(),
                Emails = new List<Email>()
            };
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventOnPropertyChange()
        {
            var fired = false;
            var wrapper = new PersonWrapper(_person);
            wrapper.PropertyChanged += (s, e) =>
            {
                if(e.PropertyName == "Name")
                {
                    fired = true;
                }
            };
            wrapper.Name = "John Memon";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldNotRaisePropertyChangedEventIfPropertyIsSetToSameValue()
        {
            var fired = false;
            var wrapper = new PersonWrapper(_person);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Name")
                {
                    fired = true;
                }
            };
            wrapper.Name = "Tarique Memon";
            Assert.IsFalse(fired);
        }
    }
}
