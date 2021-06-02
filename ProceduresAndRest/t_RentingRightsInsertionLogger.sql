create trigger t_RentingRightsInsertionLogger
on dbo.RentingRights
for insert
as
declare @id int;
select @id = i.Id from inserted i;
insert into Logs
	(Action, ActionResId, DateTime)
	values ('RentingRightsInsertion', @id, getdate());
