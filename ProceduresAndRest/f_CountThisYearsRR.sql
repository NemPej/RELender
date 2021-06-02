create function f_CountThisYearsRR
()
returns int
begin
	declare @rv int
	select @rv = count(*) from RentingRights where year(StartDate) = year(GETDATE());
	return @rv
end