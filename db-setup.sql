USE mikeskeepr;

CREATE TABLE IF NOT EXISTS users (
    id VARCHAR(255) NOT NULL,
    username VARCHAR(20) NOT NULL,
    email VARCHAR(255) NOT NULL,
    hash VARCHAR(255) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE KEY email (email)
);


CREATE TABLE IF NOT EXISTS keeps (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(255) NOT NULL,
    userId VARCHAR(255),
    img VARCHAR(255),
    isPrivate TINYINT,
    views INT DEFAULT 0,
    shares INT DEFAULT 0,
    keeps INT DEFAULT 0,
    INDEX userId (userId),
    FOREIGN KEY (userId)
        REFERENCES users(id)
        ON DELETE CASCADE,  
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS vaults (
    id int NOT NULL AUTO_INCREMENT,
    name VARCHAR(20) NOT NULL,
    description VARCHAR(255) NOT NULL,
    userId VARCHAR(255),
    INDEX userId (userId),
    FOREIGN KEY (userId)
        REFERENCES users(id)
        ON DELETE CASCADE,  
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS vaultkeeps (
    id int NOT NULL AUTO_INCREMENT,
    vaultId int NOT NULL,
    keepId int NOT NULL,
    userId VARCHAR(255) NOT NULL,

    PRIMARY KEY (id),
    INDEX (vaultId, keepId),
    INDEX (userId),

    FOREIGN KEY (userId)
        REFERENCES users(id)
        ON DELETE CASCADE,

    FOREIGN KEY (vaultId)
        REFERENCES vaults(id)
        ON DELETE CASCADE,

    FOREIGN KEY (keepId)
        REFERENCES keeps(id)
        ON DELETE CASCADE
);

-- DROP TABLE IF EXISTS vaultkeeps;
-- DROP TABLE IF EXISTS vaults;
-- DROP TABLE IF EXISTS keeps;
-- DROP TABLE IF EXISTS users;


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 
