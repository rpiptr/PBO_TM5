class Program
{
    static void Main(string[] args)
    {
        Keranjang keranjang = new Keranjang();

        Elektronik tv = new Elektronik("TV", 7300000, 8);
        tv.ongkir = 13000;
        Buku komik = new Buku("Komik", 60000);
        Baju kaos = new Baju("Kaos", 45000);

        keranjang.TambahProduk(tv);
        keranjang.TambahProduk(komik);
        keranjang.TambahProduk(kaos);
        keranjang.TambahProduk("Novel", 95000);
        keranjang.TambahProduk("Majalah", 25000);
        keranjang.IsiKeranjang();
        Console.WriteLine($"Total harga belanjaan anda beserta ongkir adalah Rp{keranjang.HitungTotalHarga()}");        
    }
}

class Produk
{
    public string nama;
    public double harga;
    public double ongkir = 0;

    public Produk(string nama, double harga)
    {
        this.nama = nama;
        this.harga = harga;
    }

    public virtual double HitungOngkir()
    {
        return this.harga + ongkir;
    }

    public string info()
    {
        return $"Barang : {this.nama}\nHarga  : {this.harga}";
    }
}

class Elektronik : Produk
{
    public double berat;
    public Elektronik(string nama, double harga, double berat) : base(nama, harga)
    {
        this.berat = berat;
    }

    public override double HitungOngkir()
    {
        return this.berat * this.ongkir;
    }
}

class Baju : Produk
{
    public Baju(string nama, double harga) : base(nama, harga)
    {

    }

    public override double HitungOngkir()
    {
        ongkir = 10500;
        return ongkir;
    }
}

class Buku : Produk
{
    public Buku(string nama, double harga) : base(nama, harga)
    {
        
    }

    public override double HitungOngkir()
    {
        ongkir = 7800;
        return ongkir;
    }
}

class Keranjang
{
    public List<Produk> keranjang = new List<Produk>();

    public void TambahProduk(Produk produk)
    {
        keranjang.Add(produk);
        Console.WriteLine("Produk berhasil ditambahkan!");
    }

    public void TambahProduk(string nama, double harga)
    {
        Buku produk = new Buku(nama, harga);
        keranjang.Add(produk);
        Console.WriteLine($"Produk Buku {nama} berhasil ditambahkan!");
    }

    public void IsiKeranjang()
    {
        Console.WriteLine("\nList Belanjaan");
        foreach (Produk produk in keranjang)
        {
            Console.WriteLine(produk.info());
        }
    }

        public double HitungTotalHarga()
    {
        double total = 0;
        foreach (Produk produk in keranjang)
        {
            total += produk.harga + produk.HitungOngkir();
        }

        return total;
    }
}