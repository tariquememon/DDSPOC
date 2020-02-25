using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPF.UI.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model;

namespace WPF.UI.Wrapper.Tests
{
    [TestClass()]
    public class BasicTests
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

        [TestMethod()]
        public void ShouldContainModelInModelProperty()
        {
            var wrapper = new PersonWrapper(_person);
            Assert.AreEqual(_person, wrapper.Model);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowArgumentNullExceptionIfModelIsNull()
        {
            try
            {
                var wrapper = new PersonWrapper(null);
            }
            catch(ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfAddressIsNull()
        {
            try
            {
                _person.Address = null;
                var wrapper = new PersonWrapper(_person);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Address cannot be null", ex.ParamName);
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowArgumentExceptionIfEmailsCollectionIsNull()
        {
            try
            {
                _person.Emails = null;
                var wrapper = new PersonWrapper(_person);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Emails cannot be null", ex.ParamName);
                throw;
            }
        }

        [TestMethod()]
        public void ShouldSetValueOfTheUnderlyingProperty()
        {
            var wrapper = new PersonWrapper(_person);

            wrapper.Name = "John Memon";
            Assert.AreEqual("John Memon", _person.Name);
        }

        [TestMethod()]
        public void ShouldGetValueOfTheUnderlyingProperty()
        {
            var wrapper = new PersonWrapper(_person);
            Assert.AreEqual(_person.Name, wrapper.Name);
        }
    }
}