


create function f_AvgRentOwnerCompensation
()
returns decimal
begin
	declare @rv as decimal
	select @rv = avg(OwnerCompensation) from RentingRights;
	return @rv;
end
