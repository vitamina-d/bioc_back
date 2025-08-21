namespace Application.DTO
{
    public class EnsemblResponseDto
    {
        public string Query { get; set; }
        public string Seq { get; set; }
        public string Molecule { get; set; }
        public string Id { get; set; }
    }
}

/*
{
  "query": "11:100000..100100",
  "seq": "TGGGAGCTACAATTCAAGATGAGATTTGGGAAAGGACACAGCCAAACCACCTCATTCTGCCTCTGGCACCTCCCAAATCTCATGTCCTCACATTTCAAAAC",
  "molecule": "dna",
  "id": "chromosome:GRCh38:11:100000:100100:1"
}
*/
