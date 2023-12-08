namespace CreditAPI.Models
{
    public class ProcessamentoCredito
    {
        public CreditoResponse ProcessarCredito(Credito request)
        {
            
            if (request.ValorCredito > 1000000)
                return new CreditoResponse { Status = "Recusado" };

            if (request.QuantidadeParcelas < 5 || request.QuantidadeParcelas > 72)
                return new CreditoResponse { Status = "Recusado" };

            if (request.TipoCredito == TipoCredito.CreditoPessoaJuridica && request.ValorCredito < 15000)
                return new CreditoResponse { Status = "Recusado" };

            var dataMinima = DateTime.Now.AddDays(15);
            var dataMaxima = DateTime.Now.AddDays(40);
            if (request.DataPrimeiroVencimento < dataMinima || request.DataPrimeiroVencimento > dataMaxima)
                return new CreditoResponse { Status = "Recusado" };

            decimal taxaJuros = ObterTaxaJuros(request.TipoCredito);
            decimal valorJuros = request.ValorCredito * (taxaJuros / 100);
            decimal valorTotalComJuros = request.ValorCredito + valorJuros;

            return new CreditoResponse
            {
                Status = "Aprovado",
                ValorTotalComJuros = valorTotalComJuros,
                ValorJuros = valorJuros
            };
        }

        private decimal ObterTaxaJuros(TipoCredito tipoCredito)
        {
            switch (tipoCredito)
            {
                case TipoCredito.CreditoDireto:
                    return 2;
                case TipoCredito.CreditoConsignado:
                    return 1;
                case TipoCredito.CreditoPessoaJuridica:
                    return 5;
                case TipoCredito.CreditoPessoaFisica:
                    return 3;
                case TipoCredito.CreditoImobiliario:
                    return 9;
                default:
                    return 0;
            }
        }
    }
}
