using System;
using System.Globalization;
using System.Text;

class Program
{
    // Đọc số nguyên dương n > 0
    static int NhapSoLuong()
    {
        int n;
        while (true)
        {
            Console.Write("Nhập số lượng sinh viên (n > 0): ");
            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
                return n;
            Console.WriteLine("  -> Giá trị không hợp lệ, vui lòng nhập lại!");
        }
    }

    // Đọc điểm trong khoảng 0 - 10
    static double NhapDiem(string ten)
    {
        while (true)
        {
            Console.Write($"  Điểm của {ten} (0 - 10): ");
            string s = (Console.ReadLine() ?? "").Trim().Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double d)
                && d >= 0 && d <= 10)
                return d;
            Console.WriteLine("  -> Điểm không hợp lệ, vui lòng nhập lại!");
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // 1. Nhập số lượng
        int n = NhapSoLuong();

        string[] hoTen = new string[n];
        double[] diem = new double[n];

        // 2. Nhập thông tin
        Console.WriteLine("\n--- NHẬP THÔNG TIN SINH VIÊN ---");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Sinh viên thứ {i + 1}:");
            string ten;
            do
            {
                Console.Write("  Họ và tên: ");
                ten = (Console.ReadLine() ?? "").Trim();
            } while (ten == "");

            hoTen[i] = ten;
            diem[i] = NhapDiem(ten);
        }

        // 3. Điểm trung bình
        double tong = 0;
        for (int i = 0; i < n; i++) tong += diem[i];
        double diemTB = tong / n;

        // 4. Điểm cao nhất (Max) và sinh viên đạt điểm đó
        double max = diem[0];
        for (int i = 1; i < n; i++)
            if (diem[i] > max) max = diem[i];

        // 5. Đếm số sinh viên đạt (>= 5.0)
        int soDat = 0;
        for (int i = 0; i < n; i++)
            if (diem[i] >= 5.0) soDat++;

        // 6. In bảng danh sách
        Console.WriteLine("\n================ DANH SÁCH LỚP ================");
        Console.WriteLine($"{"STT",-5}{"Họ và tên",-30}{"Điểm",6}");
        Console.WriteLine(new string('-', 41));
        for (int i = 0; i < n; i++)
            Console.WriteLine($"{i + 1,-5}{hoTen[i],-30}{diem[i],6:F1}");
        Console.WriteLine(new string('-', 41));

        // Kết quả thống kê
        Console.WriteLine($"Điểm trung bình cả lớp : {diemTB:F2}");
        Console.WriteLine($"Điểm cao nhất          : {max:F1}");
        Console.Write("Sinh viên điểm cao nhất: ");
        bool dauTien = true;
        for (int i = 0; i < n; i++)
        {
            if (diem[i] == max)
            {
                Console.Write((dauTien ? "" : ", ") + hoTen[i]);
                dauTien = false;
            }
        }
        Console.WriteLine();
        Console.WriteLine($"Số sinh viên đạt (>= 5): {soDat}/{n}");

        Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}