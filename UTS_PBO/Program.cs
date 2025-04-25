
namespace Kelola_Perpustakaan
{
    class Perpustakaan
    {
        public string Nama;
        public string Alamat;

        public Perpustakaan(string Nama, string Alamat)
        {
            this.Nama = Nama;
            this.Alamat = Alamat;
        }
        public void TambahBuku()
        {
            Console.WriteLine($"Buku berhasil Ditambahkan ");
        }
        public virtual void TampilkanBuku()
        {
            Console.WriteLine($"Buku yang ditampilkan");
        }
        public virtual void UpdateBuku()
        {
            Console.WriteLine($"Buku berhasil di Update");
        }

        public virtual void Delete()
        {
            Console.WriteLine($"Buku berhasil di Dalate");
        }

    }

    class Book : Perpustakaan
    {
        public int ID;
        public string Judul;
        public int TahunTerbit;

        public Book(string Nama, string Alamat, int ID, string Judul, int TahunTerbit) : base(Nama, Alamat)
        {
            this.ID = ID;
            this.Judul = Judul;
            this.TahunTerbit = TahunTerbit;
        }

        public void Cekstatus(bool Status)
        {
            string Cekstatus = Status ? "Tersedia" : "Dipinjam";
            Console.WriteLine($" {Status}");
        }
        public override void TampilkanBuku()
        {
            Console.WriteLine($"ID : {ID}");
            Console.WriteLine($"Judul : {Judul}");
            Console.WriteLine($"Tahun Terbit : {TahunTerbit}");
            Console.WriteLine($"Nama Perpustakaan : {Nama}");
            Console.WriteLine($"Alamat Perpustakaan : {Alamat}");
        }

    }
class Program
    {
        static void Main()
        {
            Perpustakaan[] Listbuku = {
            new Book("Rizqi", "Jombang", 001, "Rinjani", 2025),
            new Book("ahmad", "Banyuwangi",002, "Pulau Merah", 2024)
        };

            while (true)
            {
                Console.WriteLine("Selamat datang di Perpustakaan");
                Console.WriteLine("Silahkan pilih menu dibawah ini");
                Console.WriteLine("1. Tampilkan Buku");
                Console.WriteLine("2. Tambah Buku");
                Console.WriteLine("3. Update Buku");
                Console.WriteLine("4. Hapus Buku");
                Console.WriteLine("5. Cek Status Buku");
                Console.WriteLine("6. Keluar");

                Console.Write("Pilih menu: ");
                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        foreach (Book buku in Listbuku)
                        {
                            buku.TampilkanBuku();
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.Write("Masukkan Nama Perpustakaan: ");
                        string nama = Console.ReadLine();
                        Console.Write("Masukkan Alamat: ");
                        string alamat = Console.ReadLine();
                        Console.Write("Masukkan ID Buku: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Masukkan Judul Buku: ");
                        string judul = Console.ReadLine();
                        Console.Write("Masukkan Tahun Terbit Buku: ");
                        int tahunTerbit = Convert.ToInt32(Console.ReadLine());

                        Book bukuBaru = new Book(nama, alamat, id, judul, tahunTerbit);
                        Perpustakaan[] tempatSementara = new Perpustakaan[Listbuku.Length + 1];
                        Listbuku.CopyTo(tempatSementara, 0);
                        tempatSementara[Listbuku.Length] = bukuBaru;
                        Listbuku = tempatSementara;
                        break;
                    case 3:
                        Console.Write("Masukkan ID Buku yang ingin diupdate: ");
                        int idUpdate = Convert.ToInt32(Console.ReadLine());
                        foreach (Book buku in Listbuku)
                        {
                            if (buku.ID == idUpdate)
                            {
                                Console.Write("Masukkan Judul Buku baru: ");
                                buku.Judul = Console.ReadLine();
                                Console.Write("Masukkan Tahun Terbit Buku baru: ");
                                buku.TahunTerbit = Convert.ToInt32(Console.ReadLine());
                                buku.UpdateBuku();
                            }
                        }
                        break;
                    case 4:
                        Console.Write("Masukkan ID Buku yang ingin dihapus: ");
                        int idHapus = Convert.ToInt32(Console.ReadLine());
                        Perpustakaan[] tempatSementaraHapus = new Perpustakaan[Listbuku.Length - 1];
                        int index = 0;
                        foreach (Book buku in Listbuku)
                        {
                            if (buku.ID != idHapus)
                            {
                                tempatSementaraHapus[index] = buku;
                                index++;
                            }
                        }
                        Listbuku = tempatSementaraHapus;
                        break;
                    case 5:
                        Console.Write("Masukkan ID Buku yang ingin dicek statusnya: ");
                        int idCek = Convert.ToInt32(Console.ReadLine());
                        foreach (Book buku in Listbuku)
                        {
                            if (buku.ID == idCek)
                            {
                                buku.Cekstatus(true);
                            }
                        }
                        break;
                    case 6:
                        break;
                }
            }
        }
    }
}






