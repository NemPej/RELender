create procedure p_GetNumberOfRealEstates
(
	@P_OwnerId int,
	@P_RealEstatesNo int out
)
as
begin try
	select @P_RealEstatesNo = count(*)
	from RealEstates
	where OwnerId = @P_OwnerId;
end try

begin catch 
	select 
		ERROR_NUMBER() as ErrorNumber,
		ERROR_MESSAGE() as ErrorMessage;
end catch;