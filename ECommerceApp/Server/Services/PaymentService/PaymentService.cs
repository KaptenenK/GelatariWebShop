using Stripe;
using Stripe.Checkout;

namespace ECommerceApp.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartService;
        private readonly IAuthservice _authService;
        private readonly IOrderService _orderService;

        const string secret = "whsec_e757a2bfeabe7a62fdc294dacb095c7750c4e9256c435b8c73ea8c30f509f2e3";

        public PaymentService(ICartService cartService, IAuthservice authService, IOrderService orderService)
        {

            StripeConfiguration.ApiKey = "sk_test_51MRMhvFQXBRQh2Zy1LaPCa7gdravzis4nGh90eRMUTH1YZNxmA9AJMTA6E3rkNXOl838uAqt4E4Ddeb08AvRA0Bv00TdPF6eYb";

            _cartService = cartService;
            _authService = authService;
            _orderService = orderService;
        }
        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _cartService.GetDbCartProducts()).Data;
            var lineItem = new List<SessionLineItemOptions>();
            products.ForEach(product => lineItem.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = product.Price * 100,
                    Currency = "sek",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = product.Title,
                        Images = new List<string> { product.ImageUrl }
                    }
                },
                Quantity= product.Quantity,
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authService.GetUserEmail(),
                ShippingAddressCollection= new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries= new List<string> { "US"}
                },
                PaymentMethodTypes = new List<string>()
                {
                    "card"
                },
                LineItems = lineItem,
                Mode = "payment",
                SuccessUrl = "https://localhost:7295/order-success",
                CancelUrl = "https://localhost:7295/cart"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session;
        }


        //stripe call http request från webhook
        public async Task<ServiceResponse<bool>> FulfillOrder(HttpRequest request)
        {
            //fpr en json object
            var json = await new StreamReader(request.Body).ReadToEndAsync();

            try
            {
                //vi skapar en stripe event med en json object och får egna secret
                var stripeEvent = EventUtility.ConstructEvent(json, request.Headers["Stripe-Signature"], secret);

                //om checkoutsessioncompleted event går genom hämtar vi användarens email och från email hämtar vi user id och efter det lägger vi en order
                if(stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var user = await _authService.GetUserByEmail(session.CustomerEmail);
                    await _orderService.PlaceOrder(user.Id);
                }

                return new ServiceResponse<bool> { Data = true };
            } 
            catch(StripeException ex) 
            {
                return new ServiceResponse<bool> { Data = false, Success=false, Message=ex.Message };
            }
        }
    }
}
