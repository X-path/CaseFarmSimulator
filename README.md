Nasıl Çalışıyor?
Ekranda bulunan butonlar ile sahneye ev(Big House,Small House) ve ekin(Flower ve Tomato) ekleyebilirsiniz.
Eklediğiniz ekinler belirli zaman periyotları ile 3 kademede büyüyecek ve hasat yapma zamanı geldiğinde üstlerinde tick sembolü çıkacaktır.
Hasat yaptığınızda o alanda bulunan ekin tekrar büyüyecektir.
Remove butonu ile hem evleri hem ekin alanlarını silebilirsiniz.Silinen bu alanları tekrar kullanabilirsiniz.

Kullanılan teknolojiler ve sistem mimarisi
Observer: Oyun içi olayları yönetmek için Action yapısı kullandım.
State Pattern: Oyundaki durum yönetimini IBuildingState arayüzü ile sağladım. RemovingState, PlacementState gibi farklı durumlar var ve her biri belirli bir davranış sergiliyor.
DOTween:DOTween kullanarak küçük animasyonlar oluşturdum.
Shader Graph: Oyundaki grid sisteminin rahatlıkla görülebilmesi için kullandım.
Grid System: Oyundaki nesne yerleşimi ve düzenini yönetmek için Unity’nin Grid bileşenini kullandım.
