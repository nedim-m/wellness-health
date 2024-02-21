import 'package:flutter/material.dart';
import 'package:gap/gap.dart';

import 'package:mobile/models/treatment.dart';
import 'package:mobile/screens/treatment_time.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/date_picker.dart';
import 'package:mobile/widgets/double_text.dart';

class TreatmentDetails extends StatefulWidget {
  const TreatmentDetails({Key? key, required this.data}) : super(key: key);

  final Treatment data;

  @override
  State<TreatmentDetails> createState() => _TreatmentDetailsState();
}

class _TreatmentDetailsState extends State<TreatmentDetails> {
  late DateTime selectedDate;

  @override
  void initState() {
    super.initState();
    selectedDate = DateTime.now();
  }

  @override
  Widget build(BuildContext context) {
    bool isTodayOrBefore = selectedDate.isBefore(DateTime.now());

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
                  'Detalji tretmana',
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
              const Text(
                "Opis: ",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 18,
                ),
              ),
              const Gap(10),
              Text(widget.data.description),
              const Gap(30),
              const Text(
                "Odaberite datum: ",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 18,
                ),
              ),
              const Gap(10),
              DatePickerWidget(
                onDateSelected: (DateTime date) {
                  setState(() {
                    selectedDate = date;
                  });
                },
              ),
              const Gap(30),
              if (isTodayOrBefore)
                const Center(
                  child: Text(
                    "Ne možete rezervirati za današnji dan ili u prošlosti. Molim Vas izaberite neki datum u budućnosti.",
                    style: TextStyle(
                      color: Colors.red,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: isTodayOrBefore
                      ? null
                      : () {
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => TreatmenTime(
                                data: widget.data,
                                selectedDate: selectedDate,
                              ),
                            ),
                          );
                        },
                  child: const Text("Nastavi"),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
