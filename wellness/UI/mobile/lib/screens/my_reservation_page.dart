import 'package:flutter/material.dart';
import 'package:mobile/models/reservation.dart';
import 'package:mobile/models/treatment.dart';

import 'package:mobile/providers/reservation_provider.dart';
import 'package:mobile/providers/treatment_provider.dart';
import 'package:mobile/utils/user_store.dart';
import 'package:mobile/widgets/reservation_page.dart';
import 'package:mobile/widgets/app_bar.dart';

class MyReservationPageView extends StatefulWidget {
  const MyReservationPageView({Key? key}) : super(key: key);

  @override
  State<MyReservationPageView> createState() => _MyReservationPageViewState();
}

class _MyReservationPageViewState extends State<MyReservationPageView> {
  List<Reservation> reservations = [];
  List<Treatment> treatments = [];
  final ReservationProvider _reservationProvider = ReservationProvider();
  final TreatmentProvider _treatmentProvider = TreatmentProvider();
  int? _userId;

  @override
  void initState() {
    super.initState();
    _userId = int.parse(UserManager.getUserId()!);
    fetchData();
  }

  Future<void> fetchData() async {
    List<Reservation> fetchedReservations =
        await _reservationProvider.get(filter: {
      'userId': _userId,
    });
    print("UserId : $_userId");

    treatments = await _treatmentProvider.recommendation();

    setState(() {
      reservations = fetchedReservations;
    });
  }

  Widget _buildStatusIcon(bool? status) {
    if (status == null) {
      return const Icon(Icons.access_time, color: Colors.grey);
    } else if (status == true) {
      return const Icon(Icons.check, color: Colors.green);
    } else {
      return const Icon(Icons.close, color: Colors.red);
    }
  }

  Widget _buildListView() {
    if (reservations.isEmpty) {
      return const Center(
        child: Text(
          'Trenutno nema rezervacija',
          style: TextStyle(fontSize: 18, color: Colors.grey),
        ),
      );
    }

    return ListView.builder(
      itemCount: reservations.length,
      itemBuilder: (context, index) {
        return Card(
          elevation: 3,
          margin: const EdgeInsets.symmetric(vertical: 8.0),
          child: ListTile(
            title: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  reservations[index].treatment,
                  style: const TextStyle(fontWeight: FontWeight.bold),
                ),
                _buildStatusIcon(reservations[index].status),
              ],
            ),
            subtitle: Text(
              'Datum: ${reservations[index].date} u ${reservations[index].time} sati',
            ),
            onTap: () {
              Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => ReservationPage(
                    reservation: reservations[index],
                    treatmentList: treatments,
                  ),
                ),
              );
            },
          ),
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: Padding(
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
                  color: Colors.blue,
                ),
              ),
            ),
            const SizedBox(height: 16),
            Expanded(
              child: _buildListView(),
            ),
          ],
        ),
      ),
    );
  }
}
