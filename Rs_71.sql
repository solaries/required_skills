set foreign_key_checks =0;


create table `rs_71eventlog` ( 
`id` bigint(20) not null auto_increment,
`eventid`  bigint(20)   not null    ,
`description`  varchar(5000)   not null    ,
`userevent`   int(11)    not null    ,
`userid`  bigint(20)   not null    ,
`eventdate`  datetime   not null    ,
                        	primary key (`id`)
	)
	collate='latin1_swedish_ci'
	engine=innodb;


drop table if exists `rs_71event` ;

create table `rs_71event` ( 
`id` bigint(20) not null auto_increment,
`eventname`  varchar(60)   not null    ,
                        	primary key (`id`)
	)
	collate='latin1_swedish_ci'
	engine=innodb;


drop table if exists `rs_71authenticate_user` ;

create table `rs_71authenticate_user` ( 
`id` bigint(20) not null auto_increment,
`email`  varchar(90)   not null    ,
`first_name`  varchar(30)   not null    ,
`last_name`  varchar(30)   not null    ,
`password`  blob   not null    ,
`password2`  blob   not null    ,
	primary key (`id`), 
		unique index `un1`     (`email`)
	)
	collate='latin1_swedish_ci'
	engine=innodb;


drop table if exists `rs_71listing_site` ;

create table `rs_71listing_site` ( 
`id` bigint(20) not null auto_increment,
`site_name`  varchar(60)   not null    ,
	primary key (`id`)
	)
	collate='latin1_swedish_ci'
	engine=innodb;


drop table if exists `rs_71skill` ;

create table `rs_71skill` ( 
`id` bigint(20) not null auto_increment,
`date`  datetime   not null    ,
`site`  bigint(20)   not null    ,
`skill`  varchar(60)   not null    ,
	primary key (`id`), 
	constraint `fk1_1` foreign key (`site`) references `rs_71listing_site` (`id`) 
	)
	collate='latin1_swedish_ci'
	engine=innodb;
insert into rs_71authenticate_user(first_name,last_name, email,password, password2   ) values( 'first','last', 'solarinolakunle@yahoo.com','eBRAesiE+jmEL5Vjt7OHNA', 'eBRAesiE+jmEL5Vjt7OHNA'    );insert into rs_71skill(`date`,`site`,`skill`) values( now() , 1 ,'.'); 
insert into rs_71listing_site(`site_name`) values('.'); 
 
 insert into rs_71event(eventname) values('successful_authenticate_user_add'); 
 insert into rs_71event(eventname) values('failed_authenticate_user_add'); 
 insert into rs_71event(eventname) values('error_authenticate_user_add'); 
 insert into rs_71event(eventname) values('successful_authenticate_user_get'); 
 insert into rs_71event(eventname) values('failed_authenticate_user_get'); 
 insert into rs_71event(eventname) values('error_authenticate_user_get'); 
 insert into rs_71event(eventname) values('successful_authenticate_user_update'); 
 insert into rs_71event(eventname) values('failed_authenticate_user_update'); 
 insert into rs_71event(eventname) values('error_authenticate_user_update'); 
 insert into rs_71event(eventname) values('successful_listing_site_add'); 
 insert into rs_71event(eventname) values('failed_listing_site_add'); 
 insert into rs_71event(eventname) values('error_listing_site_add'); 
 insert into rs_71event(eventname) values('successful_listing_site_get'); 
 insert into rs_71event(eventname) values('failed_listing_site_get'); 
 insert into rs_71event(eventname) values('error_listing_site_get'); 
 insert into rs_71event(eventname) values('successful_listing_site_update'); 
 insert into rs_71event(eventname) values('failed_listing_site_update'); 
 insert into rs_71event(eventname) values('error_listing_site_update'); 
 insert into rs_71event(eventname) values('successful_skill_add'); 
 insert into rs_71event(eventname) values('failed_skill_add'); 
 insert into rs_71event(eventname) values('error_skill_add'); 
 insert into rs_71event(eventname) values('successful_skill_get'); 
 insert into rs_71event(eventname) values('failed_skill_get'); 
 insert into rs_71event(eventname) values('error_skill_get'); 
 insert into rs_71event(eventname) values('successful_skill_update'); 
 insert into rs_71event(eventname) values('failed_skill_update'); 
 insert into rs_71event(eventname) values('error_skill_update');

set foreign_key_checks =1;
