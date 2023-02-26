/* TABLES CREATION */

create table poststatus(
id int identity(1,1) PRIMARY KEY NOT NULL,
statusname varchar(30)
)

create table userroles(
id int identity(1,1) PRIMARY KEY NOT NULL,
rolename varchar(30)
)

create table users(
id int identity(1,1) Primary Key NOT NULL,
username varchar(50),
displayname varchar(100)
)

create table posts(
id int identity(1,1) primary key not null,
title varchar(100),
content varchar(1000),
createdby int,
lastmodifiedby int,
statusid int
)

alter table posts add foreign key (statusid) references poststatus(id)
alter table posts add foreign key (createdby) references users(id)
alter table posts add foreign key (lastmodifiedby) references users(id)

create table comments(
id int identity(1,1) primary key not null,
postid int,
content varchar(280)
)

alter table comments add foreign key (postid) references posts(id)

/* DATA INSERTION */

/* USER ROLES */

insert into userroles (rolename) values ('Public')
insert into userroles (rolename) values ('Writer')
insert into userroles (rolename) values ('Editor')

/* POST STATUS */

insert into poststatus (statusname) values ('Draft')
insert into poststatus (statusname) values ('Submitted')
insert into poststatus (statusname) values ('Pending Approval')
insert into poststatus (statusname) values ('Published')

