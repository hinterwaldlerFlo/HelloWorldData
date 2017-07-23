declare @id int 
select @id = 8
while @id >=1 and @id <= 1000
begin
    insert into WeatherForecast (DateFormatted, TemperatureC, TemperatureF, Summary) values('1/11/2017', ABS(CHECKSUM(NewId())) % 40, 15, 'strange')
    select @id = @id + 1
end