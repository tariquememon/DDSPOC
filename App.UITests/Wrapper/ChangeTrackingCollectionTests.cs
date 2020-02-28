using App.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WPF.UI.Wrapper;

namespace App.UITests.Wrapper
{
    [TestClass()]
    public class ChangeTrackingCollectionTests
    {
        private List<EmailWrapper> _emails;

        [TestInitialize]
        public void Initialize()
        {
            _emails = new List<EmailWrapper>
            {
                new EmailWrapper(new Email {EmailAddress = "abc@todo.com"}),
                new EmailWrapper(new Email {EmailAddress = "xyz@todo.com"})
            };
        }

        [TestMethod()]
        public void ShouldTrackAddedItems()
        {
            var emailToAdd = new EmailWrapper(new Email());

            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            c.Add(emailToAdd);
            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(1, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(emailToAdd, c.AddedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Remove(emailToAdd);
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod()]
        public void ShouldTrackRemoveditems()
        {
            var emailToRemove = _emails.First();
            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            c.Remove(emailToRemove);
            Assert.AreEqual(1, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(emailToRemove, c.RemovedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Add(emailToRemove);
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod()]
        public void ShouldTrackModifiedItems()
        {
            var emailToModify = _emails.First();
            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);
            Assert.AreEqual(2, c.Count);
            Assert.IsFalse(c.IsChanged);

            emailToModify.EmailAddress = "modified@todo.com";
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.IsTrue(c.IsChanged);

            emailToModify.EmailAddress = "abc@todo.com";
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod()] 
        public void ShouldNotTrackAddedItemsAsModified()
        {
            var emailToAdd = new EmailWrapper(new Email());

            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);
            c.Add(emailToAdd);
            emailToAdd.EmailAddress = "modified@todo.com";
            Assert.IsTrue(emailToAdd.IsChanged);
            Assert.AreEqual(3, c.Count);
            Assert.AreEqual(1, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.IsTrue(c.IsChanged);
        }

        [TestMethod()]
        public void ShouldNotTrackRemovedItemsAsModified()
        {
            var emailToModifyAndRemove = _emails.First();

            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);
            emailToModifyAndRemove.EmailAddress = "modified@todo.com";
            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.AreEqual(emailToModifyAndRemove, c.ModifiedItems.First());
            Assert.IsTrue(c.IsChanged);

            c.Remove(emailToModifyAndRemove);
            Assert.AreEqual(1, c.Count);
            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(emailToModifyAndRemove, c.RemovedItems.First());
            Assert.IsTrue(c.IsChanged);
        }

        [TestMethod()]
        public void ShouldAcceptChanges()
        {
            var emailToModify = _emails.First();
            var emailToRemove = _emails.Skip(1).First();
            var emailToAdd = new EmailWrapper(new Email { EmailAddress = "anotherOne@todo.com" });

            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);

            c.Add(emailToAdd);
            c.Remove(emailToRemove);
            emailToModify.EmailAddress = "modified@todo.com";
            Assert.AreEqual("abc@todo.com", emailToModify.EmailAddressOriginalValue);

            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(1, c.AddedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);

            c.AcceptChanges();

            Assert.AreEqual(2, c.Count);
            Assert.IsTrue(c.Contains(emailToModify));
            Assert.IsTrue(c.Contains(emailToAdd));

            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);

            Assert.IsFalse(emailToModify.IsChanged);
            Assert.AreEqual("modified@todo.com", emailToModify.EmailAddress);
            Assert.AreEqual("modified@todo.com", emailToModify.EmailAddressOriginalValue);

            Assert.IsFalse(c.IsChanged);
        }

        [TestMethod()]
        public void ShouldRejectChanges()
        {
            var emailToModify = _emails.First();
            var emailToRemove = _emails.Skip(1).First();
            var emailToAdd = new EmailWrapper(new Email { EmailAddress = "anotherOne@todo.com" });

            var c = new ChangeTrackingCollection<EmailWrapper>(_emails);

            c.Add(emailToAdd);
            c.Remove(emailToRemove);
            emailToModify.EmailAddress = "modified@todo.com";
            Assert.AreEqual("abc@todo.com", emailToModify.EmailAddressOriginalValue);

            Assert.AreEqual(2, c.Count);
            Assert.AreEqual(1, c.AddedItems.Count);
            Assert.AreEqual(1, c.ModifiedItems.Count);
            Assert.AreEqual(1, c.RemovedItems.Count);

            c.RejectChanges();

            Assert.AreEqual(2, c.Count);
            Assert.IsTrue(c.Contains(emailToModify));
            Assert.IsTrue(c.Contains(emailToRemove));

            Assert.AreEqual(0, c.AddedItems.Count);
            Assert.AreEqual(0, c.ModifiedItems.Count);
            Assert.AreEqual(0, c.RemovedItems.Count);

            Assert.IsFalse(emailToModify.IsChanged);
            Assert.AreEqual("abc@todo.com", emailToModify.EmailAddress);
            Assert.AreEqual("abc@todo.com", emailToModify.EmailAddressOriginalValue);

            Assert.IsFalse(c.IsChanged);
        }
    }
}
