using System.Runtime.Serialization;

namespace ExemploRestSharp
{
    [DataContract]
    public class Cotacao
    {
        [DataMember(Name = "high")]
        public double MaiorValor { get; set; }

        [DataMember(Name = "vol")]
        public double VolumeNegociado { get; set; }

        [DataMember(Name = "buy")]
        public double UltimoValorCompra { get; set; }

        [DataMember(Name = "last")]
        public double UltimoPreco { get; set; }

        [DataMember(Name = "low")]
        public double MenorValor { get; set; }

        [DataMember(Name = "pair")]
        public string ParMoedas { get; set; }

        [DataMember(Name = "sell")]
        public double UltimoValorVenda { get; set; }

        [DataMember(Name = "vol_brl")]
        public double VolumeReais { get; set; }
    }
}