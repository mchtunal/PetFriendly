namespace PetFriendly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetFriendly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetFriendly.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.Sehirler.Any())
            {
                foreach (KeyValuePair<int, string> entry in TurkiyeIller())
                {
                    context.Sehirler.Add(
                        new Models.Sehir { Id = entry.Key, SehirAd = entry.Value }
                    );
                }
            }
        }

        private Dictionary<int, string> TurkiyeIller()
        {
            return new Dictionary<int, string>
                {
                    {1, "Adana"},
                    {2, "Ad�yaman"},
                    {3, "Afyonkarahisar"},
                    {4, "A�r�"},
                    {5, "Amasya"},
                    {6, "Ankara"},
                    {7, "Antalya"},
                    {8, "Artvin"},
                    {9, "Ayd�n"},
                    {10, "Bal�kesir"},
                    {11, "Bilecik"},
                    {12, "Bing�l"},
                    {13, "Bitlis"},
                    {14, "Bolu"},
                    {15, "Burdur"},
                    {16, "Bursa"},
                    {17, "�anakkale"},
                    {18, "�ank�r�"},
                    {19, "�orum"},
                    {20, "Denizli"},
                    {21, "Diyarbak�r"},
                    {22, "Edirne"},
                    {23, "Elaz��"},
                    {24, "Erzincan"},
                    {25, "Erzurum"},
                    {26, "Eski�ehir"},
                    {27, "Gaziantep"},
                    {28, "Giresun"},
                    {29, "G�m��hane"},
                    {30, "Hakkari"},
                    {31, "Hatay"},
                    {32, "Isparta"},
                    {33, "Mersin"},
                    {34, "�stanbul"},
                    {35, "�zmir"},
                    {36, "Kars"},
                    {37, "Kastamonu"},
                    {38, "Kayseri"},
                    {39, "K�rklareli"},
                    {40, "K�r�ehir"},
                    {41, "Kocaeli"},
                    {42, "Konya"},
                    {43, "K�tahya"},
                    {44, "Malatya"},
                    {45, "Manisa"},
                    {46, "Kahramanmara�"},
                    {47, "Mardin"},
                    {48, "Mu�la"},
                    {49, "Mu�"},
                    {50, "Nev�ehir"},
                    {51, "Ni�de"},
                    {52, "Ordu"},
                    {53, "Rize"},
                    {54, "Sakarya"},
                    {55, "Samsun"},
                    {56, "Siirt"},
                    {57, "Sinop"},
                    {58, "Sivas"},
                    {59, "Tekirda�"},
                    {60, "Tokat"},
                    {61, "Trabzon"},
                    {62, "Tunceli"},
                    {63, "�anl�urfa"},
                    {64, "U�ak"},
                    {65, "Van"},
                    {66, "Yozgat"},
                    {67, "Zonguldak"},
                    {68, "Aksaray"},
                    {69, "Bayburt"},
                    {70, "Karaman"},
                    {71, "K�r�kkale"},
                    {72, "Batman"},
                    {73, "��rnak"},
                    {74, "Bart�n"},
                    {75, "Ardahan"},
                    {76, "I�d�r"},
                    {77, "Yalova"},
                    {78, "Karab�k"},
                    {79, "Kilis"},
                    {80, "Osmaniye"},
                    {81, "D�zce"}
                };
        }
    }
}
