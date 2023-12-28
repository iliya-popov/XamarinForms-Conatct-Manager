//Author Iliya Popov 12.12.2023
using SQLite;

namespace ContactManager.MVC
{
    public class DbCitizensModelTbl
    {
        //Primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //Max 50
        [MaxLength(50)]
        public string Names { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
