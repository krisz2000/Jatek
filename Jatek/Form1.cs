using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jatek
{
    public partial class Form1 : Form
    {
        public struct Tulajdonsagok //a karakterre(vagy ellenségre) vonatkozó tulajdonságok
        {
            public int hp; //életerő
            public bool pajzs; //van-e pajzsa
            public double speed;  //sebesség (ork=1,ember=2,patkány=4)
            public int vedelem;    //alap védelem
            public int ap; //alap támadás
            public string name; //ork, human, rat, self, enemy
        } 
        public struct Map //a térkép tulajdonságai
        {
            public string map_alap; //fal, függőleges út, vízszintes út, kereszteződés
            public bool map_generalhato; //lehet-e új utat generálni erre
            public string map_targyak; //semmi, szörny, láda, játékos
            public bool lathatosag; //látjuk-e?
        }
        string Terkep = ""; //a térkép kiírásához szükséges "szöveg"
        int Fajok_3_max_hp=0;
        bool tamadas = false; //a karakter támadni fog?
        bool vedekezes = false; //a karakter védekezni fog?
        int vedekezesi_ertek = 0; //a karakter védekezési értéke (ha védekezik+van pajzsa, akkor nagyobb)
        double sebesseg = 0; //az ellenfél sebessége (hányszor támad)
        Tulajdonsagok[] Fajok = new Tulajdonsagok[5];
        int seged1 = 1, seged2 = 1; //mapgenerálási segédváltozók
        int meret = 0; //mekkora kazamatát szeretne generálni (mindkét irányban, valóságban mindkét oldalon nagyobb lesz, mert egy áthatolhatatlan fal lesz körülötte)
        Map[,] terkep; //maga a térkép
        int terkepgeneralasi_hibak = 0; //hányszor próbálta legenálni, ez azért kell, mert ha lehetetlen, örökké generálná
        public Form1() //kezdés
        {
            InitializeComponent();
            Start();
            Csatakezdes();
        }
        public void Start()
        {
            Fajok[0].hp = 10;
            Fajok[0].ap = 4;
            Fajok[0].speed = 0.5;
            Fajok[0].name = "Ork";
            Fajok[1].hp = 10;
            Fajok[1].ap = 2;
            Fajok[1].speed = 1;
            Fajok[1].name = "Ember";
            Fajok[2].hp = 10;
            Fajok[2].ap = 1;
            Fajok[2].speed = 2;
            Fajok[2].name = "Patkony";
            //alaptulajdonságok a fajoknak (Ork, Ember, Patkony/Patkány)

            Fajok[3].ap = Fajok[1].ap;
            Fajok_3_max_hp = Fajok[1].hp * 4;
            Fajok[3].hp = Fajok_3_max_hp;
            Fajok[3].speed = Fajok[1].speed;
            Fajok[3].pajzs = false;
            Fajok[3].vedelem = 0;
            Fajok[3].name = "";
            //Saját tulajdonságok
            labelTerkep.Text = "Hello" + Environment.NewLine + "hogy vagy?";
            //alap a térkép kiírásának
        }

        public void Utgeneralas_old() //éppenséggel ezen dolgozunk, még én se értem
        {
            for(int i = 0; i <= meret + 1; i++) //Azért megpróbálom, kiválasztjuk az "i" kordinátát
            {
                for (int j = 0; j <= meret + 1; j++) //Aztán a "j" kordinátát
                {
                    if (terkep[i, j].map_alap == "O") //Hogyha ez út, akkor innen generálunk tovább
                    {
                        List<int> generalasi_iranyok = new List<int>(); //Leteszteljük hogy melyik irányokba generálhatunk, útmutató irányában
                                                                        /*if (terkep[i, j + 1].map_alap == "#" && j < meret) //északnak
                                                                        { generalasi_iranyok[0] = true; }
                                                                        if (terkep[i + 1, j].map_alap == "#" && i < meret) //keletnek
                                                                        { generalasi_iranyok[1] = true; }
                                                                        if (terkep[i, j - 1].map_alap == "#" && j > 1) //délnek
                                                                        { generalasi_iranyok[2] = true; }
                                                                        if (terkep[i - 1, j].map_alap == "#" && i > 0) //nyugatnak
                                                                        { generalasi_iranyok[3] = true; }
                                                                        for (int k=0;k<=3;k++)
                                                                        */
                                                                        //Lehetséges, hogy egy listából/tömből kiveszünk pár elemet, ezek azok, amelyekre nem generálhatunk, és a maradékot használjuk, arra hogy generáljunk?
                                                                        //Ha igen, ezzel ezt megoldhatnánk
                        if (j < terkep.GetLength(1))
                        {
                            if (terkep[i, j + 1].map_generalhato == true)
                            { generalasi_iranyok.Add(1); }
                        }
                        if (i < terkep.GetLength(0))
                        {
                            if (terkep[i + 1, j].map_generalhato == true)
                            { generalasi_iranyok.Add(2); }
                        }
                        if (j > 0)
                        {
                            if (terkep[i, j - 1].map_generalhato == true)
                            { generalasi_iranyok.Add(3); }
                        }
                        if (i > 0)
                        {
                            if (terkep[i - 1, j].map_generalhato == true)
                            { generalasi_iranyok.Add(4); }
                        }
                            Random veletlen = new Random();
                        if (generalasi_iranyok.Count != 0)
                        {
                            int generalasi_valoszinuseg = generalasi_iranyok[veletlen.Next(0, generalasi_iranyok.Count)];
                            {
                                if (generalasi_valoszinuseg == 1)
                                {
                                    terkep[i, j + 1].map_alap = "O";
                                    terkep[i, j + 1].map_generalhato = false;
                                }
                                if (generalasi_valoszinuseg == 2)
                                {
                                    terkep[i + 1, j].map_alap = "O";
                                    terkep[i + 1, j ].map_generalhato = false;
                                }
                                if (generalasi_valoszinuseg == 3)
                                {
                                    terkep[i, j - 1].map_generalhato = false;
                                    terkep[i, j - 1].map_alap = "O";
                                }
                                if (generalasi_valoszinuseg == 4)
                                {
                                    terkep[i - 1, j].map_generalhato = false;
                                    terkep[i - 1, j].map_alap = "O";
                                }
                            }
                        }
                    }
                }
            }
            Terkep_Kirajzolas();
        }

        public void Utgeneralas() // Prim algoritmus
        {
            List<int[]> falak = new List<int[]>
            {
                new int[] { 1, 2, 0 }, // Hozzáadjuk a bejárat melletti területeket
                new int[] { 2, 1, 1 }
            }; // Létrehozunk egy List-et a későbbiekben hozzáadandó "falaknak"
            while (falak.Count!= 0) // Amíg van valami a List-ben
            {

                Random rnd = new Random();
                int[] fal = falak[rnd.Next(0, falak.Count)]; // Kiválasztunk véletlenszerűen egyet a "falakból"
                int x = fal[0];
                int y = fal[1];
                int pos = fal[2]; // Kiolvassuk az adatait, a későbbi egyszerűség érdekében

                falak.RemoveAt(pos); //Kitöröljük aList-ből, mert már nem kell vele foglalkoznunk, vagy út lesz belőle, vagy tényleges fal
                for (int i = pos; i < falak.Count; i++) // Kijavítjuk a többi elem pozíciójának értékét a List-ben ami a törlés miatt rossz lehet
                {
                    int a = falak[i][0];
                    int b = falak[i][1];
                    falak.Insert(i, new int[] { a, b, i });
                    falak.RemoveAt(i + 1);
                }

                if (new[] { terkep[x + 1, y].map_alap == "O", terkep[x - 1, y].map_alap == "O", terkep[x, y + 1].map_alap == "O", terkep[x, y - 1].map_alap == "O" }.Count(p => p) == 1) //Megnézzük a sorsolt "fal"-ra, hogy pontosan 1 db út van-e mellette
                {

                    terkep[x, y].map_generalhato = false; // Ha igen beállítjuk az értékeit
                    terkep[x, y].map_alap = "O";
                    if (terkep[x, y + 1].map_generalhato == true) //Megnézzük, hogy ettől az úttól, merre felé lehet még menni, és ezeket a helyeket behelyezzük a List-be. 
                    {
                        terkep[x, y + 1].map_generalhato = false;
                        falak.Add(new int[] { x, y + 1, falak.Count });
                    }

                    if (terkep[x + 1, y].map_generalhato == true) //Az első if-ek azért kellenek, hogy ne menjünk ki a játéktérről.
                    {
                        terkep[x + 1, y].map_generalhato = false;
                        falak.Add(new int[] { x + 1, y, falak.Count });
                    }

                    if (terkep[x, y - 1].map_generalhato == true) 
                    {
                        terkep[x, y - 1].map_generalhato = false;
                        falak.Add(new int[] { x, y - 1, falak.Count });
                    }

                    if (terkep[x - 1, y].map_generalhato == true) 
                    {
                        terkep[x - 1, y].map_generalhato = false;
                        falak.Add(new int[] { x - 1, y, falak.Count });
                    }

                }
            }
            Terkep_Kirajzolas(); // Kirajzoljuk a térképet
        }

        public void ButtonTamadas_Click(object sender, EventArgs e) //ha a Csatakör();-ben a "Támadás" gombra nyomott
        {
            tamadas = true;
            Csatakör2();
        }
        public void ButtonVedekezes_Click(object sender, EventArgs e) //ha a Csatakör();-ben a "Védekezés" gombra nyomott
        {
            vedekezes = true;
            Csatakör2();
        }

        public void Csatakör() //Régi (if-es) csatakör modell, van már újjabb, jobb modell; lusta vagyok ezt is megmagyarázni
        {
            if (tamadas == true)
            {
                Fajok[4].hp -= Fajok[3].ap;

            }
            else if (vedekezes == true)
            {
                vedekezesi_ertek = 2;
            }
            else
            {
                Csatakör();
            }
            //Fajok[3].hp = Fajok[3].hp - ((Fajok[4].ap * (Fajok[4].speed - Fajok[4].speed % 2) / vedekezesi_ertek + Fajok[4].ap * ((Fajok[4].speed - 1) % 2)) - Fajok[3].vedelem);
            /*sebesseg+= Fajok[4].speed;
            for (int i=0;i<(sebesseg-sebesseg%2);sebesseg/=2)
            {
                Fajok[3].hp -= (Fajok[4].ap / vedekezesi_ertek) - Fajok[3].vedelem;
            }
            Fajok[3].hp -= Fajok[3].vedelem;
            */
            /*sebesseg += Fajok[4].speed;
            for (int i=0;i<(sebesseg-sebesseg%1);sebesseg--)
            {
                Fajok[3]-=Fajok[4].ap

            }
            */
            sebesseg = sebesseg + Fajok[4].speed;
            if (Fajok[4].speed == 0.5 && sebesseg == 1) //ha az ellenfél ork, és ebben a körben támad
            {
                Fajok[3].hp -= Fajok[4].ap / vedekezesi_ertek - Fajok[3].vedelem; //akkor csökkense az életerőmet az ellenség támadásával. A védekezés (a pajzsal) és a páncéling befijásolja
                sebesseg = 0; //elment a támadása
            }
            else if (Fajok[4].speed == 1) //ha az ellenség ember.
            {
                Fajok[3].hp -= Fajok[4].ap / vedekezesi_ertek - Fajok[3].vedelem;  //akkor csökense az életerőmet -||-
                sebesseg = 0; //elment a támadása
            }
            else if (Fajok[4].speed == 2) //ha az ellenség patkány.
            {
                Fajok[3].hp -= (Fajok[4].ap / vedekezesi_ertek - Fajok[3].vedelem) + (Fajok[4].ap - Fajok[3].vedelem); //akkor csökkense az életerőmet a patkány támadásával, a pajzs csak az egyiket csökkenti
                sebesseg = 0; //elment a támadása
            }

            if (Fajok[3].hp <= 0)
            {
                Halal_Enabled();
                Jutalom_Disabled();
                Csatakor_Disabled();

            }
            else if (Fajok[4].hp <= 0)
            {
                Jutalom_Enabled();
                Csatakor_Disabled();
                Halal_Disabled();
            }
            tamadas = false;
            vedekezes = false;
            vedekezesi_ertek = 1;

        }
        public void Csatakör2() //Az újjabb, jobb modell
        {
            if (tamadas == true)  //Ha a játékos támad
            { Fajok[4].hp -= Fajok[3].ap; } //Akkor csökkentjük az elleség életerejét
            else if (vedekezes == true) //Ha a játékos védekezik
            { vedekezesi_ertek = 1; } //Akkor a védekezést megnöveljük
            else //Egyébbként
            { Csatakör(); } //Visszatérünk ide (azaz, vagy elbasztuk, vagy a játékos csalt)
            sebesseg = sebesseg + Fajok[4].speed; //Az ellenfél kap Fajok[4].speed-nyi lehetőséget a támadásra
            int eleterokulombseg=Fajok[3].hp; //Ez a változó arra kell, ha a játékos életerőt kapna
            for (int i=1;i<=sebesseg;sebesseg--) //A csata motorja, annyiszor fut le, ahányszor támad az ellenfél [A patkány körönként 2-szer támad, ellene a páncéling jó;Az ember körönként egyszer támad;Az Ork pedig két körönként támad kétszer annyiért, ellene a pajzs a jó]
            {
                Fajok[3].hp = Fajok[3].hp - (Fajok[4].ap - Fajok[3].vedelem); //Csökkenti az életerőmet, annak fügvényében, hogy van-e páncélingem
                if (eleterokulombseg < Fajok[3].hp) //Ha a páncélingem túl erős, akkor a (Fajok[4].ap - Fajok[3].vedelem) negatív lenne, ezért hp-t kapnék
                { Fajok[3].hp = eleterokulombseg; }
                if (sebesseg == 1 && vedekezesi_ertek == 1) //Ha ez az utolsó támadása, és védekeztem, akkor...
                { Fajok[3].hp = Fajok[3].hp + Fajok[4].ap / 2; } //Növelje az életerőmet a támadásának felével (mivel a pajzs csak felét védi ki)
            }
            if (eleterokulombseg < Fajok[3].hp) //Ha több hp-m van, mint az elején, akkor...
                Fajok[3].hp = eleterokulombseg; //...akkor annyim lesz

            if (Fajok[3].hp <= 0) //Ha az ellenség meghalt, akkor...
            {
                Halal_Enabled(); //...Tiltsa le a halált
                Jutalom_Disabled(); //...Mutassa a jutalmat
                Csatakor_Disabled(); //...És kapcsolja ki a Csatát
            }
            else if (Fajok[4].hp <= 0) //Ha én haltam megm, akkor...
            {
                Jutalom_Enabled(); //...Mutassa a jutalmakat
                Halal_Disabled(); //...Tiltsa le a halált
                Csatakor_Disabled(); //...És tiltsa le a csatát
            }
            tamadas = false; //Ezekután az emberünk ne támadjon
            vedekezes = false; //Ne is védekezzen
            vedekezesi_ertek = 0; //És a védekezés mennyiségét is reseteljük
        }

        public void ButtonJutKard_Click(object sender, EventArgs e) //Ha az ellenfél legyőzése után a "Kard" jutalmat választja
        {
            Fajok[3].ap++;
            Csatakezdes();
        }
        public void ButtonJutPajzs_Click(object sender, EventArgs e) //Ha az ellenfél legyőzése után a "Pajzs" jutalmat választja
        {
            if (Fajok[3].pajzs == false) //ha még nincs pajzsa
            { Fajok[3].pajzs = true; } //akkor adjunk neki
            else                         //egyébbként
            { Fajok[3].hp = Fajok_3_max_hp; } //töltsük fel az életerejét teljesen
            Csatakezdes();
        }
        public void ButtonJutPancel_Click(object sender, EventArgs e) //Ha az ellenfél legyőzése után a "Páncél" jutalmat választja
        {
            Fajok[3].vedelem++;
            Csatakezdes();

        }
        public void Csatakezdes() //Az egész csata kezdése
        {
            Random veletlen = new Random(); //Az ellenség meghatározása
            int enemy_faj = veletlen.Next(0, 3);
            Fajok[4].hp = Fajok[enemy_faj].hp; //Adatainak átadása
            Fajok[4].ap = Fajok[enemy_faj].ap;
            Fajok[4].speed = Fajok[enemy_faj].speed;
            Fajok[4].name = Fajok[enemy_faj].name;
            Jutalom_Disabled(); //Milyen gombok legyenek jelen
            Csatakor_Enabled();
            labelEllenfel.Text = ("Az ellenfeled: " + Fajok[4].name + "!"); //Típusának kiírása
            sebesseg = 0; //Sebességének resetje
            labelEllenfel.Visible = true;
            labelSelf_hp.Visible = true;
            labelEnemy_hp.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e) //Halvány lila gőzöm sincs mi ez
        {

        }

        public void Timer1_Tick(object sender, EventArgs e) //Mi történjen minden század másodpercben
        {
            labelSelf_hp.Text = (Fajok[3].hp + " hp"); //HP kiírása
            labelEnemy_hp.Text = (Fajok[4].hp + " hp");
            if (Fajok[3].pajzs == false) //Ha nincs pajzsa, nem védekezhet
                buttonVedekezes.Enabled = false;
        }
        public void Jutalom_Enabled() //Jutalom választás kiárísa
        {
            buttonJutKard.Enabled = true;
            buttonJutKard.Visible = true;
            buttonJutPajzs.Visible = true;
            buttonJutPajzs.Enabled = true;
            buttonJutPancel.Visible = true;
            buttonJutPancel.Enabled = true;
        }
        public void Jutalom_Disabled() //Juatolm választás nem meg jelölése
        {
            buttonJutKard.Enabled = false;
            buttonJutKard.Visible = false;
            buttonJutPajzs.Visible = false;
            buttonJutPajzs.Enabled = false;
            buttonJutPancel.Visible = false;
            buttonJutPancel.Enabled = false;
        }
        public void Halal_Enabled() //Halál utáni dolgok mutatása
        {
            labelMeghaltal.Visible = true;
            buttonUjraeledes.Visible = true;
            buttonUjraeledes.Enabled = true;
        }
        public void Halal_Disabled() //Halál utáni dolgok nem mutatása
        {
            labelMeghaltal.Visible = false;
            buttonUjraeledes.Visible = false;
            buttonUjraeledes.Enabled = false;
        }
        public void Csatakor_Enabled() //Csata gombjainak mutatása
        {
            buttonTamadas.Enabled = true;
            buttonVedekezes.Enabled = true;
            buttonTamadas.Visible = true;
            buttonVedekezes.Visible = true;
        } 
        public void Csatakor_Disabled() //Csata gombjainak nem mutatása
        {
            buttonTamadas.Enabled = false;
            buttonVedekezes.Enabled = false;
            buttonTamadas.Visible = false;
            buttonVedekezes.Visible = false;
        }
           public void Terkep_Kirajzolas()//Térkép kirajzolása
           {
           Terkep = "";
               for(int i=1; i <= meret; i++)
               {
                   for (int j = 1; j <= meret; j++)
                   {
                    Terkep += terkep[i, j].map_alap; // Az elemeket egyesével behelyezzük egy string-be, új sorokkal elválasztva amkor új sor következik, majd kiírjuk
                   }
                Terkep += Environment.NewLine;
               }
               labelTerkep.Text= Terkep;

           }
           
        private void ButtonGeneralas_Click(object sender, EventArgs e) //Térkép generálás
        {
            meret = Convert.ToInt32(textBoxmeret.Text); //Megnézzük mekkora a kazamata mérete
            terkep = new Map[meret + 2, meret + 2];
            for (int i = 0; i <= meret+1; i++) //Generálunk egy akkorát
            {
                for (int j = 0; j <= meret+1; j++)
                {
                    terkep[i, j].map_alap = "#"; //Majd pedig minden celláját fallá, nem látható (jövőbeli frissítés), és semmit tartalmazóvá teszünk
                    terkep[i, j].map_targyak = "";
                    terkep[i, j].lathatosag = false;
                    if (i == 0 || j == 0 || i == meret + 1 || j == meret + 1)
                    { terkep[i, j].map_generalhato = false; }
                    else
                    { terkep[i, j].map_generalhato = true; }
                }
            }
            terkep[1, 0].map_alap = "O"; //A bejövetel helyének úttá változtatása
            terkep[1, 1].map_alap = "O";
            terkep[1, 0].map_generalhato = false;
            terkep[1, 1].map_generalhato = false;
            terkep[1, 2].map_generalhato = false;
            terkep[2, 1].map_generalhato = false;
            seged1 = 1; //Az útgenerálássi segédváltozók a bejöveteli út végeére helyezzük
            seged2 = 1; 

            Utgeneralas();//Majd pedig generálunk

            /*for (int i = 0; i < meret * 3;)
            {
                terkepgeneralasi_hibak = 0;
                Utgeneralas();
            }
            for (int j = 0; j < meret + 2; j++)
            {
                for (int l = 0; l < meret + 2; l++)
                    Terkep = Terkep + terkep[j, l].map_alap; //az elem beírása
                Terkep = Terkep + Environment.NewLine; //új sor
            } //kiírás
            labelTerkep.Text = Terkep;
            */
        }

        private void ButtonUjraeledes_Click(object sender, EventArgs e) //Újraéledés
        {
            Start();
            Csatakezdes();
        }
    }
}
