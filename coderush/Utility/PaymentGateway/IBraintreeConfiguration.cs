using Braintree;


namespace Prueba.Utility.PaymentGateway
{
    public interface IBraintreeConfiguration
    {
        IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }
}
