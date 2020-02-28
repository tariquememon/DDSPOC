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
    public class ChangeTrackingComplexProperty
    {
        private Person _person;

        [TestInitialize]
        public void Initialize()
        {
            _person = new Person
            {
                Name = "Tarique Memon",
                Address = new Address { StreetName = "ChemCentre, Perth" },
                Emails = new List<Email>()
            };
        }

        [TestMethod]
        public void ShouldSetIsChangedOfPersonWrapper()
        {
            var wrapper = new PersonWrapper(_person);
            wrapper.Address.StreetName = "XYZ";
            Assert.IsTrue(wrapper.IsChanged);

            wrapper.Address.StreetName = "ChemCentre, Perth";
            Assert.IsFalse(wrapper.IsChanged);
        }

        [TestMethod]
        public void ShouldRaisePropertyChangedEventForIsChangedPropertyOfPeopleWrapper()
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

            wrapper.Address.StreetName = "XYZ";
            Assert.IsTrue(fired);
        }

        [TestMethod]
        public void ShouldAcceptChanges()
        {
            var wrapper = new PersonWrapper(_person);
            wrapper.Address.StreetName = "XYZ";
            Assert.AreEqual("ChemCentre, Perth", wrapper.Address.StreetNameOriginalValue);

            wrapper.AcceptChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual("XYZ", wrapper.Address.StreetName);
            Assert.AreEqual("XYZ", wrapper.Address.StreetNameOriginalValue);
        }

        [TestMethod]
        public void ShouldRejectChanges()
        {
            var wrapper = new PersonWrapper(_person);
            wrapper.Address.StreetName = "XYZ";
            Assert.AreEqual("ChemCentre, Perth", wrapper.Address.StreetNameOriginalValue);

            wrapper.RejectChanges();

            Assert.IsFalse(wrapper.IsChanged);
            Assert.AreEqual("ChemCentre, Perth", wrapper.Address.StreetName);
            Assert.AreEqual("ChemCentre, Perth", wrapper.Address.StreetNameOriginalValue);
        }
    }
}
