namespace Buoi02_DanhSach
{
    // ====== BÀI TẬP 1: ======
    public class BaiTap1
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI TẬP 1: ---");
            Console.Write("Nhập số lượng phần tử n: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            Console.WriteLine("Nhập các phần tử của mảng:");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }

            // b. Hiển thị danh sách ra màn hình
            Console.WriteLine("\n-- Mảng vừa nhập --");
            Console.WriteLine(string.Join(" ", a));

            // c. Chèn phần tử x vào vị trí k
            Console.Write("\nNhập giá trị x cần chèn: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write($"Nhập vị trí k cần chèn (0 đến {n}): ");
            int k = int.Parse(Console.ReadLine());

            if (k >= 0 && k <= n)
            {
                int[] tmp = new int[n + 1];
                for (int i = 0; i < k; i++)
                    tmp[i] = a[i];

                tmp[k] = x;

                for (int i = k; i < n; i++)
                    tmp[i + 1] = a[i];

                Console.WriteLine("Mảng sau khi chèn:");
                Console.WriteLine(string.Join(" ", tmp));
            }
            else
            {
                Console.WriteLine("Vị trí k không hợp lệ!");
            }
        }
    }

    // ====== BÀI TẬP 2: ======
    public class NhanVien
    {
        public string Manv { get; set; }
        public string Hoten { get; set; }
        public int Namsinh { get; set; }
        public string Phongban { get; set; }
        public int LuongCB { get; set; }
        public int Thuong { get; set; }

        public int ThucLinh => LuongCB + Thuong;
    }

    public class BaiTap2
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI TẬP 2: ---");
            NhanVien[] DS = new NhanVien[]
            {
                new NhanVien { Manv = "NV02", Hoten = "Nguyen Van A", Namsinh = 2000, Phongban = "IT", LuongCB = 5000000, Thuong = 1500000 },
                new NhanVien { Manv = "NV01", Hoten = "Tran Thi B", Namsinh = 2001, Phongban = "HR", LuongCB = 4000000, Thuong = 1000000 },
                new NhanVien { Manv = "NV03", Hoten = "Le Van C", Namsinh = 1999, Phongban = "IT", LuongCB = 4000000, Thuong = 1200000 }
            };

            // a. Tổng thực lĩnh
            long tongThucLinh = DS.Sum(nv => (long)nv.ThucLinh);
            Console.WriteLine($"a. Tổng thực lĩnh của tất cả nhân viên: {tongThucLinh}");

            // b. Lương cơ bản thấp nhất
            int minLuongCB = DS.Min(nv => nv.LuongCB);
            Console.WriteLine($"\nb. Nhân viên có lương cơ bản thấp nhất ({minLuongCB}):");
            foreach (var nv in DS.Where(nv => nv.LuongCB == minLuongCB))
            {
                Console.WriteLine($"- Mã: {nv.Manv}, Tên: {nv.Hoten}, Phòng: {nv.Phongban}");
            }

            // c. Số lượng nhân viên thưởng >= 1.200.000
            int countThuong = DS.Count(nv => nv.Thuong >= 1200000);
            Console.WriteLine($"\nc. Số lượng nhân viên có thưởng >= 1,200,000: {countThuong}");

            // d. Sắp xếp
            Console.WriteLine("\nd. Danh sách sắp xếp theo phòng ban (tăng) và mã NV (giảm):");
            var sortedDS = DS.OrderBy(nv => nv.Phongban).ThenByDescending(nv => nv.Manv);
            foreach (var nv in sortedDS)
            {
                Console.WriteLine($"- Phòng: {nv.Phongban}, Mã NV: {nv.Manv}, Tên: {nv.Hoten}");
            }

