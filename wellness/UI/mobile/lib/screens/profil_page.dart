import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class ProfilPageView extends StatelessWidget {
  const ProfilPageView({super.key});

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
                  onPressed: () {},
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
