using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using efcoreApp.Controllers;
namespace efcoreApp.Data
{

    public class Ogrenci
    {


        public int Id { get; set; }

        public string? OgrenciAd { get; set; }

        public string? OgrenciSoyad { get; set; }

        public string? Eposta { get; set; }

        public string? Telefon { get; set; }

        [NotMapped]
        public string AdSoyad => this.OgrenciAd+" "+this.OgrenciSoyad;

        public ICollection<KursKayıt> KursKayitları {get; set;} = new List<KursKayıt>();

    }

}