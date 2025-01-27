CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) COMMENT 'User Name',
  email VARCHAR(255) UNIQUE COMMENT 'User Email',
  picture VARCHAR(255) COMMENT 'User Picture'
) default charset utf8mb4 COMMENT '';

ALTER TABLE accounts ADD COLUMN cover_img TEXT

ALTER TABLE accounts DROP COLUMN cover_img


CREATE VIEW profile_view AS
SELECT
accounts.id,
accounts.cover_img,
accounts.`createdAt`,
accounts.name,
accounts.picture,
accounts.`updatedAt`
FROM accounts



SELECT
        vault_keeps.*,
        profile_view.*,
        keeps.*,
        vaults.*
        FROM vault_keeps
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        JOIN keeps ON keeps.id = vault_keeps.keep_id
        JOIN vaults ON vaults.id = vault_keeps.vault_id
        WHERE vault_keeps.id = 1



SELECT
        vault_keeps.*,
        profile_view.*
        FROM vault_keeps
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        WHERE vault_keeps.id = 67

SELECT
        vault_keeps.*,
        keeps.*,
        profile_view.*
        FROM vault_keeps
        JOIN keeps ON keeps.id = vault_keeps.keep_id
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        WHERE vault_keeps.vault_id = 94

SELECT * FROM profile_view WHERE id = '673faac60ee76bc126981172'


SELECT
keeps.*,
profile_view.*
FROM keeps
JOIN profile_view ON profile_view.id = keeps.creator_id
WHERE profile_view.id = @profileId

CREATE TABLE keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name TINYTEXT NOT NULL,
  description TEXT NOT NULL,
  img TEXT NOT NULL,
  views INT NOT NULL DEFAULT 0,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
)

ALTER TABLE vaults
MODIFY COLUMN description TEXT


CREATE TABLE vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name TINYTEXT NOT NULL,
  description TEXT NOT NULL,
  img TEXT NOT NULL,
  is_private BOOLEAN NOT NULL,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
)

CREATE TABLE vault_keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
  updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  keep_id INT NOT NULL,
  vault_id INT NOT NULL,
  creator_id VARCHAR(255) NOT NULL,
  FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE,
  FOREIGN KEY (keep_id) REFERENCES keeps (id) ON DELETE CASCADE,
  FOREIGN KEY (vault_id) REFERENCES vaults (id) ON DELETE CASCADE
)

CREATE VIEW kept_count_view AS
SELECT
keeps.*,
COUNT(vault_keeps.id) AS kept
FROM keeps
LEFT JOIN vault_keeps ON vault_keeps.keep_id = keeps.id
GROUP BY(keeps.id)




SELECT
vault_keeps.*,
accounts.*
FROM vault_keeps
JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE vault_keeps.id = LAST_INSERT_ID()



SELECT
vault_keeps.*,
keeps.*,
accounts.*
FROM vault_keeps
JOIN keeps ON keeps.id = vault_keeps.keep_id
JOIN accounts ON accounts.id = vault_keeps.creator_id
WHERE vault_keeps.vault_id = 42