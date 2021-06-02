create procedure p_GetRealEstateOwnerProfitExtended
(
	@P_OwnerId int,
	@P_Profit int out
)
as
begin try
	select @P_Profit = Sum(OwnerCompensation)
	from RentingRights
	where RealEstate_Id in 
	(
		select Id 
		from RealEstates 
		where OwnerId in
		(
			select Id
			from RealEstateOwners
			where Id = @P_OwnerId
		)
	);

end try

begin catch 
	select 
		ERROR_NUMBER() as ErrorNumber,
		ERROR_MESSAGE() as ErrorMessage;
end catch;

