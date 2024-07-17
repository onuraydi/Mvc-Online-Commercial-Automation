Create Trigger stokAzaltSatis on SatisHarekets
After insert as 
Declare @UrunID int
Declare @Adet int
Select @UrunID = UrunID, @Adet = Adet from inserted
update Uruns set Stok = stok - @Adet where UrunID = @UrunID