using Investing.WebApp.Pages;

namespace Investing.WebApp.Models
{
    public class Sector
    {
        public int AssetClassId { get; set; }
        public int SectorId { get; set; }
        public string Name { get; set; }

        public List<Sector> ObterListaDeSetores()
        {
            List<Sector> sectors = new List<Sector>(){
            new Sector(){ SectorId = 1, Name = "Comodities", AssetClassId = 1 },
            new Sector(){ SectorId = 2, Name = "Água e Saneamento", AssetClassId = 1 },
            new Sector(){ SectorId = 3, Name = "Energia", AssetClassId = 1 },
            new Sector(){ SectorId = 4, Name = "Financeiro", AssetClassId = 1 },
            new Sector(){ SectorId = 5, Name = "Fundos de Fundos", AssetClassId = 3 },
            new Sector(){ SectorId = 6, Name = "Shoppings", AssetClassId = 3 },
            new Sector(){ SectorId = 7, Name = "Papel", AssetClassId = 3 },
            new Sector(){ SectorId = 8, Name = "Escritórios", AssetClassId = 3 },
            new Sector(){ SectorId = 9, Name = "Logística", AssetClassId = 3 }
        };

            return sectors;
        }
    }    
}
