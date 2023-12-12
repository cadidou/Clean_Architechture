namespace Bibio.API.DTO
{
    public class OuvrageDto
    {

       
        public string Id { get; set; }
        public string? titre { get; set; }
        public string? auteur { get; set; }
        public string? domain { get; set; }

        public int Nbr { get; set; }
        public bool consultable { get; set; }
    }
}
