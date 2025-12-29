using DogShow.Modules.DTO.Payment;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Stripe;
using System;

namespace DogShow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpPost("create-checkout-session")]
        public IActionResult CreateCheckoutSession([FromBody] PaymentRequestDto request)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = request.Amount,
                            Currency = request.Currency ?? "rsd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = request.Description,
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = request.SuccessUrl,
                CancelUrl = request.CancelUrl,
            };
            try
            {
                var service = new SessionService();
                Session session = service.Create(options);
                return Ok(new { sessionId = session.Id });
            }
            catch (StripeException e)
            {
                return BadRequest(new { error = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = "An internal server error occurred." });
            }
        }
    }

}