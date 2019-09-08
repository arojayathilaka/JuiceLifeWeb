create table Users
 (
 usr_id int identity primary key,
 usr_name nvarchar(50) not null,
 usr_contact nvarchar(50) not null unique,
 usr_password nvarchar(50) not null
 )
create table Product
(
pro_id int identity primary key,
pro_name nvarchar(60) not null unique,
pro_price float,
pro_desc nvarchar(500) not null,
pro_image nvarchar(max)
)

create table Invoice
(
in_id int identity primary key,
in_fk_users int foreign key references Users(usr_id),
in_date datetime,
in_totalbill float
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