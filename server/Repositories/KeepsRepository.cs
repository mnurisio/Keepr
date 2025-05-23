



namespace keepr.Repositories;

public class KeepsRepository
{

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;

    internal Keep CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO
        keeps(name, description, img, creator_id)
        VALUES(@name, @description, @img, @creatorId);
        
        SELECT
        keeps.*,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creator_id
        WHERE keeps.id = LAST_INSERT_ID();";

        Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }, keepData).SingleOrDefault();

        return keep;
    }

    internal List<Keep> GetAllKeeps()
    {
        string sql = @"
        SELECT
        kept_count_view.*,
        accounts.*
        FROM kept_count_view
        JOIN accounts ON accounts.id = kept_count_view.creator_id
        ORDER BY kept_count_view.created_at ASC;";

        List<Keep> keeps = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }).ToList();

        return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
        string sql = @"
        SELECT
        kept_count_view.*,
        accounts.*
        FROM kept_count_view
        JOIN accounts ON accounts.id = kept_count_view.creator_id
        WHERE kept_count_view.id = @keepId;";

        Keep keep = _db.Query(sql, (Keep keep, Profile account) =>
        {
            keep.Creator = account;
            return keep;
        }, new { keepId }).SingleOrDefault();

        return keep;
    }

    internal void UpdateKeep(Keep updateData)
    {
        string sql = @"
        UPDATE keeps
        SET
        name = @Name,
        description = @Description
        WHERE id = @Id LIMIT 1;";


        int rowsAffected = _db.Execute(sql, updateData);

        if (rowsAffected == 0) throw new Exception("UPDATE DID NOT AFFECT ANY ROWS");
        if (rowsAffected > 1) throw new Exception("UPDATE AFFECTED TOO MANY ROWS");
    }

    internal void DeleteKeep(int keepId)
    {
        string sql = @"DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { keepId });

        if (rowsAffected == 0) throw new Exception("DELETE DID NOT AFFECT ANY ROWS");
        if (rowsAffected > 1) throw new Exception("DELETE AFFECTED TOO MANY ROWS");

    }

    internal void IncrementViews(Keep keep)
    {
        string sql = @"
        UPDATE keeps
        SET views = @Views
        Where id = @Id
        LIMIT 1;";

        int rowsAffected = _db.Execute(sql, keep);

        if (rowsAffected == 0) throw new Exception("INCREMENT DID NOT AFFECT ANY ROWS");
        if (rowsAffected > 1) throw new Exception("INCREMENT AFFECTED TOO MANY ROWS");

    }

    internal List<Keep> GetProfileKeeps(string profileId)
    {
        string sql = @"
        SELECT
        keeps.*,
        profile_view.*
        FROM keeps
        JOIN profile_view ON profile_view.id = keeps.creator_id
        WHERE profile_view.id = @profileId;";

        List<Keep> keeps = _db.Query(sql, (Keep keeps, Profile account) =>
        {
            keeps.Creator = account;
            return keeps;
        }, new {profileId}).ToList();

        return keeps;
    }
}