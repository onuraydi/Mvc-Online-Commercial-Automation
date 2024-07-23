select CariAd + ' ' + CariSoyad from Caris where
CariMail in (Select Gonderici from mesajs) 