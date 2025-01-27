

namespace keepr.Repositories;

public class ProfilesRepository
{

    public ProfilesRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;

    internal Profile GetProfileById(string id)
    {
        string sql = @"SELECT * FROM profile_view WHERE id = @id";
        return _db.Query<Profile>(sql, new { id }).SingleOrDefault();
    }

}