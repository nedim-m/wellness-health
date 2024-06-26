// ignore_for_file: avoid_print

import 'package:flutter/material.dart';
import 'package:mobile/models/reservation.dart';
import 'package:mobile/models/treatment.dart';

import 'package:mobile/providers/reservation_provider.dart';

import 'package:mobile/utils/app_styles.dart';
import 'package:mobile/utils/recommender_helper.dart';
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

    treatments = RecommendedHelper.getRecommendation()!;

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
          child: InkWell(
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
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        reservations[index].treatment,
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 16),
                      ),
                      _buildStatusIcon(reservations[index].status),
                    ],
                  ),
                  const SizedBox(height: 8),
                  Text(
                    'Datum: ${reservations[index].date} u ${reservations[index].time} sati',
                  ),
                  const SizedBox(height: 4),
                  const Row(
                    children: [
                      Icon(
                        Icons.arrow_forward,
                        color: Colors.blue,
                      ),
                      SizedBox(width: 4),
                      Text(
                        'Pregledaj detalje rezervacije',
                        style: TextStyle(
                            color: Colors.blue,
                            fontWeight: FontWeight.bold,
                            fontSize: 13),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          ),
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Styles.bgColor,
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
