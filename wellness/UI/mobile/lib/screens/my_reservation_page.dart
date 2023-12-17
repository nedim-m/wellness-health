import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class MyReservationPageView extends StatefulWidget {
  const MyReservationPageView({super.key});

  @override
  State<MyReservationPageView> createState() => _MyReservationPageViewState();
}

class _MyReservationPageViewState extends State<MyReservationPageView> {
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      appBar: AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              DoubleTextWidget(
                bigText: "Tretman: ",
                smallText: "Tretman jedan",
              ),
              Gap(15),
              DoubleTextWidget(
                bigText: "Datum: ",
                smallText: "11.06.2023",
              ),
              Gap(15),
              DoubleTextWidget(
                bigText: "Vrijeme: ",
                smallText: "09:00",
              ),
            ],
          ),
        ),
      ),
    );
  }
}
