using FirstAppASP.NET.Models;

namespace FirstAppASP.NET.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();
        ContactModel Adding(ContactModel contact);
    }
}
