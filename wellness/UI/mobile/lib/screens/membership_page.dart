import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/screens/payment_page.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class MemberShipPageView extends StatelessWidget {
  const MemberShipPageView({super.key});

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
                  'Članarina',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue,
                  ),
                ),
              ),
              const SizedBox(height: 16),
              const DoubleTextWidget(
                bigText: "Tip članarine: ",
                smallText: "Tip 1",
              ),
              const Gap(15),
              const DoubleTextWidget(
                bigText: "Status članarine: ",
                smallText: "Aktivan/Neaktivan",
              ),
              const Gap(15),
              const DoubleTextWidget(
                bigText: "Datum aktivacije: ",
                smallText: "11.05.2023",
              ),
              const Gap(15),
              const DoubleTextWidget(
                bigText: "Datum isteka: ",
                smallText: "11.06.2023",
              ),
              const Gap(50),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => const PaymentPageView(),
                      ),
                    );
                  },
                  child: const Text("Uplati/produži članarinu"),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
