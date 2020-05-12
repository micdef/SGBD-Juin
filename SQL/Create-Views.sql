IF(NOT(EXISTS(SELECT * FROM sys.views WHERE name = 'V_OpenedTicket')))
BEGIN
	EXEC ('
		CREATE VIEW [V_OpenedTicket]
		AS
			SELECT		TIC.[ID],
						CUS.[Name],
						TIC.[Subject],
						TIC.[DateIN]
			FROM		[Ticket] AS [TIC]
				JOIN	[Customer] AS [CUS] ON TIC.[IDCustomer] = CUS.[ID]
			WHERE		TIC.[FFinished] = ''False'';
	');
END

IF(NOT(EXISTS(SELECT * FROM sys.views WHERE name = 'V_AllTickets')))
BEGIN
	EXEC ('
		CREATE VIEW [V_AllTickets]
		AS
			SELECT		TIC.[ID],
						CUS.[Name],
						TIC.[Subject],
						TIC.[DateIN]
			FROM		[Ticket] AS [TIC]
				JOIN	[Customer] AS [CUS] ON TIC.[IDCustomer] = CUS.[ID];
	');
END