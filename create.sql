create table `info_data`(
		`id`  int  not null primary key auto_increment,
		`linkType` varchar(15) not null,
		`user` varchar(100) not null,
		`size` bigint unsigned not null,
		`utype` varchar(30) not null,
		`createtime` timestamp not null,

		index (`user`,`createtime`)
) engine=innodb charset=utf8;

-- 管理者
create table `info_admin`(
		`id`   int UNSIGNED not null PRIMARY key AUTO_INCREMENT,
		`account` varchar(20) not null UNIQUE, -- 用户名
		`password` varchar(2048) not null, -- 密码(PBKDF2-HMAC-SHA512加密)
		`phone`   varchar(20) not null -- 用来发送验证码的手机	
)engine=innodb charset=utf8;

-- 服务器表
create table `info_server`(
        `id`   int UNSIGNED not null PRIMARY key AUTO_INCREMENT,
        `tags` varchar(50) not null unique, -- 服务器标记
        `address` varchar(200) not null, -- 服务器地址,
        `adminId` int UNSIGNED not null -- 管理者ID 
)engine=innodb charset=utf8;

alter table `info_server` add column `publicKey` text not null; -- 这是这个服务器的公钥（私钥服务器自己负责保存）

-- 服务器用户
create table `info_v2user`(
		`id`   int UNSIGNED not null PRIMARY key AUTO_INCREMENT,
		`email` varchar(200) not null, -- email
		`account` varchar(500) not null, -- uuid
		`alterId` int UNSIGNED not null, -- 额外ID
		`level` int UNSIGNED not null, -- 所属级别
		`disabled` int default 0, -- 是否禁用， 0 不禁用，1启用
		`serverId` int UNSIGNED not null -- 所属服务器ID
)engine=innodb charset=utf8;

-- 短信验证码表
create table `info_sms`(
		`id`   int UNSIGNED not null PRIMARY key AUTO_INCREMENT,
		`code` varchar(10) not null, -- 验证码
		`used` tinyint UNSIGNED DEFAULT 0,-- 是否已经使用，0没有使用
		`adminId` int UNSIGNED not null, -- 管理员ID
		`ctime` timestamp not null -- 创建时间
)engine=innodb charset=utf8;