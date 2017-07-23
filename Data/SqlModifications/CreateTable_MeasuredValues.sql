

DROP TABLE IF EXISTS dbo.MeasuredValues;


CREATE TABLE [dbo].[MeasuredValues] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
    [Timestamp] DATETIME      NOT NULL,
    [Value]     FLOAT (53)    NULL
);
 

/*fill with random values*/
declare @id int 
select @id = 1
while @id >=1 and @id <= 1000
begin
    insert into dbo.MeasuredValues (Name, Timestamp, Value) values(
		'TopTemperature'
		,DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')
		,ABS(CHECKSUM(NewId())) % 40);
	insert into dbo.MeasuredValues (Name, Timestamp, Value) values(
		'EarthTemperature'
		,DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')
		,ABS(CHECKSUM(NewId())) % 40);
	insert into dbo.MeasuredValues (Name, Timestamp, Value) values(
		'NormTemperature'
		,DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')
		,ABS(CHECKSUM(NewId())) % 40);
    select @id = @id + 1
end