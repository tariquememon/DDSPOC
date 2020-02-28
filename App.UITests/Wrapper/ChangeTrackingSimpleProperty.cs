using App.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.UI.Wrapper;

namespace App.UITests.Wrapper
{
    [TestClass]
    public class ChangeTrackingSimpleProperty
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
        public void ShouldStoreOriginalValue()
        {
            var wrapper = new PersonWrapper(_person);
            Assert.AreEqual("Tarique Memon", wrapper.NameOriginalValue);

            wrapper.Name = "Nik";
            Assert.AreEqual("Tarique Memon", wrapper.NameOriginalValue);
        }

        [TestMethod]
        public void ShouldSetIsChanged()
        {
            var wrapper = new PersonWrapper(_person);
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);

            wrapper.Name = "Zuhur";
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.Name = "Tarique Memon";
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForNameIsChanged()
        {
            var fired = false;
            var wrapper = new PersonWrapper(_person);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.NameIsChanged))
                {
                    fired = true;
                }
            };
            wrapper.Name = "John Memon";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChanged()
        {
            var fired = false;
            var wrapper = new PersonWrapper(_person);
            wrapper.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(wrapper.IsChanged))
                {
                    fired = true;
                }
            };
            wrapper.Name = "John Memon";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new PersonWrapper(_person);
            wrapper.Name = "Nik";

            Assert.AreEqual("Nik", wrapper.Name);
            Assert.AreEqual("Tarique Memon", wrapper.NameOriginalValue);
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.AcceptChanges();

            Assert.AreEqual("Nik", wrapper.Name);
            Assert.AreEqual("Nik", wrapper.NameOriginalValue);
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new PersonWrapper(_person);
            wrapper.Name = "Nik";

            Assert.AreEqual("Nik", wrapper.Name);
            Assert.AreEqual("Tarique Memon", wrapper.NameOriginalValue);
            Assert.IsTrue(wrapper.NameIsChanged);
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.RejectChanges();

            Assert.AreEqual("Tarique Memon", wrapper.Name);
            Assert.AreEqual("Tarique Memon", wrapper.NameOriginalValue);
            Assert.IsFalse(wrapper.NameIsChanged);
            Assert.IsFalse(wrapper.IsChanged);
        }
    }
}
