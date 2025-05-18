namespace SistemManajemenPerpustakaan
{
    public abstract class ItemPerpustakaan
    {
        public string ID { get; set; }
        public string Judul { get; set; }
        public int TahunTerbit { get; set; }

        public ItemPerpustakaan(string id, string judul, int tahunTerbit)
        {
            ID = id;
            Judul = judul;
            TahunTerbit = tahunTerbit;
        }

        public abstract void TampilkanInfo();
    }

    public class Buku : ItemPerpustakaan
    {
        public string Penulis { get; set; }
        public bool StatusTersedia { get; set; }

        public Buku(string id, string judul, string penulis, int tahunTerbit, bool statusTersedia = true)
            : base(id, judul, tahunTerbit)
        {
            Penulis = penulis;
            StatusTersedia = statusTersedia;
        }

        public override void TampilkanInfo()
        {
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Judul: {Judul}");
            Console.WriteLine($"Penulis: {Penulis}");
            Console.WriteLine($"Tahun Terbit: {TahunTerbit}");
            Console.WriteLine($"Status: {(StatusTersedia ? "Tersedia" : "Dipinjam")}");
            Console.WriteLine();
        }
    }

    public class Perpustakaan
    {
        public string Nama { get; set; }
        public string Alamat { get; set; }
        private List<Buku> DaftarBuku { get; set; }

        public Perpustakaan(string nama, string alamat)
        {
            Nama = nama;
            Alamat = alamat;
            DaftarBuku = new List<Buku>();
        }

        public void TambahBuku(Buku buku)
        {
            foreach (var b in DaftarBuku)
            {
                if (b.ID.ToLower() == buku.ID.ToLower())
                {
                    Console.WriteLine("Buku dengan ID tersebut sudah ada dalam koleksi!");
                    return;
                }
            }

            DaftarBuku.Add(buku);
            Console.WriteLine("Buku berhasil ditambahkan ke koleksi!");
        }

        public void TampilkanSemuaBuku()
        {
            if (DaftarBuku.Count == 0)
            {
                Console.WriteLine("Koleksi buku kosong!");
                return;
            }

            Console.WriteLine($"\nDaftar Buku di {Nama}:");
            Console.WriteLine("============================");

            foreach (Buku buku in DaftarBuku)
            {
                buku.TampilkanInfo();
            }
        }

        public Buku CariBukuDenganId(string id)
        {
            foreach (var b in DaftarBuku)
            {
                if (b.ID.ToLower() == id.ToLower())
                {
                    return b;
                }
            }
            return null;
        }

        public List<Buku> CariBukuDenganJudul(string judul)
        {
            List<Buku> hasil = new List<Buku>();
            foreach (var b in DaftarBuku)
            {
                if (b.Judul.ToLower().Contains(judul.ToLower()))
                {
                    hasil.Add(b);
                }
            }
            return hasil;
        }

        public void PerbaruiBuku(string id, string judul, string penulis, int tahunTerbit, bool statusTersedia)
        {
            Buku buku = CariBukuDenganId(id);

            if (buku == null)
            {
                Console.WriteLine("Buku tidak ditemukan!");
                return;
            }

            buku.Judul = judul;
            buku.Penulis = penulis;
            buku.TahunTerbit = tahunTerbit;
            buku.StatusTersedia = statusTersedia;

            Console.WriteLine("Informasi buku berhasil diperbarui!");
        }

        public void HapusBuku(string id)
        {
            Buku buku = CariBukuDenganId(id);

            if (buku == null)
            {
                Console.WriteLine("Buku tidak ditemukan!");
                return;
            }

            DaftarBuku.Remove(buku);
            Console.WriteLine("Buku berhasil dihapus dari koleksi!");
        }

        public void TampilkanInfoPerpustakaan()
        {
            Console.WriteLine($"Nama Perpustakaan: {Nama}");
            Console.WriteLine($"Alamat: {Alamat}");
            Console.WriteLine($"Jumlah Koleksi Buku: {DaftarBuku.Count}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            Perpustakaan perpustakaan = new Perpustakaan("Perpustakaan UNEJ", "Jl. Kalimantan No. 12");
            perpustakaan.TambahBuku(new Buku("B001", "Pemrograman C#", "Rizqi", 2025));
            perpustakaan.TambahBuku(new Buku("B002", "Rinjani", "Dimas", 2015));
            perpustakaan.TambahBuku(new Buku("B003", "Alam Semesta", "rayhan", 2021, false));

            bool berjalan = true;

            while (berjalan)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEM MANAJEMEN PERPUSTAKAAN ===");
                perpustakaan.TampilkanInfoPerpustakaan();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Tampilkan Semua Buku");
                Console.WriteLine("2. Cari Buku berdasarkan ID");
                Console.WriteLine("3. Cari Buku berdasarkan Judul");
                Console.WriteLine("4. Tambah Buku Baru");
                Console.WriteLine("5. Edit Informasi Buku");
                Console.WriteLine("6. Hapus Buku");
                Console.WriteLine("0. Keluar");
                Console.Write("\nPilih menu: ");

                if (int.TryParse(Console.ReadLine(), out int pilihan))
                {
                    Console.WriteLine();

                    switch (pilihan)
                    {
                        case 1:
                            perpustakaan.TampilkanSemuaBuku();
                            break;

                        case 2:
                            Console.Write("Masukkan ID buku: ");
                            string idBuku = Console.ReadLine();
                            Buku bukuDitemukan = perpustakaan.CariBukuDenganId(idBuku);

                            if (bukuDitemukan != null)
                            {
                                Console.WriteLine("\nBuku ditemukan:");
                                bukuDitemukan.TampilkanInfo();
                            }
                            else
                            {
                                Console.WriteLine("Buku tidak ditemukan!");
                            }
                            break;

                        case 3:
                            Console.Write("Masukkan judul buku: ");
                            string judulBuku = Console.ReadLine();
                            List<Buku> daftarBuku = perpustakaan.CariBukuDenganJudul(judulBuku);

                            if (daftarBuku.Any())
                            {
                                Console.WriteLine($"\nDitemukan {daftarBuku.Count} buku:");
                                foreach (Buku buku in daftarBuku)
                                {
                                    buku.TampilkanInfo();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Tidak ada buku yang sesuai dengan kriteria pencarian!");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Tambah Buku Baru");
                            Console.Write("ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Judul: ");
                            string judul = Console.ReadLine();
                            Console.Write("Penulis: ");
                            string penulis = Console.ReadLine();
                            Console.Write("Tahun Terbit: ");
                            if (int.TryParse(Console.ReadLine(), out int tahun))
                            {
                                Buku bukuBaru = new Buku(id, judul, penulis, tahun);
                                perpustakaan.TambahBuku(bukuBaru);
                            }
                            else
                            {
                                Console.WriteLine("Format tahun tidak valid!");
                            }
                            break;

                        case 5:
                            Console.Write("Masukkan ID buku yang ingin diedit: ");
                            string idEdit = Console.ReadLine();
                            Buku bukuEdit = perpustakaan.CariBukuDenganId(idEdit);

                            if (bukuEdit != null)
                            {
                                Console.WriteLine("\nInformasi Buku Saat Ini:");
                                bukuEdit.TampilkanInfo();

                                Console.WriteLine("Masukkan informasi baru:");
                                Console.Write("Judul: ");
                                string judulBaru = Console.ReadLine();
                                Console.Write("Penulis: ");
                                string penulisBaru = Console.ReadLine();
                                Console.Write("Tahun Terbit: ");
                                if (int.TryParse(Console.ReadLine(), out int tahunBaru))
                                {
                                    Console.Write("Status (1: Tersedia, 0: Dipinjam): ");
                                    if (int.TryParse(Console.ReadLine(), out int statusInput))
                                    {
                                        bool statusBaru = statusInput == 1;
                                        perpustakaan.PerbaruiBuku(idEdit, judulBaru, penulisBaru, tahunBaru, statusBaru);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Format status tidak valid!");
                                    }
                                }
                                    else
                                    {
                                        Console.WriteLine("Format tahun tidak valid!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Buku tidak ditemukan!");
                                }
                                break;

                        case 6:
                            Console.Write("Masukkan ID buku yang ingin dihapus: ");
                            string idHapus = Console.ReadLine();
                            perpustakaan.HapusBuku(idHapus);
                            break;

                        case 0:
                            berjalan = false;
                            Console.WriteLine("Terima kasih telah menggunakan Sistem Manajemen Perpustakaan!");
                            break;

                        default:
                            Console.WriteLine("Pilihan tidak valid!");
                            break;
                    }

                    if (berjalan)
                    {
                        Console.WriteLine("\nTekan Enter untuk kembali ke menu...");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Input tidak valid! Tekan Enter untuk melanjutkan...");
                    Console.ReadLine();
                }
            }
        }
    }
}
