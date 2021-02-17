using OOPProject.Db.Objects;

namespace OOPProject.Models.Interfaces
{
    public interface IUserModel
    {
        Response<User> EditUser(User user, string password, string name);
    }
}
