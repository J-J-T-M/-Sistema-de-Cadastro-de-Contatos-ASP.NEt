using FirstAppASP.NET.Models;

namespace FirstAppASP.NET.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();

        ContactModel GetById(int id);
        
        ContactModel Adding(ContactModel contact);
      
    }
}
