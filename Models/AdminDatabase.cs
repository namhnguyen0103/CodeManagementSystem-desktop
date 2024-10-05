namespace WindowsApp.Models;

public class AdminDatabase
{
    public async static Task<IEnumerable<Admin>> GetAdmins()
        {
            List<Admin> adminList = new List<Admin>(
                [
                    new Admin{AdminID = "00000001", Name = "Admin A", Email = "adminA@gmail.com", SuperAdmin=true},
                    new Admin{AdminID = "00000002", Name = "Admin B", Email = "adminB@gmail.com", SuperAdmin=true},
                    new Admin{AdminID = "00000003", Name = "Admin C", Email = "adminC@gmail.com", SuperAdmin=true},
                    new Admin{AdminID = "00000005", Name = "Admin E", Email = "adminE@gmail.com", SuperAdmin=false},
                    new Admin{AdminID = "00000004", Name = "Admin D", Email = "adminD@gmail.com", SuperAdmin=false},

                ]   
            );

            return adminList;
        }
}
