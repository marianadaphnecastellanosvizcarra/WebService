using WebService.Models;

namespace WebService.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }


        public List<catpersonal> Getpersonal()
        {
            return _context.catpersonal.ToList();
        }

        public catpersonal GetpersonalById(int id)
        {
            return _context.catpersonal.FirstOrDefault(a => a.id == id);
        }

        public void Agregarpersonal(catpersonal personal )
        {
            _context.catpersonal.Add(personal);
            _context.SaveChanges();
        }
    }
}
