using App.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WPF.UI.Wrapper;

namespace App.UITests.Wrapper
{
    [TestClass]
    public class ChangeTrackingCollectionProperty
    {
        private Person _person;

        [TestInitialize]
        public void Initialize()
        {
            _person = new Person
            {
                Name = "Tarique",
                Address = new Address(),
                Emails = new List<Email>
                {
                    new Email {EmailAddress = "abc@todo.com"},
                    new Email {EmailAddress = "xyz@todo.com"}
                }
            };
        }

        [TestMethod]
        public void ShouldSetIsChangedOfPersonWrapper()
        {
            var wrapper = new PersonWrapper(_person);
            var emailToModify = wrapper.Emails.First();
            emailToModify.EmailAddress = "modified@todo.com";

            Assert.IsTrue(wrapper.IsChanged);

            emailToModify.EmailAddress = "abc@todo.com";
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChangedPropertyOfPersonWrapper()
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

            wrapper.Emails.First().EmailAddress = "modified@todo.com";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new PersonWrapper(_person);

            var emailToModify = wrapper.Emails.First();
            emailToModify.EmailAddress = "modified@todo.com";

            Assert.IsTrue(wrapper.IsChanged);

            wrapper.AcceptChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual("modified@todo.com", emailToModify.EmailAddress);
            Assert.AreEqual("modified@todo.com", emailToModify.EmailAddressOriginalValue);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new PersonWrapper(_person);

            var emailToModify = wrapper.Emails.First();
            emailToModify.EmailAddress = "modified@todo.com";

            Assert.IsTrue(wrapper.IsChanged);

            wrapper.RejectChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual("abc@todo.com", emailToModify.EmailAddress);
            Assert.AreEqual("abc@todo.com", emailToModify.EmailAddressOriginalValue);
        }
    }
}
