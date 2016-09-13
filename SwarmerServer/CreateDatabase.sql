CREATE DATABASE "Swarmer.AccountaManagementDB"
  WITH OWNER "postgres"
  ENCODING 'UTF8'
  LC_COLLATE = 'ru_RU.UTF-8'
  LC_CTYPE = 'ru_RU.UTF-8'
  TEMPLATE = template0;

USE "Swarmer.AccountaManagementDB";

CREATE TABLE Users (
 Id int primary key not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone,
 FirstName varchar(256) not null,
 SecondName varchar(256) not null,
 Login varchar(256) not null,
 Gender varchar(8) not null,
 Role varchar(16) not null,
 SteamId varchar(256),
 BirthDate date,
 Address varchar(1024),
 Timezone int,
 Country varchar(256),
 Profile jsonb not null,
 Blocked byte not null default 0,
 BlockReason varchar(1024),
 PhoneNumber varchar(128)
);

CREATE TABLE Entries (
 Id int primary key not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone,
 Userdid int references users(id),
 Type int not null,
 Secret varchar(1024) not null
);

CREATE TABLE Teams (
 Id	int primary key not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone,
 Name	varchar(128) unique not null,
 Owner	int not null,
 Fullname varchar(1024) not null,
 Blocked byte not null default 0,
 BlockReason varchar(1024) not null,
 Profile jsonb not null
);

CREATE TABLE TeamsMembership (
 Id int primary key not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone,
 TeamId int references teams(id),
 UserId int references users(id),
 Data jsonb not null
);