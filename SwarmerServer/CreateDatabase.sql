CREATE DATABASE "Swarmer.AccountsManagementDB"
  WITH OWNER "postgres"
  ENCODING 'UTF8'
  LC_COLLATE = 'ru_RU.UTF-8'
  LC_CTYPE = 'ru_RU.UTF-8'
  TEMPLATE = template0;

CREATE TABLE Users (
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 FirstName varchar(256) not null,
 SecondName varchar(256) not null,
 Login varchar(256) UNIQUE not null,
 Email varchar(256) UNIQUE not null,
 Gender varchar(8),
 Role varchar(16),
 SteamId varchar(256),
 BirthDate date,
 Address varchar(1024),
 Timezone int,
 Country varchar(256),
 Profile jsonb not null,
 Blocked boolean not null default false,
 BlockReason varchar(1024),
 PhoneNumber varchar(128) UNIQUE
);

CREATE TABLE Entries (
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 UserId uuid references users(id) not null,
 Type varchar(128) not null,
 Secret varchar(1024) not null
);

CREATE TABLE Teams (e
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 Name	varchar(128) unique not null,
 Owner	uuid not null,
 Fullname varchar(1024) not null,
 Blocked boolean not null default false,
 BlockReason varchar(1024),
 Profile jsonb not null
);

CREATE TABLE TeamsMembership (
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 TeamId uuid references teams(id) not null,
 UserId uuid references users(id) not null,
 Data jsonb not null
);

-- TODO: CONTACTS (SKYPE, Social networks and other)