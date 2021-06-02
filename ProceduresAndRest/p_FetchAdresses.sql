create procedure p_FetchAdresses
as
declare address_cursor cursor
for select Address from RealEstates;
declare @t varchar(25);
begin
	open address_cursor;
	while @@FETCH_STATUS = 0
		begin
			fetch next from address_cursor
			into @t
			print @t;
		end

	close address_cursor;
	deallocate address_cursor;
end