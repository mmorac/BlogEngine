/* TABLES CREATION */

create table poststatus(
id int PRIMARY KEY NOT NULL,
statusname varchar(30)
)

create table userroles(
id int PRIMARY KEY NOT NULL,
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

insert into userroles (id, rolename) values (1, 'Public')
insert into userroles (id, rolename) values (2, 'Writer')
insert into userroles (id, rolename) values (3, 'Editor')

/* POST STATUS */

insert into poststatus (id, statusname) values (1, 'Draft')
insert into poststatus (id, statusname) values (2, 'Submitted')
insert into poststatus (id, statusname) values (3, 'Pending Approval')
insert into poststatus (id, statusname) values (4, 'Published')

