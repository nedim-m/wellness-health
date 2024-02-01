import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/screens/cc_page.dart';
import 'package:mobile/screens/stripe_page.dart';

import 'package:mobile/utils/current_date.dart';

import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class PaymentPageView extends StatefulWidget {
  const PaymentPageView(
      {super.key, required this.memberShipTypeName, required this.price});
  final String memberShipTypeName;

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
              const Gap(10),
              _buildPaymentOption('Credit Card', 'assets/images/cclogo.jpg'),
              const Gap(10),
              _buildPaymentOption('PayPal'),
              const Gap(10),
              _buildPaymentOption('Stripe'),
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

  void _handlePaymentOptionSelection() {
    print('Selected Payment Option: $selectedPaymentOption');

    switch (selectedPaymentOption) {
      case 'Credit Card':
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => const CCPageView(),
          ),
        );
        break;
      case 'PayPal':
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) => const CCPageView(),
          ),
        );
        break;
      case 'Stripe':
        Navigator.push(
          context,
          MaterialPageRoute(
            builder: (context) =>  StripePaymentPage(),
          ),
        );
        break;
    }
  }
}
