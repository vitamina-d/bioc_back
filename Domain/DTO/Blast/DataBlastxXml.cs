using System.Xml.Serialization;

namespace Domain.DTO.Blast
{
    [XmlRoot("BlastOutput")]
    public class DataBlastXml
    {
        [XmlElement("BlastOutput_program")]
        public string Program { get; set; }

        [XmlElement("BlastOutput_version")]
        public string Version { get; set; }

        [XmlElement("BlastOutput_reference")]
        public string Reference { get; set; }

        [XmlElement("BlastOutput_db")]
        public string Database { get; set; }

        [XmlElement("BlastOutput_query-ID")]
        public string QueryId { get; set; }

        [XmlElement("BlastOutput_query-def")]
        public string QueryDef { get; set; }

        [XmlElement("BlastOutput_query-len")]
        public int QueryLength { get; set; }

        [XmlElement("BlastOutput_param")]
        public BlastOutputParamXml ParametersBlock { get; set; }

        [XmlArray("BlastOutput_iterations")]
        [XmlArrayItem("Iteration")]
        public List<IterationXml> Iterations { get; set; }
    }

    public class BlastOutputParamXml
    {
        [XmlElement("Parameters")]
        public ParametersXml Parameters { get; set; }
    }

    public class ParametersXml
    {
        [XmlElement("Parameters_matrix")]
        public string Matrix { get; set; }

        [XmlElement("Parameters_expect")]
        public double Expect { get; set; }

        [XmlElement("Parameters_gap-open")]
        public int GapOpen { get; set; }

        [XmlElement("Parameters_gap-extend")]
        public int GapExtend { get; set; }

        [XmlElement("Parameters_filter")]
        public string Filter { get; set; }
    }

    public class IterationXml
    {
        [XmlElement("Iteration_iter-num")]
        public int IterNum { get; set; }

        [XmlElement("Iteration_query-ID")]
        public string QueryId { get; set; }

        [XmlElement("Iteration_query-def")]
        public string QueryDef { get; set; }

        [XmlElement("Iteration_query-len")]
        public int QueryLength { get; set; }

        [XmlArray("Iteration_hits")]
        [XmlArrayItem("Hit")]
        public List<HitXml> Hits { get; set; }
    }

    public class HitXml
    {
        [XmlElement("Hit_num")]
        public int Num { get; set; }

        [XmlElement("Hit_id")]
        public string Id { get; set; }

        [XmlElement("Hit_def")]
        public string Definition { get; set; }

        [XmlElement("Hit_accession")]
        public string Accession { get; set; }

        [XmlElement("Hit_len")]
        public int Length { get; set; }

        [XmlArray("Hit_hsps")]
        [XmlArrayItem("Hsp")]
        public List<HspXml> Hsps { get; set; }
    }

    public class HspXml
    {
        [XmlElement("Hsp_num")]
        public int Num { get; set; }

        [XmlElement("Hsp_bit-score")]
        public double BitScore { get; set; }

        [XmlElement("Hsp_score")]
        public int Score { get; set; }

        [XmlElement("Hsp_evalue")]
        public double EValue { get; set; }

        [XmlElement("Hsp_query-from")]
        public int QueryFrom { get; set; }

        [XmlElement("Hsp_query-to")]
        public int QueryTo { get; set; }

        [XmlElement("Hsp_hit-from")]
        public int HitFrom { get; set; }

        [XmlElement("Hsp_hit-to")]
        public int HitTo { get; set; }

        [XmlElement("Hsp_query-frame")]
        public int QueryFrame { get; set; }

        [XmlElement("Hsp_hit-frame")]
        public int HitFrame { get; set; }

        [XmlElement("Hsp_identity")]
        public int Identity { get; set; }

        [XmlElement("Hsp_positive")]
        public int Positive { get; set; }

        [XmlElement("Hsp_gaps")]
        public int Gaps { get; set; }

        [XmlElement("Hsp_align-len")]
        public int AlignLen { get; set; }

        [XmlElement("Hsp_qseq")]
        public string QuerySeq { get; set; }

        [XmlElement("Hsp_hseq")]
        public string HitSeq { get; set; }

        [XmlElement("Hsp_midline")]
        public string Midline { get; set; }
    }
    public class IterationStatXml
    {
        [XmlElement("Statistics")]
        public StatisticsXml Statistics { get; set; }
    }

    public class StatisticsXml
    {
        [XmlElement("Statistics_db-num")]
        public long DbNum { get; set; }

        [XmlElement("Statistics_db-len")]
        public long DbLen { get; set; }

        [XmlElement("Statistics_hsp-len")]
        public int HspLen { get; set; }

        [XmlElement("Statistics_eff-space")]
        public long EffSpace { get; set; }

        [XmlElement("Statistics_kappa")]
        public double Kappa { get; set; }

        [XmlElement("Statistics_lambda")]
        public double Lambda { get; set; }

        [XmlElement("Statistics_entropy")]
        public double Entropy { get; set; }
    }
}
/*
{
  "code": 200,
  "message": "Ok.",
  "data": "<?xml version=\"1.0\" encoding=\"US-ASCII\"?>\n<!DOCTYPE BlastOutput PUBLIC \"-//NCBI//NCBI BlastOutput/EN\" \"http://www.ncbi.nlm.nih.gov/dtd/NCBI_BlastOutput.dtd\">\n<BlastOutput>\n  <BlastOutput_program>blastx</BlastOutput_program>\n  <BlastOutput_version>BLASTX 2.17.0+</BlastOutput_version>\n  <BlastOutput_reference>Stephen F. Altschul, Thomas L. Madden, Alejandro A. Sch&amp;auml;ffer, Jinghui Zhang, Zheng Zhang, Webb Miller, and David J. Lipman (1997), &quot;Gapped BLAST and PSI-BLAST: a new generation of protein database search programs&quot;, Nucleic Acids Res. 25:3389-3402.</BlastOutput_reference>\n  <BlastOutput_db>nr_cluster_seq</BlastOutput_db>\n  <BlastOutput_query-ID>Query_4690166</BlastOutput_query-ID>\n  <BlastOutput_query-def>No definition line</BlastOutput_query-def>\n  <BlastOutput_query-len>320</BlastOutput_query-len>\n  <BlastOutput_param>\n    <Parameters>\n      <Parameters_matrix>BLOSUM62</Parameters_matrix>\n      <Parameters_expect>0.05</Parameters_expect>\n      <Parameters_gap-open>11</Parameters_gap-open>\n      <Parameters_gap-extend>1</Parameters_gap-extend>\n      <Parameters_filter>L;</Parameters_filter>\n    </Parameters>\n  </BlastOutput_param>\n<BlastOutput_iterations>\n<Iteration>\n  <Iteration_iter-num>1</Iteration_iter-num>\n  <Iteration_query-ID>Query_4690166</Iteration_query-ID>\n  <Iteration_query-def>No definition line</Iteration_query-def>\n  <Iteration_query-len>320</Iteration_query-len>\n<Iteration_hits>\n<Hit>\n  <Hit_num>1</Hit_num>\n  <Hit_id>ref|XP_030784615.1|</Hit_id>\n  <Hit_def>transmembrane protein 14C isoform X4 [Rhinopithecus roxellana]</Hit_def>\n  <Hit_accession>XP_030784615</Hit_accession>\n  <Hit
                 */
