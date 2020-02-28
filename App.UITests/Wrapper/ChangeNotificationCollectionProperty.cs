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
    public class ChangeNotificationCollectionProperty
    {
        private Person _person;
        private Email _email;

        [TestInitialize]
        public void Initialize()
        {
            _email = new Email { EmailAddress = "email2@gmail.com" };
            _person = new Person
            {
                Name = "Tarique Memon",
                Address = new Address(),
                Emails = new List<Email>
                {
                    new Email { EmailAddress="email1@gmail.com"},
                    _email
                }
            };
        }

        [TestMethod]
        public void ShouldInitializeEmailsProperty()
        {
            var wrapper = new PersonWrapper(_person);
            Assert.IsNotNull(wrapper.Emails);
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterAddingEmail()
        {
            _person.Emails.Remove(_email);
            var wrapper = new PersonWrapper(_person);
            wrapper.Emails.Add(new EmailWrapper(_email));
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterRemovingEmail()
        {   
            var wrapper = new PersonWrapper(_person);
            var emailToRemove = wrapper.Emails.Single(ew => ew.Model == _email);
            wrapper.Emails.Remove(emailToRemove);
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }

        [TestMethod]
        public void ShouldBeInSyncAfterClearingEmails()
        {
            var wrapper = new PersonWrapper(_person);
            wrapper.Emails.Clear();
            CheckIfModelEmailsCollectionIsInSync(wrapper);
        }


        private void CheckIfModelEmailsCollectionIsInSync(PersonWrapper wrapper)
        {
            Assert.AreEqual(_person.Emails.Count, wrapper.Emails.Count);
            Assert.IsTrue(_person.Emails.All(e => wrapper.Emails.Any(we => we.Model == e)));
        }
    }
}
