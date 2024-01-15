import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/screens/cc_page.dart';

import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class MembershipPageView extends StatefulWidget {
  const MembershipPageView({super.key});

  @override
  State<MembershipPageView> createState() => _MembershipPageViewState();
}

class _MembershipPageViewState extends State<MembershipPageView> {
  String selectedPaymentOption = '';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar:  const AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const DoubleTextWidget(
                bigText: "Tip članarine: ",
                smallText: "Tip 1",
              ),
              const Gap(15),
              const DoubleTextWidget(
                bigText: "Datum isteka: ",
                smallText: "11.06.2023",
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
        break;
    }
  }
}
