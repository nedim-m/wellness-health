import 'dart:convert';
import 'dart:io';

import 'package:equatable/equatable.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:http/io_client.dart';

part 'payment_event.dart';
part 'payment_state.dart';

class PaymentBloc extends Bloc<PaymentEvent, PaymentState> {
  PaymentBloc() : super(const PaymentState()) {
    on<PaymentStart>(_onPaymentStart);
    on<PaymentCreateIntent>(_onPaymentCreateIntent);
    on<PaymentConfirmIntent>(_onPaymentConfirmIntent);
  }

  HttpClient client = HttpClient();
  IOClient? http;

  void _onPaymentStart(
    PaymentStart event,
    Emitter<PaymentState> emit,
  ) {
    emit(state.copyWith(status: PaymentStatus.initial));
  }

  void _onPaymentCreateIntent(
    PaymentCreateIntent event,
    Emitter<PaymentState> emit,
  ) async {
    emit(state.copyWith(status: PaymentStatus.loading));

    final paymentMethod = await Stripe.instance.createPaymentMethod(
      params: PaymentMethodParams.card(
        paymentMethodData: PaymentMethodData(
          billingDetails: event.billingDetails,
        ),
      ),
    );

    final paymentIntentResult = await _callPayEndpointMethodId(
      useStripeSdk: true,
      paymentMethodId: paymentMethod.id,
      currency: 'BAM',
      item: event.items,
    );

    if (paymentIntentResult['error'] != null) {
      // Error creating or confirming the payment intent.
      emit(state.copyWith(status: PaymentStatus.failure));
    }

    if (paymentIntentResult['clientSecret'] != null &&
        paymentIntentResult['requiresAction'] == null) {
      // The payment succedeed / went through.
      emit(state.copyWith(status: PaymentStatus.success));
    }

    if (paymentIntentResult['clientSecret'] != null &&
        paymentIntentResult['requiresAction'] == true) {
      final String clientSecret = paymentIntentResult['clientSecret'];
      add(PaymentConfirmIntent(clientSecret: clientSecret));
    } else {}
  }

  void _onPaymentConfirmIntent(
    PaymentConfirmIntent event,
    Emitter<PaymentState> emit,
  ) async {
    // The payment requires action calling handleNextAction
    try {
      final paymentIntent =
          await Stripe.instance.handleNextAction(event.clientSecret);

      if (paymentIntent.status == PaymentIntentsStatus.RequiresConfirmation) {
        // Call API to confirm intent
        Map<String, dynamic> results =
            await _callPayEndpointIntentId(paymentIntentId: paymentIntent.id);

        if (results['error'] != null) {
          emit(state.copyWith(status: PaymentStatus.failure));
        } else {
          emit(state.copyWith(status: PaymentStatus.success));
        }
      }
    } catch (err) {
      print(err);
      emit(state.copyWith(status: PaymentStatus.failure));
    }
  }

  Future<Map<String, dynamic>> _callPayEndpointMethodId({
    required bool useStripeSdk,
    required String paymentMethodId,
    required String currency,
    required item,
  }) async {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);
    final url = Uri.parse(
      'https://10.0.2.2:7012/StripePayment/StripePayEndpointMethodId/',
    );
    final response = await http!.post(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode({
        'useStripeSdk': useStripeSdk,
        'paymentMethodId': paymentMethodId,
        'currency': currency,
        'memberShipTypeId': item
      }),
    );
    return json.decode(response.body);
  }

  Future<Map<String, dynamic>> _callPayEndpointIntentId({
    required String paymentIntentId,
  }) async {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);

    final url = Uri.parse(
      'https://10.0.2.2:7012/StripePayment/StripePayEndpointIntentId/',
    );
    final response = await http!.post(
      url,
      headers: {'Content-Type': 'application/json'},
      body: json.encode({
        'paymentIntentId': paymentIntentId,
      }),
    );
    return json.decode(response.body);
  }
}
