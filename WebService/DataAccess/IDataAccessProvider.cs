using WebService.Models;

namespace WebService.DataAccess
{
    public interface IDataAccessProvider
    {
        List<catpersonal> Getpersonal();
        catpersonal GetpersonalById(int id);
        void Agregarpersonal(catpersonal personal);
    }
}
