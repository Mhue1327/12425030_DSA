namespace Buoi01_DeQuy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int n1 = 5;
            Console.WriteLine($"1. Bài 1: S({n1}) = 1 + 2 + ... + {n1} = {Bai1(n1)}");

            // Bài 2: Tính S(n) = 1^2 + 2^2 + 3^2 + ... + n^2 (Ví dụ n = 4)
            int n2 = 4;
            Console.WriteLine($"2. Bài 2: S({n2}) = 1^2 + 2^2 + ... + {n2}^2 = {Bai2(n2)}");

            // Bài 3: Tính S(n) = 1 + 1/2 + 1/3 + ... + 1/n (Ví dụ n = 4)
            int n3 = 4;
            Console.WriteLine($"3. Bài 3: S({n3}) = 1 + 1/2 + ... + 1/{n3} = {Bai3(n3):F4}");

            // Bài 4: Tính S(x, n) = x^n (Ví dụ x = 2.0, n = 3)
            double x = 2.0;
            int n4 = 3;
            Console.WriteLine($"4. Bài 4: Lũy thừa {x}^{n4} = {Bai4(x, n4)}");

            // Bài 5: Tìm ước số lẻ lớn nhất của số nguyên dương n (Ví dụ n = 100, kết quả theo sách là 25)
            int n5 = 100;
            Console.WriteLine($"5. Bài 5: Ước số lẻ lớn nhất của {n5} là: {Bai5(n5)}");

            // Bài 6: Tìm ƯCLN của 2 số a, b (Ví dụ a = 24, b = 36)
            int a = 24, b = 36;
            Console.WriteLine($"6. Bài 6: ƯCLN({a}, {b}) = {Bai6(a, b)}");

            // Bài 7: Đếm số chữ số của số nguyên dương n (Ví dụ n = 12345)
            int n7 = 12345;
            Console.WriteLine($"7. Bài 7: Số chữ số của {n7} là: {Bai7(n7)}");

            // Bài 8: Tính S(n) = Can(1, n) (Ví dụ n = 4)
            int n8 = 4;
            Console.WriteLine($"8. Bài 8: S({n8}) = Can(1, {n8}) = {Bai8(1, n8):F4}");

            Console.WriteLine("\n=================================================================");
            Console.WriteLine("Nhấn phím bất kỳ để thoát chương trình...");
            Console.ReadKey();
        }
        // Bài 1: S(n) = 1 + 2 + ... + n[cite: 1]
        static int Bai1(int n)
        {
            if (n == 1) return 1;
            return Bai1(n - 1) + n;
        }

        // Bài 2: S(n) = 1^2 + 2^2 + ... + n^2[cite: 1]
        static int Bai2(int n)
        {
            if (n == 1) return 1;
            return Bai2(n - 1) + n * n;
        }

        // Bài 3: S(n) = 1 + 1/2 + 1/3 + ... + 1/n[cite: 1]
        static double Bai3(int n)
        {
            if (n == 1) return 1.0;
            return Bai3(n - 1) + 1.0 / n;
        }

        // Bài 4: Tính lũy thừa S(x, n) = x^n[cite: 1]
        static double Bai4(double x, int n)
        {
            if (n == 0) return 1.0;
            return Bai4(x, n - 1) * x;
        }

        // Bài 5: Tìm ước số lẻ lớn nhất của số nguyên dương n[cite: 2]
        static int Bai5(int n)
        {
            if (n % 2 != 0) return n;
            return Bai5(n / 2);
        }

        // Bài 6: Tìm UCLN của 2 số nguyên dương a, b (Thuật toán Euclid)[cite: 2]
        static int Bai6(int a, int b)
        {
            if (a % b == 0) return b;
            return Bai6(b, a % b);
        }

        // Bài 7: Đếm số chữ số của số nguyên dương n[cite: 2]
        static int Bai7(int n)
        {
            if (n < 10) return 1;
            return Bai7(n / 10) + 1;
        }

        // Bài 8: Tính S(n) = Can(1, n) = sqrt(1 + sqrt(2 + ... + sqrt(n)))[cite: 2]
        static double Bai8(int i, int n)
        {
            if (i == n) return Math.Sqrt(n);
            return Math.Sqrt(i + Bai8(i + 1, n));
        }
    }
}
