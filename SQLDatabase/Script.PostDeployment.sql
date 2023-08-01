if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (UserName, Password)
	values ('Joe', '1234'),
	('Cole', '4321');
end