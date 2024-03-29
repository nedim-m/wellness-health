﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wellness.Payments.Model;

[ApiController]
[Route("[controller]")]
public class StripePaymentController : ControllerBase
{
    private readonly IStripePaymentService _stripePaymentService;

    public StripePaymentController(IStripePaymentService stripePaymentService)
    {
        _stripePaymentService = stripePaymentService;
    }

    [HttpPost("process-payment")]
    public async Task<IActionResult> StripePayEndpointMethodId([FromBody] PaymentRequestModel requestModel)
    {
        if (requestModel != null)
        {
            var response = await _stripePaymentService.ProcessPaymentMethodIdAsync(
                requestModel.PaymentMethodId,
                requestModel.MemberShipTypeId,
                requestModel.Currency,
                requestModel.UseStripeSdk,
                requestModel.UserId
            );

            return Ok(response);
        }

        return BadRequest("Invalid request");
    }

    [HttpPost("confirm-payment")]
    public async Task<IActionResult> StripePayEndpointIntentId([FromBody] PaymentIntentRequestModel requestModel)
    {
        if (requestModel != null)
        {
            var response = await _stripePaymentService.ProcessPaymentIntentIdAsync(requestModel.PaymentIntentId);
            return Ok(response);
        }

        return BadRequest("Invalid request");
    }
}
