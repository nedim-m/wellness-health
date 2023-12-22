import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/reservation.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/double_text.dart';

class ReservationPage extends StatefulWidget {
  const ReservationPage({Key? key, required this.reservation})
      : super(key: key);

  final Reservation reservation;

  @override
  State<ReservationPage> createState() => _ReservationPageState();
}

class _ReservationPageState extends State<ReservationPage> {
  int selectedRating = 0;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            DoubleTextWidget(
              bigText: "Tretman: ",
              smallText: widget.reservation.treatment,
            ),
            const Gap(15),
            DoubleTextWidget(
              bigText: "Datum: ",
              smallText: widget.reservation.date,
            ),
            const Gap(15),
            DoubleTextWidget(
              bigText: "Vrijeme: ",
              smallText: widget.reservation.time,
            ),
            const Gap(20),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text(
                  'Ocijeni tretman',
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ),
                Row(
                  children: List.generate(
                    5,
                    (index) => IconButton(
                      onPressed: () {
                        setState(() {
                          
                          selectedRating = index + 1;
                        });
                      },
                      icon: Icon(
                        Icons.star,
                        color:
                            index < selectedRating ? Colors.amber : Colors.grey,
                      ),
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 20),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () {},
                child: const Text("Odjavi rezervaciju"),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
