create trigger TutarYaz on faturakalems after Insert 
as declare @FaturaID int 
declare @Tutar decimal(18,2)
select @FaturaID = FaturaID,@Tutar = Tutar
from inserted
update Faturalars set Toplam = Toplam + @Tutar where FaturaID = @FaturaID