            // e. Tăng lương 5%
            Console.WriteLine("\ne. Cập nhật lương cơ bản sau khi tăng 5%:");
            foreach (var nv in DS)
            {
                nv.LuongCB = (int)(nv.LuongCB * 1.05);
                Console.WriteLine($"- {nv.Hoten}: Lương CB mới = {nv.LuongCB}");
            }
        }
    }

    // ====== BÀI TẬP 3: ======
    public class BaiTap3
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI TẬP 3: ---");
            int n = 3;
            int[,] a = {
                { 5, 2, 9 },
                { 1, 8, 3 },
                { 4, 6, 7 }
            };

            // a. Tổng tất cả các phần tử
            int tongMaTran = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    tongMaTran += a[i, j];
            Console.WriteLine($"a. Tổng tất cả các phần tử: {tongMaTran}");

            // b. Giá trị nhỏ nhất
            int minMatran = int.MaxValue;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] < minMatran)
                        minMatran = a[i, j];
            Console.WriteLine($"b. Giá trị nhỏ nhất trong ma trận: {minMatran}");

            // c. Tổng đường chéo chính
            int tongCheoChinh = 0;
            for (int i = 0; i < n; i++)
                tongCheoChinh += a[i, i];
            Console.WriteLine($"c. Tổng các phần tử trên đường chéo chính: {tongCheoChinh}");

            // d. Kiểm tra đường chéo chính có tăng dần không
            bool tangDan = true;
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i, i] >= a[i + 1, i + 1])
                {
                    tangDan = false;
                    break;
                }
            }
            Console.WriteLine($"d. Các phần tử trên đường chéo chính {(tangDan ? "có" : "không")} tăng dần.");
        }
    }

    // ====== BÀI TẬP 4 & 5: ======
    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int data) { Data = data; Next = null; }
    }

    public class DanhSachLienKet
    {
        public Node Head;

        public void Add(int data)
        {
            if (Head == null) { Head = new Node(data); return; }
            Node current = Head;
            while (current.Next != null) current = current.Next;
            current.Next = new Node(data);
        }

        public void Display()
        {
            Node current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public int CountX(int x)
        {
            int count = 0;
            Node cur = Head;
            while (cur != null)
            {
                if (cur.Data == x) count++;
                cur = cur.Next;
            }
            return count;
        }

        public int FindMinPositive()
        {
            int min = int.MaxValue;
            Node cur = Head;
            while (cur != null)
            {
                if (cur.Data > 0 && cur.Data < min) min = cur.Data;
                cur = cur.Next;
            }
            return min == int.MaxValue ? -1 : min;
        }

        public int FindMax()
        {
            if (Head == null) throw new InvalidOperationException("Danh sách rỗng");
            int max = Head.Data;
            Node cur = Head.Next;
            while (cur != null)
            {
                if (cur.Data > max) max = cur.Data;
                cur = cur.Next;
            }
            return max;
        }

        public int Sum()
        {
            int sum = 0;
            Node cur = Head;
            while (cur != null) { sum += cur.Data; cur = cur.Next; }
            return sum;
        }

        private bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        public int CountPrimes()
        {
            int count = 0;
            Node cur = Head;
            while (cur != null)
            {
                if (IsPrime(cur.Data)) count++;
                cur = cur.Next;
            }
            return count;
        }
    }

    public class BaiTap4Va5
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI TẬP 4 & 5: ---");
            DanhSachLienKet list = new DanhSachLienKet();
            list.Add(5);
            list.Add(-2);
            list.Add(7);
            list.Add(7);
            list.Add(3);

            Console.Write("Danh sách liên kết: ");
            list.Display();

            Console.WriteLine($"Số phần tử bằng 7: {list.CountX(7)}");
            Console.WriteLine($"Phần tử lớn nhất: {list.FindMax()}");
            Console.WriteLine($"Tổng các phần tử: {list.Sum()}");
            Console.WriteLine($"Số lượng số nguyên tố: {list.CountPrimes()}");
            Console.WriteLine($"Phần tử dương nhỏ nhất: {list.FindMinPositive()}");
        }
    }
    // ====== BÀI TẬP 7: ======
    public class BaiTap7_QuanLyNhietDo
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 7: QUẢN LÝ NHIỆT ĐỘ ---");
            Console.Write("Nhập số ngày n: ");
            int n = int.Parse(Console.ReadLine());
            double[] nhietDo = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập nhiệt độ ngày {i + 1}: ");
                nhietDo[i] = double.Parse(Console.ReadLine());
            }

            double tong = nhietDo.Sum();
            double tbTuan = tong / n;
            double maxNhietDo = nhietDo.Max();
            double minNhietDo = nhietDo.Min();

            Console.WriteLine($"\n- Nhiệt độ trung bình tuần: {tbTuan:F2}");
            Console.WriteLine($"- Nhiệt độ cao nhất: {maxNhietDo} (Ngày: {Array.IndexOf(nhietDo, maxNhietDo) + 1})");
            Console.WriteLine($"- Nhiệt độ thấp nhất: {minNhietDo} (Ngày: {Array.IndexOf(nhietDo, minNhietDo) + 1})");
        }
    }

    // ====== BÀI TẬP 8: ======
    public class BaiTap8_ThongKeTu
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 8: THỐNG KÊ TỪ TRONG CHUỖI ---");
            Console.Write("Nhập một chuỗi văn bản: ");
            string vanBan = Console.ReadLine();

            // Chuẩn hóa chuỗi: chuyển về chữ thường, xóa ký tự đặc biệt
            string cleanStr = new string(vanBan.ToLower().Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            string[] tuArray = cleanStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> thongKe = new Dictionary<string, int>();
            foreach (string tu in tuArray)
            {
                if (thongKe.ContainsKey(tu))
                    thongKe[tu]++;
                else
                    thongKe[tu] = 1;
            }

            Console.WriteLine("\nSố lần xuất hiện của mỗi từ:");
            foreach (var pair in thongKe.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"- '{pair.Key}': {pair.Value} lần");
            }
        }
    }

    // ====== BÀI TẬP 9: ======
    public class BaiTap9_XuLySoNguyen
    {
        private static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        private static bool LaSoHoanHao(int n)
        {
            if (n < 2) return false;
            int sum = 1;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                    if (i * i != n) sum += n / i;
                }
            }
            return sum == n;
        }

        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 9: XỬ LÝ SỐ NGUYÊN ---");
            Console.Write("Nhập số lượng phần tử mảng: ");
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\nKết quả phân tích:");
            Console.WriteLine($"- Các số nguyên tố: {string.Join(", ", a.Where(LaSoNguyenTo))}");
            Console.WriteLine($"- Các số chẵn: {string.Join(", ", a.Where(x => x % 2 == 0))}");
            Console.WriteLine($"- Các số hoàn hảo: {string.Join(", ", a.Where(LaSoHoanHao))}");
        }
    }

    // ====== BÀI TẬP 10: ======
    public class BaiTap10_MaTranXoanOc
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 10: MA TRẬN XOẮN ỐC N x N ---");
            Console.Write("Nhập cấp của ma trận n: ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            int val = 1, top = 0, bottom = n - 1, left = 0, right = n - 1;

            while (val <= n * n)
            {
                for (int i = left; i <= right; i++) matrix[top, i] = val++;
                top++;
                for (int i = top; i <= bottom; i++) matrix[i, right] = val++;
                right--;
                for (int i = right; i >= left; i--) matrix[bottom, i] = val++;
                bottom--;
                for (int i = bottom; i >= top; i--) matrix[i, left] = val++;
                left++;
            }

            Console.WriteLine("\nIn ma trận xoắn ốc:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j],4} ");
                }
                Console.WriteLine();
            }
        }
    }

    // ====== BÀI TẬP 11: ======
    public class BaiTap11_MaTranDacBiet
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 11: KIỂM TRA MA TRẬN ĐƠN VỊ VÀ ĐỐI XỨNG ---");
            int[,] matrixDonVi = {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };

            int[,] matrixDoiXung = {
                { 1, 2, 3 },
                { 2, 5, 6 },
                { 3, 6, 9 }
            };

            int n = 3;

            // Kiểm tra ma trận đơn vị
            bool laDonVi = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j && matrixDonVi[i, j] != 1) laDonVi = false;
                    if (i != j && matrixDonVi[i, j] != 0) laDonVi = false;
                }
            }
            Console.WriteLine($"- Ma trận 1 {(laDonVi ? "là" : "không phải là")} ma trận đơn vị.");

            // Kiểm tra ma trận đối xứng
            bool laDoiXung = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrixDoiXung[i, j] != matrixDoiXung[j, i])
                    {
                        laDoiXung = false;
                        break;
                    }
                }
            }
            Console.WriteLine($"- Ma trận 2 {(laDoiXung ? "là" : "không phải là")} ma trận đối xứng.");
        }
    }

    // ====== BÀI TẬP 12: ======
    public class BaiTap12_Minesweeper
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 12: GAME MINESWEEPER ---");
            int m = 4, n = 4;
            // Ký hiệu -1 là mìn, các ô khác tạm để 0
            int[,] board = {
                {  0, -1,  0,  0 },
                {  0,  0, -1,  0 },
                { -1,  0,  0,  0 },
                {  0,  0,  0,  0 }
            };

            int[,] result = new int[m, n];
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (board[i, j] == -1)
                    {
                        result[i, j] = -1; // Ô chứa mìn
                        continue;
                    }

                    int count = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        int ni = i + dx[k];
                        int nj = j + dy[k];
                        if (ni >= 0 && ni < m && nj >= 0 && nj < n && board[ni, nj] == -1)
                        {
                            count++;
                        }
                    }
                    result[i, j] = count;
                }
            }

            Console.WriteLine("Bảng Minesweeper (Số mìn xung quanh mỗi ô):");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string cell = result[i, j] == -1 ? "M" : result[i, j].ToString();
                    Console.Write($"{cell,3} ");
                }
                Console.WriteLine();
            }
        }
    }

    // ===========================
    // CLASS HỖ TRỢ BÀI 13, 14, 15
    // ===========================
    public class SinglyNode
    {
        public int Data;
        public SinglyNode Next;
        public SinglyNode(int data) { Data = data; Next = null; }
    }

    public class SinglyLinkedList
    {
        public SinglyNode Head;

        public void Add(int data)
        {
            if (Head == null) { Head = new SinglyNode(data); return; }
            SinglyNode cur = Head;
            while (cur.Next != null) cur = cur.Next;
            cur.Next = new SinglyNode(data);
        }

        public void Display()
        {
            SinglyNode cur = Head;
            while (cur != null)
            {
                Console.Write(cur.Data + " ");
                cur = cur.Next;
            }
            Console.WriteLine();
        }

        // ====== BÀI TẬP 13: ======
        public void DaoNguoc()
        {
            SinglyNode prev = null;
            SinglyNode current = Head;
            SinglyNode next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }

        // ====== BÀI TẬP 14: ======
        public static SinglyLinkedList GopHaiDanhSach(SinglyLinkedList l1, SinglyLinkedList l2)
        {
            SinglyLinkedList gop = new SinglyLinkedList();
            SinglyNode p1 = l1.Head;
            SinglyNode p2 = l2.Head;

            while (p1 != null && p2 != null)
            {
                if (p1.Data <= p2.Data)
                {
                    gop.Add(p1.Data);
                    p1 = p1.Next;
                }
                else
                {
                    gop.Add(p2.Data);
                    p2 = p2.Next;
                }
            }
            while (p1 != null) { gop.Add(p1.Data); p1 = p1.Next; }
            while (p2 != null) { gop.Add(p2.Data); p2 = p2.Next; }
            return gop;
        }

        // ====== BÀI TẬP 15: ======
        public bool CoChuTrinh()
        {
            SinglyNode slow = Head;
            SinglyNode fast = Head;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) return true;
            }
            return false;
        }
    }

    public class BaiTap13_DaoNguocDSLKD
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 13: ĐẢO NGƯỢC DANH SÁCH LIÊN KẾT ĐƠN ---");
            SinglyLinkedList list = new SinglyLinkedList();
            list.Add(1); list.Add(2); list.Add(3); list.Add(4);
            Console.Write("Danh sách ban đầu: ");
            list.Display();

            list.DaoNguoc();
            Console.Write("Danh sách sau khi đảo ngược: ");
            list.Display();
        }
    }

    public class BaiTap14_GopDanhSach
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 14: GỘP HAI DANH SÁCH ĐÃ SẮP XẾP ---");
            SinglyLinkedList l1 = new SinglyLinkedList();
            l1.Add(1); l1.Add(3); l1.Add(5);

            SinglyLinkedList l2 = new SinglyLinkedList();
            l2.Add(2); l2.Add(4); l2.Add(6);

            Console.Write("Danh sách 1: "); l1.Display();
            Console.Write("Danh sách 2: "); l2.Display();

            SinglyLinkedList lGop = SinglyLinkedList.GopHaiDanhSach(l1, l2);
            Console.Write("Danh sách sau khi gộp: "); lGop.Display();
        }
    }

    public class BaiTap15_PhatHienChuTrinh
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 15: PHÁT HIỆN CHU TRÌNH TRONG DSLK ---");
            SinglyLinkedList list = new SinglyLinkedList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Tạo chu trình thủ công để kiểm tra (Node cuối trỏ về node số 2)
            list.Head.Next.Next.Next = list.Head.Next;

            bool hasCycle = list.CoChuTrinh();
            Console.WriteLine($"Danh sách trên {(hasCycle ? "CÓ" : "KHÔNG CÓ")} chứa chu trình.");
        }
    }

    // ====== BÀI TẬP 16: ======
    public class WebPageNode
    {
        public string Url;
        public WebPageNode Prev;
        public WebPageNode Next;
        public WebPageNode(string url) { Url = url; }
    }

    public class BrowserHistory
    {
        private WebPageNode current;

        public void Visit(string url)
        {
            WebPageNode newNode = new WebPageNode(url);
            if (current != null)
            {
                current.Next = newNode;
                newNode.Prev = current;
            }
            current = newNode;
            Console.WriteLine($"Đang truy cập: {url}");
        }

        public void Back()
        {
            if (current != null && current.Prev != null)
            {
                current = current.Prev;
                Console.WriteLine($"Quay lại (Back): {current.Url}");
            }
            else
            {
                Console.WriteLine("Không thể quay lại trang trước.");
            }
        }

        public void Forward()
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
                Console.WriteLine($"Tiến tới (Forward): {current.Url}");
            }
            else
            {
                Console.WriteLine("Không thể tiến tới trang sau.");
            }
        }
    }

    public class BaiTap16_LichSuTrinhDuyet
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 16: HỆ THỐNG LỊCH SỬ TRÌNH DUYỆT WEB ---");
            BrowserHistory browser = new BrowserHistory();
            browser.Visit("google.com");
            browser.Visit("github.com");
            browser.Visit("stackoverflow.com");

            browser.Back(); // Về github.com
            browser.Back(); // Về google.com
            browser.Forward(); // Tiến tới github.com
        }
    }

    // ====== BÀI TẬP 18: ======
    public enum OrderStatus { ChoXuLy, DangGiao, HoanThanh }

    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.ChoXuLy;

        public void NextStatus()
        {
            if (Status == OrderStatus.ChoXuLy) Status = OrderStatus.DangGiao;
            else if (Status == OrderStatus.DangGiao) Status = OrderStatus.HoanThanh;
            else Console.WriteLine("Đơn hàng đã hoàn thành, không thể chuyển trạng thái!");
        }
    }

    public class BaiTap18_HeThongDatHang
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 18: HỆ THỐNG QUẢN LÝ ĐƠN HÀNG ---");
            Order order = new Order { OrderId = "DH001", CustomerName = "Nguyen Thi Minh Hue" };

            Console.WriteLine($"Đơn hàng: {order.OrderId} - Khách: {order.CustomerName} - Trạng thái: {order.Status}");

            order.NextStatus();
            Console.WriteLine($"-> Chuyển trạng thái: {order.Status}");

            order.NextStatus();
            Console.WriteLine($"-> Chuyển trạng thái: {order.Status}");
        }
    }

    // ====== BÀI TẬP 17: ======
    public class SongNode
    {
        public string Title;
        public SongNode Prev;
        public SongNode Next;
        public SongNode(string title) { Title = title; }
    }

    public class Playlist
    {
        private SongNode head;
        private SongNode current;

        public void AddSong(string title)
        {
            SongNode newNode = new SongNode(title);
            if (head == null)
            {
                head = newNode;
                current = head;
            }
            else
            {
                SongNode temp = head;
                while (temp.Next != null) temp = temp.Next;
                temp.Next = newNode;
                newNode.Prev = temp;
            }
            Console.WriteLine($"Đã thêm bài hát: {title}");
        }

        public void PlayCurrent()
        {
            if (current != null)
                Console.WriteLine($"\n▶ Đang phát: [{current.Title}]");
            else
                Console.WriteLine("\nPlaylist trống!");
        }

        public void NextSong()
        {
            if (current != null && current.Next != null)
            {
                current = current.Next;
                PlayCurrent();
            }
            else
            {
                Console.WriteLine("Đây là bài cuối cùng trong playlist.");
            }
        }

        public void PrevSong()
        {
            if (current != null && current.Prev != null)
            {
                current = current.Prev;
                PlayCurrent();
            }
            else
            {
                Console.WriteLine("Đây là bài đầu tiên trong playlist.");
            }
        }
    }

    public class BaiTap17_PlaylistNhac
    {
        public static void Chay()
        {
            Console.WriteLine("\n--- BÀI 17: HỆ THỐNG PLAYLIST NHẠC ---");
            Playlist myPlaylist = new Playlist();
            myPlaylist.AddSong("Em của ngày hôm qua");
            myPlaylist.AddSong("Chúng ta của hiện tại");
            myPlaylist.AddSong("Hãy trao cho anh");

            myPlaylist.PlayCurrent();
            Console.WriteLine("Chuyển bài tiếp theo (Next):");
            myPlaylist.NextSong();
            Console.WriteLine("Quay lại bài trước (Previous):");
            myPlaylist.PrevSong();
        }
    }
    // ====== CLASS MAIN ======
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("CHỌN BÀI TẬP ĐỂ CHẠY:");
                Console.WriteLine("1. Bài tập 1 (Mảng một chiều)");
                Console.WriteLine("2. Bài tập 2 (Quản lý nhân viên)");
                Console.WriteLine("3. Bài tập 3 (Ma trận vuông)");
                Console.WriteLine("4. Bài tập 4 & 5 (Danh sách liên kết đơn)");
                Console.WriteLine("7. Bài 7 (Quản lý nhiệt độ)");
                Console.WriteLine("8. Bài 8 (Thống kê từ trong chuỗi)");
                Console.WriteLine("9. Bài 9 (Xử lý số nguyên: nguyên tố, chẵn, hoàn hảo)");
                Console.WriteLine("10. Bài 10 (Tạo ma trận xoắn ốc)");
                Console.WriteLine("17. Bài 17 (Playlist nhạc - Danh sách liên kết kép)");
                Console.WriteLine("11. Bài 11 (Kiểm tra ma trận đặc biệt)");
                Console.WriteLine("12. Bài 12 (Game Minesweeper)");
                Console.WriteLine("13. Bài 13 (Đảo ngược danh sách liên kết đơn)");
                Console.WriteLine("14. Bài 14 (Gộp hai danh sách đã sắp xếp)");
                Console.WriteLine("15. Bài 15 (Phát hiện chu trình trong DSLK)");
                Console.WriteLine("16. Bài 16 (Hệ thống lịch sử duyệt web)");
                Console.WriteLine("18. Bài 18 (Hệ thống quản lý đặt hàng)");
                Console.WriteLine("0. Thoát chương trình");
                Console.Write("Nhập lựa chọn của bạn (0-18): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        BaiTap1.Chay();
                        break;
                    case "2":
                        BaiTap2.Chay();
                        break;
                    case "3":
                        BaiTap3.Chay();
                        break;
                    case "4":
                        BaiTap4Va5.Chay();
                        break;
                    case "7":
                        BaiTap7_QuanLyNhietDo.Chay();
                        break;
                    case "8":
                        BaiTap8_ThongKeTu.Chay();
                        break;
                    case "9":
                        BaiTap9_XuLySoNguyen.Chay();
                        break;
                    case "10":
                        BaiTap10_MaTranXoanOc.Chay();
                        break;
                    case "17":
                        BaiTap17_PlaylistNhac.Chay();
                        break;
                    case "11":
                        BaiTap11_MaTranDacBiet.Chay();
                        break;
                    case "12":
                        BaiTap12_Minesweeper.Chay();
                        break;
                    case "13":
                        BaiTap13_DaoNguocDSLKD.Chay();
                        break;
                    case "14":
                        BaiTap14_GopDanhSach.Chay();
                        break;
                    case "15":
                        BaiTap15_PhatHienChuTrinh.Chay();
                        break;
                    case "16":
                        BaiTap16_LichSuTrinhDuyet.Chay();
                        break;
                    case "18":
                        BaiTap18_HeThongDatHang.Chay();
                        break;
                    case "0":
                        Console.WriteLine("Đang thoát chương trình. Tạm biệt!");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }
            }
        }
    }
}
