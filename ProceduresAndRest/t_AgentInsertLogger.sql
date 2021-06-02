create trigger t_AgentInsertLogger
on dbo.Agents
for insert
as
declare @id int;
select @id = i.Id from inserted i;
insert into Logs
	(Action, ActionResId, DateTime)
	values ('AgentInsertion', @id, getdate());


