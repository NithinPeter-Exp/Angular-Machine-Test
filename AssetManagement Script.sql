CREATE TABLE Login(
l_Id	INT PRIMARY KEY IDENTITY(1,1),
Username	VARCHAR(20),
Password	VARCHAR(20),
UserType	VARCHAR(15)
);

CREATE TABLE UserRegistration(
u_id	INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(20),
LastName	VARCHAR(20),
Age			INT,
Gender		VARCHAR(20),
Address		VARCHAR(40),
PhoneNumber	INT,
l_Id	INT FOREIGN KEY REFERENCES Login(l_Id)
);


CREATE TABLE AssetMasterTable(
am_id	INT PRIMARY KEY IDENTITY(1,1),
am_atype_id	VARCHAR(40),
am_make		VARCHAR(40),
am_ad	VARCHAR(40),
am_model VARCHAR(40),
am_snumber	VARCHAR(20),
am_myyear	VARCHAR(10),
am_pdate	DATE,
am_warranty VARCHAR(1),
am_from		DATE,
am_to		DATE
);

select * from AssetMasterTable