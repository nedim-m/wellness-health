import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/providers/paypal_provider.dart';

import 'package:mobile/screens/paypal_page.dart';
import 'package:mobile/screens/stripe_page.dart';

import 'package:mobile/utils/current_date.dart';

import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';
import 'package:provider/provider.dart';

class PaymentPageView extends StatefulWidget {
  const PaymentPageView(
      {super.key,
      required this.memberShipTypeName,
      required this.price,
      required this.memberShipTypeId});
  final String memberShipTypeName;
  final int memberShipTypeId;

  final String price;

  @override
  State<PaymentPageView> createState() => _PaymentPageViewState();
}

class _PaymentPageViewState extends State<PaymentPageView> {
  String selectedPaymentOption = '';
  var currentDate = CurrentDate();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 20),
              const Center(
                child: Text(
                  'Uplata',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue,
                  ),
                ),
              ),
              const SizedBox(height: 16),
              DoubleTextWidget(
                bigText: "Tip članarine: ",
                smallText: widget.memberShipTypeName,
              ),
              const Gap(15),
              DoubleTextWidget(
                bigText: "Datum aktivacije: ",
                smallText: currentDate.currentDate,
              ),
              const SizedBox(height: 16),
              DoubleTextWidget(
                bigText: "Cijena: ",
                smallText: "${widget.price} BAM",
              ),
              const Gap(30),
              _buildPaymentOption('PayPal', 'assets/images/paypallogo.png'),
              const Gap(10),
              _buildPaymentOption('Stripe', 'assets/images/cclogo.jpg'),
              const Gap(50),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: _handlePaymentOptionSelection,
                  child: const Text("Nastavi"),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildPaymentOption(String option, [String? imagePath]) {
    return ListTile(
      contentPadding: EdgeInsets.zero,
      title: imagePath != null
          ? Row(
              children: [
                Image.asset(
                  imagePath,
                  width: 170,
                  height: 35,
                ),
                const SizedBox(width: 30),
              ],
            )
          : Text(
              option,
              style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
            ),
      trailing: Radio<String>(
        value: option,
        groupValue: selectedPaymentOption,
        onChanged: (value) {
          setState(() {
            selectedPaymentOption = value!;
          });
        },
      ),
    );
  }

  Future<void> _handlePaymentOptionSelection() async {
    print('Selected Payment Option: $selectedPaymentOption');
    final paypalProvider = Provider.of<PayPalProvider>(context, listen: false);

    switch (selectedPaymentOption) {
      case 'PayPal':
        try {
          double doublePrice = double.parse(widget.price);
          String priceToEur = (doublePrice / 1.95).toStringAsFixed(2);

          final orderResult =
              await paypalProvider.createOrder(priceToEur, "EUR");
          print("Order created successfully: $orderResult");
          // ignore: use_build_context_synchronously
          Navigator.push(
            context,
            MaterialPageRoute(
              builder: (context) => PayPalCheckout(
                  paypalUrl: orderResult["approvalUrl"],
                  orderId: orderResult["orderId"],
                  membershipTypeId: widget.memberShipTypeId,
                  price: priceToEur),
            ),
          );
        } catch (error) {
          print("Failed to create order: $error");
        }
        break;
      case 'Stripe':
        // ignore: use_build_context_synchronously
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => StripePaymentPage(
              memberShipTypeId: widget.memberShipTypeId,
            ),
          ),
        );
        break;
    }
  }
}
