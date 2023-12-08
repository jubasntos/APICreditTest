namespace CreditAPI.Models
{
    public class Credito
    {
        public decimal ValorCredito { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
    }

    public class CreditoResponse
    {
        public string Status { get; set; }
        public decimal ValorTotalComJuros { get; set; }
        public decimal ValorJuros { get; set; }
    }

    public enum TipoCredito
    {
        CreditoDireto,
        CreditoConsignado,
        CreditoPessoaJuridica,
        CreditoPessoaFisica,
        CreditoImobiliario
    }
}
