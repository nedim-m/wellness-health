import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:intl/intl.dart';
import 'package:mobile/models/treatment.dart';
import 'package:mobile/utils/app_styles.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/color_coded_calendar.dart';

import 'package:mobile/widgets/double_text.dart';

class TreatmenTime extends StatefulWidget {
  const TreatmenTime(
      {super.key, required this.data, required this.selectedDate});
  final Treatment data;
  final DateTime selectedDate;

  @override
  State<TreatmenTime> createState() => _TreatmenTimeState();
}

class _TreatmenTimeState extends State<TreatmenTime> {
  @override
  Widget build(BuildContext context) {
    final DateFormat formatter = DateFormat('dd.MM.yyyy');
    return Scaffold(
      backgroundColor: Styles.bgColor,
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child:
              Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
            const SizedBox(height: 20),
            const Center(
              child: Text(
                'Pregled slobodnih termina',
                style: TextStyle(
                  fontSize: 24,
                  fontWeight: FontWeight.bold,
                  color: Colors.blue,
                ),
              ),
            ),
            const Gap(30),
            DoubleTextWidget(
              bigText: "Vrsta usluge: ",
              smallText: widget.data.treatmentType,
            ),
            const Gap(15),
            DoubleTextWidget(
              bigText: "Kategorija: ",
              smallText: widget.data.category,
            ),
            const Gap(15),
            DoubleTextWidget(
              bigText: "Datum: ",
              smallText: formatter.format(widget.selectedDate),
            ),
            const Gap(30),
            ColorCodedCalendar(
                treatmentId: widget.data.id, selectedDate: widget.selectedDate),
          ]),
        ),
      ),
    );
  }
}
