using Microsoft.AspNetCore.Mvc;
using Contact_Manager.Data;
using Contact_Manager.Models;

namespace Contact_Manager.Controllers
{
    public class HolderController : Controller
    {
        ContactsData _contactDataProvider = new ContactsData();

        // Get all contact from the database using models file
        public IActionResult GetContacts()
        {
            var oListContacts = _contactDataProvider.GetAllContacs();

            return View(oListContacts);
        }
        
        // Save contact in the database using models file (this methosd just return a view)
        public IActionResult SaveContact()
        {
            return View();
        }

        // Save contact in the databse but using an object (this method jus return an object)
        [HttpPost]
        public IActionResult SaveContact(ContactsModel oContact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var results = _contactDataProvider.SaveContact(oContact);

            if (results)
            {
                return RedirectToAction("GetContacts");

            }else
            {
                return View();

            }

        }

        public IActionResult EditContact(int ContactID)
        {
            var results = _contactDataProvider.GetContacByID(ContactID);
            return View(results);
        }

        // Edit contact in the databse but using an object (this method jus return an object)
        [HttpPost]
        public IActionResult EditContact(ContactsModel oContact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var results = _contactDataProvider.EditContact(oContact);

            if (results)
            {
                return RedirectToAction("GetContacts");

            }
            else
            {
                return View();

            }
        }

        public IActionResult DeleteContact(int ContactID)
        {
            var results = _contactDataProvider.GetContacByID(ContactID);
            return View(results);
        }

        // Edit contact in the databse but using an object (this method jus return an object)
        [HttpPost]
        public IActionResult DeleteContact(ContactsModel oContact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var results = _contactDataProvider.DeleteContact(oContact.ContactID);

            if (results)
            {
                return RedirectToAction("GetContacts");

            }
            else
            {
                return View();

            }
        }
    }
}
