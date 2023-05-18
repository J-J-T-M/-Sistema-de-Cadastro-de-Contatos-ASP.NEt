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
        public ContactModel Adding(ContactModel contact)
        {
            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges();
            
            return contact;
        }

        public List<ContactModel> GetAll()
        {
            return _bancoContext.Contacts.ToList();
        }
    }
}
