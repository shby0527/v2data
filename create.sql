create table `info_data`(
		`id`  int  not null primary key auto_increment,
		`linkType` varchar(15) not null,
		`user` varchar(100) not null,
		`size` bigint unsigned not null,
		`utype` varchar(30) not null,
		`createtime` timestamp not null,

		index (`user`,`createtime`)
) engine=innodb charset=utf8;


create table `info_user`(
		`id`  int  not null primary key auto_increment,
    `uid` varchar(150) not null  unique key,
    `email` varchar(100) not null unique key,
    `comment` varchar(200) null    
    
) engine=innodb charset=utf8;