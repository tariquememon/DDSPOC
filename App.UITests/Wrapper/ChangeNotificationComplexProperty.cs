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
    public class ChangeNotificationComplexProperty
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
        public void ShouldInitializeAddressProperty()
        {
            var wrapper = new PersonWrapper(_person);
            Assert.IsNotNull(wrapper.Address);
            Assert.AreEqual(_person.Address, wrapper.Address.Model);
        }
    }
}
