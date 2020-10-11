namespace SchoolManager.Repositories
{
    using SchoolManager.Models;
    using SchoolManager.Repositories.Contracts;
    using System.Linq;

    public class SchoolRepository : Repository<School>
    {
        public School FindByName(string schoolName)
        {
            return this.GetAll().FirstOrDefault(x => x.Name.Equals(schoolName));
        }
    }
}
