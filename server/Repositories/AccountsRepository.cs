namespace keepr.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Account GetById(string id)
  {
    string sql = @"SELECT 
    accounts.id,
    accounts.cover_img,
    accounts.`createdAt`,
    accounts.name,
    accounts.picture,
    accounts.`updatedAt`
    FROM accounts WHERE id = @Id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Profile Edit(Profile update)
  {
    string sql = @"
            UPDATE profile_view
            SET 
              name = @Name,
              picture = @Picture,
              cover_img = @CoverImg
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }
}

