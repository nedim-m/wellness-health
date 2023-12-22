import 'package:flutter/material.dart';
import 'package:mobile/models/reservation.dart';
import 'package:mobile/providers/reservation_provider.dart';
import 'package:mobile/widgets/reservation_page.dart';
import 'package:mobile/widgets/app_bar.dart';

class MyReservationPageView extends StatefulWidget {
  const MyReservationPageView({super.key});

  @override
  State<MyReservationPageView> createState() => _MyReservationPageViewState();
}

class _MyReservationPageViewState extends State<MyReservationPageView> {
  List<Reservation> reservations = [];
  final ReservationProvider _reservationProvider = ReservationProvider();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
    List<Reservation> fetchedReservations =
        await _reservationProvider.get(filter: {
      'userId': 3,
    });

    setState(() {
      reservations = fetchedReservations;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 20),
            const Center(
              child: Text(
                'Moje rezervacije',
                style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue),
              ),
            ),
            const SizedBox(height: 16),
            ListView.builder(
              shrinkWrap: true,
              itemCount: reservations.length,
              itemBuilder: (context, index) {
                return Card(
                  elevation: 3,
                  margin: const EdgeInsets.symmetric(vertical: 8.0),
                  child: ListTile(
                    title: Text(
                      reservations[index].treatment,
                      style: const TextStyle(fontWeight: FontWeight.bold),
                    ),
                    subtitle: Text(
                        'Datum: ${reservations[index].date} vrijeme: ${reservations[index].time}'),
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) =>
                              ReservationPage(reservation: reservations[index]),
                        ),
                      );
                    },
                  ),
                );
              },
            ),
          ],
        ),
      ),
    );
  }
}
