create database EmppayrollformMVC
use EmppayrollformMVC

CREATE TABLE EmployeePayrollForm
( 
    Empid int identity(1,1) primary key not null,
    Name varchar(50) not null,
    Profile_Image varchar(50),
    Gender varchar(50),
	Department varchar(50),
	Salary varchar(50),
	Start_date varchar(50),
	Notes varchar(50),
	RegisteredDate datetime default sysdatetime()
);

select *from EmployeePayrollForm
drop table EmployeePayrollForm
