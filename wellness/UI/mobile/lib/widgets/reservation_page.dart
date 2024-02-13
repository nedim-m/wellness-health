import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/models/rating.dart';
import 'package:mobile/models/reservation.dart';
import 'package:mobile/providers/rating_provider.dart';
import 'package:mobile/providers/reservation_provider.dart';
import 'package:mobile/screens/my_reservation_page.dart';
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
  bool rated = false;

  String? errorText;

  @override
  void initState() {
    super.initState();
    checkAndSetRating();
  }

  final RatingProvider _ratingProvider = RatingProvider();
  final ReservationProvider _reservationProvider = ReservationProvider();

  Future<void> _postRating(int numberOfSelectedStars) async {
    try {
      Rating newRating = Rating(
        0,
        numberOfSelectedStars,
        widget.reservation.id,
      );

      await _ratingProvider.insert(newRating);
    } catch (error) {
      print('Error during rating post: $error');
      showError();
    }
  }

  void showError() {
    setState(() {
      errorText = rated
          ? "Već ste ocijenuli tretma!"
          : "Ne možete ocijeniti ako niste bili na tretmanu!";
    });
  }

  Future<void> checkAndSetRating() async {
    try {
      var hasRating = await _ratingProvider
          .get(filter: {'reservationId': widget.reservation.id});

      if (hasRating.isNotEmpty) {
        rated = true;
        setState(() {
          selectedRating = hasRating.first.starRating;
        });
      }
    } catch (error) {
      print('Error during rating check: $error');
    }
  }

  Future<void> _cancelReservation() async {
    try {
      await _reservationProvider.cancelReservation(widget.reservation.id);
    } catch (error) {
      print('Error during cancel reservation: $error');
    }
  }

  Future<void> _showConfirmationDialog() async {
    return showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text("Potvrda"),
          content:
              const Text("Jeste li sigurni da želite odjaviti rezervaciju?"),
          actions: [
            TextButton(
              onPressed: () async {
                await _cancelReservation();
                // ignore: use_build_context_synchronously
                Navigator.of(context).pop();
                // ignore: use_build_context_synchronously
                Navigator.pushReplacement(
                  context,
                  MaterialPageRoute(
                      builder: (context) => const MyReservationPageView()),
                );
              },
              child: const Text("Potvrdi"),
            ),
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text("Odustani"),
            ),
          ],
        );
      },
    );
  }

  Future<void> _showStarRatingDialog(int numberOfSelectedStars) async {
    return showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text("Potvrda"),
          content: Text(
              "Ocijenili ste tretman sa $numberOfSelectedStars zvjezdica."),
          actions: [
            TextButton(
              onPressed: () async {
                await _postRating(numberOfSelectedStars);
                // ignore: use_build_context_synchronously
                Navigator.of(context).pop();
              },
              child: const Text("Potvrdi"),
            ),
            TextButton(
              onPressed: () {
                _cancelReservation();
                Navigator.of(context).pop();
              },
              child: const Text("Odustani"),
            ),
          ],
        );
      },
    );
  }

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
            Column(
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const Text(
                      'Ocijeni tretman',
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                    ),
                    Row(
                      children: List.generate(
                        5,
                        (index) => IconButton(
                          onPressed: widget.reservation.status != false
                              ? () {
                                  setState(() {
                                    selectedRating = index + 1;
                                  });
                                  _showStarRatingDialog(selectedRating);
                                }
                              : null,
                          icon: Icon(
                            Icons.star,
                            color: index < selectedRating
                                ? Colors.amber
                                : widget.reservation.status != false
                                    ? Colors.grey
                                    : Colors.grey.shade300,
                          ),
                        ),
                      ),
                    ),
                  ],
                ),
                if (errorText != null)
                  Text(
                    errorText!,
                    style: TextStyle(color: Colors.red),
                  ),
              ],
            ),
            const SizedBox(height: 20),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: widget.reservation.status != false
                    ? () {
                        _showConfirmationDialog();
                      }
                    : null,
                style: ElevatedButton.styleFrom(
                  backgroundColor: widget.reservation.status == false
                      ? Colors.grey.shade700
                      : Colors.red,
                ),
                child: Text(
                  widget.reservation.status != false
                      ? "Odjavi rezervaciju"
                      : "Žao nam je, Vaša rezervacija je odbijena/odjavljena",
                  style: TextStyle(
                    color: widget.reservation.status == false
                        ? Colors.black
                        : Colors.white,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
