namespace KruAll.Core.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KrutecPZE : DbContext
    {
        public KrutecPZE()
            : base("name=KrutecPZE")
        {
        }

        public virtual DbSet<Abteilungen> Abteilungens { get; set; }
        public virtual DbSet<Kostenstellen> Kostenstellens { get; set; }
        public virtual DbSet<Personalstamm> Personalstamms { get; set; }
        public virtual DbSet<Werke> Werkes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abteilungen>()
                .Property(e => e.Abt_Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<Abteilungen>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Kostenstellen>()
                .Property(e => e.Kos_Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<Kostenstellen>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Name1)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Name2)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Str)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Ort)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Mobil)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Info)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Bank)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Blz)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Kto)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Finanzamt)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Nation)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Familienstand)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Religion)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_SozVersNr)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Qualifikation)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Foto)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Krankenkasse)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_KassenVersNr)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Geschlecht)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_PinCode)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_TagesschieneNr)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.TabAbw)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z1)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z2)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z3)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z4)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z5)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z6)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z7)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z8)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z9)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_Z10)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.INFO1)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.INFO2)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.INFO3)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.INFO4)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_TEMPLATE)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.pers_position)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.PERS_HZO2)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Anrede)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_GebOrt)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Kinder)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Beruf)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_StdZahl)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z11)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z12)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z13)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z14)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z15)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z16)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z17)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z18)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z19)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Z20)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_FSchein)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_StKlasse)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Pre_Ausweis_Nr)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Pre_Ausweis_Nr2)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Prefix)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_ParkplatzFirma)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_ParkplatzKennzeichen)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_ParkplatzAutomarke)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_ParkplatzTyp)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_ParkplatzFarbe)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_WoProg)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_LKenner)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Titel)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Name12)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Bic)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Pers_Iban)
                .IsUnicode(false);

            modelBuilder.Entity<Personalstamm>()
                .Property(e => e.Berufsschule)
                .IsUnicode(false);

            modelBuilder.Entity<Werke>()
                .Property(e => e.W_Bezeichnung)
                .IsUnicode(false);

            modelBuilder.Entity<Werke>()
                .Property(e => e.W_Str)
                .IsUnicode(false);

            modelBuilder.Entity<Werke>()
                .Property(e => e.W_Ort)
                .IsUnicode(false);

            modelBuilder.Entity<Werke>()
                .Property(e => e.W_Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Werke>()
                .Property(e => e.W_Bundesland)
                .IsUnicode(false);
        }
    }
}
