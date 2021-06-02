create trigger t_RentingRightsDeleteLogger
on dbo.RentingRights
for delete
as
declare @id int;
select @id = i.Id from deleted i;
insert into Logs
	(Action, ActionResId, DateTime)
	values ('rentingRightsDeletion', @id, getdate());
