import 'package:flutter/material.dart';
import 'package:mobile/providers/paypal_provider.dart';
import 'package:provider/provider.dart';
import 'package:webview_flutter/webview_flutter.dart';

class PayPalCheckout extends StatefulWidget {
  final String paypalUrl;
  final String orderId;
  final int membershipTypeId;
  final String price;

  const PayPalCheckout({
    Key? key,
    required this.paypalUrl,
    required this.orderId,
    required this.membershipTypeId,
    required this.price,
  }) : super(key: key);

  @override
  State<PayPalCheckout> createState() => _PayPalCheckoutState();
}

class _PayPalCheckoutState extends State<PayPalCheckout> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('PayPal Checkout'),
      ),
      body: WebView(
        initialUrl: widget.paypalUrl,
        javascriptMode: JavascriptMode.unrestricted,
        navigationDelegate: (NavigationRequest request) {
          if (request.url.contains('success')) {
            final paypalProvider =
                Provider.of<PayPalProvider>(context, listen: false);
            paypalProvider.capturePayment(
                widget.orderId, widget.membershipTypeId, widget.price);

            Navigator.of(context).pop();
          }
          return NavigationDecision.navigate;
        },
      ),
    );
  }
}
