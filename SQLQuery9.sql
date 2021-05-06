create database dbSofttransport

use dbSofttransport

create table tblEmployee
(Id int identity(101,1) primary key,
Name varchar(20) not null,
Password varchar(20) not null,
Location varchar(20),
Phone varchar(20),
Vechicle_id char(8))

create table tblDriver
(Id int identity(1000,1) primary key,
Name varchar(20),
Phone varchar(20),
status varchar(50) check(status in ('active','not active')),
Area varchar(20))


create table tblVechicle
(Vechicle_number char(8) primary key,
Type varchar(10),
Capacity int,
Driver_id int references tblDriver(Id),
Filled_status int,
status varchar(50) check(status in ('active','not active')))

Insert into tblEmployee(Name,Password,Location,Phone) values('surya','123453','chennai','9182735903')

alter table tblEmployeeadd constraint fk_VID foreign key(Vechicle_Id) references tblVechicle(Vechicle_number)


--employee
create proc proc_InsertEmployee(@eName varchar(20),
@ePassword varchar(20),
@eLocation varchar(20),
@ePhone varchar(20))
as
	Insert into tblEmployee(Name,Password,Location,Phone) values(@eName,@ePassword,@eLocation,@ePhone)

create proc proc_UpdatePassword(@eId int,@ePassword varchar(20))
as
update tblEmployee set Password = @ePassword where Id = @eId

create proc proc_UpdatePhone(@eId int,@ePhone varchar(20))
as
update tblEmployee set Phone = @ePhone where Id = @eId

create proc proc_UpdateLocation(@eId int,@eLocation varchar(20))
as
update tblEmployee set Location = @eLocation where Id = @eId

create proc proc_DeletePassword(@eId int)
as
delete from tblEmployee where Id = @eId

create proc proc_GetAllEmployees
as
select * from tblEmployee


--driver
create proc proc_InsertDrivers(@eName varchar(20),
@ePhone varchar(20),
@eStatus varchar(50),
@eArea varchar(20))
as
	Insert into tblDriver(Name,Phone,status,Area) values(@eName,@ePhone,@eStatus,@eArea)

create proc proc_UpdateDriversPhone(@ePhone varchar(20),@eId int)
as
update tblDriver set Phone = @ePhone where Id = @eId

create proc proc_UpdateDriversStatus(@eStatus varchar(20),@eId int)
as
update tblDriver set status = @eStatus where Id = @eId

create proc proc_GetAllDrivers
as
select * from tblDriver