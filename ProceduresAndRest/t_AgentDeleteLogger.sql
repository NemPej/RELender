create trigger t_AgentDeleteLogger
on dbo.Agents
for delete
as
declare @id int;
select @id = i.Id from deleted i;
insert into Logs
	(Action, ActionResId, DateTime)
	values ('AgentDeletion', @id, getdate());

