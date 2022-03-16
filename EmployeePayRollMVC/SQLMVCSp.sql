create PROCEDURE sp_Emp_PayRollForm
@Name varchar(50),
@Profile_Image varchar(50),
@Gender varchar(50),
@Department varchar(50),
@Salary varchar (50),
@Start_Date	 varchar(50),
@Notes varchar(50)
AS
BEGIN
insert into EmployeePayrollForm (Name,Profile_Image,Gender,Department,Salary,Start_Date,Notes) values
(
@Name,@Profile_Image,@Gender,@Department,@Salary,@Start_Date,@Notes
)
END
GO

Create procedure spUpdateEmployee          
(          
@Empid int,
@Name varchar(50),
@Profile_Image varchar(50),
@Gender varchar(50),
@Department varchar(50),
@Salary varchar (50),
@Start_Date	 varchar(50),
@Notes varchar(50)     
)          
as          
begin  try        
   Update EmployeePayrollForm           
   set Name=@Name,          
   Profile_Image=@Profile_Image,
   Gender=@Gender,
   Department=@Department,        
   Salary=@Salary, 
   Start_Date=@Start_Date,
   Notes=@Notes
   where Empid=@Empid          
End  try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrprMessage;
end catch



Create procedure spDeleteEmployee

          
   @Empid int          
          
as           
begin  try        
   Delete from EmployeePayrollForm where @Empid=Empid          
End  try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrprMessage;
end catch



Create procedure spGetAllEmployees      
as      
Begin  try    
    select *      
    from EmployeePayrollForm      
End  try
begin catch
select
ERROR_NUMBER() as ErrorNumber,
ERROR_STATE() as ErrorState,
ERROR_PROCEDURE() as ErrorProcedure,
ERROR_LINE() as ErrorLine,
ERROR_MESSAGE() as ErrprMessage;
end catch