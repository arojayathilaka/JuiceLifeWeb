insert into Product
values('Orange Juice',150,'Fruit juice','~/Content/uploads/1.jpg')

insert into Product
values('Lemon Juice',150,'Fruit juice','~/Content/uploads/2.jpg')

insert into Product
values('Pineapple Juice',150,'Fruit juice','~/Content/uploads/3.jpg')

insert into Product
values('StrawBerry Juice',150,'Fruit juice','~/Content/uploads/4.jpg')

insert into Product
values('Apple Juice',150,'Fruit juice','~/Content/uploads/5.jpg')

insert into Product
values('Sugarcane Juice',150,'Fruit juice','~/Content/uploads/6.jpg')

SELECT *
FROM Invoice

SELECT *
FROM Orders

SELECT *
FROM product

DROP TABLE Invoice

DROP TABLE Orders

create table Invoice
(
in_id int identity primary key,
in_fk_users int foreign key references Users(usr_id),
in_date datetime,
in_totalbill FLOAT,
)

create table Orders
(
ord_id int identity primary key,
ord_fk_product int foreign key references Product(pro_id),
ord_fk_invoice int foreign key references Invoice(in_id),
ord_date datetime,
ord_qty int,
ord_bill float,
ord_unitprice int
)

DROP TABLE Users

create table Users
 (
 usr_id int identity primary key,
 usr_name nvarchar(50) not null,
 usr_contact nvarchar(50) not null unique,
 usr_password nvarchar(50) not null
 )

 INSERT INTO Users
 VALUES('Tharaka','0710456213','tharaka123')

 INSERT INTO Users
 VALUES('Pathum', '0112356487', 'pathum123')

 SELECT *
 FROM Users