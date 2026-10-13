using System;

namespace DuongTron
{
    // 1. Định nghĩa lớp Điểm
    class Diem
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // Khởi tạo mặc định
        public Diem()
        {
            x = 0;
            y = 0;
        }

        // Khởi tạo có tham số[cite: 2]
        public Diem(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Khởi tạo sao chép[cite: 2]
        public Diem(Diem p)
        {
            X = p.X;
            Y = p.Y;
        }

        // Nhập tọa độ điểm từ bàn phím
        public void Nhap()
        {
            Console.Write("Nhap x: ");
            x = int.Parse(Console.ReadLine());
            Console.Write("Nhap y: ");
            y = int.Parse(Console.ReadLine());
        }

        // Khoảng cách giữa 2 điểm[cite: 2]
        public double KhoangCach(Diem b)
        {
            return Math.Sqrt(Math.Pow(b.X - this.X, 2) + Math.Pow(b.Y - this.Y, 2));
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    // 2. Định nghĩa lớp Đường Tròn[cite: 2, 3]
    class DuongTron
    {
        private Diem tam;
        private int banKinh;

        // Properties[cite: 3]
        public Diem Tam
        {
            get { return tam; }
            set { tam = value; }
        }

        public int BanKinh
        {
            get { return banKinh; }
            set { banKinh = value; }
        }

        // Phương thức khởi tạo mặc định[cite: 4]
        public DuongTron()
        {
            tam = new Diem();
            banKinh = 0;
        }

        // Phương thức khởi tạo khi biết đầy đủ thông tin[cite: 4]
        public DuongTron(Diem t, int r)
        {
            Tam = t;
            BanKinh = r;
        }

        // Phương thức khởi tạo sao chép[cite: 4]
        public DuongTron(DuongTron dt)
        {
            Tam = new Diem(dt.Tam); // Tạo ra một đối tượng Diem mới để tránh tham chiếu trực tiếp
            BanKinh = dt.BanKinh;
        }

        // Nhập đường tròn
        public void Nhap()
        {
            Console.WriteLine("Nhap toa do tam duong tron:");
            tam = new Diem();
            tam.Nhap();
            Console.Write("Nhap ban kinh: ");
            banKinh = int.Parse(Console.ReadLine());
        }

        // Phương thức Xuất[cite: 5]
        public void Xuat()
        {
            Console.Write("Tam: " + tam.ToString() + ", Ban kinh: " + banKinh);
        }

        // Tính chu vi đường tròn[cite: 4, 5]
        public double ChuVi()
        {
            return 2 * Math.PI * BanKinh;
        }

        // Tính diện tích đường tròn
        public double DienTich()
        {
            return Math.PI * BanKinh * BanKinh;
        }

        // Kiểm tra vị trí tương đối của một điểm với một đường tròn
        public string KiemTraViTriTuongDoi(Diem p)
        {
            double khoangCach = Tam.KhoangCach(p);
            if (khoangCach < BanKinh)
                return "Diem nam TRONG duong tron";
            if (khoangCach == BanKinh)
                return "Diem nam TREN duong tron";

            return "Diem nam NGOAI duong tron";
        }

        // Kiểm tra vị trí tương đối giữa hai đường tròn[cite: 1]
        public string KiemTraViTriTuongDoi(DuongTron dt2)
        {
            double khoangCachTam = Tam.KhoangCach(dt2.Tam);
            int r1 = this.BanKinh;
            int r2 = dt2.BanKinh;

            if (khoangCachTam > r1 + r2)
                return "Hai duong tron ROI NHAU";
            if (khoangCachTam == r1 + r2)
                return "Hai duong tron TIEP XUC NGOAI";
            if (khoangCachTam == Math.Abs(r1 - r2))
                return "Hai duong tron TIEP XUC TRONG";
            if (khoangCachTam < Math.Abs(r1 - r2))
                return "Duong tron nay CHUA duong tron kia";

            return "Hai duong tron CAT NHAU";
        }
    }

    // 3. Lớp Program để chạy thử[cite: 5]
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- KHOI TAO DUONG TRON 1 MAC DINH ---");
            DuongTron dt = new DuongTron(); //[cite: 5]
            dt.Xuat(); //[cite: 5]
            Console.WriteLine();

            Console.WriteLine("\n--- KHOI TAO DUONG TRON 2 CO THAM SO ---");
            Diem point = new Diem(1, 3); //[cite: 5]
            DuongTron dt2 = new DuongTron(point, 10); //[cite: 5]
            dt2.Xuat(); //[cite: 6]
            double chuVi2 = dt2.ChuVi(); //[cite: 6]
            Console.WriteLine("\nChu vi duong tron 2: " + Math.Round(chuVi2, 2)); //[cite: 6]
            Console.WriteLine("Dien tich duong tron 2: " + Math.Round(dt2.DienTich(), 2));

            Console.WriteLine("\n--- KHOI TAO DUONG TRON 3 (SAO CHEP TU DT 2) ---");
            DuongTron dt3 = new DuongTron(dt2); //[cite: 6]
            dt3.Xuat(); //[cite: 6]
            Console.WriteLine();

            Console.WriteLine("\n--- NHAP DUONG TRON TU BAN PHIM ---");
            DuongTron dt4 = new DuongTron();
            dt4.Nhap();
            dt4.Xuat();
            Console.WriteLine();

            Console.WriteLine("\n--- KIEM TRA VI TRI TUONG DOI ---");
            Diem diemKiemTra = new Diem(5, 5);
            Console.WriteLine("Diem kiem tra: " + diemKiemTra.ToString());
            Console.WriteLine("Vi tri diem voi DT 2: " + dt2.KiemTraViTriTuongDoi(diemKiemTra));

            Console.WriteLine("\nVi tri giua DT 2 va DT 4: " + dt2.KiemTraViTriTuongDoi(dt4));

            Console.ReadLine();
        }
    }
}
