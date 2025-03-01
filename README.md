Nasıl Çalışıyor? <br>
Ekranda bulunan butonlar ile sahneye ev(Big House,Small House) ve ekin(Flower ve Tomato) ekleyebilirsiniz.<br>
Eklediğiniz ekinler belirli zaman periyotları ile 3 kademede büyüyecek ve hasat yapma zamanı geldiğinde üstlerinde tick sembolü çıkacaktır.<br>
Hasat yaptığınızda o alanda bulunan ekin tekrar büyüyecektir.<br>
Remove butonu ile hem evleri hem ekin alanlarını silebilirsiniz.Silinen bu alanları tekrar kullanabilirsiniz.<br>
Exit butonu oyunu kapatmaya ve verilerin(score) kaydetmeyi sağlamaktadır.<br>

Kullanılan teknolojiler ve sistem mimarisi <br>
Observer: Oyun içi olayları yönetmek için Action yapısı kullandım.<br>
State Pattern: Oyundaki durum yönetimini IBuildingState arayüzü ile sağladım. RemovingState, PlacementState gibi farklı durumlar var ve her biri belirli bir davranış sergiliyor.<br>
DOTween:DOTween kullanarak küçük animasyonlar oluşturdum.<br>
Shader Graph: Oyundaki grid sisteminin rahatlıkla görülebilmesi için kullandım.<br>
Grid System: Oyundaki nesne yerleşimi ve düzenini yönetmek için Unity’nin Grid bileşenini kullandım.<br>
Firebase:Oyuna giriş işlemi ve score tutmak için kullandım.<br>

Screenshots
![](/FarmLogin.PNG)
![](/FarmRegister.PNG)
![](/Farm1.PNG)
![](/Farm2.PNG)
![](/Farm3.PNG)
