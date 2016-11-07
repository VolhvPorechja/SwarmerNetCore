CREATE DATABASE "Swarmer.TournamentsDB"
  WITH OWNER "postgres"
  ENCODING 'UTF8'
  LC_COLLATE = 'ru_RU.UTF-8'
  LC_CTYPE = 'ru_RU.UTF-8'
  TEMPLATE = template0;

CREATE TABLE Tournaments (
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 Begin timestamp with time zone not null,
 Owner uuid not null,
 State int not null,
 Title varchar(1024) not null,
 Name varchar(256) not null,
 Description text not null,
 Data jsonb default value '{}'::jsonb,
 IsOpen boolean not null default false,
 Stats jsonb not null default '{}'::jsonb
);

CREATE TABLE Parties (
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 Name varchar(256) not null,
 TournamentId uuid references Tournaments(Id) not null,
 Creator uuid not null,
 Team uuid,
 Stats jsonb not null default '{}'::jsonb,
 Data jsonb not null default '{}'::jsonb
);

CREATE TABLE TournamentsInvites(
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 TournamentId uuid references Tournaments(Id) not null,
 PlayerId uuid,
 TeamId uuid,
 Inviter uuid not null,
 Used boolean not null default false
);

CREATE TABLE PartiesInvites(
 Id uuid PRIMARY KEY not null,
 Created timestamp with time zone not null,
 Updated timestamp with time zone not null,
 PartyId uuid references Parties(Id) not null,
 PlayerId uuid not null,
 Used boolean not null default false
 );