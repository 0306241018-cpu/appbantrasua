namespace WindowsFormsApp1
{
    public static class UserSession
    {
        public static int MaNV { get; set; }
        public static string TenDangNhap { get; set; }
        public static string HoTen { get; set; }
        public static string VaiTro { get; set; }
        public static bool IsLoggedIn { get; set; }

        public static void SetSession(int maNV, string tenDangNhap, string hoTen, string vaiTro)
        {
            MaNV = maNV;
            TenDangNhap = tenDangNhap;
            HoTen = hoTen;
            VaiTro = vaiTro;
            IsLoggedIn = true;
        }

        public static void ClearSession()
        {
            MaNV = 0;
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            VaiTro = string.Empty;
            IsLoggedIn = false;
        }
    }
}
