
using System.ComponentModel.DataAnnotations;
namespace efcoreApp.Data
{

    public class KursKayıt
    {

        [Key]

        public int KayıtId { get; set; }

        public int OgrenciId { get; set; }

        public int KursId { get; set; }

        public DateTime KayıtTarihi { get; set; }

        public Ogrenci Ogrenci{ get; set; } 

        public Kurs Kurs{ get; set; }   

    }

}