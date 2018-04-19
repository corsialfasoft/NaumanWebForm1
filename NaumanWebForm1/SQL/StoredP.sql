create procedure seachByDescrizione
	@des nvarchar(max)
as
	select id,descrizione,quantita
	from ProdottiSet
	where descrizione like '%'+@des+'%';
go

create procedure seachById
	@id int
as
	select id,descrizione,quantita
	from ProdottiSet
	where Id = @id
go
create procedure InsertOrdine
	@listId nvarchar(max),
	@listQta nvarchar(max)
as 
	select value as g,value
	from string_split(@listId,';') CROSS APPLY STRING_SPLIT(@listQta , ',') 
go
create Procedure CreaRichiesta
@date date
as
Insert into RichiesteSet (data) values (@date)
Select IDENT_CURRENT('RichiesteSet')
go
create Procedure CreaOrdine
	@idRichiesta int,
	@idProdotti int,
	@quantita int
as
	declare @ConR int = (Select top 1 id from RichiesteSet where id=@idRichiesta);
	if @ConR is null
		select 1 as ReturnRis;
	else 
	begin
		declare @ConP int = (Select top 1 id from ProdottiSet where id=@idProdotti);
		if @ConP is null
			select 2 as ReturnRis;
		else
			Insert into RichiesteProdotti(Richieste_Id,Prodotti_Id,quantita) values(@idRichiesta,@idProdotti,@quantita);
	end
go

insert into [ProdottiSet]([descrizione],[quantita]) values ('telefono',222),('portatile',112),('televisore',232);