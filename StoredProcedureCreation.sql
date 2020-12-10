CREATE PROCEDURE BuyTicket
@ShowId int,
@AvailableTickets int
AS
BEGIN
	UPDATE Shows
	SET AvailableTickets = @AvailableTickets
	WHERE ShowId = @ShowId;
END


EXEC BuyTicket @ShowId = '7', @AvailableTickets = '555';

select * from Shows
