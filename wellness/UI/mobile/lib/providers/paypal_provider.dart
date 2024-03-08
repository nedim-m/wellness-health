// ignore_for_file: avoid_print

import 'dart:convert';
import 'dart:io';
import 'package:flutter/material.dart';

import 'package:http/io_client.dart';
import 'package:mobile/utils/app_constants.dart';
import 'package:mobile/utils/user_store.dart';

class PayPalProvider extends ChangeNotifier {
  HttpClient client = HttpClient();
  IOClient? http;
  late int userId;

  Future<Map<String, dynamic>> createOrder(
      String amount, String currency) async {
    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);

    const String apiUrl =
        '${AppConstants.baseUrl}${AppConstants.paymentServicePort}/PayPal/create-order/';

    final response = await http!.post(
      Uri.parse(apiUrl),
      headers: {"Content-Type": "application/json"},
      body: jsonEncode({"amount": amount, "currency": currency}),
    );

    if (response.statusCode == 200) {
      notifyListeners();
      return jsonDecode(response.body);
    } else {
      throw Exception("Failed to create order");
    }
  }

  Future<Map<String, dynamic>> capturePayment(
      String orderId, int membershipTypeId, String amount) async {
    userId = int.parse(UserManager.getUserId()!);

    client.badCertificateCallback = (cert, host, port) => true;
    http = IOClient(client);

    const String apiUrl =
        '${AppConstants.baseUrl}${AppConstants.paymentServicePort}/PayPal/capture-payment/';

    final response = await http!.post(
      Uri.parse(apiUrl),
      headers: {"Content-Type": "application/json"},
      body: jsonEncode({
        "orderId": orderId,
        "userId": userId,
        'memberShipTypeId': membershipTypeId,
        'amount': amount,
      }),
    );
    print("Response iz capture paymenta $response");

    if (response.statusCode == 200) {
      notifyListeners();
      return jsonDecode(response.body);
    } else {
      throw Exception("Failed to create order");
    }
  }
}
