using Microsoft.EntityFrameworkCore;
using Project21API.ContextFolder;
using Project21API.Models;

namespace Project21API.Data
{
    public class Repository
    {
        private readonly DataContext context;
        public Repository(DataContext context)
        {
            this.context = context;
        }

        public void AddContacts(Contact contact)
        {
            using (var context = new DataContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }

        public IEnumerable<IContact> GetContacts()
        {
            return this.context.Contacts;
        }

        public async void DeleteContact(int id)
        {
            using(var context = new DataContext())
            {
                Contact contact = await context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IContact> GetContactByID(int Id) => ((IContact) await context.Contacts.FirstOrDefaultAsync(x => x.ID == Id));

        public async void ChangeContact(int id, Contact contact)
        {
            using (var context = new DataContext())
            {
                Contact concreteContact = await context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
                concreteContact.Name = contact.Name;
                concreteContact.Surname = contact.Surname;
                concreteContact.FatherName = contact.FatherName;
                concreteContact.TelephoneNumber = contact.TelephoneNumber;
                concreteContact.ResidenceAdress = contact.ResidenceAdress;
                concreteContact.Description = contact.Description;
                await context.SaveChangesAsync();
            }
        }

        public async Task<Contact> Details(int id)
        {
            IContact concreteContact = await GetContactByID(id);
            return (Contact)concreteContact;
        } 
    }
}
