using FirstAppASP.NET.Data;
using FirstAppASP.NET.Models;

namespace FirstAppASP.NET.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BancoContext _bancoContext;

        public ContactRepository(BancoContext bancoContext) 
        { 
            _bancoContext = bancoContext;
        }

        public List<ContactModel> GetAll()
        {
            return _bancoContext.Contacts.ToList();
        }

        public ContactModel GetById(int id)
        {
            return _bancoContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public ContactModel Adding(ContactModel contact)
        {
            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges();
            
            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDB = GetById(contact.Id);

            if (contactDB == null) throw new Exception("Houve um erro na atualização do contato");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.CellPhone = contact.CellPhone;

            _bancoContext.Contacts.Update(contactDB);
            _bancoContext.SaveChanges();

            return contactDB;

        }

        public bool Destroy(int id)
        {
            ContactModel contactDB = GetById(id);

            if (contactDB == null) throw new Exception("Houve um erro na deleção do contato");

            _bancoContext.Contacts.Remove(contactDB);
            _bancoContext.SaveChanges();
            
            return true;
        }
    }
}
